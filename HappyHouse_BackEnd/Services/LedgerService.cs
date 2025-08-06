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


        public async Task<List<Ledger>> GetAllLedgersAsync(DateTime date)
        {
            var ledgers = await _context.Ledgers.Where(x => x.Date == date).ToListAsync();

            return ledgers;
        }

    }
}
