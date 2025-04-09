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

    public Task<bool> CreateAsync(ProductCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<ProductGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<ProductUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
