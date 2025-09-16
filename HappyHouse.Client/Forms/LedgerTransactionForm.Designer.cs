namespace HappyHouse_Client
{
    partial class LedgerTransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            ledمصروفاتbtn = new Button();
            CashBtn = new Button();
            InstallmentsBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 58F);
            label1.Location = new Point(333, 193);
            label1.Name = "label1";
            label1.Size = new Size(503, 130);
            label1.TabIndex = 7;
            label1.Text = "نوع العملية";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ledمصروفاتbtn
            // 
            ledمصروفاتbtn.Anchor = AnchorStyles.Right;
            ledمصروفاتbtn.BackColor = Color.FromArgb(14, 52, 65);
            ledمصروفاتbtn.FlatAppearance.BorderSize = 0;
            ledمصروفاتbtn.FlatStyle = FlatStyle.Flat;
            ledمصروفاتbtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ledمصروفاتbtn.ForeColor = Color.White;
            ledمصروفاتbtn.Location = new Point(333, 340);
            ledمصروفاتbtn.Name = "ledمصروفاتbtn";
            ledمصروفاتbtn.Size = new Size(225, 62);
            ledمصروفاتbtn.TabIndex = 6;
            ledمصروفاتbtn.Text = "مصروفات";
            ledمصروفاتbtn.UseVisualStyleBackColor = false;
            ledمصروفاتbtn.Click += ledمصروفاتbtn_Click;
            // 
            // ledكاشbtn
            // 
            CashBtn.Anchor = AnchorStyles.None;
            CashBtn.BackColor = Color.FromArgb(14, 52, 65);
            CashBtn.FlatAppearance.BorderSize = 0;
            CashBtn.FlatStyle = FlatStyle.Flat;
            CashBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CashBtn.ForeColor = Color.White;
            CashBtn.Location = new Point(608, 340);
            CashBtn.Name = "ledكاشbtn";
            CashBtn.Size = new Size(225, 64);
            CashBtn.TabIndex = 5;
            CashBtn.Text = "كاش";
            CashBtn.UseVisualStyleBackColor = false;
            CashBtn.Click += CashBtn_Click;
            // 
            // ledأقساطbtn
            // 
            InstallmentsBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            InstallmentsBtn.BackColor = Color.FromArgb(14, 52, 65);
            InstallmentsBtn.FlatAppearance.BorderSize = 0;
            InstallmentsBtn.FlatStyle = FlatStyle.Flat;
            InstallmentsBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InstallmentsBtn.ForeColor = Color.White;
            InstallmentsBtn.Location = new Point(333, 434);
            InstallmentsBtn.Name = "ledأقساطbtn";
            InstallmentsBtn.Size = new Size(500, 62);
            InstallmentsBtn.TabIndex = 4;
            InstallmentsBtn.Text = "أقساط";
            InstallmentsBtn.UseVisualStyleBackColor = false;
            InstallmentsBtn.Click += InstallmentsBtn_Click;
            // 
            // ledger_transaction_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1168, 688);
            Controls.Add(label1);
            Controls.Add(ledمصروفاتbtn);
            Controls.Add(CashBtn);
            Controls.Add(InstallmentsBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ledger_transaction_form";
            Text = "ledger_transaction_form";
            Resize += LedgerTransactionForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ledمصروفاتbtn;
        private Button CashBtn;
        private Button InstallmentsBtn;
    }
}