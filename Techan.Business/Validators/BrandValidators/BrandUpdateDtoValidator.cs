using FluentValidation;
using Techan.Business.Helpers;

namespace Techan.Business.Validators.BrandValidators;

public class BrandUpdateDtoValidator : AbstractValidator<BrandUpdateDto>
{
    public BrandUpdateDtoValidator()
    {
        RuleFor(x => x.Image).Must(x => x==null || (x.CheckSize(1) && x.CheckType()));
        RuleFor(x => x.BrandDetails).Must(x => x.Count == 3);
    }
}
