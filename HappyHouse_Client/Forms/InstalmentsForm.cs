using HappyHouse_Client.Authentication;
using HappyHouse_Client.DTO;
//using HappyHouse_Client.Old;
using Newtonsoft.Json;



namespace HappyHouse_Client
{
    public partial class Installment_form : Form
    {
        private readonly HttpClient _client = new HttpClient();

        bool isFirst = true;

        public Installment_form()
        {
            InitializeComponent();
            LoadCustomers();

        }

        private void InstallmentsDataGridStyle()
        {
            customersInstallmentsDataGridView.RowTemplate.Height = 38;

            if (isFirst)
            {

                //customersDataGridView.Columns["CustomerId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["RemainingAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["NumberOfInstallments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["DueThisMonth"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                customersInstallmentsDataGridView.Columns["CustomerId"].Visible = false;

                customersInstallmentsDataGridView.Columns["CustomerName"].HeaderText = "إسم العميل";
                customersInstallmentsDataGridView.Columns["Phone"].HeaderText = "هاتف العميل";
                customersInstallmentsDataGridView.Columns["RemainingAmount"].HeaderText = "المتبقي على العميل";
                customersInstallmentsDataGridView.Columns["NumberOfInstallments"].HeaderText = "عدد الأقساط على العميل";
                customersInstallmentsDataGridView.Columns["DueThisMonth"].HeaderText = "المطلوب سداده هذا الشهر";
            }
            else
            {
                customersInstallmentsDataGridView.Columns["TotalAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["PaymentPerMonth"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["DueDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["RemainingInstallments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["DelayDays"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //ledgerDataGridView.Columns["transaction_id"].Visible = false;
                customersInstallmentsDataGridView.Columns["TotalAmount"].HeaderText = "قيمة القسط";
                customersInstallmentsDataGridView.Columns["PaymentPerMonth"].HeaderText = "المبلغ الشهري";
                customersInstallmentsDataGridView.Columns["DueDate"].HeaderText = "تاريخ استحقاق القسط القادم";
                customersInstallmentsDataGridView.Columns["RemainingInstallments"].HeaderText = "الأقساط المتبقية";
                customersInstallmentsDataGridView.Columns["DelayDays"].HeaderText = "أيام التأخير";
                customersInstallmentsDataGridView.Columns["Description"].HeaderText = "ملاحظات";

            }
        }
        private void MonthInstallmentsDataGridStyle()
        {
            customersInstallmentsDataGridView.RowTemplate.Height = 38;
            //customersInstallmentsDataGridView.Columns["InstallmentId"].Visible = false;
            //customersInstallmentsDataGridView.Columns["CustomerId"].Visible = false;

            customersInstallmentsDataGridView.Columns["CustomerName"].HeaderText = "اسم العميل";
            customersInstallmentsDataGridView.Columns["DueDate"].HeaderText = "تاريخ الإستحقاق";
            customersInstallmentsDataGridView.Columns["TotalAmount"].HeaderText = "المبلغ المراد تقسيطه";
            customersInstallmentsDataGridView.Columns["PaymentPerMonth"].HeaderText = "قيمة القسط";
            customersInstallmentsDataGridView.Columns["RemainingAmount"].HeaderText = "المتبقي";
            customersInstallmentsDataGridView.Columns["RemainingInstallments"].HeaderText = "الأقساط المتبقية";
            customersInstallmentsDataGridView.Columns["DelayDays"].HeaderText = "مر على موعد السداد";
            customersInstallmentsDataGridView.Columns["Description"].HeaderText = "ملاحظات";

            customersInstallmentsDataGridView.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["TotalAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["DueDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["PaymentPerMonth"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["RemainingAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["RemainingInstallments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["DelayDays"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
        }
        private async Task LoadCustomers()
        {

            var url = "https://localhost:7176/api/Customers";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerDTO>>(responseBody);

                customersInstallmentsDataGridView.DataSource = customers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                customersInstallmentsDataGridView.DataSource = new List<CustomerDTO>();
            }


            InstallmentsDataGridStyle();
        }


        private async Task LoadInstallmentsAsync(int id)
        {
            var url = $"https://localhost:7176/api/Installments/customer/{id}";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                var installments = JsonConvert.DeserializeObject<List<InstallmentDTO>>(body);

                customersInstallmentsDataGridView.DataSource = installments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                customersInstallmentsDataGridView.DataSource = new List<InstallmentDTO>();
            }

            InstallmentsDataGridStyle();

        }

        private async Task SearchCustomersAsync(string text)
        {
            var url = $"https://localhost:7176/api/Customers/search?text={text}";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerDTO>>(responseBody);

                customersInstallmentsDataGridView.DataSource = customers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                customersInstallmentsDataGridView.DataSource = new List<CustomerDTO>();
            }


        }

        private async Task LoadMonthInstallmentsAsync()
        {
            var url = "https://localhost:7176/api/Installments/month";

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.Token);

                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var Installments = JsonConvert.DeserializeObject<List<InstallmentDTO>>(responseBody);
                customersInstallmentsDataGridView.DataSource = Installments;
            }
            catch (Exception)
            {

                customersInstallmentsDataGridView.DataSource = new List<InstallmentDTO>();
            }

            MonthInstallmentsDataGridStyle();

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            async void handleSearch()
            {
                if (searchTextBox.Text.Length > 0)
                {
                    await SearchCustomersAsync(searchTextBox.Text);
                }
                else
                {
                    await LoadCustomers();
                }
            }

            handleSearch();
            xBtn.Visible = false;
            isFirst = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFirst)
            {
                ((MainForm)this.ParentForm).ChangeTitle("الأقساط المسجلة على العميل");
                isFirst = false;
                xBtn.Visible = true;
                DataGridView dataGridView = (DataGridView)sender;

                int row_clicked = dataGridView.CurrentRow.Index;
                int id = (int)dataGridView.Rows[row_clicked].Cells[0].Value;

                async void doubleClickHandler()
                {
                    await LoadInstallmentsAsync(id);

                }

                doubleClickHandler();
            }
        }

        private void month_installments_btn_Click(object sender, EventArgs e)
        {

            ((MainForm)this.ParentForm).ChangeTitle("أقساط الشهر الحالي");

            async void MonthInstallmentsHandler()
            {
                await LoadMonthInstallmentsAsync();
            }

            MonthInstallmentsHandler();
            xBtn.Visible = true;
        }

        private void xBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ChangeTitle("الأقساط");
            isFirst = true;
            xBtn.Visible = false;
            searchTextBox.Text = "";
            LoadCustomers();

        }



        private void new_insta_btn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ChangeTitle("قسط جديد");
            ((MainForm)this.ParentForm).loadform(new NewInstallmentForm());
        }

        private void customersInstallmentsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = customersInstallmentsDataGridView.Columns[e.ColumnIndex].Name;

            if (columnName == "RemainingInstallments")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int count))
                {
                    e.Value = $"{count} {(count == 1 || count > 10 ? "قسط" : "أقساط")}";
                    e.FormattingApplied = true;
                }
            }
            else if (columnName == "DelayDays")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int days))
                {
                    e.Value = $"{days} {(days == 1 || days > 10 ? "يوم" : "أيام")}";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
