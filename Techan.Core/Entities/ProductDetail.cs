using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class ProductDetail : BaseEntity
{
    public int ProductId { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Product? Product { get; set; }
    public Language? Language { get; set; }
}