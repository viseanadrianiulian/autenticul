using Autenticul.Gaming.Application.Features.Blog.Articles;

namespace Autenticul.Gaming.Application.Contracts.Services
{
    public interface IArticleService
    {
        Task<IReadOnlyList<ArticleDto>> ListAsync();
        Task<ArticleDto?> BySlugAsync(string slug);
    }
}
