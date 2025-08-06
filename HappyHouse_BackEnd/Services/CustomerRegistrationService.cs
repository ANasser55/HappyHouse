using HappyHouse_Server.Data;
using HappyHouse_Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HappyHouse_Server.Services
{
    public class CustomerRegistrationService
    {
        private readonly HappyHouseDbContext _context;

        public CustomerRegistrationService(HappyHouseDbContext context)
        {
            _context = context;
        }

        private async Task<int> AddLidger(DateTime date)
        {
            var ledger = await _context.Ledgers.FirstOrDefaultAsync(x => x.Date == date.Date);
            if (ledger == null)
            {
                ledger = new Ledger() { Date = date, };
                await _context.AddAsync(ledger);
                await _context.SaveChangesAsync();
            }

            return ledger.LedgerId;
        }

        public async Task AddNewCustomer(Customer customer, Installment installment, Transaction transaction)
        {
            

            var databaseTransaction = _context.Database.BeginTransaction();
            try
            {
                var customers = await _context.Customers.Where(x => x.CustomerName.Equals(customer.CustomerName)).ToListAsync();

                if (customers.IsNullOrEmpty())
                {
                    await _context.AddAsync(customer);
                    await _context.SaveChangesAsync();

                    installment.CustomerId = customer.CustomerId;

                    await _context.AddAsync(installment);
                    await _context.SaveChangesAsync();


                    
                    transaction.CustomerId = customer.CustomerId;
                    transaction.InstallmentId = installment.InstallmentId;
                    transaction.DebtorId = null;
                    transaction.LedgerId = await AddLidger(transaction.Date);
                    await _context.AddAsync(transaction);
                    await _context.SaveChangesAsync();

                    await databaseTransaction.CommitAsync();


                }
                else
                {
                    throw new Exception("Customer exist");
                }

            }
            catch (Exception ex)
            {

                await databaseTransaction.RollbackAsync();
                throw new Exception("something went wrong " + ex.Message);
            }

        }
    }
}
