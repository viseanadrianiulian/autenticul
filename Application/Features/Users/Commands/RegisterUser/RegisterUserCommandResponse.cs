using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandResponse : BaseResponse
    {
        public RegisterUserCommandResponse() : base() { }
        public UserDto? CreatedUser { get; set; } = default;
    }
}
