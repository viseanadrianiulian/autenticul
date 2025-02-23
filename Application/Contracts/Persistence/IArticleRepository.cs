using Autenticul.Gaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Contracts.Persistence
{
    public interface IArticleRepository : IAsyncRepository<Article>
    {
        IEnumerable<Article> GetAllArticlesInCategory(string categoryName);
        Task<Article> GetArticleByTitle(string title);
    }
}
