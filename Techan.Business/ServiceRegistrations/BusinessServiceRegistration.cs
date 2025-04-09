using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Techan.Business.Profiles;
using Techan.Business.Services.Abstractions;
using Techan.Business.Services.Implementations;
using Techan.Business.Validators.ProductValidators;

namespace Techan.Business.ServiceRegistrations;
public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductProfile));

        services.AddValidatorsFromAssemblyContaining<ProductCreateDtoValidator>();
        services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
