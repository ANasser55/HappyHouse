using HappyHouse.Domain.Entities;

namespace HappyHouse.Domain.Interfaces
{
    public interface IInstallmentsRepository
    {
        Task<List<Installment>> GetAllInstallmentsAsync();
        Task<List<Installment>> GetCustomerInstallmentsAsync(int customerId);
        Task<List<Installment>> GetMonthInstallmentsAsync();
    }
}