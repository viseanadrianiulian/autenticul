using Autenticul.Gaming.Application.Features.Blog.Articles;
using Autenticul.Gaming.Application.Features.Blog.Articles.Commands.CreateArticle;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Profiles
{
    public class ArticleMappingProfile : Profile
    {
        public ArticleMappingProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Article, CreateArticleCommand>().ReverseMap();
        }
    }
}
