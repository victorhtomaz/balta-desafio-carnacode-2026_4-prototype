using Challenge.Abstractions;

namespace Challenge.Models;

internal class DocumentStyle : IPrototype<DocumentStyle>
{
    public string FontFamily { get; set; } = string.Empty;
    public int FontSize { get; set; }
    public string HeaderColor { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public Margins PageMargins { get; set; } = default!;

    public DocumentStyle Clone()
    {
        return (DocumentStyle)this.MemberwiseClone();
    }

    public DocumentStyle DeepClone()
    {
        var clone = (DocumentStyle)MemberwiseClone();

        clone.PageMargins = new Margins
        {
            Top = this.PageMargins.Top,
            Bottom = this.PageMargins.Bottom,
            Left = this.PageMargins.Left,
            Right = this.PageMargins.Right
        };

        return clone;
    }
}
