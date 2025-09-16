using HappyHouse.Application.DTOs;
using HappyHouse.Domain.Entities;

namespace HappyHouse.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateUser(UserDTO userDTO);
    }
}