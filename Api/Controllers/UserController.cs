using Autenticul.Gaming.Application.Features.Users.Commands.Login;
using Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser;
using Autenticul.Gaming.Application.Features.Users.Queries.GetUserDetails;
using Autenticul.Gaming.Application.Features.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register", Name = "RegisterUser")]
        public async Task<ActionResult<RegisterUserCommandResponse>> Register([FromForm] RegisterUserCommand registerUserCommand)
        {
            var response = await _mediator.Send(registerUserCommand);
            return Ok(response);
            
        }

        [HttpPost("login", Name = "LoginUser")]
        public async Task<ActionResult<LoginUserCommandResponse>> Login([FromForm] LoginUserCommand loginUserCommand)
        {
            var response = await _mediator.Send(loginUserCommand);
            return Ok(response);
        }

       
        [HttpGet("details", Name = "UserDetails")]
        [Authorize]
        public async Task<ActionResult<GetUserDetailsQueryResponse>> Details()
        {
            var us = HttpContext.User;
            
            var response = await _mediator.Send(new GetUserDetailsQuery(us.Identity.Name));
            return Ok(response);
        }

        [HttpGet("users", Name = "Users")]
        [Authorize]
        public async Task<ActionResult<GetUsersQuery>> GetUsers()
        {
            var response = await _mediator.Send(new GetUsersQuery());
            return Ok(response);
        }
    }
}
