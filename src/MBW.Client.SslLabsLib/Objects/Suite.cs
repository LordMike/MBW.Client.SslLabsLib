namespace MBW.Client.SslLabsLib.Objects;

public class Suite
{
    /// <summary>
    /// Suite RFC ID (e.g., 5)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Suite name (e.g., TLS_RSA_WITH_RC4_128_SHA)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Suite strength (e.g., 128)
    /// </summary>
    public int CipherStrength { get; set; }

    /// <summary>
    /// Key exchange type (e.g., ECDH)
    /// </summary>
    public string KxType { get; set; }

    /// <summary>
    /// Key exchange strength, in RSA-equivalent bits
    /// </summary>
    public int KxStrength { get; set; }

    /// <summary>
    /// DH params, p component
    /// </summary>
    public int DhP { get; set; }

    /// <summary>
    /// DH params, g component
    /// </summary>
    public int DhG { get; set; }

    /// <summary>
    /// DH params, Ys component
    /// </summary>
    public int DhYs { get; set; }

    /// <summary>
    /// EC bits
    /// </summary>
    public int NamedGroupBits { get; set; }

    /// <summary>
    /// EC curve ID
    /// </summary>
    public int NamedGroupId { get; set; }

    /// <summary>
    /// EC curve name
    /// </summary>
    public string NamedGroupName { get; set; }

    /// <summary>
    /// Flag for suite insecure or weak. Not present if suite is strong or good
    /// </summary>
    public int? Q { get; set; }
}