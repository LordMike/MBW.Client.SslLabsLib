using System;

namespace MBW.Client.SslLabsLib.Enums;

[Flags]
public enum RevocationInfo
{
    /// <summary>
    /// CRL information available
    /// </summary>
    CRLAvailable = 1,

    /// <summary>
    /// OCSP information available
    /// </summary>
    OCSPAvailable = 2
}