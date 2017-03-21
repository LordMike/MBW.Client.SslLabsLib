using System.Collections.Generic;

namespace MBW.Client.SslLabsLib.Objects;

public class TrustPath
{
    /// <summary>
    /// List of certificate ID from leaf to root.
    /// </summary>
    public List<string> CertIds { get; set; }

    /// <summary>
    /// This object shows info about the trusted certificate by using Mozilla trust store.
    /// </summary>
    public List<Trust> Trust { get; set; }

    /// <summary>
    /// True if a key is pinned, else false
    /// </summary>
    public bool IsPinned { get; set; }

    /// <summary>
    /// Number of matched pins with HPKP policy
    /// </summary>
    public int MactchedPins { get; set; }
    
    /// <summary>
    /// Number of unmatched pins with HPKP policy
    /// </summary>
    public int UnmatchedPins { get; set; }
}