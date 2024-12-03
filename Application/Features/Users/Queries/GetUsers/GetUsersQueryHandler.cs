using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersQueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUsersQueryResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new GetUsersQueryResponse();

            var dbUsers = await _userRepository.GetAllAsync();
            response.Users = dbUsers.OrderByDescending(x=>x.Score).Select<User, UserDto>(x =>
                new UserDto()
                {
                    Username = x.UserName,
                    Score = x.Score,
                    LoginCounter = x.LoginCounter
                }
            ).ToList();
                

            return response;
        }
    }
}
