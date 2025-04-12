using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class Brand : BaseAuditableEntity
{
    public string ImagePath { get; set; } = null!;
    public List<BrandDetail> BrandDetails { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
}
