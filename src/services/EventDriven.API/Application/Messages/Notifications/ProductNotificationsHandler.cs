using EventDriven.API.Data;
using EventDriven.MessageBus;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventDriven.API.Application.Messages.Commands;

public class ProductNotificationsHandler : INotificationHandler<ProductCreatedDomainEvent>
{
    private readonly CatalogDbContext _dbContext;
    private readonly IMessageBusService _messageBusService;

    public ProductNotificationsHandler(IMessageBusService messageBusService, CatalogDbContext dbContext)
    {
        _messageBusService = messageBusService;
        _dbContext = dbContext;
    }

    public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Nova ordem recebida: ID {notification.id}, data {notification.Timestamp}");

        var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == notification.ProductId);

        var evt = new ProductCreatedIntegrationEvent(product.Id, product.Title, product.Description, product.Price, product.Quantity);

        _messageBusService.Publish(ExchangeType.NOTIFICATION, QueueTypes.NOTIFICATION_PRODUCT_CREATED, evt);
    }
}
