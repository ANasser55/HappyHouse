using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using HappyHouse.Application.Interfaces;
using HappyHouse.Domain.Interfaces;
using HappyHouse.Domain.Entities;
using HappyHouse.Application.DTOs;

namespace HappyHouse.Application.Services
{
    public class CustomerRegistrationService : ICustomerRegistrationService
    {
        private readonly ICustomerRegistrationRepository repository;

        public CustomerRegistrationService(ICustomerRegistrationRepository repository)
        {
            this.repository = repository;
        }

        //private async Task<int> AddLidger(DateTime date)
        //{
        //    var ledger = await repository.Ledgers.FirstOrDefaultAsync(x => x.Date == date.Date);
        //    if (ledger == null)
        //    {
        //        ledger = new Ledger() { Date = date, };
        //        await repository.AddAsync(ledger);
        //        await repository.SaveChangesAsync();
        //    }

        //    return ledger.LedgerId;
        //}

        public async Task AddNewCustomer(CustomerRegistrationDTO registrationDTO)
        {
            await repository.AddNewCustomer(registrationDTO.Customer, registrationDTO.Installment, registrationDTO.Transaction);

            //    var databaseTransaction = repository.Database.BeginTransaction();
            //    try
            //    {
            //        var customers = await repository.Customers.Where(x => x.CustomerName.Equals(customer.CustomerName)).ToListAsync();

            //        if (customers.IsNullOrEmpty())
            //        {
            //            await repository.AddAsync(customer);
            //            await repository.SaveChangesAsync();

            //            installment.CustomerId = customer.CustomerId;

            //            await repository.AddAsync(installment);
            //            await repository.SaveChangesAsync();



            //            transaction.CustomerId = customer.CustomerId;
            //            transaction.InstallmentId = installment.InstallmentId;
            //            transaction.DebtorId = null;
            //            transaction.LedgerId = await AddLidger(transaction.Date);
            //            await repository.AddAsync(transaction);
            //            await repository.SaveChangesAsync();

            //            await databaseTransaction.CommitAsync();


            //        }
            //        else
            //        {
            //            throw new Exception("Customer exist");
            //        }

            //    }
            //    catch (Exception ex)
            //    {

            //        await databaseTransaction.RollbackAsync();
            //        throw new Exception("something went wrong " + ex.Message);
            //    }

        }
    }
}
