using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHouse_Client.Old
{
    internal class InstallmentsForThisMonth
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public int installment_id { get; set; }
        public decimal installment_amount { get; set; }
        public DateTime date { get; set; }
        public decimal remaining { get; set; }
        public string description { get; set; }
    }


    internal class InstallmentsForThisMonthDAO
    {
        string connectionString = "Data Source=localhost;Initial Catalog=HappyHouse;Integrated Security=True; TrustServerCertificate=True;MultipleActiveResultSets=True;";

        public List<InstallmentsForThisMonth> getMonthInstallments()
        {

            List<InstallmentsForThisMonth> installments = new List<InstallmentsForThisMonth>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            SqlCommand sql_month_installments = new SqlCommand("SELECT c.customer_id, c.customer_name,\t\r\n\ti.installment_id, i.payment_per_month, i.next_date, \r\n\ti.remaining_amount, i.description\r\n\tFROM customers c \r\n\t\tJOIN installments i \r\n\t\tON c.customer_id = i.customer_id \r\n\t\tWHERE i.paid = 0 AND i.next_date < GETDATE() ORDER BY c.customer_name; ", connection);


            using (SqlDataReader reader = sql_month_installments.ExecuteReader())
            {
                while (reader.Read())
                {
                    InstallmentsForThisMonth i = new InstallmentsForThisMonth
                    {
                        customer_id = reader.GetInt32(0),
                        customer_name = reader.GetString(1),
                        installment_id = reader.GetInt32(2),
                        installment_amount = reader.GetDecimal(3),
                        date = reader.GetDateTime(4),
                        remaining = reader.GetDecimal(5),
                        description = reader.GetString(6)

                    };

                    installments.Add(i);
                }
            }

            return installments;
        }
    }

}
