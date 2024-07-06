namespace Bakset_API.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);
        Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket, CancellationToken cancellationToken = default);
        Task<bool> DeleteBakset(string userName, CancellationToken cancellationToken = default);
    }
}
