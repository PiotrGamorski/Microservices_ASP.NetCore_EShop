using Discount.Grpc;

namespace Bakset_API.Basket.UpdateBasket
{
    public record UpdateBasketCommand(ShoppingCart Cart) : ICommand<UpdateBasketResult>;
    public record UpdateBasketResult(bool IsSuccess);

    public class UpdateBasketCommandValidator : AbstractValidator<UpdateBasketCommand>
    {
        public UpdateBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null.");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    public class UpdateBasketHandler
        (IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto) 
        : ICommandHandler<UpdateBasketCommand, UpdateBasketResult>
    {
        public async Task<UpdateBasketResult> Handle(UpdateBasketCommand command, CancellationToken cancellationToken)
        {
            await DeductDiscount(command.Cart, cancellationToken);
            await repository.UpdateBasket(command.Cart, cancellationToken);

            return new UpdateBasketResult(true);
        }

        private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
        {
            foreach (var item in cart.Items)
            {
                var grpcRequest = new GetDiscountRequest { ProductName = item.ProductName };
                var coupon = await discountProto
                    .GetDiscountAsync(grpcRequest, cancellationToken: cancellationToken);

                item.Price = Math.Max(item.Price - coupon.Amount, 0);
            }
        }
    }
}
