using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Commands.Login
{
    public class LoginUserCommand : IRequest<LoginUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
