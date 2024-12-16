using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Admin.Prizes.Commands.CreatePrize
{
    public class CreatePrizeCommandHandler : IRequestHandler<CreatePrizeCommand, CreatePrizeCommandResponse>
    {
        private readonly IPrizeRepository _prizeRepository;

        public CreatePrizeCommandHandler(IPrizeRepository prizeRepository)
        {
            _prizeRepository = prizeRepository;
        }

        public async Task<CreatePrizeCommandResponse> Handle(CreatePrizeCommand command, CancellationToken cancellationToken)
        {
            var response = new CreatePrizeCommandResponse();

            var prizeToAdd = new Prize()
            {
                Value = command.Value,
                IsActive = true,
                Month = command.Month
            };
            await _prizeRepository.AddAsync(prizeToAdd);

            return response;
        }
    }
}
