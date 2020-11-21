using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthResource.Domain.Events
{
    public class UserCreatedDomainEvent : DomainEvent
    {
        public string Username { get; set; }

    }
}
