using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.CloseEvent
{
    public class CloseEventCommand : IRequest<CloseEventCommandResponse>
    {
        public string EventId {  get; set; }
    }
}
