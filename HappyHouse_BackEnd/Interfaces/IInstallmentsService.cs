using HappyHouse_Server.DTO;
using HappyHouse_Server.Models;

namespace HappyHouse_Server.Interfaces
{
    public interface IInstallmentsService
    {
        Task<List<Installment>> GetAllInstallmentsAsync();
        Task<List<InstallmentDTO>> GetCustomerInstallmentsAsync(int customerId);
        Task<List<InstallmentDTO>> GetMonthInstallmentsAsync();
    }
}