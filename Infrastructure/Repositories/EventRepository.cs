using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Autenticul.Gaming.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GamingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Event> GetLiveEventAsync()
        {
            return await _dbContext.Events.Include(x => x.Bets).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.IsActive);
        }
    }
}