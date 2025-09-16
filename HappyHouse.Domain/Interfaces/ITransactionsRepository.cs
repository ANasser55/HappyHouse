using HappyHouse.Domain.Entities;

namespace HappyHouse.Domain.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<int> AddCashTransaction(Transaction cash);
        Task<int> AddInstallmentTransaction(Transaction iTransaction);
        Task<IEnumerable<Transaction>> GetCustomerTransactionsAsync(int id);
        Task<IEnumerable<Transaction>> GetLedgerTransactionsAsync(int id);
    }
}