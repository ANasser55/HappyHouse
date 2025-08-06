using HappyHouse_Server.Data;
using HappyHouse_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyHouse_Server.Services
{
    public class CustomersService
    {
        private readonly HappyHouseDbContext _context;

        public CustomersService(HappyHouseDbContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }
            return customer;
        }

        public async Task<List<Customer>> SearchCustomer(string text)
        {
            var customers = await _context.Customers.Where(x => x.CustomerName.Contains(text)).ToListAsync();
            return customers;
        }



        //public async Task AddCustomer(Customer customer)
        //{
        //    _context.Add(customer);
        //    _context.SaveChanges();
        //}

    }
}
