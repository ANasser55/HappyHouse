using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHouse_Client.Old
{
    internal class InstallmentsForCustomer
    {
        public string customer_name { get; set; }
        public int installment_id { get; set; }
        public decimal installment_amount { get; set; }
        public DateTime next_date { get; set; }
        public decimal remaining { get; set; }
        public string description { get; set; }
    }


    internal class InstallmentsForCustomerDAO
    {
        string connectionString = "Data Source=localhost;Initial Catalog=HappyHouse;Integrated Security=True; TrustServerCertificate=True;MultipleActiveResultSets=True;";

        public List<InstallmentsForCustomer> getCustomerInstallments(int id)
        {

            List<InstallmentsForCustomer> installments = new List<InstallmentsForCustomer>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            SqlCommand sql_customer_installments = new SqlCommand("SELECT c.customer_name, i.installment_id ,\r\n\ti.payment_per_month, i.next_date, i.remaining_amount, i.description FROM installments i \r\nJOIN customers c ON i.customer_id = c.customer_id\r\nWHERE  i.customer_id = " + id +"\r\nORDER BY i.customer_id", connection);


            using (SqlDataReader reader = sql_customer_installments.ExecuteReader())
            {
                while (reader.Read())
                {
                    InstallmentsForCustomer i = new InstallmentsForCustomer
                    {
                        customer_name = reader.GetString(0),
                        installment_id = reader.GetInt32(1),
                        installment_amount = reader.GetDecimal(2),
                        next_date = reader.GetDateTime(3),
                        remaining = reader.GetDecimal(4),
                        description = reader.GetString(5)

                    };

                    installments.Add(i);
                }
            }

            return installments;
        }
    }

}
