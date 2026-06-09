using MassTransit;
using Microsoft.Extensions.Configuration;

namespace BuildingBlocks.Messaging.MassTransit;
// This will contain extenstions methods for setting up MassTransit with RabbitMQ
public static class Extentions
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
    {
        // Implement RabbitMQ configurations
        services.AddMassTransit(config =>
        {
            //Configure for Kebab Name formatting
            config.SetKebabCaseEndpointNameFormatter();

            if (assembly != null) config.AddConsumers(assembly);

            //RabbitMQ configurations
            config.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                {
                    host.Username(configuration["MessageBroker:UserName"]);
                    host.Password(configuration["MessageBroker:Password"]);
                });
                configurator.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
