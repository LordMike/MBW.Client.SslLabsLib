namespace MBW.Client.SslLabsLib.Enums;

public enum BleichenbacherResult
{
    /// <summary>
    /// Test failed.
    /// </summary>
    TestFailed = -1,

    /// <summary>
    /// Result is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Endpoint is not vulnerable.
    /// </summary>
    NotVulnerable = 1,

    /// <summary>
    /// Endpoint is vulnerable (weak oracle).
    /// </summary>
    VulnerableWeakOracle = 2,

    /// <summary>
    /// Endpoint is vulnerable (strong oracle).
    /// </summary>
    VulnerableStrongOracle = 3,

    /// <summary>
    /// Test produced inconsistent results.
    /// </summary>
    InconsistentResults = 4
}