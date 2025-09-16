using HappyHouse.Domain.Entities;

namespace HappyHouse.Domain.Interfaces
{
    public interface ICustomerRegistrationRepository
    {
        Task AddNewCustomer(Customer customer, Installment installment, Transaction transaction);
    }
}