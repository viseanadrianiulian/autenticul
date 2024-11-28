using Autenticul.Gaming.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }
        public string Password {  get; set; }
        public decimal Score { get; set; } = 0;
        public int LoginCounter { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}
