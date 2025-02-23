using Autenticul.Gaming.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Events.Querries.GetLiveEvent
{
    public class GetLiveEventQueryHandler : IRequestHandler<GetLiveEventQuery, GetLiveEventQueryResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IBetRepository _betRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetLiveEventQueryHandler(IEventRepository eventRepository, IMapper mapper, IBetRepository betRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _betRepository = betRepository;
            _userRepository = userRepository;
        }

        public async Task<GetLiveEventQueryResponse> Handle(GetLiveEventQuery request, CancellationToken cancellationToken)
        {
            var response = new GetLiveEventQueryResponse();

            var currentUser = await _userRepository.GetByUserNameAsync(request.UserName);
            var userBets = _betRepository.GetAllBetsForUser(currentUser.Id);

            response.PastEvents = new List<EventDto>();
            foreach (var xbet in userBets)
            {
                response.PastEvents.Add(_mapper.Map<EventDto>(xbet.Event));
            }

            var liveEvent = await _eventRepository.GetLiveEventAsync();
            if(liveEvent == null)
            {
                return response;
            }
            response.LiveEvent = _mapper.Map<EventDto>(liveEvent);

            var bet = liveEvent.Bets.FirstOrDefault(x => x.EventId == liveEvent.Id && x.UserId == currentUser.Id );
            if (bet != null)
            {
                response.UserBet = new BetDto();
                response.UserBet.Choice = bet.Choice;
                response.UserBet.IsWon = bet.IsWon;
            }

            return response;
        }
    }
}
