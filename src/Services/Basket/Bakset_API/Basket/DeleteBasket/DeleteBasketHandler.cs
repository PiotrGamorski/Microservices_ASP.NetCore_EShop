namespace Bakset_API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBaksetCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBaksetCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
        }
    }

    public class DeleteBasketHandler(IBasketRepository repository) 
        : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            await repository.DeleteBakset(command.UserName, cancellationToken);

            return new DeleteBasketResult(true);
        }
    }
}
