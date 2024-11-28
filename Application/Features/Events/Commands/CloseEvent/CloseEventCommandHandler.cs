using Autenticul.Gaming.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.CloseEvent
{
    public class CloseEventCommandHandler : IRequestHandler<CloseEventCommand, CloseEventCommandResponse>
    {
        private readonly IEventRepository _eventRepository;

        public CloseEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<CloseEventCommandResponse> Handle(CloseEventCommand command, CancellationToken cancellationToken)
        {
            var response = new CloseEventCommandResponse();


            var dbEvent = await _eventRepository.GetAsync(new Guid(command.EventId));
            dbEvent.IsActive = false;


            return response;
        }
    }
}
