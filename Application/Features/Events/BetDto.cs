using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events
{
    public class BetDto
    {
        public string Choice { get; set; }
        public bool IsWon { get; set; }
        public bool IsFinished { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public Guid EventId { get; set; }
    }
}
