namespace MBW.Client.SslLabsLib.Objects;

public class Simulation
{
    /// <summary>
    /// The client used
    /// </summary>
    public SimClient Client { get; set; }

    /// <summary>
    /// Zero if handshake was successful, 1 if it was not.
    /// </summary>
    public int ErrorCode { get; set; }

    /// <summary>
    /// Error message if simulation has failed.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Always 1 with the current implementation.
    /// </summary>
    public int Attempts { get; set; }

    /// <summary>
    /// Id of the certificate chain.
    /// </summary>
    public string CertChainId { get; set; }

    /// <summary>
    /// Negotiated protocol ID.
    /// </summary>
    public int ProtocolId { get; set; }

    /// <summary>
    /// Negotiated suite ID.
    /// </summary>
    public int SuiteId { get; set; }

    /// <summary>
    /// Negotiated suite Name.
    /// </summary>
    public string SuiteName { get; set; }

    /// <summary>
    /// Negotiated key exchange, for example "ECDH".
    /// </summary>
    public string KxType { get; set; }

    /// <summary>
    /// Key exchange strength, in RSA-equivalent bits
    /// </summary>
    public int KxStrength { get; set; }

    /// <summary>
    /// Strength of DH params (e.g., 1024)
    /// </summary>
    public int DhBits { get; set; }

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
    /// When ECDHE is negotiated, length of EC parameters.
    /// </summary>
    public int? NamedGroupBits { get; set; }

    /// <summary>
    /// When ECDHE is negotiated, EC curve ID.
    /// </summary>
    public int? NamedGroupId { get; set; }

    /// <summary>
    /// When ECDHE is negotiated, EC curve nanme (e.g., "secp256r1").
    /// </summary>
    public string? NamedGroupName { get; set; }

    /// <summary>
    /// Connection certificate key algorithsm (e.g., "RSA").
    /// </summary>
    public string KeyAlg { get; set; }

    /// <summary>
    /// Connection certificate key size (e.g., 2048).
    /// </summary>
    public int KeySize { get; set; }

    /// <summary>
    /// Connection certificate signature algorithm (e.g, "SHA256withRSA").
    /// </summary>
    public string SigAlg { get; set; }
}