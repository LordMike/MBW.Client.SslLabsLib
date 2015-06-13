namespace SslLabsLib.Objects
{
    public class Protocol
    {
        /// <summary>
        /// Protocol version number, e.g. 0x0303 for TLS 1.2
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Protocol name, i.e. SSL or TLS.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Protocol version, e.g. 1.2 (for TLS)
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Some servers have SSLv2 protocol enabled, but with all SSLv2 cipher suites disabled. In that case, this field is set to true.
        /// </summary>
        public string V2SuitesDisabled { get; set; }

        /// <summary>
        /// 0 if the protocol is insecure, null otherwise
        /// </summary>
        public int? Q { get; set; }
    }
}