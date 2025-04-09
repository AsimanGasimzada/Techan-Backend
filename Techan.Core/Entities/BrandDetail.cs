using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class BrandDetail : BaseEntity
{
    public string Name { get; set; }=null!;
    public string Desciption { get; set; }=null!;
    public string ImagePath { get; set; }= null!;
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    public Language? Language{ get; set; }
    public int LanguageId{ get; set; }
}