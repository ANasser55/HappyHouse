using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHouse_Client.Old
{
    internal class Report
    {
        public string customer_name { get; set; }
        public decimal amount { get; set; }
        public decimal pay_per_month { get; set; }
        public decimal remaining_amount { get; set; }
        public decimal january { get; set; }
        public decimal february { get; set; }
        public decimal march { get; set; }
        public decimal april { get; set; }
        public decimal may { get; set; }
        public decimal june { get; set; }
        public decimal july { get; set; }
        public decimal august { get; set; }
        public decimal september { get; set; }
        public decimal october { get; set; }
        public decimal november { get; set; }
        public decimal december { get; set; }

    }

    class Reports_DAO()
    {

        string connectionString = "Data Source=localhost;Initial Catalog=HappyHouse;Integrated Security=True; TrustServerCertificate=True;MultipleActiveResultSets=True;";

        private List<decimal> CalculateMonthsPayments(int installment_id, int start, int end, SqlConnection connection)
        {
            List<decimal> months = new List<decimal>(Enumerable.Repeat(0m, 13));
            string date_str;

            for (int i = start; i <= end; i++)
            {
                SqlCommand sql_calc_m = new SqlCommand("SELECT i.installment_id, l.date, t.transaction_amount\r\nFROM installments i\r\nJOIN transactions t ON i.installment_id = t.installment_id\r\nJOIN ledger l ON l.ledger_id = t.ledger_id\r\nWHERE i.installment_id = @installment_id\r\nAND YEAR(l.date) = @date\r\nORDER BY l.date DESC;", connection);
                sql_calc_m.Parameters.AddWithValue("@installment_id", installment_id);
                sql_calc_m.Parameters.AddWithValue("@date", i);

                using (SqlDataReader reader = sql_calc_m.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        months[0] = reader.GetInt32(0);
                        date_str = reader.GetDateTime(1).ToString("MM");
                        switch (date_str)
                        {
                            case "01":
                                months[1] += reader.GetDecimal(2);
                                break;

                            case "02":
                                months[2] += reader.GetDecimal(2);
                                break;

                            case "03":
                                months[3] += reader.GetDecimal(2);
                                break;

                            case "04":
                                months[4] += reader.GetDecimal(2);
                                break;

                            case "05":
                                months[5] += reader.GetDecimal(2);
                                break;

                            case "06":
                                months[6] += reader.GetDecimal(2);
                                break;

                            case "07":
                                months[7] += reader.GetDecimal(2);
                                break;

                            case "08":
                                months[8] += reader.GetDecimal(2);
                                break;

                            case "09":
                                months[9] += reader.GetDecimal(2);
                                break;

                            case "10":
                                months[10] += reader.GetDecimal(2);
                                break;

                            case "11":
                                months[11] += reader.GetDecimal(2);
                                break;

                            case "12":
                                months[12] += reader.GetDecimal(2);
                                break; ;
                        }
                    }
                }
            }

            return months;
        }

        private List<int> GetInstallmentsIDs(SqlConnection connection)
        {
            List<int> ids = new List<int>();
            


            SqlCommand sql_installments_ids = new SqlCommand("SELECT i.installment_id FROM installments i", connection);

            using (SqlDataReader reader = sql_installments_ids.ExecuteReader())
            {
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0));
                }
            }

            
            return ids;
        }

        private Report GetCstomerInfo(int installment_id,Report report,SqlConnection connection)
        {
            


            SqlCommand sql_Info = new SqlCommand("SELECT c.customer_name, i.amount, i.payment_per_month,\r\ni.remaining_amount\r\nFROM customers c\r\nJOIN installments i ON i.customer_id = c.customer_id\r\nWHERE i.installment_id = @installment_id\r\nORDER BY c.customer_name;", connection);
            sql_Info.Parameters.AddWithValue("@installment_id", installment_id);

            using (SqlDataReader reader = sql_Info.ExecuteReader())
            {
                while (reader.Read())
                {
                    report.customer_name = reader.GetString(0);
                    report.amount = reader.GetDecimal(1);
                    report.pay_per_month = reader.GetDecimal(2);
                    report.remaining_amount = reader.GetDecimal(3);
                }
            }
            return report;
        }



        public List<Report> GetReports(int start, int end)
        {

            List<Report> reports = new List<Report>();
            List<int> installments_ids = new List<int>();


            List<decimal> months = new List<decimal>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            installments_ids = GetInstallmentsIDs(connection);

            foreach (int id in installments_ids)
            {
                months = CalculateMonthsPayments(id, start, end, connection);

                Report report = new Report();
                report.january = months[1];
                report.february = months[2];
                report.march = months[3];
                report.april = months[4];
                report.may = months[5];
                report.june = months[6];
                report.july = months[7];
                report.august = months[8];
                report.september = months[9];
                report.october = months[10];
                report.november = months[11];
                report.december = months[12];

                reports.Add(GetCstomerInfo(id, report, connection));

                reports = reports.OrderBy(r => r.customer_name).ToList();

            }
            connection.Close();
            return reports;

        }
    }
}
