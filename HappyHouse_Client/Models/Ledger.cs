namespace HappyHouse_Client.Models
{
    public class Ledger
    {
        public int LedgerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        public decimal Balance { get; set; }
    }
}
