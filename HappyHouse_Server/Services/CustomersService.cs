using HappyHouse_Server.Data;
using HappyHouse_Server.DTO;
using HappyHouse_Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HappyHouse_Server.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly HappyHouseDbContext _context;

        public CustomersService(HappyHouseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {

            var customers = await _context.Customers
                .Select(c => new CustomerDTO
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Phone = c.Phone,
                    NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
                    RemainingAmount = c.Installments.Sum(i => i.RemainingAmount),
                    DueThisMonth = c.Installments.Sum(i => i.PaymentPerMonth)
                })
                .ToListAsync();
            return customers;
        }

        public async Task<IEnumerable<CustomerInstallmentsDTO>> GetCustomersInstallments()
        {

            var customers = await _context.Customers
                .Select(c => new CustomerInstallmentsDTO
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
                    Installments = c.Installments
                })
                .OrderBy(x => x.CustomerName)
                .ToListAsync();

            return customers;
        }

        public async Task<List<CustomerDTO>> SearchCustomers(string text)
        {
            var customers = await _context.Customers.Where(x => x.CustomerName.Contains(text))
                .Select(c => new CustomerDTO
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Phone = c.Phone,
                    NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
                    RemainingAmount = c.Installments.Sum(i => i.RemainingAmount),
                    DueThisMonth = c.Installments.Sum(i => i.PaymentPerMonth)
                })
                .ToListAsync();
            return customers;
        }



    }
}
