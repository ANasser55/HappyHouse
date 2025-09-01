using HappyHouse_Server.Models;

namespace HappyHouse_Server.DTO
{
    public class CustomerInstallmentsDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfInstallments { get; set; }
        public List<Installment> Installments { get; set; }
    }
}
