using BuildingBlocks.Behaviours;
using BuildingBlocks.Messaging.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ordering.Application;

// This class is responsible for registering application services to the dependency injection container.
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // Here you would typically register your application services, such as MediatR handlers, validators, etc.
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehaviours<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehaviour<,>));
        });

        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

        return services;
    }
}
