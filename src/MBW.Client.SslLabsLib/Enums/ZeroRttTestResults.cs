namespace MBW.Client.SslLabsLib.Enums;

/// <summary>
/// Represents the results of the 0-RTT test.
/// </summary>
public enum ZeroRttTestResults
{
    /// <summary>
    /// Test failed.
    /// </summary>
    TestFailed = -2,

    /// <summary>
    /// Test was not performed (default).
    /// </summary>
    TestNotPerformed = -1,

    /// <summary>
    /// 0-RTT is not enabled.
    /// </summary>
    NotEnabled = 0,

    /// <summary>
    /// 0-RTT is enabled.
    /// </summary>
    Enabled = 1
}