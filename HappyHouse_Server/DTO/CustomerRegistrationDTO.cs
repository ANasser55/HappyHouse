using HappyHouse_Server.Models;

namespace HappyHouse_Server.DTO
{
    public class CustomerRegistrationDTO
    {
        public Customer Customer {  get; set; }
        public Installment Installment { get; set; }
        public Transaction Transaction { get; set; }
    }
}
