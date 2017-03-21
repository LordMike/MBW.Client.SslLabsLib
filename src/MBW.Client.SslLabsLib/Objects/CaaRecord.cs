namespace MBW.Client.SslLabsLib.Objects;

public class CaaRecord
{
    /// <summary>
    /// A property of the CAA record
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// Corresponding value of a CAA property
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Corresponding flags of CAA property (8 bit)
    /// </summary>
    public int Flags { get; set; }
}