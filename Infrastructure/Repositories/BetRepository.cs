using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Persistence.Repositories
{
    public class BetRepository : BaseRepository<Bet>, IBetRepository
    {
        public BetRepository(GamingDbContext context) : base(context)
        {
            
        }
    }
}
