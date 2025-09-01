using HappyHouse_Server.Data;
using HappyHouse_Server.DTO;
using HappyHouse_Server.Interfaces;
using HappyHouse_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyHouse_Server.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly HappyHouseDbContext _context;

        public TransactionsService(HappyHouseDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Transaction>> GetAllTransactionsAsync()
        //{
        //    var transactions = await _context.Transactions.ToListAsync();
        //    return transactions;
        //}
        public async Task<List<Transaction>> GetCustomerTransactionsAsync(int id)
        {
            var transactions = await _context.Transactions.Where(x => x.CustomerId == id).ToListAsync();
            return transactions;
        }

        public async Task<List<CashTransactionDTO>> GetLedgerTransactionsAsync(int id)
        {
            var transactions = await _context.Transactions.Where(x => x.LedgerId == id)
                .Select(t =>  new CashTransactionDTO
                {
                    TransactorName = t.TransactorName,
                    Date = t.Date,
                    Amount = t.Amount,
                    IsExpense = t.IsExpense,
                    TransactionType = t.IsExpense ? "مصروفات" : "دخل",
                    Description = t.Description
                }
                ).ToListAsync();
            return transactions;
        }

        public async Task<int> AddCashTransaction(CashTransactionDTO cash)
        {
            var dbTransaction = _context.Database.BeginTransaction();

            try
            {
                var ledger = _context.Ledgers.FirstOrDefault(x => x.Date.Date == cash.Date.Date);
                if (ledger == null)
                {
                    ledger = new Ledger { Date = cash.Date };
                    await _context.Ledgers.AddAsync(ledger);
                    await _context.SaveChangesAsync();
                }

                var tansaction = new Transaction
                {
                    LedgerId = ledger.LedgerId,
                    TransactorName = cash.TransactorName,
                    Date = cash.Date,
                    Amount = cash.Amount,
                    IsExpense = cash.IsExpense,
                    Description = cash.Description,
                };
                await _context.Transactions.AddAsync(tansaction);

                await _context.SaveChangesAsync();

                await dbTransaction.CommitAsync();
                return tansaction.TransactionId;

            }
            catch (Exception)
            {
                await dbTransaction.RollbackAsync();
                return 0;
            }
        }

        public async Task<int> AddInstallmentTransaction(InstallmentTransactionDTO installment)
        {
            var dbTransaction = _context.Database.BeginTransaction();

            try
            {
                var ledger = _context.Ledgers.FirstOrDefault(x => x.Date.Date == installment.Date.Date);
                if (ledger == null)
                {
                    ledger = new Ledger { Date = installment.Date };
                    await _context.Ledgers.AddAsync(ledger);
                    await _context.SaveChangesAsync();
                }

                var tansaction = new Transaction
                {
                    LedgerId = ledger.LedgerId,
                    CustomerId = installment.CustomerId,
                    InstallmentId = installment.InstallmentId,
                    TransactorName = installment.TransactorName,
                    Date = installment.Date,
                    Amount = installment.Amount,
                    IsExpense = false,
                    Description = installment.Description,
                };
                await _context.Transactions.AddAsync(tansaction);

                await _context.SaveChangesAsync();

                await dbTransaction.CommitAsync();
                return tansaction.TransactionId;

            }
            catch (Exception)
            {
                await dbTransaction.RollbackAsync();
                return 0;
            }
        }


    }
}
