using EventDriven.API.Application.Messages.Commands;
using EventDriven.API.Application.Services;
using EventDriven.API.Background;
using EventDriven.API.Data;
using EventDriven.Core.Mediator;
using EventDriven.MessageBus.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EventDriven.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("CatalogDB"));

        services.AddMessageBus(configuration);

        services.AddTransient<ProductPopulateService>();

        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
        });

        services.AddHostedService<IntegrationEventWorker>();

        return services;
    }
}
