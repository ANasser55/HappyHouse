
using Microsoft.EntityFrameworkCore;
using HappyHouse.Application.Interfaces;
using HappyHouse.Domain.Interfaces;
using HappyHouse.Domain.Entities;
using HappyHouse.Application.DTOs;

namespace HappyHouse.Application.Services
{
    public class InstallmentsService : IInstallmentsService
    {
        private readonly IInstallmentsRepository _repository;

        public InstallmentsService(IInstallmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Installment>> GetAllInstallmentsAsync()
        {
            //var installments = await _repository.Installments.ToListAsync();
            return await _repository.GetAllInstallmentsAsync();
        }

        public async Task<List<InstallmentDTO>> GetCustomerInstallmentsAsync(int customerId)
        {
            var installments = await _repository.GetCustomerInstallmentsAsync(customerId);

            var installmentsDTO = installments.Where(i => i.CustomerId == customerId)
                .Select(i => new InstallmentDTO
                {
                    CustomerName = i.Customer.CustomerName,
                    TotalAmount = i.TotalAmount,
                    PaymentPerMonth = i.PaymentPerMonth,
                    RemainingAmount = i.RemainingAmount,
                    DueDate = i.DueDate,
                    DelayDays = Math.Max(0, (DateTime.Now.Date - i.DueDate.Date).Days),
                    RemainingInstallments = (int)(i.RemainingAmount / i.PaymentPerMonth + 0.5m),
                    Description = i.Description

                }).ToList();

            return installmentsDTO;
        }

        public async Task<List<InstallmentDTO>> GetMonthInstallmentsAsync()
        {
            var installments = await _repository.GetMonthInstallmentsAsync();
            var monthInstallments = new List<InstallmentDTO>();
            foreach (var installment in installments)
            {
                monthInstallments.Add(new InstallmentDTO
                {
                    CustomerName = installment.Customer.CustomerName,
                    TotalAmount = installment.TotalAmount,
                    PaymentPerMonth = installment.PaymentPerMonth,
                    DueDate = installment.DueDate,
                    RemainingAmount = installment.RemainingAmount,
                    DelayDays = Math.Max(0, (DateTime.Now.Date - installment.DueDate.Date).Days),
                    RemainingInstallments = (int)(installment.RemainingAmount / installment.PaymentPerMonth + 0.5m),
                    Description = installment.Description
                });
            }

            return monthInstallments;
        }

    }
}
