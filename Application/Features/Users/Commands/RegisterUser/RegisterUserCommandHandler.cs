using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var response = new RegisterUserCommandResponse();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            command.NewUser = JsonSerializer.Deserialize<UserDto>(command.NewUserString!, options);

            try
            {
                command.NewUser.Score = 0;
                var userToRegister = _mapper.Map<User>(command.NewUser);
                var newUser = await _userRepository.RegisterUserAsync(userToRegister);
                newUser.LoginCounter = 0;
                response.CreatedUser = _mapper.Map<UserDto>(newUser);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
         
            return response;
        }
    }
}
