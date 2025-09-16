using HappyHouse.Application.DTOs;
using HappyHouse.Domain.Entities;

namespace HappyHouse.Application.Interfaces
{
    public interface ICustomerRegistrationService
    {
        Task AddNewCustomer(CustomerRegistrationDTO registrationDTO);
    }
}