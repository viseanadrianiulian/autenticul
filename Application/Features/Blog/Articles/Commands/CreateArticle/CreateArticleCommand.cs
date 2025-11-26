using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<CreateArticleCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string? Author { get; set; }
        public string ImagePath { get; set; }
        public string CategoryId { get; set; } 
    }
}
