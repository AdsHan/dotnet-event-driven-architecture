using EventDriven.Core.Communication;
using MediatR;

namespace EventDriven.Core.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<BaseResult> SendCommand<T>(T command) where T : Command
    {
        return await _mediator.Send(command);
    }

    public async Task SendEvent<T>(T @event) where T : DomainEvent
    {
        await _mediator.Publish(@event);
    }

    public async Task<object> SendQuery<T>(T query)
    {
        return await _mediator.Send(query);
    }
}