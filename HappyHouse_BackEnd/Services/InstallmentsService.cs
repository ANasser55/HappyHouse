using HappyHouse_Server.Data;
using HappyHouse_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyHouse_Server.Services
{
    public class InstallmentsService
    {
        private readonly HappyHouseDbContext _context;

        public InstallmentsService(HappyHouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Installment>> GetAllInstallmentsAsync()
        {
            var installments = await _context.Installments.ToListAsync();
            return installments;
        }

        public async Task<List<Installment>> GetCustomerInstallmentsAsync(int customerId)
        {
            var installments = await _context.Installments
                .Where(i => i.CustomerId == customerId)
                .ToListAsync();
            return installments;
        }
    }
}
