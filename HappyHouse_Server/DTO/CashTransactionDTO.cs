namespace HappyHouse_Server.DTO
{
    public class CashTransactionDTO
    {
        public string TransactorName { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool IsExpense { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
    }
}
