using System.Collections.Generic;

namespace MBW.Client.SslLabsLib.Objects;

public class CaaPolicy
{
    /// <summary>
    /// Hostname where policy is located
    /// </summary>
    public string PolicyHostname { get; set; }

    /// <summary>
    /// List of Supported CAARecord
    /// </summary>
    public List<CaaRecord> CaaRecords { get; set; }
}