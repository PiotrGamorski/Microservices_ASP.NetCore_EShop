namespace Catalog_API.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product not found.")
        {
        }
    }
}
