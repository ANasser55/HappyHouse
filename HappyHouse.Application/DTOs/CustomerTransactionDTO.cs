namespace HappyHouse.Application.DTOs
{
    public class CustomerTransactionDTO
    {
        public string TransactorName { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

    }
}
