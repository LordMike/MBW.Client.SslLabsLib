using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MBW.Client.SslLabsLib.Response;

namespace MBW.Client.SslLabsLib.Extensions;

public static class SslLabsClientExtensions
{
    public static Task<Endpoint> GetEndpointData(this SslLabsClient client, string host, IPAddress ipAddress,
        bool fromCache = false,
        CancellationToken token = default) =>
        client.GetEndpointData(host, ipAddress.ToString(), fromCache, token);
}