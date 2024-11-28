using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Querries.GetLiveEvent
{
    public class GetLiveEventQuery : IRequest<GetLiveEventQueryResponse>
    {
        public string? UserName { get; set; }
        public GetLiveEventQuery()
        {
            
        }
        public GetLiveEventQuery(string userName)
        {
            UserName = userName;
        }
    }
}
