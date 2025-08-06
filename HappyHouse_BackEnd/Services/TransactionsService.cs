using HappyHouse_Server.Data;
using HappyHouse_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyHouse_Server.Services
{
    public class TransactionsService
    {
        private readonly HappyHouseDbContext _context;

        public TransactionsService(HappyHouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllTranactionsAsync()
        {
            var tranactions = await _context.Transactions.ToListAsync();
            return tranactions;
        }
        public async Task<List<Transaction>> GetCustomerTransactionsAsync(int id)
        {
            var transactions = await _context.Transactions.Where(x => x.CustomerId == id).ToListAsync();
            return transactions;
        }

        public async Task<List<Transaction>> GetLedgerTransactionsAsync(int id)
        {
            var transactions = await _context.Transactions.Where(x => x.LedgerId == id).ToListAsync();
            return transactions;
        }

    }
}
