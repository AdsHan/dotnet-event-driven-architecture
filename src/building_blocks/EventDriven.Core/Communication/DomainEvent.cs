using MediatR;

namespace EventDriven.Core.Communication;

public abstract record DomainEvent(Guid id, DateTime Timestamp) : INotification
{
    public DomainEvent(Guid id) : this(id, DateTime.Now)
    {
    }
}