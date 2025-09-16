using HappyHouse.Domain;
using HappyHouse.Domain.Entities;
using HappyHouse.Domain.Interfaces;
using HappyHouse.Infrastructure.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HappyHouse.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly JwtOptions _jwtOptions;
        private readonly HappyHouseDbContext _Context;

        public AuthenticationRepository(IOptions<JwtOptions> jwtOptions, HappyHouseDbContext context)
        {
            _jwtOptions = jwtOptions.Value;
            _Context = context;
        }

        public async Task<string> AuthenticateUser(string username, string password)
        {

            var user = _Context.Accounts.FirstOrDefault(x => x.Username == username || x.Email == username);
            if (user == null)
                return "";

            if (user.Password != password)
                return "";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Email, user.Email ?? "a@Happy.com")
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var securityToken = tokenHandler.WriteToken(token);

            return securityToken;

        }
    }
}
