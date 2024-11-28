using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.StopBets
{
    public class StopBetsCommand : IRequest<StopBetsCommandResponse>
    {
        public string EventId {  get; set; }
    }
}
