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
    public partial class ledger_form : Form
    {
        BindingSource ledgerBindingSource = new BindingSource();
        bool isSearch = true;
        bool isFirst = true;
        public ledger_form()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            LoadLedger();

            

        }

        private void LedgerDataGridStyle()
        {
            ledgerDataGridView.RowTemplate.Height = 38;

            if (isFirst)
            {
                ledgerDataGridView.Columns["date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["income"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["expense"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["safe_box"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ledgerDataGridView.Columns["date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                ledgerDataGridView.Columns["date"].HeaderText = "التاريخ";
                ledgerDataGridView.Columns["income"].HeaderText = "الدخل";
                ledgerDataGridView.Columns["expense"].HeaderText = "المصروفات";
                ledgerDataGridView.Columns["safe_box"].HeaderText = "الخزنة";
                ledgerDataGridView.Columns["ledger_id"].Visible = false;
            }
            else
            {
                ledgerDataGridView.Columns["transaction_id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["transactor_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ledgerDataGridView.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                

                //ledgerDataGridView.Columns["transaction_id"].Visible = false;
                ledgerDataGridView.Columns["transaction_id"].HeaderText = "رقم المعاملة";
                ledgerDataGridView.Columns["transactor_name"].HeaderText = "اسم العميل";
                ledgerDataGridView.Columns["amount"].HeaderText = "المبلغ";
                ledgerDataGridView.Columns["type"].HeaderText = "نوع المعامله";
                ledgerDataGridView.Columns["description"].HeaderText = "ملاحظات";
                ledgerDataGridView.Columns["customer_id"].Visible = false;
                ledgerDataGridView.Columns["debtor_id"].Visible = false;
                ledgerDataGridView.Columns["ledger_id"].Visible = false;
            }
        }

        private void LoadLedger()
        {
            Ledger_DAO ledger_DAO = new Ledger_DAO();

            ledger_DAO.Calculate_inc_exp();
            ledgerBindingSource.DataSource = ledger_DAO.GetLedgers();
            ledgerDataGridView.DataSource = ledgerBindingSource;

            LedgerDataGridStyle();


        }
        private void SearchLedger(DateTime date)
        {
            Ledger_DAO ledger_DAO = new Ledger_DAO();
            ledgerBindingSource.DataSource = ledger_DAO.search_ledger_date(date);
            ledgerDataGridView.DataSource = ledgerBindingSource;
            ledgerDataGridView.Columns["date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            ledgerDataGridView.Columns["date"].HeaderText = "التاريخ";
            ledgerDataGridView.Columns["income"].HeaderText = "الدخل";
            ledgerDataGridView.Columns["expense"].HeaderText = "المصروفات";
            ledgerDataGridView.Columns["safe_box"].HeaderText = "الخزنة";

            //ledgerDataGridView.Columns["ledger_id"].Visible = false;
        }

        private void LoadTransactions(int id)
        {
            TransactionDAO transaction_DAO = new TransactionDAO();
            ledgerBindingSource.DataSource = transaction_DAO.GetTransactionsLedger(id);
            ledgerDataGridView.DataSource = ledgerBindingSource;

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


                DateTime value = dateTimePicker.Value;
                //isFirst = true;

                SearchLedger(value);

            }

            isSearch = true;
        }

        private void dateXBtn_Click(object sender, EventArgs e)
        {
            dateXBtn.Visible = false;
            isSearch = false;
            isFirst = true;
            dateTimePicker1.Value = DateTime.Today;
            LoadLedger();
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

                LoadTransactions(id);

                dateXBtn.Visible = true;

            }
        }
    }
}
