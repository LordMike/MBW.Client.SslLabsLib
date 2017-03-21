using System;
using System.Collections.Generic;
using MBW.Client.SslLabsLib.Enums;

namespace MBW.Client.SslLabsLib.Objects;

public class Cert
{
    /// <summary>
    /// Certificate Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Certificate subject
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Certificate serial number (hex-encoded)
    /// </summary>
    public string SerialNumber { get; set; }

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
    public DateTime NotBefore { get; set; }

    /// <summary>
    /// Timestamp after which the certificate is not valid
    /// </summary>
    public DateTime NotAfter { get; set; }

    /// <summary>
    /// Issuer subject
    /// </summary>
    public string IssuerSubject { get; set; }

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
    public List<string> CrlUrIs { get; set; }

    /// <summary>
    /// OCSP URIs extracted from the certificate
    /// </summary>
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
    /// CAA Policy, Null if CAA is not supported
    /// </summary>
    public CaaPolicy? CaaPolicy { get; set; }

    /// <summary>
    /// Describes the must staple feature extension status:
    /// </summary>
    public bool MustStaple { get; set; }

    /// <summary>
    /// Server Gated Cryptography support
    /// </summary>
    public ServerGatedCryptographySupport Sgc { get; set; }

    /// <summary>
    /// E for Extended Validation certificates; may be null if unable to determine
    /// </summary>
    public string? ValidationType { get; set; }

    /// <summary>
    /// List of certificate issues, one bit per issue:
    /// </summary>
    public CertificateIssues Issues { get; set; }

    /// <summary>
    /// True if the certificate contains an embedded SCT; false otherwise.
    /// </summary> 
    public bool Sct { get; set; }

    /// <summary>
    /// SHA1 hash of certificate
    /// </summary>
    public string Sha1Hash { get; set; }

    /// <summary>
    /// SHA256 hash of certificate
    /// </summary>
    public string Sha256Hash { get; set; }

    /// <summary>
    /// SHA256 hash of certificate for HPKP pinning
    /// </summary>
    public string PinSha256 { get; set; }

    /// <summary>
    /// Key algorithm.
    /// </summary>
    public string KeyAlg { get; set; }

    /// <summary>
    /// Key size, in bits appropriate for the key algorithm.
    /// </summary>
    public int KeySize { get; set; }

    /// <summary>
    /// Key strength, in equivalent RSA bits
    /// </summary>
    public int KeyStrength { get; set; }

    /// <summary>
    /// True if debian flaw is found, else false
    /// </summary>
    public bool KeyKnownDebianInsecure { get; set; }

    /// <summary>
    /// PEM-encoded certificate
    /// </summary>
    public string Raw { get; set; }
}