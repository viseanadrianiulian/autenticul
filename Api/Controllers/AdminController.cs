using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Application.Features.Admin.Prizes.Commands.CreatePrize;
using Autenticul.Gaming.Application.Features.Admin.Prizes.Querries.GetActivePrize;
using Autenticul.Gaming.Application.Features.Events.Commands.CreateEvent;
using Autenticul.Gaming.Application.Features.Events.Querries.GetLiveEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerUpgraded
    {
        private readonly IMediator _mediator;
        public AdminController(IUserRepository userRepository, ILogger<ControllerUpgraded> logger, IMediator mediator) : base(userRepository, logger)
        {
            _mediator = mediator;
        }


        [HttpPost("create", Name = "CreatePrize")]
        [Authorize]
        public async Task<ActionResult<CreatePrizeCommandResponse>> CreatePrize([FromForm] CreatePrizeCommand createPrizeCommand)
        {
            var isAdmin = await GetIsAdminState();
            if (isAdmin)
            {
                var response = await _mediator.Send(createPrizeCommand);
                return Ok(response);
            }
            else
            {

                return Unauthorized();
            }
  
        }

        [HttpGet("activePrize", Name = "GetActivePrize")]
        [Authorize]
        public async Task<ActionResult<GetActivePrizeQueryResponse>> GetActivePrize()
        {
            var response = await _mediator.Send(new GetActivePrizeQuery());
            return Ok(response);
        }

    }
}
