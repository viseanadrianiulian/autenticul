using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Persistence.Repositories;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{
    public class ControllerUpgraded(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> GetIsAdminState()
        {
            var adminId = new Guid("c37e9e97-16ad-4efc-3550-08dd0834301a");
            var currentUser = await _userRepository.GetByUserNameAsync(HttpContext.User.Identity.Name);
            if(currentUser == null)
            {
                return false;
            }
            if (adminId == currentUser.Id)
            {
                return true;
            }
            return false;
        }
    }
}
