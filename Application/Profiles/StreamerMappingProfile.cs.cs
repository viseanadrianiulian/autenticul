using Autenticul.Gaming.Application.Features.Streamers;
using Autenticul.Gaming.Application.Features.Streamers.Commands.Register;
using Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Profiles
{
    public class StreamerMappingProfile : Profile
    {
        public StreamerMappingProfile()
        {
            CreateMap<Streamer, RegisterStreamerCommand>().ReverseMap();
            CreateMap<StreamerDto, Streamer>().ReverseMap();
        }
    }
}
