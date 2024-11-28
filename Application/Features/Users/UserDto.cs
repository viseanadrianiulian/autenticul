using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Score { get; set; }
        public int LoginCounter {  get; set; }
    }
}
