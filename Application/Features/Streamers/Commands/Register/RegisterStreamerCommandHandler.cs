using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Application.Features.Users;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Streamers.Commands.Register
{
    public class RegisterStreamerCommandHandler : IRequestHandler<RegisterStreamerCommand, RegisterStreamerCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;

        public RegisterStreamerCommandHandler(IUserRepository userRepository, IStreamerRepository streamerRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<RegisterStreamerCommandResponse> Handle(RegisterStreamerCommand command, CancellationToken cancellationToken)
        {
            var response = new RegisterStreamerCommandResponse();

            // check if username or email are taken
            var userToRegister = await _userRepository.GetByUserNameAsync(command.UserName);
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

            //create new user
            userToRegister = new User()
            {
                UserName = command.UserName,
                Email = command.Email,
                Password = command.Password,
                Score = 0,
                LoginCounter = 0
            };

            try
            {
                var newUser = await _userRepository.RegisterUserAsync(userToRegister);
                var streamerToRegister = await _streamerRepository.AddAsync(_mapper.Map<Streamer>(command));

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
