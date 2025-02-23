using Autenticul.Gaming.Application.Features.Blog.Articles.Commands.CreateArticle;
using Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetArticlesInCategoryName;
using Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetCategories;
using Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetSingleArticle;
using Autenticul.Gaming.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("articles/{category}")]
        public async Task<IActionResult> GetArticles(string category)
        {
            var response = await _mediator.Send(new GetArticlesInCategoryNameQuery { CategoryName = category });

            return Ok(response);
        }

        [HttpGet("categories/all")]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _mediator.Send(new GetCategoriesQuery());
            return Ok(response);
        }

        [HttpGet("articles/single/{title}")]
        public async Task<IActionResult> GetSingleArticle(string title)
        {
            var response = await _mediator.Send(new GetSingleArticleQuery() { Title = title });
            return Ok(response);
        }

        [HttpPost("articles/create")]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand article)
        {
            if (article == null)
            {
                return BadRequest("Articolul nu poate fi nul.");
            }
            var response = await _mediator.Send(article);

            return Ok(response);
        }
    }
}