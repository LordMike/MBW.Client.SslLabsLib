using System;
using System.Collections.Generic;
using SslLabsLib.Enums;

namespace SslLabsLib.Objects
{
    public class Cert
    {
        /// <summary>
        /// Certificate subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Common names extracted from the subject
        /// </summary>
        public List<string> CommonNames { get; set; }

        /// <summary>
        /// Alternative names
        /// </summary>
        public List<string> AltNames { get; set; }

        /// <summary>
        /// Timestamp before which the certificate is not valid
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
        /// Timestamp after which the certificate is not valid
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
        /// Issuer name
        /// </summary>
        public string IssuerLabel { get; set; }

        /// <summary>
        /// Certificate signature algorithm
        /// </summary>
        public string SigAlg { get; set; }

        /// <summary>
        /// A number that represents revocation information present in the certificate:
        /// </summary>
        public RevocationInfo RevocationInfo { get; set; }

        /// <summary>
        /// CRL URIs extracted from the certificate
        /// </summary>
        //[Json.JsonArrayName = "crlURIs")]
        public List<string> CrlURIs { get; set; }

        /// <summary>
        /// OCSP URIs extracted from the certificate
        /// </summary>
        //[JsonProperty(Name = "ocspURIs")]
        public List<string> OcspUrIs { get; set; }

        /// <summary>
        /// A number that describes the revocation status of the certificate:
        /// </summary>
        public RevocationStatus RevocationStatus { get; set; }

        /// <summary>
        /// Same as revocationStatus, but only for the CRL information (if any).
        /// </summary>
        public RevocationStatus CrlRevocationStatus { get; set; }

        /// <summary>
        /// Same as revocationStatus, but only for the OCSP information (if any).
        /// </summary>
        public RevocationStatus OcspRevocationStatus { get; set; }

        /// <summary>
        /// Server Gated Cryptography support; integer:
        /// </summary>
        //[JsonProperty(Name = "sgc")]
        public ServerGatedCryptographySupport ServerGatedCryptography { get; set; }

        /// <summary>
        /// E for Extended Validation certificates; may be null if unable to determine
        /// </summary>
        public string ValidationType { get; set; }

        /// <summary>
        /// List of certificate issues, one bit per issue:
        /// </summary>
        public CertificateIssues Issues { get; set; }

        /// <summary>
        /// True if the certificate contains an embedded SCT; false otherwise.
        /// </summary> 
        //[JsonProperty(Name = "sct")]
        public bool ContainsSignedCertificateTimestamp { get; set; }
    }
}