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
    public partial class LedgerTransactionForm : Form
    {
        public LedgerTransactionForm()
        {
            InitializeComponent();
        }

        private void CashBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerCashForm());
        }

        private void InstallmentsBtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerInstallmentsForm());
        }

        private void LedgerTransactionForm_Resize(object sender, EventArgs e)
        {
            CashBtn.Width = InstallmentsBtn.Width / 2 - 25;
            ledمصروفاتbtn.Width = InstallmentsBtn.Width / 2 - 25;
            ledمصروفاتbtn.Location = new Point(InstallmentsBtn.Location.X, CashBtn.Location.Y);
        }

        private void ledمصروفاتbtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).loadform(new LedgerExpensesForm());
        }
    }
}
