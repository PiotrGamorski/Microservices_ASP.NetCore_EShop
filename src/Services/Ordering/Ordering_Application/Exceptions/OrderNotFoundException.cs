using BuildingBlocks.Exceptions;

namespace Ordering_Application.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid id) : base("OrderId", id)
        {
        }
    }
}
