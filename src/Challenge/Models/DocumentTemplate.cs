using Challenge.Abstractions;

namespace Challenge.Models;

internal class DocumentTemplate : IPrototype<DocumentTemplate>
{
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public List<Section> Sections { get; set; } = [];
    public DocumentStyle Style { get; set; } = default!;
    public List<string> RequiredFields { get; set; } = [];
    public Dictionary<string, string> Metadata { get; set; } = [];
    public ApprovalWorkflow Workflow { get; set; } = default!;
    public List<string> Tags { get; set; } = [];

    public DocumentTemplate Clone()
    {
        return (DocumentTemplate)this.MemberwiseClone();
    }

    public DocumentTemplate DeepClone()
    {
        var copy = (DocumentTemplate)this.MemberwiseClone();

        copy.Sections = [.. this.Sections];

        copy.Style = Style.DeepClone();

        copy.RequiredFields = [.. this.RequiredFields];

        copy.Metadata = new Dictionary<string, string>(this.Metadata);

        copy.Workflow = Workflow.DeepClone();

        copy.Tags = [.. this.Tags];

        return copy;
    }
}
