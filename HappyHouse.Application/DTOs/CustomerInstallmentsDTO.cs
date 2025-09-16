using HappyHouse.Domain.Entities;

namespace HappyHouse.Application.DTOs
{
    public class CustomerInstallmentsDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfInstallments { get; set; }
        public List<InstallmentDTO> Installments { get; set; }
    }
}
