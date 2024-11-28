using Autenticul.Gaming.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.StopBets
{
    public class StopBetsCommandHandler : IRequestHandler<StopBetsCommand, StopBetsCommandResponse>
    {
        private readonly IEventRepository _eventRepository;

        public StopBetsCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<StopBetsCommandResponse> Handle(StopBetsCommand request, CancellationToken cancellationToken)
        {
            var response = new StopBetsCommandResponse();

            var dbEvent = await _eventRepository.GetAsync(new Guid(request.EventId));
            dbEvent.BetsActive = false;
            await _eventRepository.UpdateAsync(dbEvent);

            return response;
        }
    }
}