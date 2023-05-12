using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventDriven.MessageBus.Configuration;

public static class MessageBusConfig
{
    public static IServiceCollection AddMessageBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMessageBusService>(new MessageBusService(configuration.GetConnectionString("RabbitMQCs")));

        return services;
    }
}