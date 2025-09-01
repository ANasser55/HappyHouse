using HappyHouse_Server.DTO;

namespace HappyHouse_Server.Interfaces
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        Task<List<CustomerDTO>> SearchCustomers(string text);
        Task<IEnumerable<CustomerInstallmentsDTO>> GetCustomersInstallments();

    }
}