using MBW.Client.SslLabsLib.Enums;

namespace MBW.Client.SslLabsLib.Objects;

public class DrownHosts
{
    /// <summary>
    /// Ip address of server that shares same RSA-Key/hostname in its certificate
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    /// True if export cipher suites detected
    /// </summary>
    public bool Export { get; set; }

    /// <summary>
    /// Port number of the server
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// True if vulnerable OpenSSL version detected
    /// </summary>
    public bool Special { get; set; }

    /// <summary>
    /// True if SSL v2 is supported
    /// </summary>
    public string Sslv2 { get; set; }

    /// <summary>
    /// Drown host status:
    /// </summary>
    public DrownHostStatus Status { get; set; }
}