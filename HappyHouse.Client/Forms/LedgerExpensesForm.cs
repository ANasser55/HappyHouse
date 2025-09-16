

namespace HappyHouse_Client
{
    public partial class LedgerExpensesForm : Form
    {
        public LedgerExpensesForm()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerForm());
        }

        private void amountTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                string input = amountTextBox.Text.Replace("EGP", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    string formattedAmount = $"{amount:N0} EGP";

                    amountTextBox.Text = formattedAmount;
                }
                else
                {
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");

                }
            }
        }

        private void amountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            amountTextBox.Text = txt;
        }
    }
}
