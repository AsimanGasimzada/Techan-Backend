
namespace Techan.Business.Dtos;
public record BrandGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }= null!;
    public string Description { get; set; }= null!;
    public string ImagePath { get; set; }=null!;
}