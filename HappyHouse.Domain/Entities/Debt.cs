namespace HappyHouse.Domain.Entities
{
    public class Debt
    {
        public int DebtId { get; set; }
        public int DebtorId { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public string Description { get; set; }

        public Debtor Debtor { get; set; }


    }
}
