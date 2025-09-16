using HappyHouse.Application.DTOs;
using HappyHouse.Domain.Entities;

namespace HappyHouse.Application.Interfaces
{
    public interface IInstallmentsService
    {
        Task<List<Installment>> GetAllInstallmentsAsync();
        Task<List<InstallmentDTO>> GetCustomerInstallmentsAsync(int customerId);
        Task<List<InstallmentDTO>> GetMonthInstallmentsAsync();
    }
}