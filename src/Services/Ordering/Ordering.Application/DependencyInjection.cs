using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

// This class is responsible for registering application services to the dependency injection container.
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Here you would typically register your application services, such as MediatR handlers, validators, etc.

        return services;
    }
}
