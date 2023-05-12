using EventDriven.Core.Communication;

namespace EventDriven.MessageBus;

public record ProductCreatedDomainEvent(Guid id, Guid ProductId) : DomainEvent(id);
