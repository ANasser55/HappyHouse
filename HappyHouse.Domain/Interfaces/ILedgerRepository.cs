using HappyHouse.Domain.Entities;

namespace HappyHouse.Domain.Interfaces
{
    public interface ILedgerRepository
    {
        Task<List<Ledger>> GetAllLedgersAsync();
        Task<List<Ledger>> GetLedgerByDateAsync(DateTime date);
    }
}