using System;
using System.Linq;
using CommandLine;
using CommandLine.Text;
using SslLabsLib;
using SslLabsLib.Enums;
using SslLabsLib.Objects;

namespace SslLabsCli
{
    class Program
    {
        static void Main(string[] args)
        {
            // SslLabsCli csis.dk --progress --new --nowait

            Options options = new Options();
            if (!Parser.Default.ParseArguments(args, options))
            {
                return;
            }

            Analysis analysis = HandleFetch(options);

            if (analysis.Status != "READY")
            {
                Console.WriteLine("Analysis not available");
                return;
            }

            PresentAnalysis(analysis);
        }

        private static Analysis HandleFetch(Options options)
        {
            SslLabsClient client = new SslLabsClient();

            Analysis analysis = client.GetAnalysisBlocking(options.Hostname, null, AnalyzeOptions.FromCache | AnalyzeOptions.ReturnAllWhenDone);

            return analysis;
        }

        private static void PresentAnalysis(Analysis analysis)
        {
            Console.WriteLine("== Basic ==");
            Console.WriteLine("Host: " + analysis.Host + ":" + analysis.Port);
            Console.WriteLine("Public: " + analysis.IsPublic);

            Console.WriteLine();
            Console.WriteLine("== Endpoints ==");

            for (int i = 0; i < analysis.Endpoints.Count; i++)
            {
                Endpoint endpoint = analysis.Endpoints[i];

                Console.WriteLine("[" + i + "] == " + endpoint.IpAddress);
                Console.WriteLine("[" + i + "] Protocols: " + string.Join(", ", endpoint.Details.Protocols.Select(s => s.Name + " " + s.Version)));
                Console.WriteLine("[" + i + "] Grade (ignore trust): " + endpoint.Grade + " (" + endpoint.GradeTrustIgnored + ")");

                Console.WriteLine("[" + i + "] Suites (" + (endpoint.Details.Suites.Preference ? "preferred" : "not preferred") + ")");
                foreach (Ciphersuite suite in endpoint.Details.Suites.List)
                {
                    Console.WriteLine("[" + i + "]   " + suite.Name + " " + (suite.Q == 1 ? "(WEAK)" : ""));
                }

                Console.WriteLine();
            }
        }
    }

    internal class Options
    {
        [Option('p', "progress", HelpText = "Show progress while waiting.")]
        public bool Progress { get; set; }

        [Option('n', "new", HelpText = "Force a new scan.")]
        public bool New { get; set; }

        [Option('w', "nowait", HelpText = "Exit if no scan is available.")]
        public bool NoWait { get; set; }

        [ValueOption(0)]
        public string Hostname { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            HelpText autoBuild = HelpText.AutoBuild(this);

            return autoBuild;
        }
    }
}
