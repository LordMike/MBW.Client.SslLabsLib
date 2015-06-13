using System.Collections.Generic;
using RestSharp.Deserializers;
using SslLabsLib.Enums;

namespace SslLabsLib.Objects
{
    public class EndpointDetails
    {
        /// <summary>
        /// Endpoint assessment starting time, in milliseconds since 1970. 
        /// This field is useful when test results are retrieved in several HTTP invocations. 
        /// Then, you should check that the hostStartTime value matches the startTime value of the host.
        /// </summary>
        public long HostStartTime { get; set; }

        /// <summary>
        /// Key information
        /// </summary>
        public Key Key { get; set; }

        /// <summary>
        /// Certificate information
        /// </summary>
        public Cert Cert { get; set; }

        /// <summary>
        /// Chain information
        /// </summary>
        public Chain Chain { get; set; }

        /// <summary>
        /// Supported protocols
        /// </summary>
        public List<Protocol> Protocols { get; set; }

        /// <summary>
        /// Supported cipher suites
        /// </summary>
        public Suites Suites { get; set; }

        /// <summary>
        /// Contents of the HTTP Server response header when known. 
        /// This field could be absent for one of two reasons: 
        /// 1) the HTTP request failed (check httpStatusCode)
        /// 2) there was no Server response header returned.
        /// </summary>
        public string ServerSignature { get; set; }

        /// <summary>
        /// True if this endpoint is reachable via a hostname with the www prefix
        /// </summary>
        public bool PrefixDelegation { get; set; }

        /// <summary>
        /// True if this endpoint is reachable via a hostname without the www prefix
        /// </summary>
        public bool NonPrefixDelegation { get; set; }

        /// <summary>
        /// True if the endpoint is vulnerable to the BEAST attack
        /// </summary>
        public bool VulnBeast { get; set; }

        /// <summary>
        /// This is an integer value that describes the endpoint support for renegotiation:
        /// </summary>
        public RenegotiationSupport RenegSupport { get; set; }

        /// <summary>
        /// The contents of the Strict-Transport-Security (STS) response header, if seen
        /// </summary>
        [DeserializeAs(Name = "stsResponseHeader")]
        public string StrictTransportSecurityResponseHeader { get; set; }

        /// <summary>
        /// The maxAge parameter extracted from the STS parameters; null if STS not seen, or -1 if the specified value is invalid (e.g., not a zero or a positive integer; the maximum value currently supported is 2,147,483,647)
        /// </summary>
        [DeserializeAs(Name = "stsMaxAge")]
        public int StrictTransportSecurityMaxAge { get; set; }

        /// <summary>
        /// True if the includeSubDomains STS parameter is set; null if STS not seen
        /// </summary>
        [DeserializeAs(Name = "stsSubdomains")]
        public bool StrictTransportSecuritySubdomains { get; set; }

        /// <summary>
        /// The contents of the Public-Key-Pinning response header, if seen
        /// </summary>
        [DeserializeAs(Name = "pkpResponseHeader")]
        public bool PublicKeyPinningResponseHeader { get; set; }

        /// <summary>
        /// This is an integer value that describes endpoint support for session resumption.
        /// </summary>
        public SessionResumptionResult SessionResumption { get; set; }

        /// <summary>
        /// Integer value that describes supported compression methods
        /// </summary>
        public CompressionMethodsSupported CompressionMethods { get; set; }

        /// <summary>
        /// True if the server supports NPN
        /// </summary>
        public bool SupportsNpn { get; set; }

        /// <summary>
        /// List of supported protocols, separated by spaces
        /// </summary>
        public string NpnProtocols { get; set; }

        /// <summary>
        /// Indicates support for Session Tickets
        /// </summary>
        public SessionTicketsResult SessionTickets { get; set; }

        /// <summary>
        /// True if OCSP stapling is deployed on the server
        /// </summary>
        public bool OcspStapling { get; set; }

        /// <summary>
        /// RevocationStatus for the stapled OCSP response.
        /// </summary>
        public RevocationStatus StaplingRevocationStatus { get; set; }

        /// <summary>
        /// Description of the problem with the stapled OCSP response, if any.
        /// </summary>
        public string StaplingRevocationErrorMessage { get; set; }

        /// <summary>
        /// If SNI support is required to access the web site.
        /// </summary>
        public bool SniRequired { get; set; }

        /// <summary>
        /// Status code of the final HTTP response seen. When submitting HTTP requests, redirections are followed, but only if they lead to the same hostname. 
        /// If this field is not available, that means the HTTP request failed.
        /// </summary>
        public int? HttpStatusCode { get; set; }
        
        /// <summary>
        /// Available on a server that responded with a redirection to some other hostname.
        /// </summary>
        public string HttpForwarding { get; set; }

        /// <summary>
        /// True if the server supports at least one RC4 suite.
        /// </summary>
        public bool SupportsRc4 { get; set; }

        /// <summary>
        /// Indicates support for Forward Secrecy
        /// </summary>
        public ForwardSecrecyResult ForwardSecrecy { get; set; }

        /// <summary>
        /// True if RC4 is used with modern clients.
        /// </summary>
        public bool Rc4WithModern { get; set; }

        /// <summary>
        /// Client simulation details
        /// </summary>
        [DeserializeAs(Name = "sims")]
        public SimulationDetails Simulations { get; set; }

        /// <summary>
        /// True if the server is vulnerable to the Heartbleed attack.
        /// </summary>
        public bool Heartbleed { get; set; }

        /// <summary>
        /// True if the server supports the Heartbeat extension.
        /// </summary>
        public bool Heartbeat { get; set; }

        /// <summary>
        /// Results of the CVE-2014-0224 test
        /// </summary>
        public OpenSslCcsResult OpenSslCcs { get; set; }

        /// <summary>
        /// True if the endpoint is vulnerable to POODLE; false otherwise
        /// </summary>
        public bool Poodle { get; set; }

        /// <summary>
        /// Results of the POODLE TLS test
        /// </summary>
        public PoodleResult PoodleTls { get; set; }

        /// <summary>
        /// True if the server supports TLS_FALLBACK_SCSV, false if it doesn't. This field will not be available if the server's support 
        /// for TLS_FALLBACK_SCSV can't be tested because it supports only one protocol version (e.g., only TLS 1.2).
        /// </summary>
        public bool FallbackScsv { get; set; }

        /// <summary>
        /// True of the server is vulnerable to the FREAK attack, meaning it supports 512-bit key exchange.
        /// </summary>
        public bool Freak { get; set; }

        /// <summary>
        /// Information about the availability of certificate transparency information (embedded SCTs):
        /// </summary>
        [DeserializeAs(Name = "hasSct")]
        public SctResult HasSct { get; set; }
    }
}