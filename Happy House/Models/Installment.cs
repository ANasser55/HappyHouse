namespace HappyHouse_Client.Models
{
    public class Installment
    {
        public int InstallmentId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public decimal PaymentPerMonth { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextDate { get; set; }
        public bool isPaid { get; set; }
        public string Description { get; set; }
    }
}
