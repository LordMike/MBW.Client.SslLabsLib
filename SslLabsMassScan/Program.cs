using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Options;

namespace SslLabsMassScan
{
    class Program
    {
        static int Main(string[] args)
        {
            Options options = new Options();

            OptionSet parser = new OptionSet();
            parser.Add("f|file", "Save the scan to a file", s => options.Input = s);
            parser.Add("o|output", "Save the scan to a file", s => options.Output = s);

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

            List<string> domains = new List<string>();
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
                    domains.Add(line);
                }
            }

            if (anyBadInput)
            {
                Console.WriteLine("One or more bad lines found - please correct");

                return 2;
            }

            Console.WriteLine("Beginning work on " + domains.Count + " domains");

            return 0;
        }
    }

    public class Options
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
