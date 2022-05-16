using FluentValidation;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator:AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Property Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
            
            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{Property Name} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);
    
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{Property Name} is required.")
                .GreaterThan(0);
        }
    }
}
