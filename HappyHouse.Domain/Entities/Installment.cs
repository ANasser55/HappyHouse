namespace HappyHouse.Domain.Entities
{
    public class Installment
    {
        public int InstallmentId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentPerMonth { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool isPaid { get; set; }
        public string Description { get; set; }

        public Customer? Customer { get; set; }

    }
}
