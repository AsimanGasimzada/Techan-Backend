using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Techan.Business.ExternalServices.Abstractions;
using Techan.Business.ExternalServices.Implementations;
using Techan.Business.Profiles;
using Techan.Business.Services.Abstractions;
using Techan.Business.Services.Implementations;
using Techan.Business.Validators.ProductValidators;

namespace Techan.Business.ServiceRegistrations;
public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(ProductProfile));

        services.AddValidatorsFromAssemblyContaining<ProductCreateDtoValidator>();
        services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        _addServices(services);
        _addExternalServices(services);
        _addJwtBearer(services, configuration);

        return services;
    }

    private static void _addExternalServices(IServiceCollection services)
    {
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ITokenHelper, JwtHelper>();
    }

    private static void _addServices(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IAuthService, AuthService>();
    }




    private static void _addJwtBearer(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
            
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configuration["TokenOptions:Issuer"],
                ValidAudience = configuration["TokenOptions:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOptions:SecurityKey"] ?? "")),
                LifetimeValidator = (_, expired, token, _) => token != null ? expired > DateTime.UtcNow : false
            };
        });
    }


}
