using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<GetUserDetailsQueryResponse>
    {
        public string? UserName { get; set; }

        public GetUserDetailsQuery(string userName) : base()
        {
            this.UserName = userName;
        }
    }
}
