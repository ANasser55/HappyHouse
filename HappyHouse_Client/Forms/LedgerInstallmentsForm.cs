using HappyHouse_Client.Authentication;
using HappyHouse_Client.DTO;
using HappyHouse_Client.Models;
using Newtonsoft.Json;
using System.Text;


namespace HappyHouse_Client
{
    public partial class LedgerInstallmentsForm : Form
    {
        private HttpClient _client = new HttpClient();
        List<CustomerInstallmentsDTO> customers = new List<CustomerInstallmentsDTO>();
        InstallmentTransactionDTO transaction = new InstallmentTransactionDTO();


        public LedgerInstallmentsForm()
        {
            InitializeComponent();

            LoadCustomersAsync();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private async Task LoadCustomersAsync()
        {
            customers = await GetCustomersAsync();
            foreach (var c in customers)
            {
                CustomerComboBox.Items.Add($"الإسم: {c.CustomerName} - الاقساط المسجلة: {c.NumberOfInstallments}");
            }

        }

        private async Task<List<CustomerInstallmentsDTO>> GetCustomersAsync()
        {
            var url = "https://localhost:7176/api/Customers/Installments";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerInstallmentsDTO>>(responseBody);

                return customers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return new List<CustomerInstallmentsDTO>();
            }
        }

        //
        //
        // Events
        //
        //

        private void AmountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            amountTextBox.Text = txt;
        }


        private void AmountTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                string input = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    string formattedAmount = $"{amount:F2} EGP";

                    amountTextBox.Text = formattedAmount;
                }
                else
                {
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");
                }
            }
        }


        private void BackBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerTransactionForm());
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text)
                && !string.IsNullOrEmpty(CustomerComboBox.Text) && !string.IsNullOrWhiteSpace(CustomerComboBox.Text)
                && !string.IsNullOrEmpty(InstallmentComboBox.Text) && !string.IsNullOrWhiteSpace(InstallmentComboBox.Text))
            {
                if (MessageBox.Show("الإسم: " + customers[CustomerComboBox.SelectedIndex].CustomerName + "\n"
                                    + "رقم القسط: " + customers[CustomerComboBox.SelectedIndex].Installments[InstallmentComboBox.SelectedIndex].InstallmentId + "\n"
                                    + "الملاحظات: " + richTextBox1.Text + "\n",
                                    "اضافة القسط", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string amountTxt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                    decimal amount = decimal.Parse(amountTxt);

                    transaction.Amount = amount;
                    transaction.Date = dateTimePicker1.Value;
                    transaction.TransactionType = 
                    transaction.Description = richTextBox1.Text;

                    async void Handle()
                    {
                        await AddInstallmentTransaction();
                    }

                    Handle();

                }
            }
            else
            {
                MessageBox.Show("يرجى إدخال البيانات أولا");
            }
        }

        private async Task AddInstallmentTransaction()
        {
            var url = "https://localhost:7176/api/Transactions/Installment";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                var json = JsonConvert.SerializeObject(transaction);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await _client.PostAsync(url, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InstallmentComboBox.Items.Clear();
            InstallmentComboBox.Text = "";
            var customer = customers[CustomerComboBox.SelectedIndex];
            for (int i = 0; i < customer.NumberOfInstallments; i++)
            {
                InstallmentComboBox.Items.Add($" الوصف: {customer.Installments[i].Description} | قيمة القسط: {customer.Installments[i].PaymentPerMonth}");
            }
            transaction.CustomerId = customer.CustomerID;
            transaction.TransactorName = customer.CustomerName;
        }

        private void InstallmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            amountTextBox.Text = customers[CustomerComboBox.SelectedIndex].Installments[InstallmentComboBox.SelectedIndex].PaymentPerMonth.ToString();
            string input = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

            if (decimal.TryParse(input, out decimal amount))
            {
                string formattedAmount = $"{amount:F2} EGP";

                amountTextBox.Text = formattedAmount;
            }
            transaction.InstallmentId = customers[CustomerComboBox.SelectedIndex].Installments[InstallmentComboBox.SelectedIndex].InstallmentId;
        }
    }
}
