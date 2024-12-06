using Autenticul.Gaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Contracts.Persistence
{
    public interface IBetRepository : IAsyncRepository<Bet>
    {
        IEnumerable<Bet> GetAllBetsForUser(Guid userId);
    }
}
