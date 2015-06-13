using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Options;
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

            OptionSet parser = new OptionSet();
            parser.Add("p|progress", "Show progress while waiting", s => options.Progress = true);
            parser.Add("n|new", "Force a new scan", s => options.New = true);
            parser.Add("w|nowait", "Exit if no scan is available", s => options.NoWait = true);

            List<string> leftoverArgs = parser.Parse(args);
            options.Hostname = leftoverArgs.FirstOrDefault();

            if (string.IsNullOrEmpty(options.Hostname))
            {
                Console.WriteLine("Usage: ");
                Console.WriteLine("  SslLabsCli [options] ssllabs.com");
                Console.WriteLine();
                Console.WriteLine("Options");
                parser.WriteOptionDescriptions(Console.Out);
                Console.WriteLine();

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
        public bool Progress { get; set; }

        public bool New { get; set; }

        public bool NoWait { get; set; }

        public string Hostname { get; set; }
    }
}
