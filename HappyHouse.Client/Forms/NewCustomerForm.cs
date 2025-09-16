using HappyHouse.Application.DTOs;
using HappyHouse.Domain.Entities;
using HappyHouse_Client.Authentication;
using Newtonsoft.Json;
using System.Text;


namespace HappyHouse_Client
{
    public partial class NewCustomerForm : Form
    {
        private readonly HttpClient _client = new HttpClient();
        bool isExist = false;

        public NewCustomerForm()
        {
            InitializeComponent();
            InstallmentDateTimePicker.Value = DateTime.Now;
            InstallmentDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private CustomerRegistrationDTO GetRegistrationData()
        {
            var customer = new Customer();
            var installment = new Installment();
            var transaction = new Transaction();
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
            transaction.IsExpense = false;
            transaction.Description = "مقدم قسط";

            registration.Customer = customer;
            registration.Installment = installment;
            registration.Transaction = transaction;

            return registration;

        }
        private async Task AddCustomerAsync()
        {
            var url = "https://localhost:7298/api/CustomerRegistration";
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                var registrationDTO = GetRegistrationData();
                var json = JsonConvert.SerializeObject(registrationDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
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


        private void CalculateTotalAmount()
        {
            if (!string.IsNullOrEmpty(amountTextBox.Text) && !string.IsNullOrWhiteSpace(amountTextBox.Text)
                && !string.IsNullOrEmpty(advanceTextBox.Text) && !string.IsNullOrWhiteSpace(advanceTextBox.Text)
                && !string.IsNullOrEmpty(percentageTextBox.Text) && !string.IsNullOrWhiteSpace(percentageTextBox.Text))
            {
                decimal amount = decimal.TryParse(amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim(), out decimal amountResult) ? amountResult : 0;
                decimal percentage = decimal.TryParse(percentageTextBox.Text.Replace("%", "").Replace(".00", "").Trim(), out decimal percentageResult) ? percentageResult : 0;
                decimal advance = decimal.TryParse(advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim(), out decimal advanceResult) ? advanceResult : 0;

                decimal remaining = (amount - advance) * (percentage / 100) + (amount - advance);
                string formatedRemaining = $"{remaining:F2} EGP";

                totalAmountTextBox.Text = formatedRemaining;
            }


        }
        private void CalculateInstallmentAmount()
        {
            if (!string.IsNullOrEmpty(durationTextBox.Text) && !string.IsNullOrWhiteSpace(durationTextBox.Text)
                && (!string.IsNullOrEmpty(totalAmountTextBox.Text) && !string.IsNullOrWhiteSpace(totalAmountTextBox.Text)))
            {
                int duration = int.TryParse(durationTextBox.Text, out int durationResult) ? durationResult : 0;

                string txt = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
                int total_amount = (int)Math.Ceiling(decimal.Parse(txt));

                int result = (int)Math.Ceiling((double)total_amount / duration);

                string formattedResult = $"{result:F2} EGP";

                installmentAmountTextBox.Text = formattedResult.ToString();
            }

        }


        private void AmountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = amountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            amountTextBox.Text = txt;
        }
        private void PercentageTextBox_Enter(object sender, EventArgs e)
        {
            string txt = percentageTextBox.Text.Replace("%", "").Replace(".00", "").Trim();
            percentageTextBox.Text = txt;
        }
        private void AdvanceTextBox_Enter(object sender, EventArgs e)
        {
            string txt = advanceTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            advanceTextBox.Text = txt;
        }
        private void TotalAmountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = totalAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            totalAmountTextBox.Text = txt;
        }
        private void InstallmentAmountTextBox_Enter(object sender, EventArgs e)
        {
            string txt = installmentAmountTextBox.Text.Replace("EGP", "").Replace(".00", "").Trim();
            installmentAmountTextBox.Text = txt;
        }



        private void PercentageTextBox_Leave(object sender, EventArgs e)
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

            CalculateTotalAmount();

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

            CalculateTotalAmount();

        }
        private void AdvanceTextBox_Leave(object sender, EventArgs e)
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

            CalculateTotalAmount();
        }
        private void TotalAmountTextBox_Leave(object sender, EventArgs e)
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

            CalculateInstallmentAmount();

        }
        private void InstallmentAmountTextBox_Leave(object sender, EventArgs e)
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
        private void DurationTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(durationTextBox.Text) && !string.IsNullOrWhiteSpace(durationTextBox.Text))
            {
                if (int.TryParse(durationTextBox.Text, out int durationResult) && durationResult != 0)
                {
                    CalculateInstallmentAmount();
                }
                else
                {
                    MessageBox.Show("الرجاء إدخال عدد شهور صحيح");
                    durationTextBox.Focus();
                }
            }

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            async void AddCustomerHandler()
            {
                await AddCustomerAsync();
            }

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
                    try
                    {
                        AddCustomerHandler();
                        isExist = true;
                        MessageBox.Show(InstallmentDateTimePicker.Value.ToString("تم اضافة " + nameTextBox.Text + " بنجاح"));
                        ((MainForm)this.ParentForm).loadform(new NewCustomerForm());
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error: " + ex);
                    }
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
        private void BackBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ChangeTitle("العملاء");
            ((MainForm)this.ParentForm).loadform(new customers_form());
        }
    }
}
