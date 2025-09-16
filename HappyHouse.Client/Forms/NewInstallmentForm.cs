using HappyHouse.Application.DTOs;
using HappyHouse.Domain.Entities;
using Newtonsoft.Json;

namespace HappyHouse_Client
{
    public partial class NewInstallmentForm : Form
    {
        private HttpClient _client = new HttpClient();
        List<CustomerInstallmentsDTO> customers = new List<CustomerInstallmentsDTO>();

        public NewInstallmentForm()
        {
            InitializeComponent();

            LoadCustomers();

            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private async Task LoadCustomers()
        {
            customers = await GetCustomersAsync();
            foreach (var c in customers)
            {
                CustomerComboBox.Items.Add($"الإسم: {c.CustomerName} - الاقساط المسجلة: {c.NumberOfInstallments}");
            }

        }

        private async Task<List<CustomerInstallmentsDTO>> GetCustomersAsync()
        {
            var url = "https://localhost:7298/api/Customers/Installments";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerInstallmentsDTO>>(responseBody);
                return customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                return new List<CustomerInstallmentsDTO>(); 
            }
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



        private void addBtn_Click(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(searchTextBox.Text) && !string.IsNullOrWhiteSpace(searchTextBox.Text)
            //     && !string.IsNullOrEmpty(totalAmountTextBox.Text) && !string.IsNullOrWhiteSpace(totalAmountTextBox.Text)
            //     && !string.IsNullOrEmpty(installmentAmountTextBox.Text) && !string.IsNullOrWhiteSpace(installmentAmountTextBox.Text)
            //     )
            //{

            //    if (MessageBox.Show("الإسم: " + name + "\n"
            //                        + "المقدم: " + advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim() + "\n"
            //                        + "مبلغ القسط: " + installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim() + "\n"
            //                        + "الملاحظات: " + descriptionTextBox.Text + "\n",
            //                        "اضافة العميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        Customers_DAO customers_DAO = new Customers_DAO();
            //        TransactionDAO transactionDAO = new TransactionDAO();
            //        decimal advance = 0;

            //        if (!string.IsNullOrEmpty(advanceTextBox.Text) && !string.IsNullOrWhiteSpace(advanceTextBox.Text))
            //        {
            //            string advanceTxt = advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            //            advance = decimal.Parse(advanceTxt);
            //        }


            //        transactionDAO.AddAdvanceTransaction(dateTimePicker1.Value.ToString("yyyy-MM-dd"), customer_id, name, advance);



            //        string amountTxt = installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            //        decimal installmentAmount = decimal.Parse(amountTxt);

            //        string remainingTxt = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            //        decimal remaining = decimal.Parse(remainingTxt);



            //        customers_DAO.AddInstallment(customer_id, installmentAmount, remaining, dateTimePicker1.Value, string.IsNullOrEmpty(descriptionTextBox.Text) ? " " : descriptionTextBox.Text);

            //        MessageBox.Show(dateTimePicker1.Value.ToString("تم اضافة القسط بنجاح "));

            //        ((MainForm)this.ParentForm).loadform(new NewInstallmentForm());

            //    }



            //}
            //else
            //{
            //    MessageBox.Show("الرجاء ادخال البيانات أولا");
            //}
        }

        private void amountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            amountTextBox.Text = txt;
        }

        private void amountTextBox_Leave(object sender, EventArgs e)
        {
            string input = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
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

        private void percentageTextBox_Enter(object sender, EventArgs e)
        {
            string txt = percentageTextBox.Text.Replace("%", "").Replace(".00", "").Trim();
            percentageTextBox.Text = txt;
        }

        private void percentageTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(percentageTextBox.Text) && !string.IsNullOrWhiteSpace(percentageTextBox.Text))
            {
                string input = percentageTextBox.Text.Replace("%", "").Trim();

                if (decimal.TryParse(input, out decimal percentage))
                {
                    string formattedAmount = $"{percentage:F2}%";

                    percentageTextBox.Text = formattedAmount;
                }
                else
                {
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
                string input = advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {
                    string formattedAmount = $"{amount:F2} EGP";

                    advanceTextBox.Text = formattedAmount;
                }
                else
                {
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

                string input = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {

                    string formattedAmount = $"{amount:F2} EGP";


                    totalAmountTextBox.Text = formattedAmount;
                }
                else
                {

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

                string input = installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();

                if (decimal.TryParse(input, out decimal amount))
                {

                    string formattedAmount = $"{amount:F2} EGP";


                    installmentAmountTextBox.Text = formattedAmount;
                }
                else
                {

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
            xBtn.Visible = false;
            LoadCustomers();
        }



        private void backBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ChangeTitle("الأقساط");
            ((MainForm)this.ParentForm).loadform(new Installment_form());
        }

        private void new_installment_form_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }


    }
}

