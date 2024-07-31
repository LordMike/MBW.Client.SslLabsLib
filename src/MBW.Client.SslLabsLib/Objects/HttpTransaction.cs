using System.Collections.Generic;

namespace MBW.Client.SslLabsLib.Objects;

public class HttpTransaction
{
    /// <summary>
    /// Request URL
    /// </summary>
    public string RequestUrl { get; set; }

    /// <summary>
    /// Response status code
    /// </summary>
    public int? StatusCode { get; set; }

    /// <summary>
    /// The entire request line as a single field
    /// </summary>
    public string RequestLine { get; set; }

    /// <summary>
    /// An array of request HTTP headers
    /// </summary>
    public List<string> RequestHeaders { get; set; }

    /// <summary>
    /// The entire response line as a single field
    /// </summary>
    public string ResponseLine { get; set; }

    /// <summary>
    /// All response headers as a single field (useful if the headers are malformed)
    /// </summary>
    public List<string> ResponseHeadersRaw { get; set; }

    /// <summary>
    /// An array of response HTTP headers,
    /// </summary>
    public List<ResponseHeader> ResponseHeaders { get; set; }

    /// <summary>
    /// True if the server crashes when inspected by SSL Labs (in which case the full test is refused)
    /// </summary>
    public bool FragileServer { get; set; }
}