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
    public partial class ledger_transaction_form : Form
    {
        public ledger_transaction_form()
        {
            InitializeComponent();
        }

        private void ledكاشbtn_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).loadform(new ledger_cash_form());
        }

        private void ledأقساطbtn_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).loadform(new ledger_installments());
        }

        private void ledger_transaction_form_Resize(object sender, EventArgs e)
        {
            ledكاشbtn.Width = ledأقساطbtn.Width / 2 - 25;
            ledمصروفاتbtn.Width = ledأقساطbtn.Width / 2 - 25;
            ledمصروفاتbtn.Location = new Point(ledأقساطbtn.Location.X, ledكاشbtn.Location.Y);
        }

        private void ledمصروفاتbtn_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).loadform(new ledger_expenses_form());
        }
    }
}
