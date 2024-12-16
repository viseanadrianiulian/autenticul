using Autenticul.Gaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Contracts.Persistence
{
    public interface IPrizeRepository : IAsyncRepository<Prize>
    {
        Task<Prize> GetActivePrizeAsync();
    }
}
