using System.Collections.Generic;
using MBW.Client.SslLabsLib.Objects;

namespace MBW.Client.SslLabsLib.Response;

internal class ErrorsResponse
{
    public List<Error>? Errors { get; set; }
}