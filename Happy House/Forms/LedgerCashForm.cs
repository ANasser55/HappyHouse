using HappyHouse_Client.Old;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyHouse_Client
{
    public partial class LedgerCashForm : Form
    {
        public LedgerCashForm()
        {
            InitializeComponent();
            cashDateTimePicker.Value = DateTime.Now;
            cashDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private void عودةbtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerTransactionForm());
        }

        private void cashAmountTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cashAmountTextBox.Text) && !string.IsNullOrWhiteSpace(cashAmountTextBox.Text))
            {
                // Remove any existing "EGP" suffix
                string input = cashAmountTextBox.Text.Replace("EGP", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    // Format the amount as EGP currency without adding two decimal zeros
                    string formattedAmount = $"{amount:N0} EGP";

                    // Update the text in the amountTextBox
                    cashAmountTextBox.Text = formattedAmount;
                }
                else
                {
                    // Handle invalid input if needed
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");

                }
            }
        }

        private void ledger_cash_form_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cashAmountTextBox.Text) && !string.IsNullOrWhiteSpace(cashAmountTextBox.Text))
            {

                if (MessageBox.Show("المبلغ: " + cashAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim() + "\n"
                                    + "الملاحظات: " + cashRichTextBox1.Text + "\n",
                                    "عمليه كاش", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string amountTxt = cashAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                    decimal amount = decimal.Parse(amountTxt);

                    TransactionDAO transactionDAO = new TransactionDAO();

                    transactionDAO.AddCashTransaction(cashDateTimePicker.Value.ToString("yyyy-MM-dd"), amount, cashRichTextBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("الرجاء إدخال مبلغ أولا");
            }
        }

        private void cashAmountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = cashAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            cashAmountTextBox.Text = txt;
        }
    }
}
