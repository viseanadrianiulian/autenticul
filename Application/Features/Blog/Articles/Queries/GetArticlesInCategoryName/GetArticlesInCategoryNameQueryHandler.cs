using Autenticul.Gaming.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetArticlesInCategoryName
{
    public class GetArticlesInCategoryNameQueryHandler : IRequestHandler<GetArticlesInCategoryNameQuery, GetArticlesInCategoryNameResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public GetArticlesInCategoryNameQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<GetArticlesInCategoryNameResponse> Handle(GetArticlesInCategoryNameQuery request, CancellationToken cancellationToken)
        {
            var response = new GetArticlesInCategoryNameResponse();

            var dbArticles = _articleRepository.GetAllArticlesInCategory(request.CategoryName).ToList();
            response.Articles = _mapper.Map<List<ArticleDto>>(dbArticles);

            return response;
        }
    }
}
