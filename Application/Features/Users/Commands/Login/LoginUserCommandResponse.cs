using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Commands.Login
{
    public class LoginUserCommandResponse : BaseResponse
    {
        public string? JWTToken {  get; set; } = string.Empty;
        public DateTime? ExpiresIn { get; set; }
    }
}
