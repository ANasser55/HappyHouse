using HappyHouse.Application.DTOs;
using HappyHouse.Application.Interfaces;
using HappyHouse.Domain.Entities;
using HappyHouse.Domain.Interfaces;
using System.Security.Claims;
using System.Text;

namespace HappyHouse.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _repository;

        public AuthenticationService(IAuthenticationRepository context)
        {
            _repository = context;
        }

        public async Task<string> AuthenticateUser(UserDTO userDTO)
        {
            //var account = _repository.Accounts.FirstOrDefault(x => x.Username == userDTO.Username || x.Email == userDTO.Username);
            //if (account == null)
            //    return "";

            //if (account.Password != userDTO.Password)
            //    return "";

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Issuer = _jwtOptions.Issuer,
            //    Audience = _jwtOptions.Audience,
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)), SecurityAlgorithms.HmacSha256),
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, account.Username),
            //        new Claim(ClaimTypes.Email, account.Email ?? "a@Happy.com")
            //    })
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var securityToken = tokenHandler.WriteToken(token);

            var securityToken = await _repository.AuthenticateUser(userDTO.Username, userDTO.Password);
            return securityToken;

        }
    }
}
