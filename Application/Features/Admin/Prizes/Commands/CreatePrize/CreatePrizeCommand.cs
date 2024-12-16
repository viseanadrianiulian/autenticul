using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Admin.Prizes.Commands.CreatePrize
{
    public class CreatePrizeCommand : IRequest<CreatePrizeCommandResponse>
    {
        public decimal Value { get; set; }
        public string Month { get; set; }
    }
}
