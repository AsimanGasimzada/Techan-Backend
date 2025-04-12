namespace Techan.Business.Profiles;
public class BrandDetailProfile : Profile
{
    public BrandDetailProfile()
    {
        CreateMap<BrandDetail, BrandDetailCreateDto>().ReverseMap();
        CreateMap<BrandDetail, BrandDetailUpdateDto>().ReverseMap();
    }
}
