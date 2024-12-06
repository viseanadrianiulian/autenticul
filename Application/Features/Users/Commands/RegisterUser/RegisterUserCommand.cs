using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterUserCommandResponse>
    { 
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Email-ul nu este valid.")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
