using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MBW.Client.SslLabsLib.Serializer.Internals;

internal class UnixDateTimeConverter : JsonConverter<DateTime>
{
    public static UnixDateTimeConverter Instance { get; } = new();

    private UnixDateTimeConverter()
    {
    }

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).UtcDateTime;

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(((DateTimeOffset)value).ToUnixTimeMilliseconds());
    }
}