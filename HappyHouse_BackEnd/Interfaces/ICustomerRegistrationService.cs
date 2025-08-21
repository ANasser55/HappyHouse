using HappyHouse_Server.Models;

namespace HappyHouse_Server.Interfaces
{
    public interface ICustomerRegistrationService
    {
        Task AddNewCustomer(Customer customer, Installment installment, Transaction transaction);
    }
}