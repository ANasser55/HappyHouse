using Microsoft.IdentityModel.Tokens;

namespace HappyHouse_Server.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }

        public List<Installment>? Installments { get; set; }

    }
}
