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
    public partial class LedgerExpensesForm : Form
    {
        public LedgerExpensesForm()
        {
            InitializeComponent();

            //dateTimePicker1.CustomFormat  = 
        }

        private void amountTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                // Remove any existing "EGP" suffix
                string input = amountTextBox.Text.Replace("EGP", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    // Format the amount as EGP currency without adding two decimal zeros
                    string formattedAmount = $"{amount:N0} EGP";

                    // Update the text in the amountTextBox
                    amountTextBox.Text = formattedAmount;
                }
                else
                {
                    // Handle invalid input if needed
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");

                }
            }
        }

        private void amountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            amountTextBox.Text = txt;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                string amountTxt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                decimal amount = decimal.Parse(amountTxt);

                TransactionDAO transactionDAO = new TransactionDAO();

                transactionDAO.AddExpensesTransaction(dateTimePicker1.Value.ToString("yyyy-MM-dd"), amount, descriptionTextBox.Text);

                ((MainForm)this.ParentForm).loadform(new LedgerForm());
            }
            else
            {
                MessageBox.Show("الرجاء إدخال مبلغ أولا");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerForm());
        }
    }
}
