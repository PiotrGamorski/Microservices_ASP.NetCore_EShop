using MediatR;
using Microsoft.Extensions.Logging;
using Ordering_Domain.Events;

namespace Ordering_Application.Orders.EventHandlers.Domain
{
    public class OrderUpdatedEventHandler
        (ILogger<OrderUpdatedEventHandler> logger)
        : INotificationHandler<OrderUpdateEvent>
    {
        public Task Handle(OrderUpdateEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
