using Microsoft.EntityFrameworkCore;
using HappyHouse.Application.Interfaces;
using HappyHouse.Domain.Interfaces;
using HappyHouse.Domain.Entities;


namespace HappyHouse.Application.Services
{
    public class LedgerService : ILedgerService
    {
        private readonly ILedgerRepository _repository;

        public LedgerService(ILedgerRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<Ledger>> GetAllLedgersAsync()
        {
            //await updateLedger();
            //var ledgers = await _repository.Ledgers.OrderByDescending(x => x.Date).ToListAsync();


            //return ledgers;

            return await _repository.GetAllLedgersAsync();
        }

        public async Task<List<Ledger>> GetLedgerByDateAsync(DateTime date)
        {
            //var ledger = await _repository.Ledgers.Where(x => x.Date == date).ToListAsync();
            //return ledger;

            return await _repository.GetLedgerByDateAsync(date);
        }

        //private async Task<List<Ledger>> getLastLidgers()
        //{
        //    var ledgers = await _repository.Ledgers.FromSqlRaw("select top(5) * from ledger order by date desc").ToListAsync();
        //    return ledgers;
        //}

        //private async Task updateLedger()
        //{
        //    var ledgers = await getLastLidgers();
        //    foreach (var ledger in ledgers)
        //    {
        //        ledger.Income = 0;
        //        ledger.Expense = 0;
        //        //var transactions = _context.Transactions.Where(x => x.LedgerId == ledger.LedgerId);
        //        var transactions = _repository.Transactions.Where(x => x.LedgerId == ledger.LedgerId)
        //            .Select(t => new
        //            {
        //                LedgerId = t.LedgerId,
        //                IsExpense = t.IsExpense,
        //                Amount = t.Amount
        //            });
        //        foreach (var transaction in transactions)
        //        {
        //            if (transaction.IsExpense == false)
        //                ledger.Income += transaction.Amount;
        //            else if (transaction.IsExpense == true)
        //                ledger.Expense += transaction.Amount;
        //        }
        //    }
        //    for (int i = ledgers.Count - 1; i > 0; i--)
        //    {
        //        var ledger = ledgers[i];
        //        var led = ledgers[i - 1];
        //        ledgers[i - 1].Balance = ledgers[i].Balance + ledgers[i - 1].Income - ledgers[i - 1].Expense;
        //    }

        //    await _repository.SaveChangesAsync();
        //}

    }
}
