using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingBlocks.SharedKernel;

public abstract class Entity<TId> : IEntity<TId>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TId Id { get; set; } = default!;

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    protected void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}
