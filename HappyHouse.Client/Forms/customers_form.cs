using HappyHouse.Application.DTOs;
using HappyHouse.Domain.Entities;
using HappyHouse_Client.Authentication;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;


namespace HappyHouse_Client
{
    public partial class customers_form : Form
    {
        private readonly HttpClient _client = new HttpClient();
        bool isFirst = true;

        public customers_form()
        {
            InitializeComponent();
            LoadCustomersAsync();
        }

        private async Task<List<CustomerDTO>> GetCustomersAsync()
        {
            var url = "https://localhost:7298/api/Customers";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerDTO>>(responseBody);

                return customers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return new List<CustomerDTO>();
            }
        }


        private async Task LoadCustomersAsync()
        {
                   
            var customers = await GetCustomersAsync();
            customersDataGridView.DataSource = customers;
            if (!customers.IsNullOrEmpty())
                CustomersDataGridStyle();

        }

        private async Task<List<CustomerDTO>> SearchCustomersAsync(string text)
        {
            var url = $"https://localhost:7298/api/Customers/search?text={text}";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerDTO>>(responseBody);

                return customers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return new List<CustomerDTO>();
            }

            
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            async void HandleSearchAsync()
            {
                if (searchTextBox.Text.Length > 0)
                {
                    customersDataGridView.DataSource = await SearchCustomersAsync(searchTextBox.Text);
                }
                else
                {
                    await LoadCustomersAsync();
                }
            }

            HandleSearchAsync();
            xBtn.Visible = false;

        }

        private async Task LoadCustomerTransactions(int id)
        {
            var url = $"https://localhost:7298/api/Transactions/CustomerTransactions/{id}";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var transactions = JsonConvert.DeserializeObject<List<Transaction>>(responseBody);
                if (transactions.IsNullOrEmpty())
                {
                    MessageBox.Show("لا توجد معاملات لهذا العميل");

                }
                customersDataGridView.DataSource = transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                customersDataGridView.DataSource = new List<Transaction>();
            }

        }

        private void CustomersDataGridStyle()
        {
            customersDataGridView.RowTemplate.Height = 38;

            if (isFirst)
            {   
                //customersDataGridView.Columns["CustomerId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["RemainingAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["NumberOfInstallments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["DueThisMonth"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                customersDataGridView.Columns["CustomerId"].Visible = false;
                //customersDataGridView.Columns["CustomerId"].HeaderText = "كود العميل";
                customersDataGridView.Columns["CustomerName"].HeaderText = "إسم العميل";
                customersDataGridView.Columns["Phone"].HeaderText = "هاتف العميل";
                customersDataGridView.Columns["RemainingAmount"].HeaderText = "المتبقي على العميل";
                customersDataGridView.Columns["NumberOfInstallments"].HeaderText = "عدد الأقساط على العميل";
                customersDataGridView.Columns["DueThisMonth"].HeaderText = "المطلوب سداده هذا الشهر";
            }
            else 
            {
                customersDataGridView.Columns["TransactorName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                customersDataGridView.Columns["TransactionId"].Visible = false;
                customersDataGridView.Columns["InstallmentId"].Visible = false;
                customersDataGridView.Columns["LedgerId"].Visible = false;
                customersDataGridView.Columns["CustomerId"].Visible = false;
                customersDataGridView.Columns["DebtorId"].Visible = false;
                //customersDataGridView.Columns["Type"].Visible = false;
                customersDataGridView.Columns["TransactorName"].HeaderText = "إسم العميل";
                customersDataGridView.Columns["Date"].HeaderText = "التاريخ";
                customersDataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                customersDataGridView.Columns["Amount"].HeaderText = "الميلغ";
                customersDataGridView.Columns["Description"].HeaderText = "ملاحظات";
            }
        }


        private void customersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            async void HandleDoubleClickAsync()
            {
                if (isFirst)
                {
                    ((MainForm)this.ParentForm).ChangeTitle("سجل معاملات العميل");
                    isFirst = false;
                    xBtn.Visible = true;

                    DataGridView dataGridView = (DataGridView)sender;

                    int row_clicked = dataGridView.CurrentRow.Index;
                    int id = (int)dataGridView.Rows[row_clicked].Cells[0].Value;

                    await LoadCustomerTransactions(id);
                    CustomersDataGridStyle();
                }
            }

            HandleDoubleClickAsync();
            
        }

        private void newCustomerBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ChangeTitle("عميل جديد");
            ((MainForm)this.ParentForm).loadform(new NewCustomerForm());
        }

        private void xBtn_Click(object sender, EventArgs e)
        {
            isFirst = true;
            xBtn.Visible = false;
            searchTextBox.Text = "";
            ((MainForm)this.ParentForm).ChangeTitle("العملاء");

            LoadCustomersAsync();
        }

    }
}
