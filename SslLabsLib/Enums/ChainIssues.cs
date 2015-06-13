using System;

namespace SslLabsLib.Enums
{
    [Flags]
    public enum ChainIssues
    {
        /// <summary>
        /// Unused
        /// </summary>
        Unused = 1,

        /// <summary>
        /// Incomplete chain (set only when we were able to build a chain by adding missing intermediate certificates from external sources)
        /// </summary>
        IncompleteChain = 2,

        /// <summary>
        /// Chain contains unrelated or duplicate certificates (i.e., certificates that are not part of the same chain)
        /// </summary>
        HasExcessCertficates = 4,

        /// <summary>
        /// The certificates form a chain (trusted or not), but the order is incorrect
        /// </summary>
        BadOrder = 8,

        /// <summary>
        /// Contains a self-signed root certificate (not set for self-signed leafs)
        /// </summary>
        SelfSignedRoot = 16,

        /// <summary>
        /// The certificates form a chain (if we added external certificates, bit 1 will be set), but we could not validate it. If the leaf was trusted, that means that we built a different chain we trusted.
        /// </summary>
        UnableToValidate = 32,

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
        Unused17 = 17,
        Unused18 = 18,
        Unused19 = 19,
        Unused20 = 20,
        Unused21 = 21,
        Unused22 = 22,
        Unused23 = 23,
        Unused24 = 24,
        Unused25 = 25,
        Unused26 = 26,
        Unused27 = 27,
        Unused28 = 28,
        Unused29 = 29,
        Unused30 = 30,
        Unused31 = 31,
    }
}