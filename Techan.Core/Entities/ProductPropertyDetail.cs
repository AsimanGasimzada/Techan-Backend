using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class ProductPropertyDetail : BaseEntity
{
    public string Value { get; set; } = null!;
    public int ProductPropertyId { get; set; }
    public ProductProperty? ProductProperty { get; set; }
    public int LanguageId{ get; set; }
    public Language? Language{ get; set; }
}
