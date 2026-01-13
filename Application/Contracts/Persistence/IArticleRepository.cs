using Autenticul.Gaming.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Contracts.Persistence
{
    public interface IArticleRepository : IAsyncRepository<Article>
    {
        IEnumerable<Article> GetAllArticlesInCategory(string categoryName);
        Task<Article> GetArticleByTitle(string title);
        Task<Article?> GetArticleBySlugAsync(string slug);
    }
}
