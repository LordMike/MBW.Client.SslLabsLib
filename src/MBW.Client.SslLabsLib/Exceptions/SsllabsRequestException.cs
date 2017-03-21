using System;
using System.Collections.Generic;
using System.Text;
using MBW.Client.SslLabsLib.Objects;
using MBW.Client.SslLabsLib.Response;

namespace MBW.Client.SslLabsLib.Exceptions;

public class SsllabsRequestException : SsllabsException
{
    public IReadOnlyList<Error> Errors { get; }

    private SsllabsRequestException(string method, string message, List<Error> errors) : base(method, message)
    {
        Errors = errors;
    }

    internal static SsllabsRequestException Create(string method, ErrorsResponse errors)
    {
        _ = errors.Errors ?? throw new ArgumentNullException(nameof(errors));

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("An error was reported by SSL Labs for the request made:");

        foreach (Error? error in errors.Errors)
        {
            sb.Append("- ")
                .Append(error.Message);

            if (error.Field != null)
                sb.Append(" (").Append(error.Field).Append(")");

            sb.AppendLine();
        }

        return new SsllabsRequestException(method, sb.ToString(), errors.Errors);
    }
}