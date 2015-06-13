using System.Collections.Generic;

namespace SslLabsLib.Objects
{
    public class Chain
    {
        /// <summary>
        /// Certificates in the chain
        /// </summary>
        public List<ChainCertificate> Certs { get; set; }

        /// <summary>
        /// The issues with this chain
        /// </summary>
        public int Issues { get; set; }
    }
}