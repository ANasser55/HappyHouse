using HappyHouse_Server.DTO;

namespace HappyHouse_Server.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateUser(UserDTO userDTO);
    }
}