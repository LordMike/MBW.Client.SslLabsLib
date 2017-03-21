using System;
using System.Collections.Generic;

namespace MBW.Client.SslLabsLib.Response;

public class Info : SsllabsResponseBase
{
    /// <summary>
    /// SSL Labs software version as a string (e.g., "1.11.14")
    /// </summary>
    public string EngineVersion { get; set; }

    /// <summary>
    /// Rating criteria version as a string (e.g., "2009f")
    /// </summary>
    public string CriteriaVersion { get; set; }

    /// <summary>
    /// The maximum number of concurrent assessments the client is allowed to initiate.
    /// </summary>
    public int MaxAssessments { get; set; }

    /// <summary>
    /// The number of ongoing assessments submitted by this client.
    /// </summary>
    public int CurrentAssessments { get; set; }

    /// <summary>
    /// The cool-off period after each new assessment; you're not allowed to submit a new assessment before the cool-off expires, otherwise you'll get a 429.
    /// </summary>
    public TimeSpan NewAssessmentCoolOff { get; set; }

    /// <summary>
    /// A list of messages (strings). Messages can be public (sent to everyone) and private (sent only to the invoking client). Private messages are prefixed with "[Private]".
    /// </summary>
    public List<string> Messages { get; set; }
}