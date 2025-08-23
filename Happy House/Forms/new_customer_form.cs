using HappyHouse_Client.DTO;
using HappyHouse_Client.Models;
using HappyHouse_Client.Old;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyHouse_Client
{
    public partial class new_customer_form : Form
    {
        private readonly HttpClient _client = new HttpClient();
        bool isExist = false;

        public new_customer_form()
        {
            InitializeComponent();
            InstallmentDateTimePicker.Value = DateTime.Now;
            InstallmentDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }
        private void AddAdvance(int customer_id, string name)
        {
            TransactionDAO transactionDAO = new TransactionDAO();
            decimal advance = 0;

            string advanceTxt = advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            advance = decimal.Parse(advanceTxt);
            transactionDAO.AddAdvanceTransaction(InstallmentDateTimePicker.Value.ToString("yyyy-MM-dd"), customer_id, name, advance);


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

        //
        //
        //Events
        //
        //
        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                Customers_DAO customers_DAO = new Customers_DAO();
                if (customers_DAO.isCustomerExist(nameTextBox.Text))
                {
                    MessageBox.Show("العميل موجود بالفعل");
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }
        }


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

                    // Update the text in the amountTextBox
                    amountTextBox.Text = formattedAmount;
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


        private CustomerRegistrationDTO GetRegistrationData()
        {
            var customer = new Customer();
            var installment = new Installment();
            var transaction = new Models.Transaction();
            var registration = new CustomerRegistrationDTO();

            decimal amount = decimal.Parse(totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim());
            decimal installmentAmount = decimal.Parse(installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim());

            customer.CustomerName = nameTextBox.Text;
            customer.Phone = phoneTextBox.Text;

            installment.TotalAmount = amount;
            installment.PaymentPerMonth = installmentAmount;
            installment.RemainingAmount = amount;
            installment.StartDate = InstallmentDateTimePicker.Value;
            installment.DueDate = InstallmentDateTimePicker.Value.AddMonths(1);
            installment.isPaid = false;
            installment.Description = descriptionTextBox.Text;

            transaction.Date = installment.StartDate;
            transaction.TransactorName = customer.CustomerName;
            transaction.Amount = decimal.Parse(advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim());
            transaction.Type = "دخل";
            transaction.Description = "مقدم قسط";

            registration.Customer = customer;
            registration.Installment = installment;
            registration.Transaction = transaction;
            
            return registration;

        }

        private async Task AddCustomerAsync()
        {
            var url = "https://localhost:7176/api/CustomerRegistration";
            try
            {
                var registrationDTO = GetRegistrationData();
                var json = JsonConvert.SerializeObject(registrationDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(url, content);
                //response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("تم تسجيل العميل بنجاح");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("خطأ: " + error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            AddCustomerAsync();

            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text)
                 && !string.IsNullOrEmpty(totalAmountTextBox.Text) && !string.IsNullOrWhiteSpace(totalAmountTextBox.Text)
                 && !string.IsNullOrEmpty(installmentAmountTextBox.Text) && !string.IsNullOrWhiteSpace(installmentAmountTextBox.Text)
                 && !isExist)
            {
                if (MessageBox.Show("الإسم: " + nameTextBox.Text + "\n"
                                    + "رقم الهاتف: " + phoneTextBox.Text + "\n"
                                    + "المقدم: " + advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim() + "\n"
                                    + "مبلغ القسط: " + installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim() + "\n"
                                    + "الملاحظات: " + descriptionTextBox.Text + "\n",
                                    "اضافة العميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    isExist = true;

                    Customers_DAO customers_DAO = new Customers_DAO();


                    string amountTxt = installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                    decimal installmentAmount = decimal.Parse(amountTxt);

                    string remainingTxt = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                    decimal remaining = decimal.Parse(remainingTxt);



                    int customer_id = customers_DAO.AddCustomer(nameTextBox.Text, phoneTextBox.Text, installmentAmount, remaining, InstallmentDateTimePicker.Value, string.IsNullOrEmpty(descriptionTextBox.Text) ? " " : descriptionTextBox.Text);

                    if (!string.IsNullOrEmpty(advanceTextBox.Text) && !string.IsNullOrWhiteSpace(advanceTextBox.Text))
                    {
                        AddAdvance(customer_id, nameTextBox.Text);
                    }

                    MessageBox.Show(InstallmentDateTimePicker.Value.ToString("تم اضافة " + nameTextBox.Text + " بنجاح"));

                    ((MainForm)this.ParentForm).loadform(new new_customer_form());


                }


            }
            else if (isExist)
            {
                MessageBox.Show("العميل موجود مسبقا يمكنك اضافة قسط جديد له من صفحة الاقساط");
            }
            else
            {
                MessageBox.Show("الرجاء ادخال البيانات أولا");
            }

        }


        private void backBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ChangeTitle("العملاء");
            ((MainForm)this.ParentForm).loadform(new customers_form());
        }


        private void new_customer_form_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

        }
        //
        //
    }
}
