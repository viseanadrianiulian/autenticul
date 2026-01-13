using Autenticul.Gaming.Api.Utility;
using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Application.Features.Blog.Articles.Commands.CreateArticle;
using Autenticul.Gaming.Application.Features.Blog.Articles.Commands.UpdateArticle;
using Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetArticlesInCategoryName;
using Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetCategories;
using Autenticul.Gaming.Application.Features.Blog.Articles.Queries.GetSingleArticle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerUpgraded
    {
        private readonly IMediator _mediator;

        public BlogController(IUserRepository userRepository, ILogger<ControllerUpgraded> logger, IMediator mediator) : base(userRepository, logger)
        {
            _mediator = mediator;
        }


        // Get all articles in a category (ex: mama-si-bebe, dezvoltare-personala)
        [HttpGet("articles/{category}")]
        public async Task<IActionResult> GetArticles(string category)
        {
            var response = await _mediator.Send(new GetArticlesInCategoryNameQuery { CategoryName = category });
            return Ok(response);
        }

        // Get all categories
        [HttpGet("categories/all")]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _mediator.Send(new GetCategoriesQuery());
            return Ok(response);
        }

        // Get single article by slug (SEO-friendly)
        [HttpGet("articles/single/{slug}")]
        public async Task<IActionResult> GetSingleArticle(string slug)
        {
            var response = await _mediator.Send(new GetSingleArticleQuery { Slug = slug });
            if (response == null)
                return NotFound($"Article with slug '{slug}' not found.");

            response.IsAdmin = await GetIsAdminState();

            return Ok(response);
        }

        // Create new article (admin only)
        [HttpPost("articles/create")]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand article)
        {
            if (article == null)
                return BadRequest("Article cannot be null.");

            var response = await _mediator.Send(article);
            return Ok(response);
        }

        // Update article (admin only)
        [HttpPost("articles/update")]
        public async Task<IActionResult> UpdateArticle([FromBody] UpdateArticleCommand article)
        {
            if (article == null)
                return BadRequest("Article cannot be null.");

            var response = await _mediator.Send(article);
            return Ok(response);
        }
    }
}
