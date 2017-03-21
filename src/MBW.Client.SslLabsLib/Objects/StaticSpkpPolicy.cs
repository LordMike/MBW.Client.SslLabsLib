using System.Collections.Generic;
using MBW.Client.SslLabsLib.Enums;

namespace MBW.Client.SslLabsLib.Objects;

/// <summary>
/// Represents a static public key pinning policy.
/// </summary>
public class StaticSpkpPolicy
{
    /// <summary>
    /// Gets or sets the SPKP status.
    /// </summary>
    public SpkpStatus Status { get; set; }

    /// <summary>
    /// Error message, when the policy is invalid
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// True if the includeSubDomains directive is set else false
    /// </summary>
    public bool IncludeSubDomains { get; set; }

    /// <summary>
    /// Gets or sets the report-uri value from the policy.
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
    /// List of pins that match the current configuration
    /// </summary>
    public List<HpkpPin> ForbiddenPins { get; set; }

    /// <summary>
    /// List of forbidden pins that match the current configuration
    /// </summary>
    public List<HpkpPin> MatchedForbiddenPins { get; set; }
}