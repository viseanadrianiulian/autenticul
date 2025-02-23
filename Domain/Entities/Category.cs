using Autenticul.Gaming.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name {  get; set; }

    }
}
