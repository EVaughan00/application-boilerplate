using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BuildingBlocks.Common
{
    public abstract class Command<T> : IRequest<T> {}

    public abstract class CommandHandler<T, R> : 
        IRequestHandler<T, R> 
        where T: Command<R>
    {
        public abstract Task<R> Handle(T request, CancellationToken cancellationToken);

    }
}