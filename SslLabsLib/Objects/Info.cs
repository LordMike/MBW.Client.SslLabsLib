using System.Collections.Generic;
using Newtonsoft.Json;

namespace SslLabsLib.Objects
{
    public class Info
    {
        /// <summary>
        /// SSL Labs software version as a string (e.g., "1.11.14")
        /// </summary>
        [JsonProperty("version")]
        public string EngineVersion { get; set; }

        /// <summary>
        /// Rating criteria version as a string (e.g., "2009f")
        /// </summary>
        [JsonProperty("criteriaVersion")]
        public string CriteriaVersion { get; set; }

        /// <summary>
        /// The maximum number of concurrent assessments the client is allowed to initiate.
        /// </summary>
        [JsonProperty("maxAssessments")]
        public int MaxAssessments { get; set; }

        /// <summary>
        /// The number of ongoing assessments submitted by this client.
        /// </summary>
        [JsonProperty("currentAssessments")]
        public int CurrentAssessments { get; set; }

        /// <summary>
        /// A list of messages (strings). Messages can be public (sent to everyone) and private (sent only to the invoking client). Private messages are prefixed with "[Private]".
        /// </summary>
        [JsonProperty("messages")]
        public List<string> Messages { get; set; }

        public Info()
        {
            Messages = new List<string>();
        }
    }
}