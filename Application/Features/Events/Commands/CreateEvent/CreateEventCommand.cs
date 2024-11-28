using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<CreateEventCommandResponse>
    {
        public EventDto? NewEvent { get; set; }
        public string? NewEventString {  get; set; }

    }
}
