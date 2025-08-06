using HappyHouse_Server.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace HappyHouse_Server.Services
{
    public class MonthInstallmentsService
    {
        private readonly HappyHouseDbContext _context;

        public MonthInstallmentsService(HappyHouseDbContext context)
        {
            _context = context;
        }


        public async Task<List<MonthInstallment>> GetMonthInstallmentsAsync()
        {
            var monthInstallments = await _context.MonthInstallments.ToListAsync();
            return monthInstallments;
        }
    }
}
