using BuildingBlocks.Exceptions;

namespace Ordering_Application.Exceptions
{
    public class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(Guid id) : base("CustomerId", id)
        {
        }
    }
}
