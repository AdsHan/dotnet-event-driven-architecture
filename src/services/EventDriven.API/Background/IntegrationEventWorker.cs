using EventDriven.MessageBus;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventDriven.API.Background;

public class IntegrationEventWorker : BackgroundService, IConsumer
{
    private readonly IMessageBusService _messageBusService;
    private readonly ILogger<IntegrationEventWorker> _logger;

    public IntegrationEventWorker(IMessageBusService messageBusService, IServiceProvider serviceProvider, ILogger<IntegrationEventWorker> logger)
    {
        _messageBusService = messageBusService;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("**** WORKER Registrado");
        _messageBusService.Subscribe(QueueTypes.NOTIFICATION_PRODUCT_CREATED, RegisterConsumer);
        return Task.CompletedTask;
    }

    public void RegisterConsumer(BasicDeliverEventArgs message)
    {
        var byteArray = message.Body.ToArray();
        var messageString = Encoding.UTF8.GetString(byteArray);
        var product = JsonConvert.DeserializeObject<ProductCreatedIntegrationEvent>(messageString);
    }
}
