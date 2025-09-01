using HappyHouse_Client.Models;


namespace HappyHouse_Client.DTO
{
    public class CustomerInstallmentsDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfInstallments { get; set; }
        public List<Installment> Installments { get; set; }
    }
}
