using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Persistence.Repositories;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace Autenticul.Gaming.Api.Controllers
{
    public class ControllerUpgraded : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ControllerUpgraded> _logger;

        public ControllerUpgraded(IUserRepository userRepository, ILogger<ControllerUpgraded> logger) : base()
        {
            this._userRepository = userRepository;
            this._logger = logger;
        }


        public async Task<bool> GetIsAdminState()
        {
            _logger.LogDebug("Inside GetIsAdminState: ");
            var adminId = new Guid("17d8ff1b-ac63-48cc-42f8-08dd12f5870b");
            var currentUser = await _userRepository.GetByUserNameAsync(HttpContext.User.Identity.Name);
            if(currentUser!=null)
            {
                _logger.LogDebug("Current user id: {0} and adminID: {1}", currentUser.Id.ToString(), adminId.ToString());
                if (currentUser == null)
                {
                    return false;
                }
                if (adminId == currentUser.Id)
                {
                    return true;
                }
               
            }
            return false;
        }
    }
}
