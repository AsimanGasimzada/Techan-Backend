using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class Language : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? ImagePath { get; set; }
}
