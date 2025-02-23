using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetArticlesInCategoryName
{
    public class GetArticlesInCategoryNameResponse : BaseResponse
    {
        public List<ArticleDto> Articles { get; set; }
    }
}
