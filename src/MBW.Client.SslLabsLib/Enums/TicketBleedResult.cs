using System;

namespace MBW.Client.SslLabsLib.Enums;

public enum TicketBleedResult
{
    TestFailed = -1,
    Unknown = 0,

    /// <summary>
    /// Not vulnerable
    /// </summary>
    NotVulnerable = 1,

    /// <summary>
    /// Vulnerable and insecure
    /// </summary>
    Vulnerable = 2,

    /// <summary>
    /// Not vulnerable but a similar bug detected, see https://community.qualys.com/thread/17180-is-ticketbleed-cve-2016-9244-possible-in-a-non-f5-environment#comment-36958
    /// </summary>
    NotVulnerableButSimilarBugDetected = 3
}