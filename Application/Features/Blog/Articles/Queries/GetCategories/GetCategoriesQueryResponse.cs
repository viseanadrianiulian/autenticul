using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetCategories
{
    public class GetCategoriesQueryResponse : BaseResponse
    {
        public List<CategoryDto> Categories { get; set; }
    }
}
