using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Streamers.Querries.GetStreamerDetails
{
    public class GetStreamerDetailsQuery : IRequest<GetStreamerDetailsQueryResponse>
    {
        public string UserName {  get; set; }
    }
}
