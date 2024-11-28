using Autenticul.Gaming.Application.Features.Users.Commands.Login;
using Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser;
using Autenticul.Gaming.Application.Features.Users;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autenticul.Gaming.Application.Features.Events.Commands.CreateEvent;
using Autenticul.Gaming.Application.Features.Events;

namespace Autenticul.Gaming.Application.Profiles
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, CreateEventCommand>()
                .ReverseMap();
            CreateMap<Event, EventDto>()
                .ReverseMap();
        }
    }
}
