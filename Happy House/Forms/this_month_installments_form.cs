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
    public partial class this_month_installments_form : Form
    {
        public this_month_installments_form()
        {
            InitializeComponent();
            InstallmentsForThisMonthDAO installmentsForThisMonthDAO = new InstallmentsForThisMonthDAO();
            month_installments_binding_source.DataSource = installmentsForThisMonthDAO.getMonthInstallments();
            monthInstallmentsDataGridView.DataSource = month_installments_binding_source;
        }

        BindingSource month_installments_binding_source = new BindingSource();
    }
}
