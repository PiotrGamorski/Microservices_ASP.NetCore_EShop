
namespace Bakset_API.Basket.UpdateBasket
{
    public record UpdateBasketRequest(ShoppingCart Cart);
    public record UpdateBasketResponse(bool IsSuccess);

    public class UpdateBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/update", async (UpdateBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateBasketCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateBasket")
            .Produces<UpdateBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("UpdateBasket")
            .WithDescription("UpdateBasket");
        }
    }
}
