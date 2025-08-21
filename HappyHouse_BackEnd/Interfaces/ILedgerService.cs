using HappyHouse_Server.Models;

namespace HappyHouse_Server.Interfaces
{
    public interface ILedgerService
    {
        Task<List<Ledger>> GetAllLedgersAsync();
        Task<List<Ledger>> GetLedgerByDateAsync(DateTime date);
    }
}