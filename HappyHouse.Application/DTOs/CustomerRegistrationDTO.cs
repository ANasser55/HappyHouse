using HappyHouse.Domain.Entities;

namespace HappyHouse.Application.DTOs
{
    public class CustomerRegistrationDTO
    {
        public Customer Customer {  get; set; }
        public Installment Installment { get; set; }
        public Transaction Transaction { get; set; }
    }
}
