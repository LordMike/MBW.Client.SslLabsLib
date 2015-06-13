namespace SslLabsLib.Objects
{
    public class Key
    {
        /// <summary>
        /// Key size, e.g., 1024 or 2048 for RSA and DSA, or 256 bits for EC.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Key algorithm; possible values: RSA, DSA, and EC.
        /// </summary>
        public string Alg { get; set; }

        /// <summary>
        /// 0 if key is insecure, null otherwise
        /// </summary>
        public int? Q { get; set; }
        
        /// <summary>
        /// True if we suspect that the key was generated using a weak random number generator (detected via a blacklist database)
        /// </summary>
        public bool DebianFlaw { get; set; }

        /// <summary>
        /// Key size expressed in RSA bits.
        /// </summary>
        public int Strength { get; set; }
    }
}