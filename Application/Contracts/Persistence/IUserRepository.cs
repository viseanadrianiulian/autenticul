using Autenticul.Gaming.Application.Features.Users;
using Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser;
using Autenticul.Gaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task<string> LoginUserAsync(UserDto user);
        Task<User> RegisterUserAsync(User user);
    }
}
