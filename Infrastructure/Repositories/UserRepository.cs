using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Application.Features.Users;
using Autenticul.Gaming.Application.Features.Users.Commands.RegisterUser;
using Autenticul.Gaming.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(GamingDbContext dbContext, IConfiguration configuration) : base(dbContext) 
        {
            _configuration = configuration;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _dbContext.Users.FirstAsync(x => x.UserName == userName);
        }

        public async Task<string> LoginUserAsync(UserDto user)
        {
            var dbUser = await GetByUserNameAsync(user.Username);
            var checkPassword = BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password);
            if(checkPassword)
            {
                return GenerateJwtToken(dbUser);
            }
            return "";
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("Id",user.Id.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> RegisterUserAsync(User user )
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return await this.AddAsync(user);
        }
    }
}
