using FluentValidation;
using Techan.Business.Dtos;

namespace Techan.Business.Validators.ProductValidators;
public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
            //RuleFor(x=>x.)
    }
}
