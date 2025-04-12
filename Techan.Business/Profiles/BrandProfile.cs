namespace Techan.Business.Profiles;
internal class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BrandCreateDto>().ReverseMap();
        CreateMap<Brand, BrandUpdateDto>().ReverseMap();
        CreateMap<Brand, BrandGetDto>()
            .ForMember(x => x.Name, x => x.MapFrom(x => x.BrandDetails.FirstOrDefault() != null ? x.BrandDetails.FirstOrDefault()!.Name : string.Empty))
            .ForMember(x => x.Description, x => x.MapFrom(x => x.BrandDetails.FirstOrDefault() != null ? x.BrandDetails.FirstOrDefault()!.Description : string.Empty))
            .ReverseMap();
    }
}
