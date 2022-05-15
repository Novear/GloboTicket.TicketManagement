using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery:IRequest<List<CategoryEventListVm>>
    {
        // to specify if I want to get all events or just the ones in the future 
        public bool IncludeHistory { get; set; }
    }
}
