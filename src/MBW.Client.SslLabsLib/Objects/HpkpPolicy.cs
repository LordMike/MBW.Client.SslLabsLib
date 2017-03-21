using System.Collections.Generic;
using MBW.Client.SslLabsLib.Enums;

namespace MBW.Client.SslLabsLib.Objects;

public class HpkpPolicy
{
    /// <summary>
    /// The contents of the HPKP response header, if present
    /// </summary>
    public string Header { get; set; }
    
    /// <summary>
    /// HPKP Status
    /// </summary>
    public HpkpStatus Status { get; set; }

    /// <summary>
    /// Error message, when the policy is invalid
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// The max-age value from the policy
    /// </summary>
    public long MaxAge { get; set; }

    /// <summary>
    /// True if the includeSubDomains directive is set; null otherwise
    /// </summary>
    public bool IncludeSubDomains { get; set; }

    /// <summary>
    /// The report-uri value from the policy
    /// </summary>
    public string ReportUri { get; set; }

    /// <summary>
    /// List of all pins used by the policy
    /// </summary>
    public List<HpkpPin> Pins { get; set; }

    /// <summary>
    /// List of pins that match the current configuration
    /// </summary>
    public List<HpkpPin> MatchedPins { get; set; }

    /// <summary>
    /// List of raw policy directives
    /// </summary>
    public List<List<string>> Directives { get; set; }
}