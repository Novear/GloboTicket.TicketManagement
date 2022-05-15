using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery:IRequest<EventDetailVM>
    {
        // here ana extra parameter which event detail by adding Id
        public Guid Id { get; set; }
    }
}
