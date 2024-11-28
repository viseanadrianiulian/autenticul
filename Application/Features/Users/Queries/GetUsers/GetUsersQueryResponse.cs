using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryResponse : BaseResponse
    {
        public IList<UserDto> Users { get; set; }
    }
}
