namespace SslLabsLib.Objects
{
    public class Client
    {
        /// <summary>
        /// Unique client ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// True if the browser is considered representative of modern browsers, false otherwise. 
        /// This flag does not correlate to client's capabilities, but is used by SSL Labs to determine if a particular configuration is effective. 
        /// For example, to track Forward Secrecy support, we mark several representative browsers as "modern" and then test to see if they succeed in negotiating a FS suite. 
        /// Just as an illustration, modern browsers are currently Chrome, Firefox (not ESR versions), IE/Win7, and Safari.
        /// </summary>
        public bool IsReference { get; set; }

        /// <summary>
        /// Platform
        /// </summary>
        public string Platform { get; set; }
    }
}