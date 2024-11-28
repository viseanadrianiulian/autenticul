using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Commands.SaveEventResult
{
    public class SaveEventResultCommand : IRequest<SaveEventResultCommandResponse>
    {
        public string EventId { get; set; }
        public string Result {  get; set; }
    }
}
