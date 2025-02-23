using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetArticlesInCategoryName
{
    public class GetArticlesInCategoryNameQuery : IRequest<GetArticlesInCategoryNameResponse>
    {
        public string CategoryName {  get; set; }
    }
}
