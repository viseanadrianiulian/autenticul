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
    public class PrizeRepository : BaseRepository<Prize>, IPrizeRepository
    {
        public PrizeRepository(GamingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Prize> GetActivePrizeAsync()
        {
            return await _dbContext.Prizes.FirstOrDefaultAsync(p => p.IsActive);
        }
    }
}
