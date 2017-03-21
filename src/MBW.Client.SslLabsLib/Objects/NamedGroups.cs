using System.Collections.Generic;

namespace MBW.Client.SslLabsLib.Objects;

public class NamedGroups
{
    public List<NamedGroup> List { get; set; }

    /// <summary>
    /// True if the server has preferred curves that it uses first
    /// </summary>
    public bool Preference { get; set; }
}