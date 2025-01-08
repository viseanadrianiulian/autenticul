using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Streamers.Commands.Register
{
    public class RegisterStreamerCommand : IRequest<RegisterStreamerCommandResponse>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string Interests { get; set; }
        public string UsualHours { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
        public string YoutubeChannel1 { get; set; }
        public string YoutubeChannel1Url { get; set; }
        public string YoutubeChannel2 { get; set; }
        public string YoutubeChannel2Url { get; set; }
        public string TwitchChannel { get; set; }
        public string TwitchUrl { get; set; }
        public string InstagramName { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookName { get; set; }
        public string FacebookUrl { get; set; }
        public string TiktokName { get; set; }
        public string TiktokUrl { get; set; }
    }
}
