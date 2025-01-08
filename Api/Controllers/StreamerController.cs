using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Application.Features.Streamers.Commands.Register;
using Autenticul.Gaming.Application.Features.Streamers.Querries.GetStreamerDetails;
using Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StreamerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StreamerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register", Name = "RegisterStreamer")]
        public async Task<ActionResult<RegisterStreamerCommandResponse>> Register([FromForm] RegisterStreamerCommand registerStreamerCommand)
        {
            var response = await _mediator.Send(registerStreamerCommand);
            return Ok(response);

        }

        [HttpGet("details", Name = "GetStreamerDetails")]
        public async Task<ActionResult<GetStreamerDetailsQueryResponse>> Details([FromQuery] string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Username-ul nu poate fi gol.");
            }

            var query = new GetStreamerDetailsQuery { UserName = username };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound($"Nu s-au găsit detalii pentru streamerul cu username-ul {username}.");
            }

            return Ok(result);
        }

    }
}
