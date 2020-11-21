using BuildingBlocks.Common.Events;

namespace AuthResource.Infrastructure.IntegrationEvents
{
    public class AuthResourceCreatedIntegrationEvent : DomainEvent
    {
        public string AuthResourceID{ get; private set; }

        public AuthResourceCreatedIntegrationEvent(string authresourceID)
        {
            AuthResourceID = authresourceID;
        }
    }
}
