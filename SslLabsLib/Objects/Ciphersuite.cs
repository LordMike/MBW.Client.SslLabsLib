using RestSharp.Deserializers;

namespace SslLabsLib.Objects
{
    public class Ciphersuite
    {
        /// <summary>
        /// Suite RFC ID (e.g., 5)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Suite name (e.g., TLS_RSA_WITH_RC4_128_SHA)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Suite strength (e.g., 128)
        /// </summary>
        public int CipherStrength { get; set; }

        /// <summary>
        /// ECDH bits
        /// </summary>
        public int EcdhBits { get; set; }

        /// <summary>
        /// ECDH RSA-equivalent strength
        /// </summary>
        public int EcdhStrength { get; set; }

        /// <summary>
        /// Strength of DH params (e.g., 1024)
        /// </summary>
        public string DhStrength { get; set; }

        /// <summary>
        /// DH params, p component
        /// </summary>
        [DeserializeAs(Name = "dhP")]
        public string DhP { get; set; }

        /// <summary>
        /// DH params, g component
        /// </summary>
        [DeserializeAs(Name = "dhG")]
        public string DhG { get; set; }

        /// <summary>
        /// DH params, Ys component
        /// </summary>
        [DeserializeAs(Name = "dhYs")]
        public string DhYs { get; set; }

        /// <summary>
        /// 0 if the suite is insecure, null otherwise
        /// </summary>
        public int? Q { get; set; }
    }
}