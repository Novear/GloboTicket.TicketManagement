using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper, IEmailService emailService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);


            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var @event = _mapper.Map<Event>(request);
            @event =  await _eventRepository.AddAsync(@event);

            var email = new Email() { To = "noveerkoose@gmail.com", Body = $"A new event is created:{request} ", Subject= "A new event is created" };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                throw;
            }

            return @event.EventId;
        }
    }
}
