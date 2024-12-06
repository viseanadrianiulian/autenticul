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
            var userToRegister = await _userRepository.GetByUserNameAsync(command.Username);
            if (userToRegister != null)
            {
                response.Success = false;
                response.Message = "Exista deja un user cu acest username.";
                return response;
            }
            userToRegister = await _userRepository.GetByEmailAsync(command.Email);
            if (userToRegister != null)
            {
                response.Success = false;
                response.Message = "Exista deja un user cu acest email.";
                return response;
            }

            userToRegister = new User()
            {
                UserName = command.Username,
                Email = command.Email,
                Password = command.Password,
                Score = 0,
                LoginCounter = 0
            };
            try
            {
                var newUser = await _userRepository.RegisterUserAsync(userToRegister);
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
