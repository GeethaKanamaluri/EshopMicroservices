using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse>       
    {
    }

    public interface IQuery : IQuery<Unit>
    {

    }

   
}
