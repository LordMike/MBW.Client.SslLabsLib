using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MBW.Client.SslLabsLib.Serializer.Internals;

namespace MBW.Client.SslLabsLib.Serializer;

public class SystemTextJsonSsllabsSerializer : ISsllabsSerializer
{
    public static SystemTextJsonSsllabsSerializer Instance { get; } = new();

    public JsonSerializerOptions Options { get; }

    private SystemTextJsonSsllabsSerializer()
    {
        Options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = SsllabsNamingPolicy.Instance,
            Converters =
            {
                TimespanConverter.Instance,
                UnixDateTimeConverter.Instance,
                IPAddressConverter.Instance,
                new JsonStringEnumConverter(allowIntegerValues: true)
            }
            // TypeInfoResolver = null,
            // AllowTrailingCommas = false,
            // DefaultBufferSize = 0,
            // Encoder = null,
            // DictionaryKeyPolicy = null,
            // DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            // NumberHandling = JsonNumberHandling.Strict,
            // IgnoreReadOnlyProperties = false,
            // IgnoreReadOnlyFields = false,
            // IncludeFields = false,
            // MaxDepth = 0,
            // PropertyNameCaseInsensitive = false,
            // ReadCommentHandling = JsonCommentHandling.Disallow,
            // UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
            // WriteIndented = false,
            // ReferenceHandler = null
        };
    }

    public async ValueTask<object> Deserialize(Stream source, Type type)
    {
        try
        {
            return await JsonSerializer.DeserializeAsync(source, type, Options);
        }
        catch (Exception e)
        {
            if (!(source is MemoryStream asMemoryStream))
                throw;

            string tmp = Encoding.UTF8.GetString(asMemoryStream.ToArray());
            throw new Exception("Unable to deserialize json as " + type.FullName + ":" + Environment.NewLine + tmp, e);
        }
    }
}