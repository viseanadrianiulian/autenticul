using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Persistence.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(GamingDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Article> GetAllArticlesInCategory(string categoryName)
        {
            return _dbContext.Articles
                .Include(a => a.Category)
                .Where(a => a.Category.Name == categoryName);
        }

        public async Task<Article> GetArticleByTitle(string title)
        {
            return await _dbContext.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Title == title);
        }

        public async Task<Article?> GetArticleBySlugAsync(string slug)
        {
            return await _dbContext.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Slug == slug);
        }

    }
}
