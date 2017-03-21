namespace MBW.Client.SslLabsLib.Enums;

/// <summary>
/// Represents the results of the Sleeping POODLE test.
/// </summary>
public enum SleepingPoodleTestResults
{
    TestFailed = -1,
    Unknown = 0,
    NotVulnerable = 1,
    Vulnerable = 10,
    VulnerableAndExploitable = 11
}