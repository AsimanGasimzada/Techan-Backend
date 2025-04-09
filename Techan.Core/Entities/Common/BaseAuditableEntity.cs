namespace Techan.Core.Entities.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public int ViewCount { get; set; } = 0;
}