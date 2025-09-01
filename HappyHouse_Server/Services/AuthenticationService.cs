using HappyHouse_Server.Data;
using HappyHouse_Server.DTO;
using HappyHouse_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HappyHouse_Server.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly HappyHouseDbContext _Context;

        public AuthenticationService(JwtOptions jwtOptions, HappyHouseDbContext context)
        {
            _jwtOptions = jwtOptions;
            _Context = context;
        }

        public async Task<string> AuthenticateUser(UserDTO userDTO)
        {
            var account = _Context.Accounts.FirstOrDefault(x => x.Username == userDTO.Username || x.Email == userDTO.Username);
            if (account == null)
                return "";

            if (account.Password != userDTO.Password)
                return "";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Username),
                    new Claim(ClaimTypes.Email, account.Email ?? "a@Happy.com")
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var securityToken = tokenHandler.WriteToken(token);

            return securityToken;

        }
    }
}
