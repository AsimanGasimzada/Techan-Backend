using Techan.Business.Services.Abstractions;
using Techan.Core.Enums;

namespace Techan.Business.Services.Implementations;
internal class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<ResultDto> CreateAsync(ProductCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto<List<ProductGetDto>>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto<ProductGetDto>> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto<ProductUpdateDto>> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto> UpdateAsync(ProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
