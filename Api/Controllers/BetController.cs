using Autenticul.Gaming.Application.Features.Events.Commands.PlaceBet;
using Autenticul.Gaming.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("placebet", Name = "PlaceBet")]
        [Authorize]
        public async Task<ActionResult<PlaceBetCommandResponse>> PlaceBet([FromForm] PlaceBetCommand createBetCommand)
        {
            createBetCommand.NewBet = new();
            createBetCommand.NewBet.Username = HttpContext.User.Identity.Name;
            var response = await _mediator.Send(createBetCommand);         
            return Ok(response);
        }
    }
}
