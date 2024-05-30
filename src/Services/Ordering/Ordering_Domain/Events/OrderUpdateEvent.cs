namespace Ordering_Domain.Events
{
    public record OrderUpdateEvent(Order order) : IDomainEvent;
}
