using Autenticul.Gaming.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Domain.Entities
{
    public class Bet : AuditableEntity
    {
        public string Choice {  get; set; }
        public bool IsWon {  get; set; }
        public bool IsFinished { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
