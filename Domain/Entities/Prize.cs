using Autenticul.Gaming.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Domain.Entities
{
    public class Prize : AuditableEntity
    {
        public decimal Value {  get; set; }
        public bool IsActive { get; set; }
        public string Month { get; set; }
    }
}
