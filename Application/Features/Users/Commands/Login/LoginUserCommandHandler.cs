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

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            command.UserLogin = JsonSerializer.Deserialize<UserDto>(command.UserLoginString!, options);
            if (command.UserLogin != null)
            {

                response.JWTToken = await _userRepository.LoginUserAsync(command.UserLogin);
                response.ExpiresIn = DateTime.Now.AddHours(2);
                if(String.IsNullOrWhiteSpace(response.JWTToken))
                {
                    response.Success = false;
                }
                else
                {
                    var dbUser = await _userRepository.GetByUserNameAsync(command.UserLogin.Username);
                   
                }

            }
            if (!response.Success)
            {
                response.Message = "Login credentials are incorrect.";
            }
            return response;
        }
    }
}
