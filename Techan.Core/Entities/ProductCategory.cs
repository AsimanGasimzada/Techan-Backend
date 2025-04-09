using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class ProductCategory : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; } 
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
