using SslLabsLib.Enums;

namespace SslLabsLib.Objects
{
    public class Endpoint
    {
        /// <summary>
        /// Endpoint IP address, in IPv4 or IPv6 format.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Server name retrieved via reverse DNS
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Assessment status message
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Code of the operation currently in progress
        /// </summary>
        public string StatusDetails { get; set; }

        /// <summary>
        /// Description of the operation currently in progress
        /// </summary>
        public string StatusDetailsMessage { get; set; }

        /// <summary>
        /// Possible values: A+, A-, A-F, T (no trust) and M (certificate name mismatch)
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// Possible values: A+, A-, A-F and M (certificate name mismatch), if trust issues are ignored
        /// </summary>
        public string GradeTrustIgnored { get; set; }

        /// <summary>
        /// If this endpoint has warnings that might affect the score (e.g., get A- instead of A).
        /// </summary>
        public bool HasWarnings { get; set; }

        /// <summary>
        /// This flag will be raised when an exceptional configuration is encountered. The SSL Labs test will give such sites an A+.
        /// </summary>
        public bool IsExceptional { get; set; }

        /// <summary>
        /// Assessment progress, which is a value from 0 to 100, and -1 if the assessment has not yet started
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Assessment duration, in milliseconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Estimated time, in seconds, until the completion of the assessment
        /// </summary>
        public int Eta { get; set; }

        /// <summary>
        /// Indicates domain name delegation with and without the www prefix
        /// </summary>
        public Delegation Delegation { get; set; }

        /// <summary>
        /// Details for an Endpoint. It's not present by default, but can be enabled by using the AnalyzeOptions.ReturnAll paramerer to the analyze API call.
        /// </summary>
        public EndpointDetails Details { get; set; }
    }
}