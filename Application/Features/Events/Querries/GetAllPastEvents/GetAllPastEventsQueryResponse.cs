using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Querries.GetAllPastEvents
{
    public class GetAllPastEventsQueryResponse : BaseResponse
    {
        public IEnumerable<EventDto> Events { get; set; }
    }
}
