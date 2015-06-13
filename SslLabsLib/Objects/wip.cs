using System.Collections.Generic;
using RestSharp.Deserializers;

namespace SslLabsLib.Objects
{
    public class EndpointDetails
    {
        public long HostStartTime { get; set; }

        public Key Key { get; set; }

        public Cert Cert { get; set; }

        public Chain Chain { get; set; }

        public List<Protocol> Protocols { get; set; }

        public Suites Suites { get; set; }

        public string ServerSignature { get; set; }

        public bool PrefixDelegation { get; set; }

        public bool NonPrefixDelegation { get; set; }

        public bool VulnBeast { get; set; }

        public int RenegSupport { get; set; }

        public string StsResponseHeader { get; set; }

        public int StsMaxAge { get; set; }

        public bool StsSubdomains { get; set; }

        public int SessionResumption { get; set; }

        public int CompressionMethods { get; set; }

        public bool SupportsNpn { get; set; }

        public string NpnProtocols { get; set; }

        public int SessionTickets { get; set; }

        public bool OcspStapling { get; set; }

        public bool SniRequired { get; set; }

        public int HttpStatusCode { get; set; }

        public bool SupportsRc4 { get; set; }

        public int ForwardSecrecy { get; set; }

        public bool Rc4WithModern { get; set; }

        [DeserializeAs(Name = "sims")]
        public SimulationDetails Simulations { get; set; }

        public bool Heartbleed { get; set; }

        public bool Heartbeat { get; set; }

        public int OpenSslCcs { get; set; }

        public bool Poodle { get; set; }

        public int PoodleTls { get; set; }

        public bool FallbackScsv { get; set; }

        public bool Freak { get; set; }

        public int HasSct { get; set; }
    }
}