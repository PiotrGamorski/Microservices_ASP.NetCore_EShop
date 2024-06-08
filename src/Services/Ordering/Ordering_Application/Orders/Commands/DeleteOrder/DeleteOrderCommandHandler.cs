
namespace Ordering_Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler(IApplicationDbContext dbContext)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = OrderId.Of(command.OrderId);
            var order = await dbContext.Orders
                .FindAsync([orderId], cancellationToken: cancellationToken);

            _ = order ?? throw new OrderNotFoundException(command.OrderId);

            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteOrderResult(true);
        }
    }
}
