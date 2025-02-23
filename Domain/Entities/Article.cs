using Autenticul.Gaming.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Domain.Entities
{
    public class Article : AuditableEntity
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string ImagePath {  get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
