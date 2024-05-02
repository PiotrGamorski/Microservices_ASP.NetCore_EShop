namespace Catalog_API.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid Id) : base(nameof(Product), Id)
        {
        }
    }
}
