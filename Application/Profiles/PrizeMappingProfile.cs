using Autenticul.Gaming.Application.Features.Events.Commands.CreateEvent;
using Autenticul.Gaming.Application.Features.Events;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autenticul.Gaming.Application.Features.Admin.Prizes;

namespace Autenticul.Gaming.Application.Profiles
{
    public class PrizeMappingProfile : Profile
    {
        public PrizeMappingProfile()
        {
            CreateMap<Prize, PrizeDto>()
                .ReverseMap();
        }
    }
}
