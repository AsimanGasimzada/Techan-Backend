using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;
public class Product : BaseAuditableEntity
{
    public decimal Price { get; set; }
    public decimal? DiscountedPrice { get; set; }
    //public decimal? PurchasePrice { get; set; }
    public int Count { get; set; }
    public bool IsActive { get; set; } = true;
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; } = [];
    public ICollection<ProductDetail> ProductDetails { get; set; } = [];
    public ICollection<ProductImage> ProductImages { get; set; } = [];
    public ICollection<ProductProperty> ProductProperties  { get; set; } = [];
}
