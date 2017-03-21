using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MBW.Client.SslLabsLib.Enums;
using MBW.Client.SslLabsLib.Response;
using MBW.Client.SslLabsLib.Serializer;

namespace MBW.Client.SslLabsLib.TestApplication;

class Program
{
    static async Task Main(string[] args)
    {
        SslLabsClient client = new SslLabsClient(new HttpClient(new SocketsHttpHandler
        {
            Proxy = new WebProxy("http://127.0.0.1:8888")
        })
        {
            BaseAddress = SslLabsConstants.DefaultUri
        });

        var serializer = SystemTextJsonSsllabsSerializer.Instance;

        // var tmp = await client.GetEndpointData("a", "b");
        // Console.WriteLine(JsonSerializer.SerializeToDocument(tmp).RootElement.ToString());

        var info = await client.GetInfo();
        Console.WriteLine(JsonSerializer.SerializeToDocument(info).RootElement.ToString());

        // var statusCodes = await client.GetStatusCodes();
        // Console.WriteLine(JsonSerializer.SerializeToDocument(statusCodes).RootElement.ToString());

        // foreach (var ssllabsTrustStore in Enum.GetValues<SsllabsTrustStore>())
        // {
        //     var getRootCertsRaw = await client.GetRootCertsRaw(ssllabsTrustStore);
        //     Console.WriteLine(JsonSerializer.SerializeToDocument(getRootCertsRaw).RootElement.ToString());
        // }

        // var endpoint = await client.GetEndpointData("www.csis.dk", "141.101.90.97", true);
        // Console.WriteLine(JsonSerializer.SerializeToDocument(endpoint).RootElement.ToString());


        // HostInfo host;
        // while (true)
        // {
        //     host = await client.Analyze("csis.dk", false, false, true, 1440, false, true);
        //     Console.WriteLine(JsonSerializer.SerializeToDocument(host, serializer.Options).RootElement.ToString());
        //     Console.WriteLine("Status: " + host.Status);
        //
        //     if (host.Status != AnalysisStatus.DNS && host.Status != AnalysisStatus.IN_PROGRESS)
        //         break;
        //
        //     Console.WriteLine("Waiting " + client.WaitTimeScan);
        //     await Task.Delay(client.WaitTimeScan);
        // }
        //
        // host = await client.Analyze("csis.dk", false, false, true, 1440, true, true);
        // Console.WriteLine(JsonSerializer.SerializeToDocument(host, serializer.Options).RootElement.ToString());
    }
}