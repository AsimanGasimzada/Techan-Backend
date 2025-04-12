using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Techan.DataAccess.Contexts;
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

        services.AddScoped<BaseAuditableInterceptor>();

        _addRepositories(services);
        _addLocalizers(services);

        return services;
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
