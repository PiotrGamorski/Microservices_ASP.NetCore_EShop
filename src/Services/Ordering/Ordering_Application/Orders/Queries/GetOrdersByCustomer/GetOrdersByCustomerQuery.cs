using BuildingBlocks.CQRS.Query;
using FluentValidation;

namespace Ordering_Application.Orders.Queries.GetOrdersByCustomer
{
    public record GetOrdersByCustomerQuery(Guid CustomerId)
        : IQuery<GetOrdersByCustomerResult>;

    public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);

    public class GetOrdersByCustomerQueryValidator : AbstractValidator<GetOrdersByCustomerQuery>
    {
        public GetOrdersByCustomerQueryValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required");
        }
    }
}
