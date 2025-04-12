using Techan.Business.Services.Abstractions.Generic;

namespace Techan.Business.Services.Abstractions;
public interface IBrandService:IGetServiceWithLanguage<BrandGetDto>,IModifyService<BrandCreateDto,BrandUpdateDto>
{
}
