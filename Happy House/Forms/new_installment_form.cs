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
    public partial class new_installment_form : Form
    {
        //Variables
        //
        //
        int customer_id;
        string name = "";

        BindingSource customersBidingSource = new BindingSource();
        bool isFirst = true;
        //
        //
        //Functions
        //
        //
        public new_installment_form()
        {
            InitializeComponent();

            LoadCustomers();

            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void LoadCustomers()
        {
            Customers_DAO customers_DAO = new Customers_DAO();
            customers_DAO.calculate_installments();

            customersBidingSource.DataSource = customers_DAO.getAllCustomers();
            customersDataGridView.DataSource = customersBidingSource;

            customersDataGridView.Columns["customer_id"].HeaderText = "كود العميل";
            customersDataGridView.Columns["customer_name"].HeaderText = "إسم العميل";
            customersDataGridView.Columns["customer_phone"].Visible = false;
            customersDataGridView.Columns["customer_next_payment"].Visible = false;
            customersDataGridView.Columns["customer_total_remaining"].HeaderText = "المتبقي على العميل";
        }

        private void CalculateInstallmentAmount()
        {
            int duration = int.TryParse(durationTextBox.Text, out int durationResult) ? durationResult : 0;

            string txt = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            int total_amount = (int)Math.Ceiling(decimal.Parse(txt));

            // Use Math.Ceiling to round up the result if there is a fraction
            int result = (int)Math.Ceiling((double)total_amount / duration);

            string formattedResult = $"{result:F2} EGP";

            installmentAmountTextBox.Text = formattedResult.ToString();
        }

        private void CalculateTotalAmount()
        {

            decimal amount = decimal.TryParse(amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim(), out decimal amountResult) ? amountResult : 0;
            decimal percentage = decimal.TryParse(percentageTextBox.Text.Replace("%", "").Replace(".00", "").Trim(), out decimal percentageResult) ? percentageResult : 0;
            decimal advance = decimal.TryParse(advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim(), out decimal advanceResult) ? advanceResult : 0;

            decimal remaining = (amount - advance) * (percentage / 100) + (amount - advance);
            string formatedRemaining = $"{remaining:F2} EGP";

            totalAmountTextBox.Text = formatedRemaining;
        }
        //
        //
        //Events
        //
        //
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            customersDataGridView.Visible = true;
            customersDataGridView.BringToFront();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchTextBox.Text))
            {
                if (isFirst)
                {

                    Customers_DAO customers_DAO = new Customers_DAO();

                    if (searchTextBox.Text.Length > 0)
                    {
                        customersBidingSource.DataSource = customers_DAO.searchCustomers(searchTextBox.Text);
                        customersDataGridView.DataSource = customersBidingSource;
                    }
                    else
                    {
                        customersBidingSource.DataSource = customers_DAO.getAllCustomers();
                        customersDataGridView.DataSource = customersBidingSource;
                    }
                }
            }
            else
            {
                isFirst = true;
                xBtn.Visible = false;
                LoadCustomers();
            }



        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            customersDataGridView.Visible = false;
        }

        private void customersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            isFirst = false;

            DataGridView dataGridView = (DataGridView)sender;

            int row_clicked = dataGridView.CurrentRow.Index;
            customer_id = (int)dataGridView.Rows[row_clicked].Cells[0].Value;
            name = (string)dataGridView.Rows[row_clicked].Cells[1].Value;

            searchTextBox.Text = "الإسم = " + name + "  كود العميل " + customer_id;
            customersDataGridView.Visible = false;


            xBtn.Visible = true;

        }

        private void amountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            amountTextBox.Text = txt;
        }

        private void amountTextBox_Leave(object sender, EventArgs e)
        {
            // Remove any existing "EGP" suffix
            string input = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                if (decimal.TryParse(input, out decimal amount))
                {
                    // Format the amount as "55.00 EGP"
                    string formattedAmount = $"{amount:F2} EGP";

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

        private void percentageTextBox_Enter(object sender, EventArgs e)
        {
            string txt = percentageTextBox.Text.Replace("%", "").Replace(".00", "").Trim();
            percentageTextBox.Text = txt;
        }

        private void percentageTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(percentageTextBox.Text) && !string.IsNullOrWhiteSpace(percentageTextBox.Text))
            {
                // Remove any existing "EGP" suffix
                string input = percentageTextBox.Text.Replace("%", "").Trim();

                if (decimal.TryParse(input, out decimal percentage))
                {
                    // Format the amount as EGP currency with two decimal places and add %
                    string formattedAmount = $"{percentage:F2}%";

                    // Update the text in the percentageTextBox
                    percentageTextBox.Text = formattedAmount;
                }
                else
                {
                    // Handle invalid input if needed
                    MessageBox.Show("الرجاء ادخال نسبة صحيحة");
                }
            }

            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text)
                && !string.IsNullOrEmpty(advanceTextBox.Text) && !string.IsNullOrWhiteSpace(advanceTextBox.Text)
                && !string.IsNullOrEmpty(percentageTextBox.Text) && !string.IsNullOrWhiteSpace(percentageTextBox.Text))
            {
                CalculateTotalAmount();
            }
        }

        private void advanceTextBox_Enter(object sender, EventArgs e)
        {
            string txt = advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            advanceTextBox.Text = txt;
        }

        private void advanceTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(advanceTextBox.Text) && !string.IsNullOrWhiteSpace(advanceTextBox.Text))
            {
                // Remove any existing "EGP" suffix
                string input = advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    // Format the amount as "55.00 EGP"
                    string formattedAmount = $"{amount:F2} EGP";

                    // Update the text in the advanceTextBox
                    advanceTextBox.Text = formattedAmount;
                }
                else
                {
                    // Handle invalid input if needed
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");
                }
            }

            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text)
                && !string.IsNullOrEmpty(advanceTextBox.Text) && !string.IsNullOrWhiteSpace(advanceTextBox.Text)
                && !string.IsNullOrEmpty(percentageTextBox.Text) && !string.IsNullOrWhiteSpace(percentageTextBox.Text))
            {
                CalculateTotalAmount();
            }
        }

        private void totalAmountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            totalAmountTextBox.Text = txt;
        }

        private void totalAmountTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(totalAmountTextBox.Text) && !string.IsNullOrWhiteSpace(totalAmountTextBox.Text))
            {
                // Remove any existing "EGP" suffix
                string input = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    // Format the amount as "55.00 EGP"
                    string formattedAmount = $"{amount:F2} EGP";

                    // Update the text in the installmentAmountTextBox
                    totalAmountTextBox.Text = formattedAmount;
                }
                else
                {
                    // Handle invalid input if needed
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");
                    totalAmountTextBox.Focus();
                }
            }

            if (!string.IsNullOrEmpty(durationTextBox.Text) && !string.IsNullOrWhiteSpace(durationTextBox.Text))
            {
                CalculateInstallmentAmount();
            }
        }

        private void installmentAmountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            installmentAmountTextBox.Text = txt;
        }

        private void installmentAmountTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(installmentAmountTextBox.Text) && !string.IsNullOrWhiteSpace(installmentAmountTextBox.Text))
            {
                // Remove any existing "EGP" suffix
                string input = installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    // Format the amount as "55.00 EGP"
                    string formattedAmount = $"{amount:F2} EGP";

                    // Update the text in the installmentAmountTextBox
                    installmentAmountTextBox.Text = formattedAmount;
                }
                else
                {
                    // Handle invalid input if needed
                    MessageBox.Show("الرجاء ادخال مبلغ صحيح");
                    installmentAmountTextBox.Focus();
                }
            }
        }

        private void durationTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(durationTextBox.Text) && !string.IsNullOrWhiteSpace(durationTextBox.Text))
            {
                if (int.TryParse(durationTextBox.Text, out int durationResult) && durationResult != 0)
                {
                    if (!string.IsNullOrEmpty(totalAmountTextBox.Text) && !string.IsNullOrWhiteSpace(totalAmountTextBox.Text))
                    {
                        CalculateInstallmentAmount();
                    }
                }
                else
                {
                    MessageBox.Show("الرجاء إدخال عدد شهور صحيح");
                    durationTextBox.Focus();
                }
            }
        }

        private void xBtn_Click(object sender, EventArgs e)
        {
            isFirst = true;
            xBtn.Visible = false;
            searchTextBox.Text = "";
            LoadCustomers();
        }


        private void addBtn_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(searchTextBox.Text) && !string.IsNullOrWhiteSpace(searchTextBox.Text)
                 && !string.IsNullOrEmpty(totalAmountTextBox.Text) && !string.IsNullOrWhiteSpace(totalAmountTextBox.Text)
                 && !string.IsNullOrEmpty(installmentAmountTextBox.Text) && !string.IsNullOrWhiteSpace(installmentAmountTextBox.Text)
                 )
            {

                if (MessageBox.Show("الإسم: " + name + "\n"
                                    + "المقدم: " + advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim() + "\n"
                                    + "مبلغ القسط: " + installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim() + "\n"
                                    + "الملاحظات: " + descriptionTextBox.Text + "\n",
                                    "اضافة العميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Customers_DAO customers_DAO = new Customers_DAO();
                    TransactionDAO transactionDAO = new TransactionDAO();
                    decimal advance = 0;

                    if (!string.IsNullOrEmpty(advanceTextBox.Text) && !string.IsNullOrWhiteSpace(advanceTextBox.Text))
                    {
                        string advanceTxt = advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                        advance = decimal.Parse(advanceTxt);
                    }


                    transactionDAO.AddAdvanceTransaction(dateTimePicker1.Value.ToString("yyyy-MM-dd"), customer_id, name, advance);



                    string amountTxt = installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                    decimal installmentAmount = decimal.Parse(amountTxt);

                    string remainingTxt = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                    decimal remaining = decimal.Parse(remainingTxt);



                    customers_DAO.AddInstallment(customer_id, installmentAmount, remaining, dateTimePicker1.Value, string.IsNullOrEmpty(descriptionTextBox.Text) ? " " : descriptionTextBox.Text);

                    MessageBox.Show(dateTimePicker1.Value.ToString("تم اضافة القسط بنجاح "));

                    ((Form1)this.ParentForm).loadform(new new_installment_form());

                }



            }
            else
            {
                MessageBox.Show("الرجاء ادخال البيانات أولا");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).ChangeTitle("الأقساط");
            ((Form1)this.ParentForm).loadform(new installment_form());
        }

        private void new_installment_form_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            customersDataGridView.Visible = false;
        }

       
    }
}

