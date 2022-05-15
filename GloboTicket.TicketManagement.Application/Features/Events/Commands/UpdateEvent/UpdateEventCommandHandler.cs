using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepositroy;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepositroy, IMapper mapper)
        {
            _eventRepositroy = eventRepositroy;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepositroy.GetByIdAsync(request.EventId);
            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            //_mapper.Map<Event>(request);
            await _eventRepositroy.UpdateAsync(eventToUpdate);
            return Unit.Value; 
        }
    }
}
