using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MBW.Client.SslLabsLib.Serializer;

namespace MBW.Client.SslLabsLib.Extensions;

public static class HttpClientExtensions
{
    public static async ValueTask<T> Deserialize<T>(this HttpResponseMessage message, ISsllabsSerializer serializer)
    {
        using Stream stream = await message.Content.ReadAsStreamAsync();
        return await serializer.Deserialize<T>(stream);
    }
}