
using Autenticul.Gaming.Application.Contracts.Services;
using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Application.Dezvoltare;
using Microsoft.Extensions.Caching.Memory;
using Autenticul.Gaming.Application.Features.Blog.Articles;

namespace Autenticul.Application.Dezvoltare
{
    public class ArticleService : IArticleService

    {
        private readonly IArticleRepository _repo;
        private readonly IMemoryCache _cache;

        public ArticleService(IArticleRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<IReadOnlyList<ArticleDto>> ListAsync()
        {
            const string key = "articles:mama-si-bebe";
            if (_cache.TryGetValue(key, out IReadOnlyList<ArticleDto>? cached)) return cached!;

            var items = await _repo.GetAllAsync();
            var dtos = items.Select(x => new ArticleDto(
                x.Id, x.Title, x.Description, x.Content, x.Author,
                x.ImagePath, x.Tags, x.Slug, x.Summary, x.CategoryId
            )).ToList();

            _cache.Set(key, dtos, TimeSpan.FromMinutes(10));
            return dtos;
        }

        public async Task<ArticleDto?> BySlugAsync(string slug)
        {
            var key = $"article:{slug}";
            if (_cache.TryGetValue(key, out ArticleDto? cached)) return cached;

            var x = await _repo.GetArticleBySlugAsync(slug);
            if (x is null) return null;

            var dto = new ArticleDto(
                 x.Id, x.Title, x.Description, x.Content, x.Author,
                x.ImagePath, x.Tags, x.Slug, x.Summary, x.CategoryId
            );

            _cache.Set(key, dto, TimeSpan.FromMinutes(15));
            return dto;
        }
    }
}
