namespace MBW.Client.SslLabsLib.Enums;

/// <summary>
/// Represents the results of the Zombie POODLE test.
/// </summary>
public enum ZombiePoodleTestResults
{
    TestFailed = -1,
    Unknown = 0,
    NotVulnerable = 1,
    Vulnerable = 2,
    VulnerableAndExploitable = 3
}