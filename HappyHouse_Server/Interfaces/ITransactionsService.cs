using HappyHouse_Server.DTO;
using HappyHouse_Server.Models;

namespace HappyHouse_Server.Interfaces
{
    public interface ITransactionsService
    {
        //Task<List<Transaction>> GetAllTransactionsAsync();
        Task<List<Transaction>> GetCustomerTransactionsAsync(int id);
        Task<List<CashTransactionDTO>> GetLedgerTransactionsAsync(int id);
        Task<int> AddCashTransaction(CashTransactionDTO cash);
        Task<int> AddInstallmentTransaction(InstallmentTransactionDTO cash);

    }
}