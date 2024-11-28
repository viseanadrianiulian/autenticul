using Autenticul.Gaming.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Domain.Entities
{
    public class Event : AuditableEntity
    {
        public string? Name {  get; set; }
        public string? Description { get; set; }
        public string? Choice1 { get;set; }
        public string? Choice2 { get;set; }
        public string? Choice3 { get;set; }
        public string? CorrectChoice {  get;set; }
        public bool IsActive { get; set; }
        public bool BetsActive { get; set; }
        public ICollection<Bet> Bets { get; set; }

    }
}
