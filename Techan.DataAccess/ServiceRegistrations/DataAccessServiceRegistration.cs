using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Techan.DataAccess.Abstractions;
using Techan.DataAccess.Contexts;
using Techan.DataAccess.DataInitalizers;
using Techan.DataAccess.Interceptors;
using Techan.DataAccess.Localizers;
using Techan.DataAccess.Repositories.Abstractions;
using Techan.DataAccess.Repositories.Implementations;


namespace Techan.DataAccess.ServiceRegistrations;
public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        _addIdentity(services);

        services.AddScoped<BaseAuditableInterceptor>();

        services.AddScoped<IDbInitalizer, DbContextInitalizer>();

        _addRepositories(services);
        _addLocalizers(services);

        return services;
    }

    private static void _addIdentity(IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;

            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
        })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();
    }

    private static void _addRepositories(IServiceCollection services)
    {

        //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
    }

    private static void _addLocalizers(IServiceCollection services)
    {

        services.AddTransient<ErrorLocalizer>();
    }
}
