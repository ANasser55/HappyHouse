using HappyHouse_Server.Data;
using HappyHouse_Server.DTO;
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

        public async Task<List<MonthInstallmentDTO>> GetMonthInstallmentsAsync()
        {
            var installments = await _context.Installments.Where(i => i.isPaid == false).Where(i => i.NextDate <= DateTime.Now).Include(i => i.Customer).ToListAsync();
            var monthInstallments = new List<MonthInstallmentDTO>();
            foreach (var installment in installments)
            {
                monthInstallments.Add(new MonthInstallmentDTO
                {
                    CustomerName = installment.Customer.CustomerName,
                    TotalAmount = installment.TotalAmount,
                    PaymentPerMonth = installment.PaymentPerMonth,
                    NextDate = installment.NextDate,
                    DelayDays = installment.DelayDays,
                    RemainingAmount = installment.RemainingAmount,
                    RemainingInstallments = installment.RemainingInstallments,
                    Description = installment.Description
                });
            }

            return monthInstallments;
        }

    }
}
