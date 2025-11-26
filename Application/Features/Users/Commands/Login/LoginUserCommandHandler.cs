using Autenticul.Gaming.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var response = new LoginUserCommandResponse();

            var userLogin = new UserDto() { Username = command.UserName, Password = command.Password };

            response.JWTToken = await _userRepository.LoginUserAsync(userLogin);
            if (String.IsNullOrWhiteSpace(response.JWTToken))
            {
                response.Success = false;
            }
            else
            {
                response.ExpiresIn = DateTime.Now.AddHours(2);
                if(userLogin.Username.StartsWith("s_"))
                {
                    response.IsStreamer = true;
                }
                else
                {
                    response.IsStreamer = false;
                }
                response.UserName = command.UserName;

            }
        
            if (!response.Success)
            {
                response.Message = "Login credentials are incorrect.";
            }
            return response;
        }
    }
}
