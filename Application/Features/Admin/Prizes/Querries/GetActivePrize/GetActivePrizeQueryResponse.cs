using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Admin.Prizes.Querries.GetActivePrize
{
    public class GetActivePrizeQueryResponse : BaseResponse
    {
        public PrizeDto Prize { get; set; }
    }
}
