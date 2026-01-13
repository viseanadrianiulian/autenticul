using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Application.Features.Blog.Articles.Commands.CreateArticle;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, UpdateArticleCommandResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<UpdateArticleCommandResponse> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateArticleCommandResponse();
            try
            {
                request.Author = "admin";
                var dbArticle = await _articleRepository.GetAsync(request.Id);
                if (dbArticle != null)
                {
                    dbArticle.Slug = String.IsNullOrEmpty(request.Slug) ? dbArticle.Slug : request.Slug;
                    dbArticle.Tags = request.Tags.Count() > 0 ? request.Tags : dbArticle.Tags;
                    dbArticle.Summary = String.IsNullOrEmpty(request.Summary) ? dbArticle.Summary : request.Summary;
                    dbArticle.Content = String.IsNullOrEmpty(request.Content) ? dbArticle.Content : request.Content;
                    dbArticle.CategoryId = String.IsNullOrEmpty(request.CategoryId) ? dbArticle.CategoryId : Guid.Parse(request.CategoryId);
                    dbArticle.Description = String.IsNullOrEmpty(request.Description) ? dbArticle.Description : request.Description;
                    dbArticle.ImagePath = String.IsNullOrEmpty(request.ImagePath) ? dbArticle.ImagePath : request.ImagePath;
                    dbArticle.Title = String.IsNullOrEmpty(request.Title) ? dbArticle.Title : request.Title;
                    await _articleRepository.UpdateAsync(dbArticle);
                }
                
            }
            catch (Exception ex)
            {

            }


            return response;
        }
    }
}
