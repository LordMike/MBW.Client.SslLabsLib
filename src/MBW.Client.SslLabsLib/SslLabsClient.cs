using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MBW.Client.SslLabsLib.Enums;
using MBW.Client.SslLabsLib.Exceptions;
using MBW.Client.SslLabsLib.Extensions;
using MBW.Client.SslLabsLib.Helpers;
using MBW.Client.SslLabsLib.Objects;
using MBW.Client.SslLabsLib.Response;
using MBW.Client.SslLabsLib.Serializer;

namespace MBW.Client.SslLabsLib;

public class SslLabsClient
{
    private readonly HttpClient _client;
    private readonly ISsllabsSerializer _serializer;

    /// <summary>
    /// Latest value of the X-Max-Assesments header
    /// </summary>
    public int MaxAssesments { get; private set; }

    /// <summary>
    /// Latest value of the X-Current-Assesments header
    /// </summary>
    public int CurrentAssesments { get; private set; }

    public SslLabsClient(HttpClient client, ISsllabsSerializer? serializer = null)
    {
        _client = client;
        _serializer = serializer ?? SystemTextJsonSsllabsSerializer.Instance;
    }

    public SslLabsClient()
        : this(SslLabsConstants.DefaultUri)
    {
    }

    public SslLabsClient(Uri baseUrl)
    {
        if (baseUrl == null)
            throw new ArgumentNullException(nameof(baseUrl));

        _client = new HttpClient();
        _client.BaseAddress = baseUrl;
        _serializer = SystemTextJsonSsllabsSerializer.Instance;
    }

    private void Enrich(HttpResponseMessage responseMessage, SsllabsResponseBase response)
    {
        int maxAssesments = Convert.ToInt32(responseMessage.Headers.GetValues("X-Max-Assessments").First());
        int currentAssesments = Convert.ToInt32(responseMessage.Headers.GetValues("X-Current-Assessments").First());

        MaxAssesments = maxAssesments;
        CurrentAssesments = currentAssesments;

        response.Response = new ApiResponse();
        response.Response.MaxAssessments = MaxAssesments = maxAssesments;
        response.Response.CurrentAssessments = CurrentAssesments = currentAssesments;
    }

    /// <summary>
    /// As Ssllabs packs errors into responses that are indistinguishable from other responses, we deserialize twice
    /// </summary>
    private async Task ThrowIfError(string method, Stream stream)
    {
        ErrorsResponse errors = await _serializer.Deserialize<ErrorsResponse>(stream);

        if (errors is { Errors.Count: > 0 })
            throw SsllabsRequestException.Create(method, errors);

        // Reset the stream for the caller, so they can deserialize another thing
        stream.Seek(0, SeekOrigin.Begin);
    }

    public async Task<Info> GetInfo(CancellationToken token = default)
    {
        using HttpResponseMessage
            resp = await _client.GetAsync("info", HttpCompletionOption.ResponseContentRead, token);
        using Stream stream = await resp.Content.ReadAsStreamAsync();
        await ThrowIfError("info", stream);

        Info obj = await _serializer.Deserialize<Info>(stream);
        Enrich(resp, obj);

        return obj;
    }

    public async Task<StatusCodes> GetStatusCodes(CancellationToken token = default)
    {
        using HttpResponseMessage resp =
            await _client.GetAsync("getStatusCodes", HttpCompletionOption.ResponseContentRead, token);
        using Stream stream = await resp.Content.ReadAsStreamAsync();
        await ThrowIfError("getStatusCodes", stream);

        StatusCodes obj = await _serializer.Deserialize<StatusCodes>(stream);
        Enrich(resp, obj);

        return obj;
    }

    public async Task<GetRootCertsRaw> GetRootCertsRaw(SsllabsTrustStore? trustStore = null,
        CancellationToken token = default)
    {
        UrlBuilder endpoint = new UrlBuilder("getRootCertsRaw");
        if (trustStore.HasValue)
            endpoint.AddParam("trustStore", ((int)trustStore.Value).ToString());

        using HttpResponseMessage resp =
            await _client.GetAsync(endpoint.Build(), HttpCompletionOption.ResponseHeadersRead, token);
        using Stream stream = await resp.Content.ReadAsStreamAsync();

        GetRootCertsRaw obj = new GetRootCertsRaw();
        StreamReader sr = new StreamReader(stream);

        async Task<string> RequireLine()
        {
            string? tmp = await sr.ReadLineAsync();
            return tmp ?? throw new SsllabsException("getRootCertsRaw", "Invalid format of the root certs response");
        }

        string? line = await RequireLine();
        StringBuilder buffer = new StringBuilder();
        do
        {
            RootCertificateDetails item = new RootCertificateDetails();

            // Read all messages
            do
            {
                item.Messages.Add(line);
                line = await RequireLine();
            } while (line.StartsWith("#"));

            // Read certificate
            buffer.Clear();

            do
            {
                buffer.AppendLine(line);
                line = await RequireLine();
            } while (line != string.Empty);

            item.EncodedCertificate = buffer.ToString();
            obj.Certificates.Add(item);

            // Move to next
            line = await sr.ReadLineAsync();
        } while (line != null);

        Enrich(resp, obj);

        return obj;
    }

    public async Task<Endpoint> GetEndpointData(string host, string ipAddress, bool fromCache = false,
        CancellationToken token = default)
    {
        UrlBuilder endpoint = new UrlBuilder("getEndpointData")
            .AddParam("s", ipAddress)
            .AddParam("fromCache", fromCache ? "on" : "off")
            .AddParam("host", host);

        using HttpResponseMessage resp =
            await _client.GetAsync(endpoint.Build(), HttpCompletionOption.ResponseContentRead, token);
        using Stream stream = await resp.Content.ReadAsStreamAsync();
        await ThrowIfError("getEndpointData", stream);

        Endpoint obj = await _serializer.Deserialize<Endpoint>(stream);
        Enrich(resp, obj);

        return obj;
    }

    public async Task<HostInfo> Analyze(string host, bool? publish = null, bool? startNew = null,
        bool? fromCache = null, int? maxAge = null, AnalysisAll all = AnalysisAll.Default,
        bool? ignoreMismatch = null, CancellationToken token = default)
    {
        UrlBuilder endpoint = new UrlBuilder("analyze")
            .AddParam("host", host);

        if (publish.GetValueOrDefault())
            endpoint.AddParam("publish", "on");

        if (startNew.GetValueOrDefault())
            endpoint.AddParam("startNew", "on");

        if (maxAge.HasValue && maxAge.Value > 0)
            endpoint.AddParam("maxAge", maxAge.ToString());

        if (ignoreMismatch.GetValueOrDefault())
            endpoint.AddParam("ignoreMismatch", "on");

        if (fromCache.GetValueOrDefault())
            endpoint.AddParam("fromCache", "on");

        if (all == AnalysisAll.Always)
            endpoint.AddParam("all", "on");
        else if (all == AnalysisAll.WhenDone)
            endpoint.AddParam("all", "done");

        using HttpResponseMessage resp =
            await _client.GetAsync(endpoint.Build(), HttpCompletionOption.ResponseContentRead, token);
        using Stream stream = await resp.Content.ReadAsStreamAsync();
        await ThrowIfError("analyze", stream);

        HostInfo obj = await _serializer.Deserialize<HostInfo>(stream);
        Enrich(resp, obj);

        return obj;
    }
}