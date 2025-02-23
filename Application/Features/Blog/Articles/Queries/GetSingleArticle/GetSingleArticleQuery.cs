using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetSingleArticle
{
    public class GetSingleArticleQuery : IRequest<GetSingleArticleResponse>
    {
        public string Title {  get; set; } 
    }
}
