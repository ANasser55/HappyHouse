using HappyHouse_Client.Authentication;
using HappyHouse_Client.DTO;
using HappyHouse_Client.Models;
using Newtonsoft.Json;


namespace HappyHouse_Client
{
    public partial class LedgerInstallmentsForm : Form
    {
        private HttpClient _client = new HttpClient();
        List<CustomerInstallmentsDTO> customers = new List<CustomerInstallmentsDTO>();
        Transaction transaction = new Transaction();


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
                && !string.IsNullOrEmpty(searchTextBox.Text) && !string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                if (MessageBox.Show("الإسم: " + customers[CustomerComboBox.SelectedIndex].CustomerName + "\n"
                                    + "رقم القسط: " + customers[CustomerComboBox.SelectedIndex].Installments[InstallmentComboBox.SelectedIndex].InstallmentId + "\n"
                                    + "الملاحظات: " + richTextBox1.Text + "\n",
                                    "اضافة القسط", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string amountTxt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                    decimal amount = decimal.Parse(amountTxt);

                    //    TransactionDAO transactionDAO = new TransactionDAO();
                    //    transactionDAO.AddInstallmentTransaction(customer_name, dateTimePicker1.Value.ToString("yyyy-MM-dd"), customer_id, installment_id, amount, string.IsNullOrEmpty(richTextBox1.Text) ? " " : richTextBox1.Text);

                    //    MessageBox.Show("تمت الإضافة بنجاح");

                    //    ((MainForm)this.ParentForm).loadform(new LedgerInstallmentsForm());
                }
            }
            else
            {
                MessageBox.Show("يرجى إدخال البيانات أولا");
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
