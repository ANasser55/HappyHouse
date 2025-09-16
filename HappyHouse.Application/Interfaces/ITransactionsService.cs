using HappyHouse.Application.DTOs;
using HappyHouse.Domain.Entities;

namespace HappyHouse.Application.Interfaces
{
    public interface ITransactionsService
    {
        //Task<List<Transaction>> GetAllTransactionsAsync();
        Task<IEnumerable<Transaction>> GetCustomerTransactionsAsync(int id);
        Task<IEnumerable<CashTransactionDTO>> GetLedgerTransactionsAsync(int id);
        Task<int> AddCashTransaction(Transaction cash);
        Task<int> AddInstallmentTransaction(Transaction cash);

    }
}