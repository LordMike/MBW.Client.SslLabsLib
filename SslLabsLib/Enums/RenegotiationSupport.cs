using System;

namespace SslLabsLib.Enums
{
    [Flags]
    public enum RenegotiationSupport
    {
        /// <summary>
        /// Insecure client-initiated renegotiation is supported
        /// </summary>
        InsecureClientInitiatedSupported = 1,

        /// <summary>
        /// Secure renegotiation is supported
        /// </summary>
        SecureSupported = 2,

        /// <summary>
        /// Secure client-initiated renegotiation is supported
        /// </summary>
        SecureClientInitiatedSupported = 4,

        /// <summary>
        /// The server requires secure renegotiation support
        /// </summary>
        ServerRequiresSecure = 8,

        // TODO: Remove this when Restsharp handles Flags
        Unused3 = 3,
        Unused5 = 5,
        Unused6 = 6,
        Unused7 = 7,
    }
}