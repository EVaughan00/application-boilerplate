using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BuildingBlocks.Common
{
    public abstract class Query<T> : IRequest<T> {}

    public abstract class QueryHandler<T, R> : 
        IRequestHandler<T, R> 
        where T: Query<R>
    {
        public abstract Task<R> Handle(T request, CancellationToken cancellationToken);

    }
}