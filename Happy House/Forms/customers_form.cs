using HappyHouse_Client.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyHouse_Client
{
    public partial class customers_form : Form
    {
        private readonly HttpClient _client = new HttpClient();
        bool isFirst = true;

        public customers_form()
        {
            InitializeComponent();
            LoadCustomers();

        }

        private async Task<List<Customer>> GetCustomersAsync()
        {
            var url = "https://localhost:7176/api/Customers";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<Customer>>(responseBody);

                return customers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return new List<Customer>();
            }
        }


        private async Task LoadCustomers()
        {
                   
            var customers = await GetCustomersAsync();
            customersDataGridView.DataSource = customers;
            if (!customers.IsNullOrEmpty())
                CustomersDataGridStyle();

        }





        private async Task<List<Customer>> SearchCustomersAsync(string text)
        {
            var url = $"https://localhost:7176/api/Customers/search?text={text}";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<Customer>>(responseBody);

                return customers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return new List<Customer>();
            }

            
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            async Task HandleSearchAsync()
            {
                if (searchTextBox.Text.Length > 0)
                {
                    customersDataGridView.DataSource = await SearchCustomersAsync(searchTextBox.Text);
                    //CustomersDataGridStyle();
                }
                else
                {
                    LoadCustomers();
                }
            }

            HandleSearchAsync();
            xBtn.Visible = false;

        }

        public async Task<List<Transaction>> GetTransactionsByIdAsync(int id)
        {
            var url = $"https://localhost:7176/api/Transactions/getCustomerTransactions?id={id}";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var transactions = JsonConvert.DeserializeObject<List<Transaction>>(responseBody);
                if (transactions.IsNullOrEmpty())
                {
                    MessageBox.Show("لا توجد معاملات لهذا العميل");

                }
                return transactions;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
                //LoadCustomers();
                return new List<Transaction>();
            }
        }

        private async Task LoadTransactionsCustomer(int id)
        {
            var transactions = await GetTransactionsByIdAsync(id);
            customersDataGridView.DataSource = transactions;

            //TransactionDAO transactionDAO = new TransactionDAO();

            //customersBindingSource.DataSource = transactionDAO.GetTransactionsCustomer(id);
            //customersDataGridView.DataSource = customersBindingSource;


        }




        private void CustomersDataGridStyle()
        {
            customersDataGridView.RowTemplate.Height = 38;

            if (isFirst)
            {
                
                customersDataGridView.Columns["CustomerId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //customersDataGridView.Columns["NextPayment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["RemainingAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                customersDataGridView.Columns["CustomerId"].HeaderText = "كود العميل";
                customersDataGridView.Columns["CustomerName"].HeaderText = "إسم العميل";
                customersDataGridView.Columns["Phone"].HeaderText = "هاتف العميل";
                //customersDataGridView.Columns["NextPayment"].Visible = false;
                customersDataGridView.Columns["RemainingAmount"].HeaderText = "المتبقي عل العميل";
            }
            else 
            {

                customersDataGridView.Columns["TransactorName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



                customersDataGridView.Columns["TransactionId"].Visible = false;
                customersDataGridView.Columns["LedgerId"].Visible = false;
                customersDataGridView.Columns["CustomerId"].Visible = false;
                customersDataGridView.Columns["DebtorId"].Visible = false;
                customersDataGridView.Columns["Type"].Visible = false;
                customersDataGridView.Columns["TransactorName"].HeaderText = "إسم العميل";
                customersDataGridView.Columns["Date"].HeaderText = "التاريخ";
                customersDataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                customersDataGridView.Columns["Amount"].HeaderText = "الميلغ";
                customersDataGridView.Columns["Description"].HeaderText = "ملاحظات";
            }
        }


        private void customersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            async Task HandleDoubleClickAsync()
            {
                if (isFirst)
                {
                    ((Form1)this.ParentForm).ChangeTitle("سجل معاملات العميل");
                    isFirst = false;
                    xBtn.Visible = true;

                    DataGridView dataGridView = (DataGridView)sender;

                    int row_clicked = dataGridView.CurrentRow.Index;
                    int id = (int)dataGridView.Rows[row_clicked].Cells[0].Value;

                    await LoadTransactionsCustomer(id);
                    CustomersDataGridStyle();
                }
            }

            HandleDoubleClickAsync();
            
        }

        private void newCustomerBtn_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).ChangeTitle("عميل جديد");
            ((Form1)this.ParentForm).loadform(new new_customer_form());
        }


        private void xBtn_Click(object sender, EventArgs e)
        {
            isFirst = true;
            xBtn.Visible = false;
            searchTextBox.Text = "";

            ((Form1)this.ParentForm).ChangeTitle("العملاء");


            LoadCustomers();
        }

    }
}
