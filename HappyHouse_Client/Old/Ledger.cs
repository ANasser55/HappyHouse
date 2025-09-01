using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace HappyHouse_Client.Old
{
    internal class Ledger
    {
        public int ledger_id { get; set; }
        public DateTime date { get; set; }
        public decimal income { get; set; }
        public decimal expense { get; set; }
        public decimal safe_box { get; set; }
    }


    internal class Ledger_DAO
    {
        string connectionString = "Data Source=localhost;Initial Catalog=HappyHouse;Integrated Security=True; TrustServerCertificate=True;MultipleActiveResultSets=True;";

        public List<Ledger> GetLedgers()
        {
            List<Ledger> ledgers = new List<Ledger>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sql_all_ledgers = new SqlCommand("SELECT * FROM ledger ORDER BY date DESC;", sqlConnection);

            using (SqlDataReader reader = sql_all_ledgers.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ledger ledger = new Ledger
                    {
                        ledger_id = reader.GetInt32(0),
                        date = reader.GetDateTime(1),
                        income = reader.GetDecimal(2),
                        expense = reader.GetDecimal(3),
                        safe_box = reader.GetDecimal(4),
                    };

                    ledgers.Add(ledger);
                }
            }

            sqlConnection.Close();

            return ledgers;
        }

        public List<Ledger> search_ledger_date(DateTime date)
        {
            List<Ledger> ledgers = new List<Ledger>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();


            SqlCommand sql_search = new SqlCommand();
            sql_search.CommandText = "SELECT * FROM ledger WHERE CONVERT(VARCHAR, date, 23) = @search";
            sql_search.Parameters.AddWithValue("@search", date);
            sql_search.Connection = sqlConnection;

            using (SqlDataReader reader = sql_search.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ledger ledger = new Ledger
                    {
                        ledger_id = reader.GetInt32(0),
                        date = reader.GetDateTime(1),
                        income = reader.GetDecimal(2),
                        expense = reader.GetDecimal(3),
                        safe_box = reader.GetDecimal(4),
                    };

                    ledgers.Add(ledger);
                }
            }

            sqlConnection.Close();

            return ledgers;

        }

        internal void Calculate_inc_exp()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sql_inc = new SqlCommand("UPDATE ledger\r\nSET income = COALESCE(\r\n\t(\r\n\tSELECT SUM(t.transaction_amount)\r\n\tFROM transactions t \r\n\tWHERE t.ledger_id = ledger.ledger_id AND t.transaction_type <> N'مصروفات'\r\n\t),\r\n\t0\r\n\t);");
            sql_inc.Connection = sqlConnection;
            sql_inc.ExecuteNonQuery();

            SqlCommand sql_exp = new SqlCommand("UPDATE ledger\r\nSET expense = COALESCE(\r\n\t(\r\n\tSELECT SUM(t.transaction_amount)\r\n\tFROM transactions t \r\n\tWHERE t.ledger_id = ledger.ledger_id AND t.transaction_type = N'مصروفات'\r\n\t),\r\n\t0\r\n\t);");
            sql_exp.Connection = sqlConnection;
            sql_exp.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void CalculateSafeBox()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sql_safe = new SqlCommand("");
            sql_safe.Connection = sqlConnection;
            sql_safe.ExecuteNonQuery();
        }
    }

}
