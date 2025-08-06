using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HappyHouse_Client.Old
{
    internal class Transaction
    {
        public int transaction_id { get; set; }
        public int customer_id { get; set; }
        public int ledger_id { get; set; }
        public int debtor_id { get; set; }
        public DateTime date { get; set; }
        public string transactor_name { get; set; }
        public decimal amount { get; set; }
        public string type { get; set; }
        public string description { get; set; }

        
    }


    internal class TransactionDAO
    {
        string connectionString = "Data Source=localhost;Initial Catalog=HappyHouse;Integrated Security=True; TrustServerCertificate=True;MultipleActiveResultSets=True;";

        public List<Transaction> GetTransactionsLedger(int i)
        {
            List<Transaction> transactions = new List<Transaction>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand sqlGetTransactions = new SqlCommand("SELECT t.transaction_id,l.ledger_id , l.date AS ledger_date, t.transactor_name,t.transaction_amount, t.transaction_type,t.transaction_description FROM transactions t JOIN ledger l ON t.ledger_id = l.ledger_id WHERE l.ledger_id = " + i, connection);

            using (SqlDataReader reader = sqlGetTransactions.ExecuteReader())
            {
                while (reader.Read())
                {
                    Transaction transaction = new Transaction();

                    transaction.transaction_id = reader.GetInt32(0);
                    transaction.ledger_id = reader.GetInt32(1);
                    transaction.date = reader.GetDateTime(2);
                    transaction.transactor_name = reader.GetString(3);
                    transaction.amount = reader.GetDecimal(4);
                    transaction.type = reader.GetString(5);
                    transaction.description = reader.GetString(6);

                    transactions.Add(transaction);
                }
            }

                connection.Close();

            return transactions;
        }

        public List<Transaction> GetTransactionsCustomer(int id)
        {
            List<Transaction> transactions = new List<Transaction>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand sqlGetTransactions = new SqlCommand("SELECT t.transaction_id, t.customer_id, t.transactor_name,\r\n\t\tl.date, t.transaction_amount, t.transaction_description\r\nFROM transactions t join ledger l ON t.ledger_id = l.ledger_id\r\nWHERE customer_id = " + id  , connection);

            using (SqlDataReader reader = sqlGetTransactions.ExecuteReader())
            {
                while (reader.Read())
                {
                    Transaction transaction = new Transaction();

                    transaction.transaction_id = reader.GetInt32(0);
                    transaction.customer_id = reader.GetInt32(1);
                    transaction.transactor_name = reader.GetString(2);
                    transaction.date = reader.GetDateTime(3);     
                    transaction.amount = reader.GetDecimal(4);
                    transaction.description = reader.GetString(5);

                    transactions.Add(transaction);
                }
            }

            connection.Close();

            return transactions;
        }

        public bool IsDateExist(string date)
        {
            int d = 0;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sql_Is_exist = new SqlCommand("SELECT COUNT(*) FROM ledger WHERE date = @date;", connection);
            sql_Is_exist.Parameters.AddWithValue("@date", date);

            using (SqlDataReader reader = sql_Is_exist.ExecuteReader())
            {
                while (reader.Read())
                {
                    d = reader.GetInt32(0);
                }
            }
            if (d == 0)
            {
                return false;
            }
            else 
            {
                return  true;
            }

        }
        private int AddLedger(string date)
        {
            int ledger_id = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (!IsDateExist(date))
            {
                SqlCommand AddLedger = new SqlCommand("INSERT INTO ledger (date) VALUES (@date); SELECT SCOPE_IDENTITY();", connection);
                AddLedger.Parameters.AddWithValue("@date", date);

                ledger_id = Convert.ToInt32(AddLedger.ExecuteScalar());
            }
            else
            {
                SqlCommand get_ledger_id = new SqlCommand("SELECT l.ledger_id FROM ledger l WHERE l.date = @date", connection);
                get_ledger_id.Parameters.AddWithValue("@date", date);

                using (SqlDataReader reader = get_ledger_id.ExecuteReader())
                    while (reader.Read())
                    {
                        ledger_id = reader.GetInt32(0);
                    }
            }

            return ledger_id;
        }

        public void AddCashTransaction(string date, decimal amount, string description)
        {
            int ledger_id = AddLedger(date);

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand AddCashTransaction  = new SqlCommand("INSERT INTO transactions(ledger_id, transactor_name, \r\n\t\t\ttransaction_amount, transaction_type, transaction_description)\r\nVALUES(@ledger_id, N'كاش', @amount, N'كاش', @description);", connection);
            AddCashTransaction.Parameters.AddWithValue("@ledger_id", ledger_id);
            AddCashTransaction.Parameters.AddWithValue("@amount", amount);
            AddCashTransaction.Parameters.AddWithValue("description", description);

            AddCashTransaction.ExecuteNonQuery();
            connection.Close();

        }

        public void AddExpensesTransaction(string date, decimal amount, string description)
        {
            int ledger_id = AddLedger(date);
            

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand addExpensesTransaction = new SqlCommand("INSERT INTO transactions(ledger_id, transactor_name,\r\n\t\t\t\t\t\ttransaction_amount, transaction_type, transaction_description)\r\n\t\t\t\t\t\tVALUES(@ledger_id, N'مصروفات', @amount, N'مصروفات', @description);", connection);
            addExpensesTransaction.Parameters.AddWithValue("@ledger_id", ledger_id);
            addExpensesTransaction.Parameters.AddWithValue("@amount", amount);
            addExpensesTransaction.Parameters.AddWithValue("description", description);

            addExpensesTransaction.ExecuteNonQuery();
            connection.Close();
        }


        public void AddAdvanceTransaction(string date, int customer_id, string name, decimal amount) 
        {
            int ledger_id = AddLedger(date);

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand add_installment_transaction = new SqlCommand("INSERT INTO transactions(customer_id, ledger_id, transactor_name,\r\n\t\t\ttransaction_amount, transaction_type, transaction_description)\r\nVALUES(@customer_id, @ledger_id, @name, @amount, N'كاش', N'مقدم قسط جديد')", connection);
            add_installment_transaction.Parameters.AddWithValue("@customer_id", customer_id);
            add_installment_transaction.Parameters.AddWithValue("@ledger_id", ledger_id);
            add_installment_transaction.Parameters.AddWithValue("@name", name);
            add_installment_transaction.Parameters.AddWithValue("@amount", amount);

            add_installment_transaction.ExecuteNonQuery();

            connection.Close();


        }

        public void AddInstallmentTransaction(string customer_name, string date, int customer_id, int installment_id, decimal amount, string description)
        {
            int ledger_id = AddLedger(date);

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand Add_Installment_Transaction = new SqlCommand("INSERT INTO transactions \r\n(customer_id, transactor_name, installment_id, ledger_id,\r\ntransaction_amount, transaction_type, transaction_description)\r\nVALUES(@customer_id, @customer_name, @installment_id, @ledger_id, @amount,\r\nN'قسط', @description)", connection);
            Add_Installment_Transaction.Parameters.AddWithValue("@customer_id", customer_id);
            Add_Installment_Transaction.Parameters.AddWithValue("@customer_name", customer_name);
            Add_Installment_Transaction.Parameters.AddWithValue("@installment_id", installment_id);
            Add_Installment_Transaction.Parameters.AddWithValue("@ledger_id", ledger_id);
            Add_Installment_Transaction.Parameters.AddWithValue("@amount", amount);
            Add_Installment_Transaction.Parameters.AddWithValue("@description", description);

            Add_Installment_Transaction.ExecuteNonQuery();

            UpdateInstallment(installment_id, amount, connection);

            connection.Close();
        }

        private void UpdateInstallment(int installment_id, decimal amount, SqlConnection connection)
        {
            SqlCommand update_remaining = new SqlCommand("UPDATE installments\r\nSET remaining_amount = remaining_amount - @amount\r\nWHERE installment_id = @installment_id", connection);
            update_remaining.Parameters.AddWithValue("@amount", amount);
            update_remaining.Parameters.AddWithValue("@installment_id", installment_id);

            update_remaining.ExecuteNonQuery();

            SqlCommand update_next_date = new SqlCommand("UPDATE installments\r\nSET next_date = DATEADD(MONTH, 1, next_date)\r\nWHERE installment_id = @installment_id\r\nAND (YEAR(GETDATE()) > YEAR(next_date) OR (YEAR(GETDATE()) = YEAR(next_date) AND MONTH(GETDATE()) >= MONTH(next_date)));", connection);
            update_next_date.Parameters.AddWithValue("@installment_id", installment_id);

            update_next_date.ExecuteNonQuery();
        }



    }
}
