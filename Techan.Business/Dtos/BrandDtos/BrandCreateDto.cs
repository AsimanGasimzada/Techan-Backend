
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Techan.Business.Dtos;

public class BrandCreateDto : IDto
{
    public IFormFile Image { get; set; } = null!;
    public List<BrandDetailCreateDto> BrandDetails { get; set; } = [];
}
