namespace HappyHouse_Server.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int? CustomerId { get; set; }
        public int? InstallmentId { get; set; }
        public int? DebtorId { get; set; }
        public int? LedgerId { get; set; }
        public DateTime Date { get; set; }
        public string TransactorName { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }


        public Customer? Customer { get; set; }
        public Installment? Installment { get; set; }
        public Debtor? Debtor { get; set; }
        public Ledger? Ledger { get; set; }

    }
}
