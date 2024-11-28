using Autenticul.Gaming.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.SaveEventResult
{
    public class SaveEventResultCommandHandler : IRequestHandler<SaveEventResultCommand,SaveEventResultCommandResponse>
    {
        private readonly IEventRepository _eventRepository;
        public SaveEventResultCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<SaveEventResultCommandResponse> Handle(SaveEventResultCommand command, CancellationToken cancellationToken)
        {
            var response = new SaveEventResultCommandResponse();
            var dbEvent = await _eventRepository.GetLiveEventAsync();
            if (dbEvent != null)
            {
                dbEvent.CorrectChoice = command.Result;
                dbEvent.IsActive = false;
                foreach (var bet in dbEvent.Bets)
                {
                    bet.IsFinished = true;
                    bet.IsWon = command.Result.Equals(bet.Choice);
                    if(bet.IsWon)
                    {
                        bet.User.Score += 1;
                    }
                }
                await _eventRepository.UpdateAsync(dbEvent);
            }
            
            
            return response;
            
        }
    }
}
