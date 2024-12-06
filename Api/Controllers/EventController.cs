using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Application.Features.Events.Commands.CloseEvent;
using Autenticul.Gaming.Application.Features.Events.Commands.CreateEvent;
using Autenticul.Gaming.Application.Features.Events.Commands.PlaceBet;
using Autenticul.Gaming.Application.Features.Events.Commands.SaveEventResult;
using Autenticul.Gaming.Application.Features.Events.Commands.StopBets;
using Autenticul.Gaming.Application.Features.Events.Querries.GetAllPastEvents;
using Autenticul.Gaming.Application.Features.Events.Querries.GetLiveEvent;
using Autenticul.Gaming.Domain.Entities;
using Autenticul.Gaming.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerUpgraded
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<EventController> _logger;

        public EventController(IMediator mediator, IUserRepository userRepository, ILogger<EventController> logger) : base(userRepository, logger)
        {
            _mediator = mediator;
        }

        [HttpGet("getallpastevents", Name = "GetAllPastEvents")]
        [Authorize]
        public async Task<ActionResult<GetAllPastEventsQueryResponse>> GetAllPastEvents()
        {
            var response = await _mediator.Send(new GetAllPastEventsQuery());

            return Ok(response);
        }

        [HttpPost("create", Name = "CreateEvent")]
        [Authorize]
        public async Task<ActionResult<CreateEventCommandResponse>> Create([FromForm] CreateEventCommand createEventCommand)
        {
            var response = await _mediator.Send(createEventCommand);
            return Ok(response);
        }

        [HttpGet("liveevent", Name = "GetLiveEvent")]
        [Authorize]
        public async Task<ActionResult<GetLiveEventQueryResponse>> GetLiveEvent()
        {
            var response = await _mediator.Send(new GetLiveEventQuery(HttpContext.User.Identity.Name));
            response.IsAdmin = await GetIsAdminState();
            return Ok(response);
        }

        [HttpPost("saveeventresult", Name = "SaveEventResult")]
        [Authorize]
        public async Task<ActionResult<SaveEventResultCommandResponse>> SaveEventResult([FromForm] SaveEventResultCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("stopbets", Name = "StopBets")]
        [Authorize]
        public async Task<ActionResult<StopBetsCommandResponse>> StopBets([FromForm] StopBetsCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("closeevent", Name = "CloseEvent")]
        [Authorize]
        public async Task<ActionResult<CloseEventCommandResponse>> CloseEvent([FromForm] CloseEventCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }



    }
}
