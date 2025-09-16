using Microsoft.EntityFrameworkCore;
using HappyHouse.Infrastructure.Data;
using HappyHouse.Domain.Entities;
using HappyHouse.Domain.Interfaces;

namespace HappyHouse.Infrastructure.Repositories
{
    public class InstallmentsRepository : IInstallmentsRepository
    {
        private readonly HappyHouseDbContext _context;

        public InstallmentsRepository(HappyHouseDbContext context)
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
            //var installments = await _context.Installments.Where(i => i.CustomerId == customerId)
            //    .Select(i => new InstallmentDTO
            //    {
            //        CustomerName = i.Customer.CustomerName,
            //        TotalAmount = i.TotalAmount,
            //        PaymentPerMonth = i.PaymentPerMonth,
            //        RemainingAmount = i.RemainingAmount,
            //        DueDate = i.DueDate,
            //        DelayDays = Math.Max(0, (DateTime.Now.Date - i.DueDate.Date).Days),
            //        RemainingInstallments = (int)(i.RemainingAmount / i.PaymentPerMonth + 0.5m),
            //        Description = i.Description

            //    }).ToListAsync();
            var installments = await _context.Installments.Where(i => i.CustomerId == customerId).Include(i => i.Customer).ToListAsync();

            return installments;
        }

        public async Task<List<Installment>> GetMonthInstallmentsAsync()
        {
            //var installments = await _context.Installments.Where(i => i.isPaid == false)
            //    .Where(i => i.DueDate <= DateTime.Now).Include(i => i.Customer).ToListAsync();
            //var monthInstallments = new List<Installment>();
            //foreach (var installment in installments)
            //{
            //    monthInstallments.Add(new InstallmentDTO
            //    {
            //        CustomerName = installment.Customer.CustomerName,
            //        TotalAmount = installment.TotalAmount,
            //        PaymentPerMonth = installment.PaymentPerMonth,
            //        DueDate = installment.DueDate,
            //        RemainingAmount = installment.RemainingAmount,
            //        DelayDays = Math.Max(0, (DateTime.Now.Date - installment.DueDate.Date).Days),
            //        RemainingInstallments = (int)(installment.RemainingAmount / installment.PaymentPerMonth + 0.5m),
            //        Description = installment.Description
            //    });
            //}

            var monthInstallments = await _context.Installments.Where(i => i.isPaid == false)
                .Where(i => i.DueDate <= DateTime.Now).Include(i => i.Customer).ToListAsync();

            return monthInstallments;
        }

    }
}
