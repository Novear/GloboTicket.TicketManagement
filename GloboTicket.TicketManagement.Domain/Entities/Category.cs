using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    // it contains a couple of base properties 
    // and I just want every other entity to have full logging for 
    // let's say tracking purposes in my data store
    public class Category: AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
