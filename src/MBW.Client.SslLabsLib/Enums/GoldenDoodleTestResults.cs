namespace MBW.Client.SslLabsLib.Enums;

/// <summary>
/// Represents the results of the GOLDENDOODLE test.
/// </summary>
public enum GoldenDoodleTestResults
{
    TestFailed = -1,
    Unknown = 0,
    NotVulnerable = 1,
    Vulnerable = 4,
    VulnerableAndExploitable = 5
}