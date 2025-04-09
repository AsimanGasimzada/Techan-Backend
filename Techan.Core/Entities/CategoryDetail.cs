using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class CategoryDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}