using System.Text.Json;

namespace MBW.Client.SslLabsLib.Serializer.Internals;

internal sealed class SsllabsNamingPolicy : JsonNamingPolicy
{
    public static SsllabsNamingPolicy Instance { get; } = new();

    private SsllabsNamingPolicy()
    {
    }

    public override string ConvertName(string name)
    {
        char[] newName = name.ToCharArray();

        // Change first char to be lowercase
        newName[0] = char.ToLowerInvariant(newName[0]);

        return new string(newName);
    }
}