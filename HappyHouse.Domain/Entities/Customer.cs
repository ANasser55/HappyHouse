namespace HappyHouse.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }

        public List<Installment>? Installments { get; set; }

    }
}
