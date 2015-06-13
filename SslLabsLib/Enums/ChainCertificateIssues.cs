using System;

namespace SslLabsLib.Enums
{
    [Flags]
    public enum ChainCertificateIssues
    {
        /// <summary>
        /// Certificate not yet valid
        /// </summary>
        NotYetValid = 1,

        /// <summary>
        /// Certificate expired
        /// </summary>
        Expired = 2,

        /// <summary>
        /// Weak key
        /// </summary>
        WeakKey = 4,

        /// <summary>
        /// Weak signature
        /// </summary>
        WeakSignature = 8,

        /// <summary>
        /// Blacklisted
        /// </summary>
        Blacklisted = 16,

        // TODO: Remove this when Restsharp handles Flags
        Unused3 = 3,
        Unused5 = 5,
        Unused6 = 6,
        Unused7 = 7,
        Unused9 = 9,
        Unused10 = 10,
        Unused11 = 11,
        Unused12 = 12,
        Unused13 = 13,
        Unused14 = 14,
        Unused15 = 15,
    }
}