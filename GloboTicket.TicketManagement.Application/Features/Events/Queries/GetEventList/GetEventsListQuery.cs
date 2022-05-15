using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    // I want to make this class a message  
    // the parameter (the type parameter) is going to be the type 
    // of data that this query is going to be getting back and it is going 
    // to be a list of EventListVms
    // that is another class that I'm going to be returning. 
    // I am going to create a specific object, a view model,
    // that I'm going to return for my client application.
    // it is going to be a view model that is going to contain just the properties 
    // to visualize in a list, just enough information so that I do not return 
    // too much data.


    public class GetEventsListQuery: IRequest<List<EventListVM>>
    {

    }
}
