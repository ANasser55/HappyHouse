using HappyHouse_Server.Models;

namespace HappyHouse_Server.Interfaces
{
    public interface ITransactionsService
    {
        Task<List<Transaction>> GetAllTransactionsAsync();
        Task<List<Transaction>> GetCustomerTransactionsAsync(int id);
        Task<List<Transaction>> GetLedgerTransactionsAsync(int id);
    }
}