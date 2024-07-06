using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shopping.Web.Pages
{
    public class CartModel
        (IBasketService basketService, ILogger<CartModel> logger) 
        : PageModel
    {
        public ShoppingCartModel Cart { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Cart page visited.");

            Cart = await basketService.LoadUserBasket();

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(Guid productId)
        {
            logger.LogInformation("Remove to cart button was clicked.");

            Cart = await basketService.LoadUserBasket();
            Cart.Items.RemoveAll(x => x.ProductId == productId);

            // store new to add new into reddis distributed cache
            await basketService.StoreBasket(new StoreBasketRequest(Cart));

            return RedirectToPage();
        }
    }
}
