using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BuildingBlocks.Common.Events
{       
    public abstract class DomainEvent : 
        INotification {}

    public abstract class DomainEventHandler<T> : 
        INotificationHandler<T> 
        where T: DomainEvent
    {
        public abstract Task Handle(T request, CancellationToken cancellationToken);

    }
}