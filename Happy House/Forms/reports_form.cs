using Azure;
using HappyHouse_Client.Old;
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
    public partial class reports_form : Form
    {
        BindingSource reportsBindingSource = new BindingSource();
        public reports_form()
        {
            InitializeComponent();

            reportsDataGridView.AllowUserToAddRows = false;
            dateTimePickerFrom.CustomFormat = "yyyy";
            dateTimePickerTo.CustomFormat = "yyyy";

            // Set the Format property to Custom to allow custom formatting
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.Format = DateTimePickerFormat.Custom;

            // Set the ShowUpDown property to true to display up and down buttons
            dateTimePickerFrom.ShowUpDown = true;
            dateTimePickerTo.ShowUpDown = true;

            LoadReports();
            

        }

        private void SetArabicHeaders()
        {
            string[] arabicMonths = { "يناير", "فبراير", "مارس", "إبريل", "مايو", "يونيو", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر" };

            for (int i = 4; i <= 15; i++) // Assuming the months start from column index 4 and end at 15
            {
                string englishMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i - 3); // Get the English month name
                reportsDataGridView.Columns[englishMonth].HeaderText = arabicMonths[i - 4];
            }
            reportsDataGridView.Columns["customer_name"].HeaderText = "إسم العميل";
            reportsDataGridView.Columns["amount"].HeaderText = "المبلغ الكلي";
            reportsDataGridView.Columns["pay_per_month"].HeaderText = "قيمه القسط";
            reportsDataGridView.Columns["remaining_amount"].HeaderText = "المبلغ المتبقي";
        }


        

        private void LoadReports()
        {

            Reports_DAO reports_DAO = new Reports_DAO();
            reportsBindingSource.DataSource = reports_DAO.GetReports(int.Parse(dateTimePickerFrom.Value.ToString("yyyy")), int.Parse(dateTimePickerTo.Value.ToString("yyyy")));
            reportsDataGridView.DataSource = reportsBindingSource;
            Calculate_sammary();
            reportsDataGridView.Columns[0].Frozen = true;
            reportsDataGridView.RowTemplate.Height = 38;

            SetArabicHeaders();

            

        }


        private void reports_form_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }



        private void Calculate_sammary()
        {
            decimal s_amount = 0;
            decimal s_per_month = 0;
            decimal s_remaining = 0;
            decimal s_january = 0;
            decimal s_february = 0;
            decimal s_march = 0;
            decimal s_april = 0;
            decimal s_may = 0;
            decimal s_june = 0;
            decimal s_july = 0;
            decimal s_august = 0;
            decimal s_september = 0;
            decimal s_october = 0;
            decimal s_november = 0;
            decimal s_december = 0;

            for (int i = 0; i < reportsDataGridView.Rows.Count; i++)
            {
                s_amount += decimal.Parse(reportsDataGridView.Rows[i].Cells[1].Value.ToString());
                s_per_month += decimal.Parse(reportsDataGridView.Rows[i].Cells[2].Value.ToString());
                s_remaining += decimal.Parse(reportsDataGridView.Rows[i].Cells[3].Value.ToString());

                // Add values for each month
                s_january += decimal.Parse(reportsDataGridView.Rows[i].Cells[4].Value.ToString());
                s_february += decimal.Parse(reportsDataGridView.Rows[i].Cells[5].Value.ToString());
                s_march += decimal.Parse(reportsDataGridView.Rows[i].Cells[6].Value.ToString());
                s_april += decimal.Parse(reportsDataGridView.Rows[i].Cells[7].Value.ToString());
                s_may += decimal.Parse(reportsDataGridView.Rows[i].Cells[8].Value.ToString());
                s_june += decimal.Parse(reportsDataGridView.Rows[i].Cells[9].Value.ToString());
                s_july += decimal.Parse(reportsDataGridView.Rows[i].Cells[10].Value.ToString());
                s_august += decimal.Parse(reportsDataGridView.Rows[i].Cells[11].Value.ToString());
                s_september += decimal.Parse(reportsDataGridView.Rows[i].Cells[12].Value.ToString());
                s_october += decimal.Parse(reportsDataGridView.Rows[i].Cells[13].Value.ToString());
                s_november += decimal.Parse(reportsDataGridView.Rows[i].Cells[14].Value.ToString());
                s_december += decimal.Parse(reportsDataGridView.Rows[i].Cells[15].Value.ToString());
            }

            UpdateDataSourceWithSummary(s_amount, s_per_month, s_remaining, s_january, s_february, s_march, s_april, s_may, s_june, s_july, s_august, s_september, s_october, s_november, s_december);
        }

        private void UpdateDataSourceWithSummary(decimal s_amount, decimal s_per_month, decimal s_remaining, decimal s_january, decimal s_february, decimal s_march, decimal s_april, decimal s_may, decimal s_june, decimal s_july, decimal s_august, decimal s_september, decimal s_october, decimal s_november, decimal s_december)
        {
            List<Report> reportsList = (List<Report>)reportsBindingSource.DataSource;

            // Create a new instance of Happy_House.Report for the summary
            Report summaryReport = new Report
            {
                customer_name = "الملخص",
                amount = s_amount,
                pay_per_month = s_per_month,
                remaining_amount = s_remaining,
                january = s_january,
                february = s_february,
                march = s_march,
                april = s_april,
                may = s_may,
                june = s_june,
                july = s_july,
                august = s_august,
                september = s_september,
                october = s_october,
                november = s_november,
                december = s_december,
            };

            // Add the summary report to the list
            reportsList.Add(summaryReport);

            // Reset the data source to reflect the changes
            reportsBindingSource.DataSource = null;
            reportsBindingSource.DataSource = reportsList;
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value > dateTimePickerTo.Value)
            {
                dateTimePickerTo.Value = dateTimePickerFrom.Value;
            }
            LoadReports();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerTo.Value < dateTimePickerFrom.Value)
            {
                dateTimePickerFrom.Value = dateTimePickerTo.Value;
            }
            LoadReports();
        }



    }

}

