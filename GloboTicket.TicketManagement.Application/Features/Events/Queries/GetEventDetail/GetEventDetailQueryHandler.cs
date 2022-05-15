﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler :IRequestHandler<GetEventDetailQuery, EventDetailVM>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<EventDetailVM> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            var eventDetailDto = _mapper.Map<EventDetailVM>(@event);

            var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);
            eventDetailDto.Category = _mapper.Map<CategoryDto>(category);
            return eventDetailDto;
        }
    }
}
