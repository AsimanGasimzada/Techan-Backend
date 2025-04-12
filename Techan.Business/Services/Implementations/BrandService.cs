using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Techan.Business.Exceptions;
using Techan.Business.ExternalServices.Abstractions;
using Techan.Business.Services.Abstractions;
using Techan.Core.Enums;

namespace Techan.Business.Services.Implementations;
internal class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    public BrandService(IBrandRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<ResultDto> CreateAsync(BrandCreateDto dto)
    {
        var brand = _mapper.Map<Brand>(dto);

        string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
        brand.ImagePath = imagePath;

        await _repository.CreateAsync(brand);
        await _repository.SaveChangesAsync();

        return new();
    }

    public async Task<ResultDto> DeleteAsync(int id)
    {
        var brand = await _getBrandById(id);

        _repository.Delete(brand);
        await _repository.SaveChangesAsync();

        return new();
    }

    public async Task<ResultDto<List<BrandGetDto>>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        var brands = await _repository.GetAll(include: _getIncludeFunc(language)).ToListAsync();

        var dtos = _mapper.Map<List<BrandGetDto>>(brands);

        return new(dtos);
    }


    public async Task<ResultDto<BrandGetDto>> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        var brand = await _getBrandById(id, language);

        var dto = _mapper.Map<BrandGetDto>(brand);

        return new(dto);
    }

    public async Task<ResultDto<BrandUpdateDto>> GetUpdatedDtoAsync(int id)
    {
        var brand = await _getBrandById(id);

        var dto = _mapper.Map<BrandUpdateDto>(brand);

        return new(dto);
    }

    public async Task<ResultDto> UpdateAsync(BrandUpdateDto dto)
    {
        var existBrand = await _getBrandById(dto.Id);

        existBrand = _mapper.Map(dto, existBrand);

        if (dto.Image is { })
        {
            await _cloudinaryService.FileDeleteAsync(existBrand.ImagePath);
            existBrand.ImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
        }

        _repository.Update(existBrand);
        await _repository.SaveChangesAsync();

        return new();
    }

    private async Task<Brand> _getBrandById(int id, Languages? language = null)
    {
        Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>? func = null;

        if (language is { })
            func = _getIncludeFunc(language.Value);

        var brand = await _repository.GetAsync(id, include: func);

        if (brand is null)
            throw new NotFoundException($"Brand is not found");

        return brand;
    }
    private static Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>> _getIncludeFunc(Languages language)
    {
        return x => x.Include(x => x.BrandDetails.Where(x => x.LanguageId == (int)language));
    }

}
