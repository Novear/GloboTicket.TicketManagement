using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    // this view model will contain the data that I want to visualize for an event
    // when shown in alist, it contains just a number of base properties 
    // not all properties of event, but just the ones I'll need in the list view.
    // 
    public class EventListVM
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}
