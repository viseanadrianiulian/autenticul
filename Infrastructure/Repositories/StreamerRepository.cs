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
    public class StreamerRepository : BaseRepository<Streamer>, IStreamerRepository
    {
        public StreamerRepository(GamingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Streamer> GetByUserNameAsync(string userName)
        {
            return await _dbContext.Streamers.FirstOrDefaultAsync(s => s.UserName == userName); ;
        }
    }
}
