namespace HappyHouse_Server.Models
{
    public class Installment
    {
        public int InstallmentId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentPerMonth { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextDate { get; set; }
        public bool isPaid { get; set; }
        public string Description { get; set; }
        public int DelayDays
        {
            get
            {
                var delay = (DateTime.Now - NextDate).Days;
                return delay < 0 ? 0 : delay;
            }
        }
        public int RemainingInstallments
        {
            get
            {
                var totalMonths = (int)((RemainingAmount / PaymentPerMonth) + 0.5m);
                return totalMonths < 0 ? 0 : totalMonths;
            }
        }
        public Customer Customer { get; set; }
        
    }
}
