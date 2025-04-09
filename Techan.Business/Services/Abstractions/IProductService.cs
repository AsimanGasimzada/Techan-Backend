using Techan.Business.Services.Abstractions.Generic;

namespace Techan.Business.Services.Abstractions;
public interface IProductService : IModifyService<ProductCreateDto, ProductUpdateDto>, IGetServiceWithLanguage<ProductGetDto>
{
}
