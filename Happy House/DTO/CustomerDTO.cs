namespace HappyHouse_Client.DTO
{
    internal class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public int NumberOfInstallments { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal DueThisMonth { get; set; }
    }
}
