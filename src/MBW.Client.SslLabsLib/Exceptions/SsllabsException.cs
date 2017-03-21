using System;
using System.Runtime.Serialization;

namespace MBW.Client.SslLabsLib.Exceptions;

public class SsllabsException : Exception
{
    public string Method { get; }

    public SsllabsException(string method)
    {
        Method = method;
    }

    protected SsllabsException(string method, SerializationInfo info, StreamingContext context) : base(info, context)
    {
        Method = method;
    }

    public SsllabsException(string method, string message) : base(message)
    {
        Method = method;
    }

    public SsllabsException(string method, string message, Exception innerException) : base(message, innerException)
    {
        Method = method;
    }
}