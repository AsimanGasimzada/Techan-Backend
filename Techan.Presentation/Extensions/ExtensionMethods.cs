using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Models;
using Techan.DataAccess.Abstractions;

namespace Techan.Presentation.Extensions;

public static class ExtensionMethods
{
    public static async Task InitDatabaseAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<IDbInitalizer>();
            await initializer.InitDatabaseAsync();
        }
    }
    public static void ConfigureLocalizerOptions(this IApplicationBuilder app)
    {
        var supportedCultures = new[] { "az", "en", "ru" };

        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture("az")
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        localizationOptions.RequestCultureProviders = new List<IRequestCultureProvider>
        {
              new CookieRequestCultureProvider(),
              new AcceptLanguageHeaderRequestCultureProvider()
        };

        app.UseRequestLocalization(localizationOptions);
    }

    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });

        return services;
    }

}
