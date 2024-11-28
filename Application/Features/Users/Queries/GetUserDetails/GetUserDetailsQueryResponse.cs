using Autenticul.Gaming.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryResponse : BaseResponse
    {
        public UserDto? UserDetails { get; set; }

        public GetUserDetailsQueryResponse() : base() { } 
        
    }
}
