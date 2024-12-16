using Autenticul.Gaming.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;


namespace Autenticul.Gaming.Application.Features.Admin.Prizes.Querries.GetActivePrize
{
    public class GetActivePrizeQueryHandler : IRequestHandler<GetActivePrizeQuery, GetActivePrizeQueryResponse>
    {
        private readonly IPrizeRepository _prizeRepository;
        private readonly IMapper _mapper;

        public GetActivePrizeQueryHandler(IPrizeRepository prizeRepository, IMapper mapper)
        {
            _prizeRepository = prizeRepository;
            _mapper = mapper;
        }

        public async Task<GetActivePrizeQueryResponse> Handle(GetActivePrizeQuery request, CancellationToken cancellationToken)
        {
            var response = new GetActivePrizeQueryResponse();

            var activePrize = await _prizeRepository.GetActivePrizeAsync();

            response.Prize = _mapper.Map<PrizeDto>(activePrize);

            return response;
        }
    }
}
