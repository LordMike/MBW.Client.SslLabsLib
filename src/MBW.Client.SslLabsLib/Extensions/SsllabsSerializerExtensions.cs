using System.IO;
using System.Threading.Tasks;
using MBW.Client.SslLabsLib.Serializer;

namespace MBW.Client.SslLabsLib.Extensions;

public static class SsllabsSerializerExtensions
{
    public static async ValueTask<T> Deserialize<T>(this ISsllabsSerializer serializer, Stream source) => (T)await serializer.Deserialize(source, typeof(T));
}