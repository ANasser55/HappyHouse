using HappyHouse.Application.DTOs;
using HappyHouse_Client.Authentication;
using System.Text;
using System.Text.Json;


namespace HappyHouse_Client
{
    public partial class LedgerCashForm : Form
    {
        private readonly HttpClient _client = new HttpClient();
        public LedgerCashForm()
        {
            InitializeComponent();
            cashDateTimePicker.Value = DateTime.Now;
            cashDateTimePicker.CustomFormat = "dd/MM/yyyy";
            TypeComboBox.Items.Add("بيع");
            TypeComboBox.Items.Add("شراء");
            TypeComboBox.SelectedIndex = 0;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerTransactionForm());
        }


        private CashTransactionDTO GetTransactionData()
        {
            var cash = new CashTransactionDTO();

            cash.TransactorName = "كاش";
            cash.Amount = decimal.Parse(cashAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim());
            cash.IsExpense = TypeComboBox.SelectedIndex == 0 ? false : true;
            cash.TransactionType = cash.IsExpense ? "مصروفات" : "دخل";
            cash.Date = cashDateTimePicker.Value;
            cash.Description = cashRichTextBox1.Text;

            return cash;
        }

        private async Task AddCashTransaction()
        {
            var url = "https://localhost:7298/api/Transactions/cash";

            try
            {
                _client.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                var cash = GetTransactionData();
                var json = JsonSerializer.Serialize(cash);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await _client.PostAsync(url, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cashAmountTextBox.Text) && !string.IsNullOrWhiteSpace(cashAmountTextBox.Text)
                && !string.IsNullOrEmpty(cashRichTextBox1.Text) && !string.IsNullOrWhiteSpace(cashRichTextBox1.Text))
            {

                if (MessageBox.Show("المبلغ: " + cashAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim() + "\n"
                                    + "الملاحظات: " + cashRichTextBox1.Text + "\n",
                                    "عملية كاش", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    async void HandleClick()
                    {
                        await AddCashTransaction();
                        MessageBox.Show("تمت إضافة العملية بنجاح");
                        ((MainForm)this.ParentForm).loadform(new LedgerForm());
                    }

                    HandleClick();
                }
            }
            else
            {
                MessageBox.Show("الرجاء إدخال مبلغ أولا");
            }
        }

        private void CashAmountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = cashAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            cashAmountTextBox.Text = txt;
        }
        private void CashAmountTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cashAmountTextBox.Text) && !string.IsNullOrWhiteSpace(cashAmountTextBox.Text))
            {
                string input = cashAmountTextBox.Text.Replace("EGP", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    string formattedAmount = $"{amount:N0} EGP";

                    cashAmountTextBox.Text = formattedAmount;
                }
                else
                {
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");
                }
            }
        }

    }
}
