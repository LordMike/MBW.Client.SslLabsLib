using System.IO;
using System.Text;
using System.Threading.Tasks;
using MBW.Client.SslLabsLib.Extensions;
using MBW.Client.SslLabsLib.Serializer;

namespace MBW.Client.SslLabsLib.Tests.Helpers;

public static class SerializerExtensions
{
    public static ValueTask<T> Deserialize<T>(this ISsllabsSerializer serializer, string json)
    {
        var bytes = Encoding.UTF8.GetBytes(json);
        using var ms = new MemoryStream(bytes);

        return serializer.Deserialize<T>(ms);
    }
}