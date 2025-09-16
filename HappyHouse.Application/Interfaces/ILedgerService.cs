using HappyHouse.Domain.Entities;

namespace HappyHouse.Application.Interfaces
{
    public interface ILedgerService
    {
        Task<List<Ledger>> GetAllLedgersAsync();
        Task<List<Ledger>> GetLedgerByDateAsync(DateTime date);
    }
}