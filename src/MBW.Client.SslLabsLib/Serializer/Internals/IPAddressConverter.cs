using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MBW.Client.SslLabsLib.Serializer.Internals;

internal class IPAddressConverter : JsonConverter<IPAddress>
{
    public static IPAddressConverter Instance { get; } = new();

    private IPAddressConverter()
    {
    }

    public override IPAddress Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        IPAddress.Parse(reader.GetString());

    public override void Write(Utf8JsonWriter writer, IPAddress value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString());
}