namespace Ordering_Domain.Events
{
    public record OrderCreatedEvent(Order order) : IDomainEvent;
}
