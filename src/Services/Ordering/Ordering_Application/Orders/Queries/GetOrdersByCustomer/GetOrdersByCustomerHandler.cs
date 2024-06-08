using BuildingBlocks.CQRS.Query;
using Microsoft.EntityFrameworkCore;
using Ordering_Application.Extensions;

namespace Ordering_Application.Orders.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
    {
        public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {
            _ = await dbContext.Customers
                .FindAsync([query.CustomerId], cancellationToken: cancellationToken)
                ?? throw new CustomerNotFoundException(query.CustomerId);

            var orders = await dbContext.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
                .OrderBy(o => o.OrderName.Value)
                .ToListAsync(cancellationToken);

            return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
        }
    }
}
