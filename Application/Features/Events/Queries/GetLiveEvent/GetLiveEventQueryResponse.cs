using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Querries.GetLiveEvent
{
    public class GetLiveEventQueryResponse : BaseResponse
    {
        public GetLiveEventQueryResponse() : base() { }
        public EventDto? LiveEvent { get; set; }
        public List<EventDto> PastEvents { get; set; }
        public BetDto? UserBet { get; set; }
    }
}
