namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        // Here you would typically register your API services, such as controllers, filters, etc.
        // For example:
        // services.AddControllers();

        return services;
    }

    public static WebApplication UseApiService(this WebApplication app)
    {
        // Here you would typically configure your API middleware, such as routing, authentication, etc.
        // For example:
        // app.UseRouting();
        // app.UseAuthentication();
        // app.UseAuthorization();
        // app.MapControllers();
        return app;
    }
}
