namespace HappyHouse_Client
{
    partial class ledger_transaction_form
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
            ledكاشbtn = new Button();
            ledأقساطbtn = new Button();
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
            ledكاشbtn.Anchor = AnchorStyles.None;
            ledكاشbtn.BackColor = Color.FromArgb(14, 52, 65);
            ledكاشbtn.FlatAppearance.BorderSize = 0;
            ledكاشbtn.FlatStyle = FlatStyle.Flat;
            ledكاشbtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ledكاشbtn.ForeColor = Color.White;
            ledكاشbtn.Location = new Point(608, 340);
            ledكاشbtn.Name = "ledكاشbtn";
            ledكاشbtn.Size = new Size(225, 64);
            ledكاشbtn.TabIndex = 5;
            ledكاشbtn.Text = "كاش";
            ledكاشbtn.UseVisualStyleBackColor = false;
            ledكاشbtn.Click += ledكاشbtn_Click;
            // 
            // ledأقساطbtn
            // 
            ledأقساطbtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ledأقساطbtn.BackColor = Color.FromArgb(14, 52, 65);
            ledأقساطbtn.FlatAppearance.BorderSize = 0;
            ledأقساطbtn.FlatStyle = FlatStyle.Flat;
            ledأقساطbtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ledأقساطbtn.ForeColor = Color.White;
            ledأقساطbtn.Location = new Point(333, 434);
            ledأقساطbtn.Name = "ledأقساطbtn";
            ledأقساطbtn.Size = new Size(500, 62);
            ledأقساطbtn.TabIndex = 4;
            ledأقساطbtn.Text = "أقساط";
            ledأقساطbtn.UseVisualStyleBackColor = false;
            ledأقساطbtn.Click += ledأقساطbtn_Click;
            // 
            // ledger_transaction_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1168, 688);
            Controls.Add(label1);
            Controls.Add(ledمصروفاتbtn);
            Controls.Add(ledكاشbtn);
            Controls.Add(ledأقساطbtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ledger_transaction_form";
            Text = "ledger_transaction_form";
            Resize += ledger_transaction_form_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ledمصروفاتbtn;
        private Button ledكاشbtn;
        private Button ledأقساطbtn;
    }
}