using HappyHouse_Server.Data;
using HappyHouse_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyHouse_Server.Services
{
    public class LedgerService
    {
        private readonly HappyHouseDbContext _context;

        public LedgerService(HappyHouseDbContext context)
        {
            _context = context;
        }


        public async Task<List<Ledger>> GetAllLedgersAsync()
        {
            await updateLedger();
            var ledgers = await _context.Ledgers.ToListAsync();


            return ledgers;
        }

        public async Task<List<Ledger>> GetLedgerByDateAsync(DateTime date)
        {
            var ledger = await _context.Ledgers.Where(x => x.Date == date).ToListAsync();
            return ledger;
        }

        private async Task<List<Ledger>> getLastLidgers()
        {
            var ledgers = await _context.Ledgers.FromSqlRaw("select top(5) * from ledger order by date desc").ToListAsync();
            return ledgers;
        }

        private async Task updateLedger()
        {
            var ledgers = await getLastLidgers();
            foreach (var ledger in ledgers)
            {
                ledger.Income = 0;
                ledger.Expense = 0;
                var transactions = _context.Transactions.Where(x => x.LedgerId == ledger.LedgerId);
                foreach (var transaction in transactions)
                {
                    if (transaction.Type == "دخل")
                    ledger.Income += transaction.Amount;
                    else if (transaction.Type == "مصروفات")
                        ledger.Expense += transaction.Amount;
                }
            }
            for (int i = ledgers.Count - 1; i > 0; i--)
            {
                var ledger = ledgers[i];
                var led = ledgers[i - 1];
                ledgers[i-1].Balance = ledgers[i].Balance + ledgers[i-1].Income - ledgers[i-1].Expense;
            }

            await _context.SaveChangesAsync();
        }

    }
}
