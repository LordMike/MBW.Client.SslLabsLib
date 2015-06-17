using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mono.Options;
using Newtonsoft.Json;
using SslLabsLib;
using SslLabsLib.Enums;
using SslLabsLib.Objects;
using Timer = System.Timers.Timer;

namespace SslLabsMassScan
{
    class Program
    {
        private const int DefaultMaxAssesments = 10;

        static int Main(string[] args)
        {
            Options options = new Options();
            options.Max = DefaultMaxAssesments;

            OptionSet parser = new OptionSet();
            parser.Add("f|file=", "Input file, one host pr. line, required", s => options.Input = s);
            parser.Add("o|output=", "Output directory, will be created", s => options.Output = s);
            parser.Add("n|new", "Forces new scans", s => options.ForceNew = true);
            parser.Add("p|publish", "Published scans", s => options.Publish = true);
            parser.Add<int>("m|max=", "Max concurrent scans, default: " + DefaultMaxAssesments, s => options.Max = s);

            List<string> excessArgs = parser.Parse(args);

            if (string.IsNullOrEmpty(options.Input) || !File.Exists(options.Input))
            {
                Console.WriteLine("Missing input file");
                Console.WriteLine();
                Console.WriteLine("Help:");
                parser.WriteOptionDescriptions(Console.Out);

                return 1;
            }

            if (string.IsNullOrEmpty(options.Output))
            {
                Console.WriteLine("Missing output directory");
                Console.WriteLine();
                Console.WriteLine("Help:");
                parser.WriteOptionDescriptions(Console.Out);

                return 1;
            }

            if (!Directory.Exists(options.Output))
                Directory.CreateDirectory(options.Output);

            Queue<string> domains = new Queue<string>();
            bool anyBadInput = false;
            foreach (string line in File.ReadLines(options.Input))
            {
                if (Uri.CheckHostName(line) != UriHostNameType.Dns)
                {
                    Console.WriteLine("Bad input: " + line);
                    anyBadInput = true;
                }
                else
                {
                    domains.Enqueue(line);
                }
            }

            if (anyBadInput)
            {
                Console.WriteLine("One or more bad lines found - please correct");

                return 2;
            }

            Console.WriteLine("Beginning work on " + domains.Count + " domains");

            int runningTasks = 0, completedTasks = 0;
            SslLabsClient client = new SslLabsClient();

            AnalyzeOptions startOptions = AnalyzeOptions.None;
            if (options.ForceNew)
                startOptions |= AnalyzeOptions.StartNew;
            else
                startOptions = AnalyzeOptions.ReturnAllIfDone;

            if (options.Publish)
                startOptions |= AnalyzeOptions.Publish;

            Action printStatus = () => Console.WriteLine("Queue: " + domains.Count +
                                                         ", running: " + runningTasks +
                                                         " (of " + client.MaxAssesments + "), " +
                                                         "completed: " + completedTasks);

            AutoResetEvent limitChangedEvent = new AutoResetEvent(false);

            client.MaxAssesmentsChanged += () => limitChangedEvent.Set();
            client.CurrentAssesmentsChanged += () => limitChangedEvent.Set();

            while (domains.Any())
            {
                string domain = domains.Peek();

                // Attempt to start the task
                Analysis analysis;
                while (true)
                {
                    if (runningTasks < options.Max)
                    {
                        bool didStart = client.TryStartAnalysis(domain, out analysis, startOptions);

                        if (didStart)
                        {
                            printStatus();
                            break;
                        }
                    }

                    // Wait for one to free up, fall back to trying every 30s
                    limitChangedEvent.WaitOne(30000);

                    printStatus();
                }

                // The task was started
                domains.Dequeue();
                //Console.WriteLine("Started " + domain);

                Task.Factory.StartNew(() =>
                {
                    Analysis innerAnalysis;
                    if (analysis != null && analysis.Status == AnalysisStatus.READY)
                        // Use the one we fetched immediately
                        innerAnalysis = analysis;
                    else
                        // Block till we have an analysis
                        innerAnalysis = client.GetAnalysisBlocking(domain);

                    File.WriteAllText(Path.Combine(options.Output, domain + ".scan"), JsonConvert.SerializeObject(innerAnalysis));

                    Console.WriteLine("Completed " + domain);

                    Interlocked.Increment(ref completedTasks);
                    Interlocked.Decrement(ref runningTasks);

                    limitChangedEvent.Set();
                });

                Interlocked.Increment(ref runningTasks);
            }

            Timer timer = new Timer(2000);
            timer.Elapsed += (sender, eventArgs) => printStatus();
            timer.Start();

            while (runningTasks != 0)
            {
                // Wait for tasks to finish, fall back to checking every15s
                limitChangedEvent.WaitOne(15000);
            }

            timer.Stop();

            return 0;
        }
    }

    public class Options
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public bool ForceNew { get; set; }
        public bool Publish { get; set; }
        public int Max { get; set; }
    }
}
