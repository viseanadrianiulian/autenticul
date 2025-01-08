using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Streamers.Querries.GetStreamerDetails
{
    public class GetStreamerDetailsQueryResponse : BaseResponse
    {
        public StreamerDto? StreamerDetails { get; set; }
    }
}
