using HappyHouse.Domain.Entities;

namespace HappyHouse.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<string> AuthenticateUser(string username, string password);
    }
}