using System;
using System.Collections.Generic;
using MBW.Client.SslLabsLib.Enums;

namespace MBW.Client.SslLabsLib.Objects;

public class EndpointDetails
{
    /// <summary>
    /// Endpoint assessment starting time, in milliseconds since 1970. 
    /// This field is useful when test results are retrieved in several HTTP invocations. 
    /// Then, you should check that the hostStartTime value matches the startTime value of the host.
    /// </summary>
    public DateTime HostStartTime { get; set; }

    /// <summary>
    /// Server Certificate chains
    /// </summary>
    public List<CertificateChain> CertChains { get; set; }

    /// <summary>
    /// Supported protocols
    /// </summary>
    public List<Protocol> Protocols { get; set; }

    /// <summary>
    /// Supported cipher suites
    /// </summary>
    public List<Suites> Suites { get; set; }

    /// <summary>
    /// Cipher suites observed only with client that does not support Server Name Indication (SNI).
    /// </summary>
    public Suites NoSniSuites { get; set; }

    /// <summary>
    /// </summary>
    public NamedGroups NamedGroups { get; set; }

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
    /// True if the server supports ALPN
    /// </summary>
    public bool SupportsAlpn { get; set; }

    /// <summary>
    /// List of supported ALPN protocols, separated by spaces
    /// </summary>
    public string AlpnProtocols { get; set; }

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
    public string? StaplingRevocationErrorMessage { get; set; }

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
    public string? HttpForwarding { get; set; }

    /// <summary>
    /// True if the server supports at least one RC4 suite.
    /// </summary>
    public bool SupportsRc4 { get; set; }

    /// <summary>
    /// True if RC4 is used with modern clients.
    /// </summary>
    public bool Rc4WithModern { get; set; }

    /// <summary>
    /// True if only RC4 suites are supported.
    /// </summary>
    public bool Rc4Only { get; set; }

    /// <summary>
    /// Indicates support for Forward Secrecy
    /// </summary>
    public ForwardSecrecyResult ForwardSecrecy { get; set; }

    /// <summary>
    /// supportsAead - true if the server supports at least one AEAD suite.
    /// </summary>
    public bool SupportsAead { get; set; }

    /// <summary>
    /// supportsCBC - true if the server supports at least one CBC suite.
    /// </summary>
    public bool SupportsCbc { get; set; }

    /// <summary>
    /// Indicates protocol version intolerance issues:
    /// </summary>
    public ProtocolIntoleranceType ProtocolIntolerance { get; set; }

    /// <summary>
    /// Indicates various other types of intolerance:
    /// </summary>
    public MiscIntoleranceType MiscIntolerance { get; set; }

    /// <summary>
    /// Client simulation details
    /// </summary>
    public SimDetails Sims { get; set; }

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
    /// Results of the CVE-2016-2107 test:
    /// </summary>
    public OpenSSLLuckyMinus20Result OpenSslLuckyMinus20 { get; set; }

    /// <summary>
    /// Results of the ticketbleed CVE-2016-9244 test
    /// </summary>
    public TicketBleedResult Ticketbleed { get; set; }

    /// <summary>
    /// Results of the Return Of Bleichenbacher's Oracle Threat (ROBOT) test
    /// </summary>
    public BleichenbacherResult Bleichenbacher { get; set; }

    /// <summary>
    /// Results of the Zombie POODLE test.
    /// </summary>
    public ZombiePoodleTestResults ZombiePoodle { get; set; }

    /// <summary>
    /// Results of the GOLDENDOODLE test.
    /// </summary>
    public GoldenDoodleTestResults GoldenDoodle { get; set; }

    /// <summary>
    /// Results of the 0-Length Padding Oracle test.
    /// </summary>
    public ZeroLengthPaddingOracleTestResults ZeroLengthPaddingOracle { get; set; }

    /// <summary>
    /// Results of the Sleeping POODLE test.
    /// </summary>
    public SleepingPoodleTestResults SleepingPoodle { get; set; }

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
    public SctResult HasSct { get; set; }

    /// <summary>
    /// List of hex-encoded DH primes used by the server
    /// </summary>
    public string[]? DhPrimes { get; set; }

    /// <summary>
    /// Whether the server uses known DH primes:
    /// </summary>
    public DhKnownPrimesResult DhUsesKnownPrimes { get; set; }

    /// <summary>
    /// True if the DH ephemeral server value is reused.
    /// </summary>
    public bool DhYsReuse { get; set; }

    /// <summary>
    /// True if the server reuses its ECDHE values
    /// </summary>
    public bool EcdhParameterReuse { get; set; }

    /// <summary>
    /// True if the server uses DH parameters weaker than 1024 bits.
    /// </summary>
    public bool LogJam { get; set; }

    /// <summary>
    /// True if the server takes into account client preferences when deciding if to use ChaCha20 suites.
    /// </summary>
    public bool ChaCha20Preference { get; set; }

    /// <summary>
    /// Server's HSTS policy. Experimental.
    /// </summary>
    public HstsPolicy HstsPolicy { get; set; }

    /// <summary>
    /// Information about preloaded HSTS policies.
    /// </summary>
    public List<HstsPreload> HstsPreloads { get; set; }

    /// <summary>
    /// Server's HPKP policy. Experimental.
    /// </summary>
    public HpkpPolicy HpkpPolicy { get; set; }

    /// <summary>
    /// Server's HPKP RO (Report Only) policy. Experimental.
    /// </summary>
    public HpkpPolicy HpkpRoPolicy { get; set; }

    /// <summary>
    /// Server's SPKP policy.
    /// </summary>
    public StaticSpkpPolicy StaticPkpPolicy { get; set; }

    /// <summary>
    /// An array of HttpTransaction objects.
    /// </summary>
    public List<HttpTransaction> HttpTransactions { get; set; }

    /// <summary>
    /// List of drown hosts. Experimental.
    /// </summary>
    public List<DrownHosts> DrownHosts { get; set; }

    /// <summary>
    /// True if error occurred in drown test.
    /// </summary>
    public bool DrownErrors { get; set; }

    /// <summary>
    /// True if server vulnerable to drown attack.
    /// </summary>
    public bool DrownVulnerable { get; set; }

    /// <summary>
    /// True if server supports mandatory TLS 1.3 cipher suite (TLS_AES_128_GCM_SHA256), null if TLS 1.3 not supported.
    /// </summary>
    public bool? ImplementsTls13MandatoryCs { get; set; }

    /// <summary>
    /// Results of the 0-RTT test.
    /// </summary>
    public ZeroRttTestResults ZeroRttEnabled { get; set; }
}