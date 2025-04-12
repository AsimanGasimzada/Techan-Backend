using FluentValidation;
using Techan.Business.Helpers;

namespace Techan.Business.Validators.BrandValidators;
public class BrandCreateDtoValidator : AbstractValidator<BrandCreateDto>
{
    public BrandCreateDtoValidator()
    {
        RuleFor(x => x.Image).NotNull().Must(x => x.CheckSize(1) && x.CheckType());
        RuleFor(x => x.BrandDetails).NotNull().Must(x => x.Count == 3);
    }
}