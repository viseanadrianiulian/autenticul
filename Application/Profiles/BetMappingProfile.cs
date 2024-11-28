using Autenticul.Gaming.Application.Features.Events.Commands.CreateEvent;
using Autenticul.Gaming.Application.Features.Events;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autenticul.Gaming.Application.Features.Events.Commands.PlaceBet;

namespace Autenticul.Gaming.Application.Profiles
{
    public class BetMappingProfile : Profile
    {
        public BetMappingProfile()
        {
            CreateMap<Bet, PlaceBetCommand>()
                .ReverseMap();
            CreateMap<Bet, BetDto>()
                .ReverseMap();
        }
    }
}
