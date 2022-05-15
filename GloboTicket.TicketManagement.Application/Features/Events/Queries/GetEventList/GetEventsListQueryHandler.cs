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

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVM>>
    {
        // we do not have an implementation here for IAsyncRepository
        // that'll be plugged into dependency injection, basically
        // the implementation of the dependency version, later on. we'll 
        // still need to write an actual repository that knows how to handle this 
        // in the database, in our apllication project we just talking with the 
        // abstractions 
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        // in the constructor I am getting in a mapper that is auto mapper 
        //and IAsyncRepository in events, indeed this query handler is my businesslogic
        // and is going to work with the repositories to get the list of events
        // to construct the injection I am going to get an instance of both eventRepository
        // and AutoMapper 
        public GetEventsListQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        // the method which will handle the message, so this method will be called automatically 
        // when GetEventsListQuery is fired off, and this handler will pick it up
        public async Task<List<EventListVM>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            // this will yield a list of entities, an IOrderedEnumerable of events
            // so my domain events I do not want to return entities to my client 
            // I want to return objects that I am in control of that only contain
            // the properties I want to return, and those are availbale on my EventListVM
            // Now I do not want ot write mapping code myself, so I am going to use AutoMapper for that
            // and in AutoMapper,I can use the Map method here as defining the type I want to map 
            // to, that is the lidt of EventListVms and I am going to use allEvents as the object 
            // that I want to be mapping from so what is going to be returned is alist of events 
            // list view models. 
            // Now AutoMApper does need some more information for this to actually work
            // it does need what is known as profile. A profile will contain mapping information 
            // so that AutoMapper knows I should actually be able to try to map from this type,
            // to this type, AutoMapper does a lot of work automatically biut sometimes
            // you'll need to help it a bit. but if the properties on the EventListVm
            // have the same as the ones on the actual entity, then it will do the mapping itself 
            // if we can just create a profile the mapping will be done automatically for us,
            // if we define that in a profile 

            var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x=>x.Date);
            return _mapper.Map<List<EventListVM>>(allEvents);
        }
    }
}






