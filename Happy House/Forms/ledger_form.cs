using HappyHouse_Client.Old;
using HappyHouse_Client.Models;
using Newtonsoft.Json;
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
    public partial class ledger_form : Form
    {
        private readonly HttpClient httpClient = new HttpClient();

        BindingSource ledgerBindingSource = new BindingSource();
        bool isSearch = true;
        bool isFirst = true;
        public ledger_form()
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


                //ledgerDataGridView.Columns["TransactionId"].Visible = false;
                ledgerDataGridView.Columns["TransactionId"].HeaderText = "رقم المعاملة";
                ledgerDataGridView.Columns["TransactorName"].HeaderText = "اسم العميل";
                ledgerDataGridView.Columns["Amount"].HeaderText = "المبلغ";
                ledgerDataGridView.Columns["Type"].HeaderText = "نوع المعامله";
                ledgerDataGridView.Columns["Description"].HeaderText = "ملاحظات";
                ledgerDataGridView.Columns["CustomerId"].Visible = false;
                ledgerDataGridView.Columns["DebtorId"].Visible = false;
                ledgerDataGridView.Columns["LedgerId"].Visible = false;
            }
        }

        public async Task<List<Models.Ledger>> GetLedgersAsync()
        {
            var url = "https://localhost:7176/api/Ledger/all";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var ledgers = JsonConvert.DeserializeObject<List<Models.Ledger>>(body);

                return ledgers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return new List<Models.Ledger>();
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
                var ledgers = JsonConvert.DeserializeObject<List<Models.Ledger>>(body);

                ledgerDataGridView.DataSource = ledgers;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                ledgerDataGridView.DataSource = new List<Models.Ledger>();
            }

        }

        private async Task LoadTransactions(int id)
        {
            var url = $"https://localhost:7176/api/Transactions/getLedgerTransactions?id={id}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var transactions = JsonConvert.DeserializeObject<List<Models.Transaction>>(body);

                ledgerDataGridView.DataSource = transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                ledgerDataGridView.DataSource = new List<Models.Transaction>();
            }

            //TransactionDAO transaction_DAO = new TransactionDAO();
            //ledgerBindingSource.DataSource = transaction_DAO.GetTransactionsLedger(id);
            //ledgerDataGridView.DataSource = ledgerBindingSource;

            //LedgerDataGridStyle();


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
                //isFirst = true;

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
            ((Form1)this.ParentForm).loadform(new ledger_transaction_form());
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
                //LedgerDataGridStyle();

                dateXBtn.Visible = true;

            }
        }
    }
}
