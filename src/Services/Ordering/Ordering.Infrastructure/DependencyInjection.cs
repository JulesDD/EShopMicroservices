namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    // This class is responsible for registering infrastructure services to the dependency injection container.
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        // Here you would typically register your infrastructure services, such as database contexts, repositories, etc.
        // For example:
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });            

        return services;
    }
}
