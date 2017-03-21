using System.Collections.Generic;
using System.Text.Json.Serialization;
using MBW.Client.SslLabsLib.Enums;

namespace MBW.Client.SslLabsLib.Objects;

public class HstsPolicy
{
    /// <summary>
    /// This constant contains what SSL Labs considers to be sufficiently large max-age value
    /// </summary>
    [JsonPropertyName("LONG_MAX_AGE")]
    public long LongMaxAge { get; set; }

    /// <summary>
    /// The contents of the HSTS response header, if present
    /// </summary>
    public string Header { get; set; }

    /// <summary>
    /// HSTS Status
    /// </summary>
    public HstsStatus Status { get; set; }

    /// <summary>
    /// Error message when error is encountered, null otherwise
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// The max-age value specified in the policy; null if policy is missing or invalid or on parsing error; the maximum value currently supported is 9223372036854775807
    /// </summary>
    public long? MaxAge { get; set; }

    /// <summary>
    /// True if the includeSubDomains directive is set; null otherwise
    /// </summary>
    public bool? IncludeSubDomains { get; set; }

    /// <summary>
    /// True if the preload directive is set; null otherwise
    /// </summary>
    public bool? Preload { get; set; }

    /// <summary>
    /// List of raw policy directives
    /// </summary>
    public Dictionary<string, string> Directives { get; set; }
}