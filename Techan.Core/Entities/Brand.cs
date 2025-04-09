using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class Brand : BaseAuditableEntity
{
    public ICollection<BrandDetail> BrandDetails { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
}
