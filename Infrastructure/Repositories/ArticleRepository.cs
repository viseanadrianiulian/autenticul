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
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(GamingDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Article> GetAllArticlesInCategory(string categoryName)
        {
            var articles = _dbContext.Articles.Include(a => a.Category);
            return articles.Where(a => a.Category.Name == categoryName);
        }

        public async Task<Article> GetArticleByTitle(string title)
        {
            return await _dbContext.Articles.FirstAsync(a => a.Title == title);
        }
    }
}
