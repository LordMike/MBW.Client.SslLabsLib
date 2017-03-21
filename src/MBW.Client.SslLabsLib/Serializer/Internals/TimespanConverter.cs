using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MBW.Client.SslLabsLib.Serializer.Internals;

internal class TimespanConverter : JsonConverter<TimeSpan>
{
    public static TimespanConverter Instance { get; } = new();

    private TimespanConverter()
    {
    }

    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        TimeSpan.FromMilliseconds(reader.GetInt64());
    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) => writer.WriteNumberValue((long)value.TotalMilliseconds);
}