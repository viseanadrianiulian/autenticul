using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Admin.Prizes
{
    public class PrizeDto
    {
        public decimal Value {  get; set; }
        public bool IsActive {  get; set; }
        public string Month {  get; set; }
    }
}
