using Autenticul.Gaming.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Streamers.Querries.GetStreamerDetails
{
    public class GetStreamerDetailsQueryHandler : IRequestHandler<GetStreamerDetailsQuery, GetStreamerDetailsQueryResponse>
    {

        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;

        public GetStreamerDetailsQueryHandler(IStreamerRepository streamerRepository, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<GetStreamerDetailsQueryResponse> Handle(GetStreamerDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetStreamerDetailsQueryResponse();

            var streamer = await _streamerRepository.GetByUserNameAsync(request.UserName);

            response.StreamerDetails = _mapper.Map<StreamerDto>(streamer);

            return response;
        }
    }
}
