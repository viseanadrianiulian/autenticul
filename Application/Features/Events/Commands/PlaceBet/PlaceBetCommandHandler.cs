using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Autenticul.Gaming.Application.Features.Events.Commands.PlaceBet
{
    public class PlaceBetCommandHandler : IRequestHandler<PlaceBetCommand, PlaceBetCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBetRepository _betRepository;
        public PlaceBetCommandHandler(IMapper mapper, IEventRepository eventRepository, IUserRepository userRepository, IBetRepository betRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _betRepository = betRepository;
        }

        public async Task<PlaceBetCommandResponse> Handle(PlaceBetCommand command, CancellationToken cancellationToken)
        {
            var response = new PlaceBetCommandResponse();

            var userDb = await _userRepository.GetByUserNameAsync(command.NewBet.Username);
            command.NewBet = new BetDto();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            command.NewBet = JsonSerializer.Deserialize<BetDto>(command.NewBetString, options);

            var betToBeAdded = _mapper.Map<Bet>(command.NewBet);
            betToBeAdded.Event = await _eventRepository.GetLiveEventAsync();
            betToBeAdded.User = userDb;
            try
            {
                var newBet = await _betRepository.AddAsync(betToBeAdded);
                response.Success = true;

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
