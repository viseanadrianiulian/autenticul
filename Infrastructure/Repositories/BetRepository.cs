using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Bet> GetAllBetsForUser(Guid userId)
        {
            return _dbContext.Bets.Include(x => x.Event).Where(x => x.UserId == userId);


        }
    }
}
