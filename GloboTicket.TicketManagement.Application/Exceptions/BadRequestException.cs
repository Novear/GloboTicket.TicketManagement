using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    // that is more used if the input is for example null when you are expecting to 
    // update an event 
    public class BadRequestException:ApplicationException
    {
        public BadRequestException(string message):base(message)
        {

        }
    }
}
