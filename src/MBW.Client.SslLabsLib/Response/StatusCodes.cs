using System.Collections.Generic;

namespace MBW.Client.SslLabsLib.Response;

public class StatusCodes : SsllabsResponseBase
{
    /// <summary>
    /// A map containing all status details codes and the corresponding English translations. 
    /// Please note that, once in use, the codes will not change, whereas the translations may change at any time.
    /// </summary>
    public Dictionary<string, string> StatusDetails { get; set; }
}