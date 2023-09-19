using System;

namespace MBW.Client.SslLabsLib;

public class SslLabsManagedClient
{
    /// <summary>
    /// Time between lookups, before a scan has started (before moving to IN_PROGRESS)
    /// </summary>
    public TimeSpan WaitTimePreScan { get; set; } = TimeSpan.FromSeconds(10);

    /// <summary>
    /// Time between lookups, once a scan has started (moved to IN_PROGRESS, before READY or ERROR)
    /// </summary>
    public TimeSpan WaitTimeScan { get; set; } = TimeSpan.FromSeconds(5);

    /// <summary>
    /// Time to pause, once SSLLabs report the service is overloaded. This is not the same as rate limiting.
    /// </summary>
    public TimeSpan WaitTimeOverloaded { get; set; } = TimeSpan.FromSeconds(30);
}