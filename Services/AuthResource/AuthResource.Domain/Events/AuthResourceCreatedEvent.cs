using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthResource.Domain.Events
{
    public class AuthResourceCreatedEvent : Event
    {
        public string AuthResourceID{ get; private set; }

        public AuthResourceCreatedEvent(string authresourceID)
        {
            AuthResourceID = authresourceID;
        }
    }
}
