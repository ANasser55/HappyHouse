using HappyHouse_Client.Models;
using Newtonsoft.Json;


namespace HappyHouse_Client
{
    public partial class LedgerForm : Form
    {
        private readonly HttpClient httpClient = new HttpClient();

        bool isSearch = true;
        bool isFirst = true;
        public LedgerForm()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            LoadLedgerAsync();

        }

        private void LedgerDataGridStyle()
        {
            ledgerDataGridView.RowTemplate.Height = 38;

            if (isFirst)
            {
                ledgerDataGridView.Columns["date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["income"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["expense"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ledgerDataGridView.Columns["date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                ledgerDataGridView.Columns["date"].HeaderText = "التاريخ";
                ledgerDataGridView.Columns["income"].HeaderText = "الدخل";
                ledgerDataGridView.Columns["expense"].HeaderText = "المصروفات";
                ledgerDataGridView.Columns["balance"].HeaderText = "الخزنة";
                ledgerDataGridView.Columns["LedgerId"].Visible = false;
            }
            else
            {
                ledgerDataGridView.Columns["TransactionId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["TransactorName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                ledgerDataGridView.Columns["TransactorName"].HeaderText = "اسم العميل";
                ledgerDataGridView.Columns["Amount"].HeaderText = "المبلغ";
                ledgerDataGridView.Columns["Type"].HeaderText = "نوع المعامله";
                ledgerDataGridView.Columns["Description"].HeaderText = "ملاحظات";
                ledgerDataGridView.Columns["CustomerId"].Visible = false;
                ledgerDataGridView.Columns["DebtorId"].Visible = false;
                ledgerDataGridView.Columns["LedgerId"].Visible = false;
                ledgerDataGridView.Columns["TransactionId"].Visible = false;
                ledgerDataGridView.Columns["InstallmentId"].Visible = false;
            }
        }

        public async Task<List<Ledger>> GetLedgersAsync()
        {
            var url = "https://localhost:7176/api/Ledger/all";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var ledgers = JsonConvert.DeserializeObject<List<Ledger>>(body);

                return ledgers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return new List<Ledger>();
            }
        }
        private async Task LoadLedgerAsync()
        {
            var ledgers = await GetLedgersAsync();
            ledgerDataGridView.DataSource = ledgers;

            LedgerDataGridStyle();
        }
        private async Task SearchLedgerAsync(DateTime date)
        {
            var url = $"https://localhost:7176/api/Ledger/date?date={date}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var ledgers = JsonConvert.DeserializeObject<List<Ledger>>(body);

                ledgerDataGridView.DataSource = ledgers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                ledgerDataGridView.DataSource = new List<Ledger>();
            }

        }

        private async Task LoadTransactions(int id)
        {
            var url = $"https://localhost:7176/api/Transactions/LedgerTransactions/{id}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var transactions = JsonConvert.DeserializeObject<List<Transaction>>(body);

                ledgerDataGridView.DataSource = transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                ledgerDataGridView.DataSource = new List<Transaction>();
            }

            LedgerDataGridStyle();
        }





        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (isSearch)
            {
                dateXBtn.Visible = true;

                DateTimePicker dateTimePicker = (DateTimePicker)sender;
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "dd/MM/yyyy";


                DateTime date = dateTimePicker.Value;

                async void HandleSearch()
                {
                   await SearchLedgerAsync(date);
                }

                HandleSearch();

            }

            isSearch = true;
        }

        private void dateXBtn_Click(object sender, EventArgs e)
        {
            dateXBtn.Visible = false;
            isSearch = false;
            isFirst = true;
            dateTimePicker1.Value = DateTime.Today;
            LoadLedgerAsync();
        }

        private void ledعملية_جديدةbtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerTransactionForm());
        }

        private void ledgerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFirst)
            {
                isFirst = false;
                DataGridView dataGridView = (DataGridView)sender;

                int row_clicked = dataGridView.CurrentRow.Index;
                int id = (int)dataGridView.Rows[row_clicked].Cells[0].Value;
                DateTime date = (DateTime)dataGridView.Rows[row_clicked].Cells[1].Value;

                isSearch = false;

                dateTimePicker1.Value = date;

                isSearch = true;

                async void Handler()
                {
                    await LoadTransactions(id);
                }

                Handler();

                dateXBtn.Visible = true;

            }
        }
    }
}
