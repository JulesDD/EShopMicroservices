using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    // This class is responsible for registering infrastructure services to the dependency injection container.
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Here you would typically register your infrastructure services, such as database contexts, repositories, etc.
        // For example:
        // services.AddDbContext<OrderingDbContext>(options =>
        //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        var connectionString = configuration.GetConnectionString("Database");

        return services;
    }
}
