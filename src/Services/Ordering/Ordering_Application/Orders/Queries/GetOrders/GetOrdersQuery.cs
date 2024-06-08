using BuildingBlocks.CQRS.Query;
using BuildingBlocks.Pagination;

namespace Ordering_Application.Orders.Queries.GetOrders
{
    public record GetOrdersQuery(PaginationRequest PaginationRequest) 
        : IQuery<GetOrdersResult>;

    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
}
