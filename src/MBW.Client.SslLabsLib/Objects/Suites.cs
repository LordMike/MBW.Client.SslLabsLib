using System.Collections.Generic;

namespace MBW.Client.SslLabsLib.Objects;

public class Suites
{
    /// <summary>
    /// List of suites used
    /// </summary>
    public List<Suite> List { get; set; }

    /// <summary>
    /// True if the server actively selects cipher suites; if false, we were not able to determine if the server has a preference
    /// </summary>
    public bool Preference { get; set; }

    public Suites()
    {
        List = new List<Suite>();
    }
}