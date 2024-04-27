using MediatR;

namespace BuildingBlocks.CQRS.Query
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
        where TResponse : notnull
    {
    }
}
