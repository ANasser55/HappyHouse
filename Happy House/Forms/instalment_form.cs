using HappyHouse_Client.Models;
using HappyHouse_Client.Old;
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
    public partial class instalment_form : Form
    {
        private readonly HttpClient _client = new HttpClient();

        public instalment_form()
        {
            InitializeComponent();

            LoadCustomers();

        }

        private void InstallmentsDataGridStyle()
        {
            customersInstallmentsDataGridView.RowTemplate.Height = 38;

            if (isFirst)
            {
                customersInstallmentsDataGridView.Columns["customer_id"].Width = 150;
                customersInstallmentsDataGridView.Columns["customer_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["customer_phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["customer_next_payment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["customer_total_remaining"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                customersInstallmentsDataGridView.Columns["customer_id"].HeaderText = "كود العميل";
                customersInstallmentsDataGridView.Columns["customer_name"].HeaderText = "إسم العميل";
                customersInstallmentsDataGridView.Columns["customer_phone"].HeaderText = "هاتف العميل";
                customersInstallmentsDataGridView.Columns["customer_next_payment"].HeaderText = "المطلوب سداده هذا الشهر";
                customersInstallmentsDataGridView.Columns["customer_total_remaining"].HeaderText = "المتبقي على العميل";
            }
            else
            {
                customersInstallmentsDataGridView.Columns["installment_id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["customer_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["installment_amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["next_date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["remaining"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                customersInstallmentsDataGridView.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //ledgerDataGridView.Columns["transaction_id"].Visible = false;
                customersInstallmentsDataGridView.Columns["customer_name"].HeaderText = "اسم العميل";
                customersInstallmentsDataGridView.Columns["installment_id"].HeaderText = "رقم القسط";
                customersInstallmentsDataGridView.Columns["installment_amount"].HeaderText = "قيمة القسط";
                customersInstallmentsDataGridView.Columns["next_date"].HeaderText = "تاريخ استحقاق القسط القادم";
                customersInstallmentsDataGridView.Columns["remaining"].HeaderText = "المتبقي";
                customersInstallmentsDataGridView.Columns["description"].HeaderText = "ملاحظات";

            }
        }
        private void MonthInstallmentsDataGridStyle()
        {
            customersInstallmentsDataGridView.RowTemplate.Height = 38;
            customersInstallmentsDataGridView.Columns["InstallmentId"].Visible = false;
            customersInstallmentsDataGridView.Columns["CustomerId"].Visible = false;

            customersInstallmentsDataGridView.Columns["CustomerName"].HeaderText = "اسم العميل";
            customersInstallmentsDataGridView.Columns["NextDate"].HeaderText = "تاريخ الإستحقاق";
            customersInstallmentsDataGridView.Columns["MonthlyAmount"].HeaderText = "قيمة القسط";
            customersInstallmentsDataGridView.Columns["RemainingAmount"].HeaderText = "المتبقي";
            customersInstallmentsDataGridView.Columns["RemainingInstallments"].HeaderText = "الأقساط المتبقية";
            customersInstallmentsDataGridView.Columns["DelayDays"].HeaderText = "مر على موعد السداد";
            customersInstallmentsDataGridView.Columns["Description"].HeaderText = "ملاحظات";

            customersInstallmentsDataGridView.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["NextDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["MonthlyAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["RemainingAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["RemainingInstallments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["DelayDays"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            customersInstallmentsDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
        }
        private void LoadCustomers()
        {
            Customers_DAO customers_DAO = new Customers_DAO();
            customers_DAO.calculate_installments();

            customersBindingSource.DataSource = customers_DAO.getAllCustomers();
            customersInstallmentsDataGridView.DataSource = customersBindingSource;

            InstallmentsDataGridStyle();
        }

        BindingSource customersBindingSource = new BindingSource();
        bool isFirst = true;


        private void LoadInstallments(int id)
        {
            InstallmentsForCustomerDAO installmentsForCustomerDAO = new InstallmentsForCustomerDAO();
            customersBindingSource.DataSource = installmentsForCustomerDAO.getCustomerInstallments(id);
            customersInstallmentsDataGridView.DataSource = customersBindingSource;

            InstallmentsDataGridStyle();


        }

        private void SearchCustomers()
        {
            Customers_DAO customers_DAO = new Customers_DAO();
            customersBindingSource.DataSource = customers_DAO.searchCustomers(searchTextBox.Text);
            customersInstallmentsDataGridView.DataSource = customersBindingSource;
            customersInstallmentsDataGridView.Columns["customer_id"].HeaderText = "كود العميل";
            customersInstallmentsDataGridView.Columns["customer_name"].HeaderText = "إسم العميل";
            customersInstallmentsDataGridView.Columns["customer_phone"].HeaderText = "هاتف العميل";
            customersInstallmentsDataGridView.Columns["customer_next_payment"].HeaderText = "المطلوب سداده هذا الشهر";
            customersInstallmentsDataGridView.Columns["customer_total_remaining"].HeaderText = "المتبقي على العميل";
        }

        private async Task<List<MonthInstallment>> GetThisMonthInstallments()
        {
            var url = "https://localhost:7176/api/MonthInstallments";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var Installments = JsonConvert.DeserializeObject<List<MonthInstallment>>(responseBody);
                return Installments;
            }
            catch (Exception)
            {

                return new List<MonthInstallment>();
            }

        }

        private async Task LoadMonthInstallments()
        {

            customersInstallmentsDataGridView.DataSource = await GetThisMonthInstallments();
            MonthInstallmentsDataGridStyle();

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            Customers_DAO customers_DAO = new Customers_DAO();

            if (searchTextBox.Text.Length > 0)
            {
                SearchCustomers();
            }
            else
            {
                LoadCustomers();
            }
            xBtn.Visible = false;
            isFirst = true;


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFirst)
            {
                ((Form1)this.ParentForm).ChangeTitle("الأقساط المسجلة على العميل");
                isFirst = false;
                xBtn.Visible = true;
                DataGridView dataGridView = (DataGridView)sender;

                int row_clicked = dataGridView.CurrentRow.Index;
                int id = (int)dataGridView.Rows[row_clicked].Cells[0].Value;

                LoadInstallments(id);

            }


        }

        private void month_installments_btn_Click(object sender, EventArgs e)
        {

            ((Form1)this.ParentForm).ChangeTitle("أقساط الشهر الحالي");

            async void MonthInstallmentsHandler()
            {
                await LoadMonthInstallments();
            }

            MonthInstallmentsHandler();
            xBtn.Visible = true;
        }

        private void xBtn_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).ChangeTitle("الأقساط");
            isFirst = true;
            xBtn.Visible = false;
            searchTextBox.Text = "";
            LoadCustomers();

        }



        private void new_insta_btn_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).ChangeTitle("قسط جديد");
            ((Form1)this.ParentForm).loadform(new new_installment_form());
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
