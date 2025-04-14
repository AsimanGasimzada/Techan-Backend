﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
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

}
