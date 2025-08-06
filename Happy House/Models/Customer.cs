namespace HappyHouse_Client.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? Phone { get; set; }
        public decimal RemainingAmount { get; set; }
    }
}
