using Microsoft.EntityFrameworkCore;
using HappyHouse.Infrastructure.Data;
using HappyHouse.Domain.Entities;
using HappyHouse.Domain.Interfaces;



namespace HappyHouse.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly HappyHouseDbContext _context;

        public CustomersRepository(HappyHouseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            //var customers = await _context.Customers
            //    .Select(c => new CustomerD
            //    {
            //        CustomerId = c.CustomerId,
            //        CustomerName = c.CustomerName,
            //        Phone = c.Phone,
            //        NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
            //        RemainingAmount = c.Installments.Sum(i => i.RemainingAmount),
            //        DueThisMonth = c.Installments.Sum(i => i.PaymentPerMonth)
            //    })
            //    .ToListAsync();

            var customers = await _context.Customers.Include(c => c.Installments)
                .OrderBy(x => x.CustomerName).ToListAsync();
            return customers;
        }

        public async Task<IEnumerable<Customer>> GetCustomersInstallments()
        {

            //var customers = await _context.Customers
            //    .Select(c => new CustomerInstallmentsDTO
            //    {
            //        CustomerId = c.CustomerId,
            //        CustomerName = c.CustomerName,
            //        NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
            //        Installments = c.Installments
            //    })
            //    .OrderBy(x => x.CustomerName)
            //    .ToListAsync();

            var customers = await _context.Customers
                .OrderBy(x => x.CustomerName).ToListAsync();

            return customers;
        }

        public async Task<List<Customer>> SearchCustomers(string text)
        {
            //var customers = await _context.Customers.Where(x => x.CustomerName.Contains(text))
            //    .Select(c => new CustomerDTO
            //    {
            //        CustomerId = c.CustomerId,
            //        CustomerName = c.CustomerName,
            //        Phone = c.Phone,
            //        NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
            //        RemainingAmount = c.Installments.Sum(i => i.RemainingAmount),
            //        DueThisMonth = c.Installments.Sum(i => i.PaymentPerMonth)
            //    })
            //    .ToListAsync();

            var customers = await _context.Customers.Where(x => x.CustomerName.Contains(text))
                .Include(c => c.Installments)
                .OrderBy(x => x.CustomerName).ToListAsync();

            return customers;

        }



    }
}
