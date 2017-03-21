namespace MBW.Client.SslLabsLib.Objects;

public class NamedGroup
{
    /// <summary>
    /// Named curve ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Named curve name 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Named curve strength in EC bits
    /// </summary>
    public int Bits { get; set; }
}