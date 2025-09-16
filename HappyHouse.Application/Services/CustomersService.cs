using HappyHouse.Application.Interfaces;
using HappyHouse.Application.DTOs;
using HappyHouse.Domain.Interfaces;

namespace HappyHouse.Application.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomersService(ICustomersRepository repository)
        {
            _customerRepository = repository;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();

            var customersDTO = customers
                .Select(c => new CustomerDTO
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Phone = c.Phone,
                    NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
                    RemainingAmount = c.Installments.Sum(i => i.RemainingAmount),
                    DueThisMonth = c.Installments.Sum(i => i.PaymentPerMonth)
                }).ToList();
            return customersDTO;
        }

        public async Task<IEnumerable<CustomerInstallmentsDTO>> GetCustomersInstallments()
        {
            var customers = await _customerRepository.GetAllCustomers();

            var customersDTO = customers
                .Select(c => new CustomerInstallmentsDTO
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
                    Installments = c.Installments.Select( i => new InstallmentDTO
                    {
                        InstallmentId = i.InstallmentId,
                        CustomerName = c.CustomerName,
                        TotalAmount = i.TotalAmount,
                        PaymentPerMonth = i.PaymentPerMonth,
                        RemainingAmount= i.RemainingAmount,
                        DueDate = i.DueDate,
                        DelayDays = Math.Max(0, (DateTime.Now.Date - i.DueDate.Date).Days),
                        RemainingInstallments = (int)(i.RemainingAmount / i.PaymentPerMonth + 0.5m),
                        Description = i.Description,
                    }).ToList()
                })
                .OrderBy(x => x.CustomerName).ToList();

            return customersDTO;
        }

        public async Task<IEnumerable<CustomerDTO>> SearchCustomers(string text)
        {
            var customers = await _customerRepository.SearchCustomers(text);

            var customersDTO = customers
                .Select(c => new CustomerDTO
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Phone = c.Phone,
                    NumberOfInstallments = c.Installments.Count(i => i.RemainingAmount > 0),
                    RemainingAmount = c.Installments.Sum(i => i.RemainingAmount),
                    DueThisMonth = c.Installments.Sum(i => i.PaymentPerMonth)
                }).ToList();
            return customersDTO;
        }



    }
}
