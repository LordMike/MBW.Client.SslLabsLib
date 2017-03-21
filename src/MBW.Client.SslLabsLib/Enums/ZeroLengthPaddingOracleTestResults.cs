namespace MBW.Client.SslLabsLib.Enums;

/// <summary>
/// Represents the results of the 0-Length Padding Oracle (CVE-2019-1559) test.
/// </summary>
public enum ZeroLengthPaddingOracleTestResults
{
    TestFailed = -1,
    Unknown = 0,
    NotVulnerable = 1,
    Vulnerable = 6,
    VulnerableAndExploitable = 7
}