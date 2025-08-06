using HappyHouse_Server.Data;
using HappyHouse_Server.Models;

namespace HappyHouse_Server.Services
{
    public class AddInstallmentService
    {
        private readonly HappyHouseDbContext _context;

        public AddInstallmentService(HappyHouseDbContext context)
        {
            _context = context;
        }


        public async Task AddNewInstallmentAsync(Installment installment)
        {
            if (installment == null)
            {
                throw new ArgumentNullException(nameof(installment), "Installment cannot be null");
            }
            _context.Installments.Add(installment);
            await _context.SaveChangesAsync();

        }
    }
}

