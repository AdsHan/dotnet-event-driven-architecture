using RabbitMQ.Client.Events;

namespace EventDriven.MessageBus;

public interface IConsumer
{
    void RegisterConsumer(BasicDeliverEventArgs message);
}
