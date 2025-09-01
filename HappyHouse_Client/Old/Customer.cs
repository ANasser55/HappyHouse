using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HappyHouse_Client.Old
{
    internal class CustomerOld
    {
        public required int customer_id { get; set; }
        public required string customer_name { get; set; }
        public string customer_phone { get; set; }
        public decimal customer_next_payment { get; set; }
        public decimal customer_total_remaining { get; set; }
    }

    internal class Customers_DAO
    {
        string connectionString = "Data Source=localhost;Initial Catalog=HappyHouse;Integrated Security=True; TrustServerCertificate=True;MultipleActiveResultSets=True;";

        public void calculate_installments()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand sql_sum_next_payment = new SqlCommand("SELECT     c.customer_id,      COALESCE(SUM(i.payment_per_month), 0) AS TotalPayments  FROM     customers c  LEFT JOIN     Installments i  ON c.customer_id = i.customer_id AND i.paid = 0  AND i.next_date < GETDATE()  GROUP BY     c.customer_id;     UPDATE     Customers SET     customer_next_payment = COALESCE(subquery.TotalPayments, 0)  FROM      (           SELECT             c.customer_id,              COALESCE(SUM(i.payment_per_month), 0) AS TotalPayments          FROM             Customers c         LEFT JOIN             Installments i  ON c.customer_id = i.customer_id AND i.paid = 0AND i.next_date < GETDATE()         GROUP BY             c.customer_id     ) subquery  WHERE     Customers.customer_id = subquery.customer_id;", connection);
            sql_sum_next_payment.ExecuteNonQuery();

            SqlCommand sql_sum_remaining = new SqlCommand("SELECT     c.customer_id,      COALESCE(SUM(i.remaining_amount), 0) AS TotalRemaining   FROM     customers c  LEFT JOIN     Installments i ON c.customer_id = i.customer_id  GROUP BY     c.customer_id;   UPDATE     Customers  SET     customer_remaining = COALESCE(subquery.TotalRemaining, 0)  FROM     (          SELECT             c.customer_id,              COALESCE(SUM(i.remaining_amount), 0) AS TotalRemaining          FROM             Customers c          LEFT JOIN             Installments i ON c.customer_id = i.customer_id          GROUP BY             c.customer_id     ) subquery  WHERE     Customers.customer_id = subquery.customer_id;", connection);
            sql_sum_remaining.ExecuteNonQuery();

            connection.Close();

        }

        public List<CustomerOld> getAllCustomers()
        {
            List<CustomerOld> customers = new List<CustomerOld>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            SqlCommand sql_all_cistomers = new SqlCommand("SELECT * FROM customers ORDER BY customer_name", connection);


            using (SqlDataReader reader = sql_all_cistomers.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustomerOld c = new CustomerOld
                    {
                        customer_id = reader.GetInt32(0),
                        customer_name = reader.GetString(1),
                        customer_phone = reader.GetString(2),
                        customer_next_payment = reader.GetDecimal(3),
                        customer_total_remaining = reader.GetDecimal(4),
                    };

                    customers.Add(c);
                }
            }

            connection.Close();

            return customers;
        }

        public List<CustomerOld> searchCustomers(string search_txt)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            List<CustomerOld> customers = new List<CustomerOld>();

            SqlCommand sql_search = new SqlCommand();
            sql_search.CommandText = "Select * from customers where customer_name LIKE @search";
            sql_search.Parameters.AddWithValue("@search", "%" + search_txt + "%");
            sql_search.Connection = connection;


            using (SqlDataReader reader = sql_search.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustomerOld c = new CustomerOld
                    {
                        customer_id = reader.GetInt32(0),
                        customer_name = reader.GetString(1),
                        customer_phone = reader.GetString(2),
                        customer_next_payment = reader.GetDecimal(3),
                        customer_total_remaining = reader.GetDecimal(4),
                    };

                    customers.Add(c);
                }

            }

            connection.Close();

            return customers;
        }


        public bool isCustomerExist(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            List<CustomerOld> customers = new List<CustomerOld>();

            SqlCommand sql_exist = new SqlCommand();
            sql_exist.CommandText = "SELECT COUNT(*) FROM customers WHERE customer_name = @CustomerName";
            sql_exist.Parameters.AddWithValue("@CustomerName", name);
            sql_exist.Connection = connection;

            int count = Convert.ToInt32(sql_exist.ExecuteScalar());
            connection.Close();

            if (count > 0)
                return true;
            else
                return false;


        }

        public int AddCustomer(string name, string phone, decimal amount, decimal remaining, DateTime date, string description)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            SqlCommand sql_add_customer = new SqlCommand();
            sql_add_customer.CommandText = "INSERT INTO customers (customer_name, customer_phone, customer_next_payment, customer_remaining) VALUES (@name, @phone, 0, 0); SELECT SCOPE_IDENTITY();";
            sql_add_customer.Parameters.AddWithValue("@name", name);
            sql_add_customer.Parameters.AddWithValue("@phone", phone);
            sql_add_customer.Connection = connection;

            int customer_id = Convert.ToInt32(sql_add_customer.ExecuteScalar());
            MessageBox.Show("id = " + customer_id);



            connection.Close();

            AddInstallment(customer_id, amount, remaining, date, description);

            return customer_id;
        }

        public void AddInstallment(int customer_id, decimal amount, decimal remaining, DateTime date, string description)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            DateTime next_date = date.AddMonths(1);

            SqlCommand sql_add_installment = new SqlCommand();
            sql_add_installment.CommandText = "INSERT INTO installments(customer_id, payment_per_month, amount, \r\nremaining_amount, start_date, next_date, description)\t\r\nVALUES (@customer_id, @amount, @remaining, @remaining, @start_date, @next_date, @description);";
            sql_add_installment.Parameters.AddWithValue("@customer_id", customer_id);
            sql_add_installment.Parameters.AddWithValue("@amount", amount);
            sql_add_installment.Parameters.AddWithValue("@remaining", remaining);
            sql_add_installment.Parameters.AddWithValue("@start_date", date.ToString("yyyy-MM-dd"));
            sql_add_installment.Parameters.AddWithValue("@next_date", next_date.ToString("yyyy-MM-dd"));
            sql_add_installment.Parameters.AddWithValue("@description", description);
            sql_add_installment.Connection = connection;

            MessageBox.Show("start date = " + date.ToString("yyyy-MM-dd") + " next date = " + next_date.ToString("yyyy-MM-dd"));

            sql_add_installment.ExecuteNonQuery();

            connection.Close();

        }


    }
}
