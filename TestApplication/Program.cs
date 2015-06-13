using System;
using System.Net;
using SslLabsLib;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SslLabsClient client = new SslLabsClient();

            //Analysis res = client.GetAnalysis("csis.dk", null, AnalyzeOptions.FromCache | AnalyzeOptions.ReturnAllWhenDone);
            var res = client.GetCachedEndpointAnalysis("csis.dk", IPAddress.Parse("46.51.179.119"));

            var xa = res.Details.Cert;

            Console.WriteLine(res);
        }
    }
}
