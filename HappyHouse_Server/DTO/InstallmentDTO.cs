namespace HappyHouse_Server.DTO
{
    public class InstallmentDTO
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentPerMonth { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime DueDate { get; set; }
        public int DelayDays { get; set; }
        public int RemainingInstallments { get; set; }
        public string Description { get; set; }

    }
}
