using System;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;
using SslLabsLib.Enums;
using SslLabsLib.Objects;

namespace SslLabsLib
{
    public class SslLabsClient
    {
        private RestClient _restClient;

        public int MaxAssesments { get; private set; }

        public int CurrentAssesments { get; private set; }

        public SslLabsClient()
            : this(new Uri("https://api.ssllabs.com/api/v2/"))
        {
        }

        public SslLabsClient(Uri baseUrl)
        {
            if (baseUrl == null)
                throw new ArgumentNullException("baseUrl");

            _restClient = new RestClient(baseUrl);

        }

        public Info GetInfo()
        {
            RestRequest req = new RestRequest("info");
            IRestResponse<Info> resp = _restClient.Execute<Info>(req);

            ReadXHeaders(resp);

            return resp.Data;
        }

        public StatusCodes GetStatusCodes()
        {
            RestRequest req = new RestRequest("getStatusCodes");
            IRestResponse<StatusCodes> resp = _restClient.Execute<StatusCodes>(req);

            ReadXHeaders(resp);

            return resp.Data;
        }

        public Analysis GetAnalysis(string hostname, int? maxAge = null, AnalyzeOptions options = AnalyzeOptions.None)
        {
            Analysis analysis;
            AnalysisResult result = GetAnalysisInternal(hostname, maxAge, options, out analysis);

            switch (result)
            {
                case AnalysisResult.Success:
                    return analysis;
                case AnalysisResult.Error:
                case AnalysisResult.UnknownError:
                    throw new Exception("The server was unable to handle the request (" + result + ")");
                case AnalysisResult.Maintenance:
                    throw new Exception("The server was unable to handle the request due to Maintenance (HTTP 503)");
                case AnalysisResult.RateLimit:
                    throw new Exception("The server was unable to handle the request due to rate limits (HTTP 429)");
                case AnalysisResult.Overloaded:
                    throw new Exception("The server was unable to handle the request due to being overloaded (HTTP 529)");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Endpoint GetCachedEndpointAnalysis(string hostname, IPAddress endpoint)
        {
            IRestRequest req = new RestRequest("getEndpointData")
                .AddQueryParameter("host", hostname)
                .AddQueryParameter("s", endpoint.ToString());

            IRestResponse<Endpoint> resp = _restClient.Execute<Endpoint>(req);

            ReadXHeaders(resp);

            return resp.Data;
        }

        private void ReadXHeaders<T>(IRestResponse<T> resp)
        {
            foreach (Parameter header in resp.Headers)
            {
                int tmp;
                if (header.Name == "X-Max-Assessments" && int.TryParse(header.Value as string, out tmp))
                    MaxAssesments = tmp;
                else if (header.Name == "X-Current-Assessments" && int.TryParse(header.Value as string, out tmp))
                    CurrentAssesments = tmp;
            }
        }

        private AnalysisResult GetAnalysisInternal(string hostname, int? maxAge, AnalyzeOptions options, out Analysis analysis)
        {
            IRestRequest req = new RestRequest("analyze")
                      .AddQueryParameter("host", hostname);

            if (options.HasFlag(AnalyzeOptions.Publish))
                req.AddQueryParameter("publish", "on");

            if (options.HasFlag(AnalyzeOptions.StartNew))
                req.AddQueryParameter("startNew", "on");
            else if (options.HasFlag(AnalyzeOptions.FromCache))
                req.AddQueryParameter("fromCache", "on");

            if (options.HasFlag(AnalyzeOptions.ReturnAll))
                req.AddQueryParameter("all", "on");
            else if (options.HasFlag(AnalyzeOptions.ReturnAllWhenDone))
                req.AddQueryParameter("all", "done");

            if (options.HasFlag(AnalyzeOptions.IgnoreMismatch))
                req.AddQueryParameter("ignoreMismatch", "on");

            IRestResponse<Analysis> resp = _restClient.Execute<Analysis>(req);

            ReadXHeaders(resp);

            analysis = null;
            if (resp.StatusCode == HttpStatusCode.BadRequest || resp.StatusCode == HttpStatusCode.InternalServerError)
                // 400 - invocation error (e.g., invalid parameters)
                // 500 - internal error
                return AnalysisResult.Error;

            if (resp.StatusCode == (HttpStatusCode)429)
                // 429 - client request rate too high
                return AnalysisResult.RateLimit;

            if (resp.StatusCode == HttpStatusCode.ServiceUnavailable)
                // 503 - the service is not available (e.g., down for maintenance)
                return AnalysisResult.Maintenance;

            if (resp.StatusCode == (HttpStatusCode)529)
                // 529 - the service is overloaded
                return AnalysisResult.Overloaded;

            if (resp.StatusCode != HttpStatusCode.OK)
                return AnalysisResult.UnknownError;

            // Success
            analysis = resp.Data;

            return AnalysisResult.Success;
        }

        enum AnalysisResult
        {
            Success,
            Error,
            UnknownError,
            Maintenance,
            RateLimit,
            Overloaded
        }
    }
}
