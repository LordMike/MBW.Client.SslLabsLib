using System;
using System.IO;
using System.Threading.Tasks;

namespace MBW.Client.SslLabsLib.Serializer;

public interface ISsllabsSerializer
{
    ValueTask<object> Deserialize(Stream source, Type type);
}