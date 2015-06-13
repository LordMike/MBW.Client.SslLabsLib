using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace SslLabsLib
{
    public class SslLabsClient
    {
        private RestClient _restClient;

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

            return resp.Data;
        }

    }

    public class Info
    {
        public string EngineVersion { get; set; }

        public string CriteriaVersion { get; set; }

        public int ClientMaxAssessments { get; set; }

        public int MaxAssessments { get; set; }

        public int CurrentAssessments { get; set; }

        public List<string> Messages { get; set; }
    }
}
