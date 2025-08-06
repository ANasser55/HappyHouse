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
    public partial class ledger_installments : Form
    {

        // Variables
        BindingSource customersBidingSource = new BindingSource();
        bool isFirst = true;
        bool isSecond = false;
        int installment_id = 0;
        int customer_id = 0;
        string customer_name = "";
        //
        //
        // Functions
        public ledger_installments()
        {
            InitializeComponent();

            LoadCustomers();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void LoadCustomers()
        {
            Customers_DAO customers_DAO = new Customers_DAO();
            customers_DAO.calculate_installments();

            customersBidingSource.DataSource = customers_DAO.getAllCustomers();
            customersLedgerDataGridView.DataSource = customersBidingSource;

            customersLedgerDataGridView.Columns["customer_id"].HeaderText = "كود العميل";
            customersLedgerDataGridView.Columns["customer_name"].HeaderText = "إسم العميل";
            customersLedgerDataGridView.Columns["customer_phone"].Visible = false;
            customersLedgerDataGridView.Columns["customer_next_payment"].HeaderText = "قيمه القسط الحالي";
            customersLedgerDataGridView.Columns["customer_total_remaining"].HeaderText = "المتبقي على العميل";
        }

        private void LoadInstallments(int id)
        {
            InstallmentsForCustomerDAO installmentsForCustomerDAO = new InstallmentsForCustomerDAO();
            customersBidingSource.DataSource = installmentsForCustomerDAO.getCustomerInstallments(id);
            customersLedgerDataGridView.DataSource = customersBidingSource;
            //ledgerDataGridView.Columns["transaction_id"].Visible = false;
            customersLedgerDataGridView.Columns["installment_id"].HeaderText = "رقم القسط";
            customersLedgerDataGridView.Columns["customer_name"].HeaderText = "اسم العميل";
            customersLedgerDataGridView.Columns["installment_amount"].HeaderText = "المبلغ";
            customersLedgerDataGridView.Columns["remaining"].HeaderText = "المتبقي";

        }

        //
        //
        // Events
        //
        //
        private void amountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            amountTextBox.Text = txt;
        }


        private void amountTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                // Remove any existing "EGP" suffix
                string input = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    // Format the amount as "55.00 EGP"
                    string formattedAmount = $"{amount:F2} EGP";

                    // Update the text in the advanceTextBox
                    amountTextBox.Text = formattedAmount;
                }
                else
                {
                    // Handle invalid input if needed
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");
                }
            }
        }


        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isFirst && !isSecond)
            {
                Customers_DAO customers_DAO = new Customers_DAO();

                if (searchTextBox.Text.Length > 0)
                {
                    customersBidingSource.DataSource = customers_DAO.searchCustomers(searchTextBox.Text);
                    customersLedgerDataGridView.DataSource = customersBidingSource;
                }
                else
                {
                    customersBidingSource.DataSource = customers_DAO.getAllCustomers();
                    customersLedgerDataGridView.DataSource = customersBidingSource;
                }
            }
        }


        private void customersLedgerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFirst)
            {
                xBtn.Visible = true;
                isFirst = false;
                isSecond = true;
                DataGridView dataGridView = (DataGridView)sender;

                int row_clicked = dataGridView.CurrentRow.Index;
                customer_id = (int)dataGridView.Rows[row_clicked].Cells[0].Value;

                LoadInstallments(customer_id);
            }
            else if (isSecond && !isFirst)
            {

                DataGridView dataGridView = (DataGridView)sender;

                int row_clicked = dataGridView.CurrentRow.Index;
                customer_name = (string)dataGridView.Rows[row_clicked].Cells[0].Value;
                installment_id = (int)dataGridView.Rows[row_clicked].Cells[1].Value;

                searchTextBox.Text = customer_name + "  معامله رقم " + installment_id;
            }
        }

        private void xBtn_Click(object sender, EventArgs e)
        {
            isFirst = true;
            isSecond = false;
            xBtn.Visible = false;
            searchTextBox.Text = "";
            LoadCustomers();
        }




        private void backBtn_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).loadform(new ledger_transaction_form());
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text)
                && !string.IsNullOrEmpty(searchTextBox.Text) && !string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                if (MessageBox.Show("الإسم: " + customer_name + "\n"
                                    + "رقم القسط: " + installment_id + "\n"
                                    + "الملاحظات: " + richTextBox1.Text + "\n",
                                    "اضافة القسط", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string amountTxt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                    decimal amount = decimal.Parse(amountTxt);

                    TransactionDAO transactionDAO = new TransactionDAO();
                    transactionDAO.AddInstallmentTransaction(customer_name, dateTimePicker1.Value.ToString("yyyy-MM-dd"), customer_id, installment_id, amount, string.IsNullOrEmpty(richTextBox1.Text) ? " " : richTextBox1.Text);

                    MessageBox.Show("تمت الإضافة بنجاح");

                    ((Form1)this.ParentForm).loadform(new ledger_installments());
                }
            }
            else
            {
                MessageBox.Show("يرجى إدخال البيانات أولا");
            }
        }

        
    }
}
