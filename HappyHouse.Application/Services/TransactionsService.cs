using HappyHouse.Application.DTOs;
using HappyHouse.Application.Interfaces;
using HappyHouse.Domain.Entities;
using HappyHouse.Domain.Interfaces;

namespace HappyHouse.Application.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _repository;

        public TransactionsService(ITransactionsRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<CustomerTransactionDTO>> GetCustomerTransactionsAsync(int id)
        {
            //var transactions = await _context.Transactions.Where(x => x.CustomerId == id).ToListAsync();
            //return transactions;

            var transactions =  await _repository.GetCustomerTransactionsAsync(id);
            var transactionDTO = transactions.Select(t => new CustomerTransactionDTO
            {
                TransactorName = t.TransactorName,
                Date = t.Date,
                Amount = t.Amount,
                Description = t.Description,
            }).ToList();
            return transactionDTO;
        }

        public async Task<IEnumerable<CashTransactionDTO>> GetLedgerTransactionsAsync(int id)
        {
            var transactions = await _repository.GetLedgerTransactionsAsync(id);
            var transactionsDTO = transactions
                .Select(t => new CashTransactionDTO
                {
                    TransactorName = t.TransactorName,
                    Date = t.Date,
                    Amount = t.Amount,
                    IsExpense = t.IsExpense,
                    TransactionType = t.IsExpense ? "مصروفات" : "دخل",
                    Description = t.Description
                }
                ).ToList();
            return transactionsDTO;
        }

        public async Task<int> AddCashTransaction(Transaction cash)
        {
            return await _repository.AddCashTransaction(cash);
            //var dbTransaction = _context.Database.BeginTransaction();

            //try
            //{
            //    var ledger = _context.Ledgers.FirstOrDefault(x => x.Date.Date == cash.Date.Date);
            //    if (ledger == null)
            //    {
            //        ledger = new Ledger { Date = cash.Date };
            //        await _context.Ledgers.AddAsync(ledger);
            //        await _context.SaveChangesAsync();
            //    }

            //    var tansaction = new Transaction
            //    {
            //        LedgerId = ledger.LedgerId,
            //        TransactorName = cash.TransactorName,
            //        Date = cash.Date,
            //        Amount = cash.Amount,
            //        IsExpense = cash.IsExpense,
            //        Description = cash.Description,
            //    };
            //    await _context.Transactions.AddAsync(tansaction);

            //    await _context.SaveChangesAsync();

            //    await dbTransaction.CommitAsync();
            //    return tansaction.TransactionId;

            //}
            //catch (Exception)
            //{
            //    await dbTransaction.RollbackAsync();
            //    return 0;
            //}
        }

        public async Task<int> AddInstallmentTransaction(Transaction iTransaction)
        {
            return await _repository.AddInstallmentTransaction(iTransaction);

            //var dbTransaction = _context.Database.BeginTransaction();

            //try
            //{
            //    var ledger = _context.Ledgers.FirstOrDefault(x => x.Date.Date == iTransaction.Date.Date);
            //    if (ledger == null)
            //    {
            //        ledger = new Ledger { Date = iTransaction.Date };
            //        await _context.Ledgers.AddAsync(ledger);
            //        await _context.SaveChangesAsync();
            //    }

            //    var tansaction = new Transaction
            //    {
            //        LedgerId = ledger.LedgerId,
            //        CustomerId = iTransaction.CustomerId,
            //        InstallmentId = iTransaction.InstallmentId,
            //        TransactorName = iTransaction.TransactorName,
            //        Date = iTransaction.Date,
            //        Amount = iTransaction.Amount,
            //        IsExpense = false,
            //        Description = iTransaction.Description,
            //    };

            //    await _context.Transactions.AddAsync(tansaction);
            //    await _context.SaveChangesAsync();

            //    var installment = _context.Installments.FirstOrDefault(x => x.InstallmentId == iTransaction.InstallmentId);
            //    installment.RemainingAmount = installment.RemainingAmount - iTransaction.Amount;
            //    if (installment.DueDate.Date > DateTime.Now.Date)
            //    {
            //        installment.isPaid = true;
            //    }
            //    else
            //    {
            //        installment.DueDate = installment.DueDate.AddMonths(1);
            //        installment.isPaid = false;
            //    }
            //    await _context.SaveChangesAsync();

            //    await dbTransaction.CommitAsync();
            //    return tansaction.TransactionId;

            //}
            //catch (Exception)
            //{
            //    await dbTransaction.RollbackAsync();
            //    return 0;
            //}
        }


    }
}
