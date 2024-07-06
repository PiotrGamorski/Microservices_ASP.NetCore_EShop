
namespace Bakset_API.Basket.UpdateBasket
{
    public record UpdateBasketRequest(ShoppingCart Cart);
    public record UpdateBasketResponse(string UserName);

    public class UpdateBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/basket", async (UpdateBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateBasketCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateBasket")
            .Produces<UpdateBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("UpdateBasket")
            .WithDescription("UpdateBasket");
        }
    }
}
