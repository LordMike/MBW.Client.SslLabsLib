using System;
using Newtonsoft.Json;
using SslLabsLib.Enums;

namespace SslLabsLib.Objects
{
    public class ChainCertificate
    {
        /// <summary>
        /// Certificate subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Certificate label (user-friendly name)
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Certificate start time
        /// </summary>
        public long NotBefore { get; set; }

        public DateTime NotBeforeDateTime
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(NotBefore);
            }
        }

        /// <summary>
        /// Certificate end time
        /// </summary>
        public long NotAfter { get; set; }

        public DateTime NotAfterDateTime
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(NotAfter);
            }
        }

        /// <summary>
        /// Issuer subject
        /// </summary>
        public string IssuerSubject { get; set; }

        /// <summary>
        /// Issuer label (user-friendly name)
        /// </summary>
        public string IssuerLabel { get; set; }

        /// <summary>
        /// Signature algorithm
        /// </summary>
        [JsonProperty("sigAlg")]
        public string SignatureAlgorithm { get; set; }

        /// <summary>
        /// Issues with this certificate
        /// </summary>
        public ChainCertificateIssues Issues { get; set; }

        /// <summary>
        /// Key algorithm
        /// </summary>
        [JsonProperty("keyAlg")]
        public string KeyAlgorithm { get; set; }

        /// <summary>
        /// Key size, in bits appopriate for the key algorithm
        /// </summary>
        public int KeySize { get; set; }

        /// <summary>
        /// Key strength, in equivalent RSA bits
        /// </summary>
        public int KeyStrength { get; set; }

        /// <summary>
        /// Revocation status of the certificate
        /// </summary>
        public RevocationStatus RevocationStatus { get; set; }

        /// <summary>
        /// Revocation status of the certificate, but only for the CRL information (if any)
        /// </summary>
        public RevocationStatus CrlRevocationStatus { get; set; }

        /// <summary>
        /// Revocation status of the certificate, but only for the OCSP information (if any)
        /// </summary>
        public RevocationStatus OcspRevocationStatus { get; set; }

        /// <summary>
        /// PEM-encoded certificate data
        /// </summary>
        public string Raw { get; set; }
    }
}