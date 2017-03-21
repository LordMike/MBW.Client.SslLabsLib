namespace MBW.Client.SslLabsLib.Objects;

public class Trust
{
    /// <summary>
    /// This field shows the Trust store being used (eg. "Mozilla")
    /// </summary>
    public string RootStore { get; set; }

    /// <summary>
    /// True if trusted against above rootStore
    /// </summary>
    public bool IsTrusted { get; set; }

    /// <summary>
    /// Shows the error message if any, Null otherwise.
    /// </summary>
    public string? TrustErrorMessage { get; set; }
}