using Challenge.Abstractions;

namespace Challenge.Models;

internal class Section : IPrototype<Section>
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsEditable { get; set; }
    public List<string> Placeholders { get; set; } = [];

    public Section Clone()
    {
        return (Section)this.MemberwiseClone();
    }

    public Section DeepClone()
    {
        var clone = (Section)this.MemberwiseClone();

        clone.Placeholders = [.. this.Placeholders];

        return clone;
    }
}
