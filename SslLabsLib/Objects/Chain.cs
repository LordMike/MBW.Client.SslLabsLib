using System.Collections.Generic;
using SslLabsLib.Enums;

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
        public ChainIssues Issues { get; set; }
    }
}