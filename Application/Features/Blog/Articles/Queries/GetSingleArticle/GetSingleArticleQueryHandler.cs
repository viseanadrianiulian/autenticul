using Autenticul.Gaming.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetSingleArticle
{
    public class GetSingleArticleQueryHandler : IRequestHandler<GetSingleArticleQuery, GetSingleArticleResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public GetSingleArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<GetSingleArticleResponse> Handle(GetSingleArticleQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSingleArticleResponse();

            var dbArticle = await _articleRepository.GetArticleBySlugAsync(request.Slug);
            response.Article = _mapper.Map<ArticleDto>(dbArticle);

            return response;
        }
    }
}
