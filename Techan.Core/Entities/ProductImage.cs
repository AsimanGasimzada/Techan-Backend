using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class ProductImage : BaseEntity
{
    public string Path { get; set; } = null!;
    public bool IsMain { get; set; } = false;
    public bool IsHover { get; set; } = false;
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
