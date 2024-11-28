using Autenticul.Gaming.Application.Features.Users;
using Autenticul.Gaming.Application.Features.Users.Commands.Login;
using Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser;
using Autenticul.Gaming.Domain.Entities;
using AutoMapper;


namespace Autenticul.Gaming.Application.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, RegisterUserCommand>()
                .ReverseMap();
            CreateMap<User, LoginUserCommand>()
               .ReverseMap();
            CreateMap<User, UserDto>()
          .ReverseMap();
        }
    }
}
