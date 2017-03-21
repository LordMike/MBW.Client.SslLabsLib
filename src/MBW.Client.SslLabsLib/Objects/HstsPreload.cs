using System;
using MBW.Client.SslLabsLib.Enums;

namespace MBW.Client.SslLabsLib.Objects;

public class HstsPreload
{
    /// <summary>
    /// Source name
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Hostname of this preload
    /// </summary>
    public string Hostname { get; set; }

    /// <summary>
    /// Preload status
    /// </summary>
    public HstsPreloadStatus Status { get; set; }

    /// <summary>
    /// Error message, when status is "error"
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// Time, as a Unix timestamp, when the preload database was retrieved
    /// </summary>
    public DateTime SourceTime { get; set; }
}