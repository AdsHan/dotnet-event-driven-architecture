using EventDriven.Core.Communication;

namespace EventDriven.Core.Mediator;

public interface IMediatorHandler
{
    Task<BaseResult> SendCommand<T>(T command) where T : Command;
    Task SendEvent<T>(T @event) where T : DomainEvent;
    Task<object> SendQuery<T>(T query);
}