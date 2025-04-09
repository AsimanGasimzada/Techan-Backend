using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class ProductProperty : BaseEntity
{
    public string Key { get; set; } = null!;
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public ICollection<ProductPropertyDetail> ProductPropertyDetails { get; set; } = [];
}
