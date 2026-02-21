using Challenge.Abstractions;

namespace Challenge.Models;

internal class ApprovalWorkflow : IPrototype<ApprovalWorkflow>
{
    public List<string> Approvers { get; set; } = [];
    public int RequiredApprovals { get; set; }
    public int TimeoutDays { get; set; }

    public ApprovalWorkflow Clone()
    {
        return (ApprovalWorkflow)this.MemberwiseClone();
    }

    public ApprovalWorkflow DeepClone()
    {
        var clone = (ApprovalWorkflow)this.MemberwiseClone();
        
        clone.Approvers = [.. this.Approvers];
        return clone;
    }
}
