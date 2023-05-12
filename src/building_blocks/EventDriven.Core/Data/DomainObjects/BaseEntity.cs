using EventDriven.Core.Communication;
using EventDriven.Core.Data.Enums;

namespace EventDriven.Core.Data.DomainObjects;

public abstract class BaseEntity
{
    private readonly List<DomainEvent> _domainEvents = new();
    public ICollection<DomainEvent> GetEvents() => _domainEvents;
    protected void AddEvent(DomainEvent @event) => _domainEvents.Add(@event);

    public Guid Id { get; set; }
    public EntityStatusEnum Status { get; set; }
    public DateTime DateCreateAt { get; private set; }

    protected BaseEntity()
    {
        DateCreateAt = DateTime.Now;
        Status = EntityStatusEnum.Active;
    }
}