using HappyHouse.Application.DTOs;

namespace HappyHouse.Application.Interfaces
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        Task<IEnumerable<CustomerDTO>> SearchCustomers(string text);
        Task<IEnumerable<CustomerInstallmentsDTO>> GetCustomersInstallments();

    }
}