using System.Collections.Generic;
using MBW.Client.SslLabsLib.Objects;

namespace MBW.Client.SslLabsLib.Response;

public class GetRootCertsRaw : SsllabsResponseBase
{
    public IList<RootCertificateDetails> Certificates { get; set; } = new List<RootCertificateDetails>();
}