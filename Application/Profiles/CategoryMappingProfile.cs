using Autenticul.Gaming.Application.Features.Blog.Articles;
using Autenticul.Gaming.Application.Features.Events.Commands.PlaceBet;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
               .ReverseMap();
        }
    }
}
