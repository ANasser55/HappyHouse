using HappyHouse.Domain.Entities;

namespace HappyHouse.Domain.Interfaces
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<IEnumerable<Customer>> GetCustomersInstallments();
        Task<List<Customer>> SearchCustomers(string text);
    }
}