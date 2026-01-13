using MediatR;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest<UpdateArticleCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string? Author { get; set; }
        public string ImagePath { get; set; }
        public string CategoryId { get; set; }
        public string Slug { get; set; } = "";
        public string Summary { get; set; } = "";
        public string[] Tags { get; set; } = Array.Empty<string>();
    }
}
