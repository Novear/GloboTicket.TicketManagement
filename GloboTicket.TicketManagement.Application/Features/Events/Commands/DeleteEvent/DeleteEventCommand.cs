using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    internal class DeleteEventCommand:IRequest
    {
        public Guid EventId { get; set; }
    }
}
