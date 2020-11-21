using System.Threading;
using System.Threading.Tasks;
using AuthResource.Domain.Events;
using BuildingBlocks.Common.Events;
using Microsoft.Extensions.Logging;

namespace AuthResource.API.Application.DomainEventHandlers
{
    public class UserCreatedDomainEventHandler : DomainEventHandler<UserCreatedDomainEvent>
    {
        private readonly ILogger<UserCreatedDomainEventHandler> _logger;
        public UserCreatedDomainEventHandler(ILogger<UserCreatedDomainEventHandler> logger)
        {
            _logger = logger;

        }
        public override async Task Handle(UserCreatedDomainEvent request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _logger.LogInformation("User created domain event");

        }
    }
}