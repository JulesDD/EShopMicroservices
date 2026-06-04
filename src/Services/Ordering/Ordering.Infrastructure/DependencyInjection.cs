namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    // This class is responsible for registering infrastructure services to the dependency injection container.
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        // Here you would typically register your infrastructure services, such as database contexts, repositories, etc.
        // For example:
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}
