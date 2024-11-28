using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<CreateEventCommandResponse> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateEventCommandResponse();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            command.NewEvent = JsonSerializer.Deserialize<EventDto>(command.NewEventString!, options);
    
            var eventToBeCreated = _mapper.Map<Event>(command.NewEvent);
            try
            {
                var newEvent = await _eventRepository.AddAsync(eventToBeCreated);
                response.CreatedEvent = _mapper.Map<EventDto>(newEvent);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
