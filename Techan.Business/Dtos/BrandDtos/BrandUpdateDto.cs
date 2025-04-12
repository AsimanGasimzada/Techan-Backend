
using Microsoft.AspNetCore.Http;

namespace Techan.Business.Dtos;

public record BrandUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? Image { get; set; }
    public List<BrandDetailUpdateDto> BrandDetails { get; set; } = [];
}
