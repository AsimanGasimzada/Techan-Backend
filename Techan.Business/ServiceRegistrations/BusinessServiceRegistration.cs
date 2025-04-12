using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Techan.Business.ExternalServices.Abstractions;
using Techan.Business.ExternalServices.Implementations;
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

        _addServices(services);
        _addExternalServices(services);

        return services;
    }

    private static void _addExternalServices(IServiceCollection services)
    {
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddScoped<IEmailService, EmailService>();
    }

    private static void _addServices(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBrandService, BrandService>();
    }
}
