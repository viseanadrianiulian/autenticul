using Autenticul.Gaming.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Querries.GetAllPastEvents
{
    public class GetAllPastEventsQueryHandler : IRequestHandler<GetAllPastEventsQuery, GetAllPastEventsQueryResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetAllPastEventsQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<GetAllPastEventsQueryResponse> Handle(GetAllPastEventsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllPastEventsQueryResponse();
            var dbEvents = await _eventRepository.GetAllAsync();
            response.Events = _mapper.Map<IEnumerable<EventDto>>(dbEvents.Where(x => x.IsActive == false).ToList());
            response.Success = true;

            return response;
        }
    }
}
