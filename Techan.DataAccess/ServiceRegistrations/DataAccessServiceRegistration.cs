using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Techan.DataAccess.Contexts;
using Techan.DataAccess.Repositories.Abstractions;
using Techan.DataAccess.Repositories.Abstractions.Generic;
using Techan.DataAccess.Repositories.Implementations;
using Techan.DataAccess.Repositories.Implementations.Generic;

namespace Techan.DataAccess.ServiceRegistrations;
public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
