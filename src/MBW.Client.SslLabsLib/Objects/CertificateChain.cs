using System.Collections.Generic;
using MBW.Client.SslLabsLib.Enums;

namespace MBW.Client.SslLabsLib.Objects;

public class CertificateChain
{
    /// <summary>
    /// Certificate chain ID
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// List of IDs of each certificate, representing the chain certificates in the order in which they were retrieved from the server
    /// </summary>
    public List<string> CertIds { get; set; }

    /// <summary>
    /// Trust paths
    /// </summary>
    public List<TrustPath> TrustPaths  { get; set; }

    /// <summary>
    /// Flags indicating the issues with the certificate chain.
    /// </summary>
    public ChainIssues Issues { get; set; }
    
    /// <summary>
    /// True for certificate obtained only with No Server Name Indication (SNI).
    /// </summary>
    public bool NoSni { get; set; }
}