using System.Collections.Generic;
using SslLabsLib.Enums;

namespace SslLabsLib.Objects
{
    public class ChainCertificate
    {
        public string Subject { get; set; }

        public string Label { get; set; }

        public object NotBefore { get; set; }

        public object NotAfter { get; set; }

        public string IssuerSubject { get; set; }

        public string IssuerLabel { get; set; }

        public string SigAlg { get; set; }

        public int Issues { get; set; }

        public string KeyAlg { get; set; }

        public int KeySize { get; set; }

        public int KeyStrength { get; set; }

        public int RevocationStatus { get; set; }

        public int CrlRevocationStatus { get; set; }

        public int OcspRevocationStatus { get; set; }

        public string Raw { get; set; }
    }

    public class Chain
    {
        public List<ChainCertificate> Certs { get; set; }

        public int Issues { get; set; }
    }

    public class Protocol
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }
    }

    public class List
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CipherStrength { get; set; }

        public int EcdhBits { get; set; }

        public int EcdhStrength { get; set; }
    }

    public class Suites
    {
        public List<List> List { get; set; }

        public bool Preference { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public bool IsReference { get; set; }

        public string Platform { get; set; }
    }

    public class Result
    {
        public Client Client { get; set; }

        public int ErrorCode { get; set; }

        public int Attempts { get; set; }

        public int ProtocolId { get; set; }

        public int SuiteId { get; set; }
    }

    public class Sims
    {
        public List<Result> Results { get; set; }
    }

    public class Details
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

        public Sims Sims { get; set; }

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