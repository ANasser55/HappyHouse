namespace HappyHouse_Client
{
    partial class LedgerInstallmentsForm
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
            backBtn = new Button();
            addBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            amountTextBox = new TextBox();
            richTextBox1 = new RichTextBox();
            dateTimePicker1 = new DateTimePicker();
            CustomerComboBox = new ComboBox();
            InstallmentComboBox = new ComboBox();
            InstallmentsLabel = new Label();
            CustomerLabel = new Label();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.FromArgb(14, 52, 65);
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(274, 477);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(94, 28);
            backBtn.TabIndex = 0;
            backBtn.Text = "عودة";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += BackBtn_Click;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(14, 52, 65);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(754, 477);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 28);
            addBtn.TabIndex = 1;
            addBtn.Text = "حفظ";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += AddBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(923, 231);
            label1.Name = "label1";
            label1.Size = new Size(44, 19);
            label1.TabIndex = 2;
            label1.Text = "المبلغ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(921, 287);
            label2.Name = "label2";
            label2.Size = new Size(47, 19);
            label2.TabIndex = 3;
            label2.Text = "التاريخ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(923, 366);
            label4.Name = "label4";
            label4.Size = new Size(63, 19);
            label4.TabIndex = 5;
            label4.Text = "ملاحظات";
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(274, 231);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(574, 26);
            amountTextBox.TabIndex = 6;
            amountTextBox.Enter += AmountTextBox_Enter;
            amountTextBox.Leave += AmountTextBox_Leave;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(274, 345);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(574, 114);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 9F);
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(274, 280);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.RightToLeft = RightToLeft.No;
            dateTimePicker1.Size = new Size(574, 26);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.Value = new DateTime(2023, 7, 31, 0, 0, 0, 0);
            // 
            // CustomerComboBox
            // 
            CustomerComboBox.FormattingEnabled = true;
            CustomerComboBox.Location = new Point(274, 130);
            CustomerComboBox.Name = "CustomerComboBox";
            CustomerComboBox.RightToLeft = RightToLeft.Yes;
            CustomerComboBox.Size = new Size(574, 27);
            CustomerComboBox.TabIndex = 13;
            CustomerComboBox.SelectedIndexChanged += CustomerComboBox_SelectedIndexChanged;
            // 
            // InstallmentComboBox
            // 
            InstallmentComboBox.FormattingEnabled = true;
            InstallmentComboBox.Location = new Point(274, 185);
            InstallmentComboBox.Name = "InstallmentComboBox";
            InstallmentComboBox.RightToLeft = RightToLeft.Yes;
            InstallmentComboBox.Size = new Size(574, 27);
            InstallmentComboBox.TabIndex = 14;
            InstallmentComboBox.SelectedIndexChanged += InstallmentComboBox_SelectedIndexChanged;
            // 
            // InstallmentsLabel
            // 
            InstallmentsLabel.AutoSize = true;
            InstallmentsLabel.Location = new Point(918, 185);
            InstallmentsLabel.Name = "InstallmentsLabel";
            InstallmentsLabel.Size = new Size(49, 19);
            InstallmentsLabel.TabIndex = 16;
            InstallmentsLabel.Text = "القسط";
            // 
            // CustomerLabel
            // 
            CustomerLabel.AutoSize = true;
            CustomerLabel.Location = new Point(918, 130);
            CustomerLabel.Name = "CustomerLabel";
            CustomerLabel.Size = new Size(48, 19);
            CustomerLabel.TabIndex = 15;
            CustomerLabel.Text = "العميل";
            // 
            // LedgerInstallmentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 654);
            Controls.Add(InstallmentsLabel);
            Controls.Add(CustomerLabel);
            Controls.Add(InstallmentComboBox);
            Controls.Add(CustomerComboBox);
            Controls.Add(dateTimePicker1);
            Controls.Add(richTextBox1);
            Controls.Add(amountTextBox);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addBtn);
            Controls.Add(backBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LedgerInstallmentsForm";
            Text = "ledger_installments";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backBtn;
        private Button addBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox amountTextBox;
        private RichTextBox richTextBox1;
        private DataGridView customersLedgerDataGridView;
        private DateTimePicker dateTimePicker1;
        private Button xBtn;
        private ComboBox CustomerComboBox;
        private ComboBox InstallmentComboBox;
        private Label InstallmentsLabel;
        private Label CustomerLabel;
    }
}