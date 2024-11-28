using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.PlaceBet
{
    public class PlaceBetCommand : IRequest<PlaceBetCommandResponse>
    {
        public BetDto? NewBet { get; set; }
        public string NewBetString { get;set;}
    }
}
