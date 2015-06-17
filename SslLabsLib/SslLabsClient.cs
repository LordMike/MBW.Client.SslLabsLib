using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SslLabsLib.Enums;
using SslLabsLib.Objects;

namespace SslLabsLib
{
    public class SslLabsClient
    {
        private static TimeSpan _waitTimePreScan = TimeSpan.FromSeconds(10);
        private static TimeSpan _waitTimeScan = TimeSpan.FromSeconds(5);
        private static TimeSpan _waitTimeOverloaded = TimeSpan.FromSeconds(30);

        private HttpClient _restClient;

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

            _restClient = new HttpClient();
            _restClient.BaseAddress = baseUrl;
        }

        public Info GetInfo()
        {
            string json = _restClient.GetStringAsync("info").Result;
            return JsonConvert.DeserializeObject<Info>(json);
        }

        public StatusCodes GetStatusCodes()
        {
            string json = _restClient.GetStringAsync("getStatusCodes").Result;
            return JsonConvert.DeserializeObject<StatusCodes>(json);
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
            Dictionary<string, string> parms = new Dictionary<string, string>();
            parms["s"] = endpoint.ToString();
            parms["host"] = hostname;

            HttpResponseMessage resp = _restClient.GetAsync(BuildUrl("getEndpointData", parms)).Result;

            ReadXHeaders(resp);

            string json = resp.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Endpoint>(json);
        }

        public Analysis GetAnalysisBlocking(string hostname, int? maxAge = null, AnalyzeOptions options = AnalyzeOptions.None, Action<Analysis> progressCallback = null)
        {
            // Deactivate ReturnAll, activate ReturnAllWhenDone
            options &= ~AnalyzeOptions.ReturnAll;
            options |= AnalyzeOptions.ReturnAllWhenDone;

            // Initial request
            Analysis analysis;
            AnalysisResult result = GetAnalysisInternal(hostname, maxAge, options, out analysis);

            switch (result)
            {
                case AnalysisResult.Error:
                case AnalysisResult.UnknownError:
                    throw new Exception("The server was unable to handle the request (" + result + ")");
                case AnalysisResult.Maintenance:
                    throw new Exception("The server was unable to handle the request due to Maintenance (HTTP 503)");
            }

            if (analysis.Status == "READY")
                return analysis;

            if (progressCallback != null)
                progressCallback(analysis);

            // Deactivate StartNew
            options &= ~AnalyzeOptions.StartNew;

            // Loop till we're done
            TimeSpan toWait = _waitTimePreScan;

            while (true)
            {
                Thread.Sleep(toWait);

                // Perform next analysis
                result = GetAnalysisInternal(hostname, maxAge, options, out analysis);

                if (result == AnalysisResult.Error || result == AnalysisResult.UnknownError)
                    throw new Exception("The server was unable to handle the request (" + result + ")");

                if (result == AnalysisResult.Maintenance)
                    throw new Exception("The server was unable to handle the request due to Maintenance (HTTP 503)");

                if (result == AnalysisResult.RateLimit || result == AnalysisResult.Overloaded)
                {
                    toWait = _waitTimeOverloaded;
                }
                else if (result == AnalysisResult.Success)
                {
                    toWait = _waitTimePreScan;

                    // Success
                    // States: DNS, ERROR, IN_PROGRESS, and READY.
                    if (analysis.Status == "DNS" || analysis.Status == "IN_PROGRESS")
                    {
                        // Underways
                        toWait = _waitTimeScan;
                    }
                    else if (analysis.Status == "READY" || analysis.Status == "ERROR")
                    {
                        // We're done
                        break;
                    }
                    else
                        throw new InvalidOperationException("Unknown response...");
                }
                else
                    // Unknown?
                    throw new InvalidOperationException("Unknown state...");

                if (progressCallback != null)
                    progressCallback(analysis);
            }

            return analysis;
        }

        private string BuildUrl(string method, Dictionary<string, string> parms)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(method);

            bool first = true;
            foreach (KeyValuePair<string, string> pair in parms)
            {
                if (first)
                    sb.Append("?");
                else
                    sb.Append("&");

                sb.Append(pair.Key);
                sb.Append("=");
                sb.Append(Uri.EscapeUriString(pair.Value));

                first = false;
            }

            return sb.ToString();
        }

        private void ReadXHeaders(HttpResponseMessage resp)
        {
            foreach (KeyValuePair<string, IEnumerable<string>> header in resp.Headers)
            {
                int tmp;
                if (header.Key == "X-Max-Assessments" && int.TryParse(header.Value.FirstOrDefault(), out tmp))
                    MaxAssesments = tmp;
                else if (header.Key == "X-Current-Assessments" && int.TryParse(header.Value.FirstOrDefault(), out tmp))
                    CurrentAssesments = tmp;
            }
        }

        private AnalysisResult GetAnalysisInternal(string hostname, int? maxAge, AnalyzeOptions options, out Analysis analysis)
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();
            parms["host"] = hostname;

            if (options.HasFlag(AnalyzeOptions.Publish))
                parms["publish"] = "on";

            if (options.HasFlag(AnalyzeOptions.StartNew))
                parms["startNew"] = "on";
            else if (options.HasFlag(AnalyzeOptions.FromCache))
                parms["fromCache"] = "on";

            if (options.HasFlag(AnalyzeOptions.ReturnAll))
                parms["all"] = "on";
            else if (options.HasFlag(AnalyzeOptions.ReturnAllWhenDone))
                parms["all"] = "done";

            if (options.HasFlag(AnalyzeOptions.IgnoreMismatch))
                parms["ignoreMismatch"] = "on";

            if (maxAge.HasValue)
                parms["maxAge"] = maxAge.ToString();

            HttpResponseMessage resp = _restClient.GetAsync(BuildUrl("analyze", parms)).Result;

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

            string json = resp.Content.ReadAsStringAsync().Result;
            analysis = JsonConvert.DeserializeObject<Analysis>(json);

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
