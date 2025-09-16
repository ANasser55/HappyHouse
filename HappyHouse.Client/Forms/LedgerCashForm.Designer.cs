namespace HappyHouse_Client
{
    partial class LedgerCashForm
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
            cashAmountTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            addBtn = new Button();
            عودةbtn = new Button();
            cashDateTimePicker = new DateTimePicker();
            cashRichTextBox1 = new RichTextBox();
            TypeComboBox = new ComboBox();
            TypeLabel = new Label();
            SuspendLayout();
            // 
            // cashAmountTextBox
            // 
            cashAmountTextBox.Location = new Point(397, 148);
            cashAmountTextBox.Name = "cashAmountTextBox";
            cashAmountTextBox.Size = new Size(374, 26);
            cashAmountTextBox.TabIndex = 0;
            cashAmountTextBox.Enter += CashAmountTextBox_Enter;
            cashAmountTextBox.Leave += CashAmountTextBox_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(817, 140);
            label1.Name = "label1";
            label1.Size = new Size(62, 28);
            label1.TabIndex = 2;
            label1.Text = "المبلغ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(800, 329);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 3;
            label2.Text = "ملاحظات";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(815, 257);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 6;
            label3.Text = "التاريخ";
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(14, 52, 65);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(655, 513);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(116, 46);
            addBtn.TabIndex = 7;
            addBtn.Text = "حفظ";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += AddBtn_Click;
            // 
            // عودةbtn
            // 
            عودةbtn.BackColor = Color.FromArgb(14, 52, 65);
            عودةbtn.FlatAppearance.BorderSize = 0;
            عودةbtn.FlatStyle = FlatStyle.Flat;
            عودةbtn.ForeColor = Color.White;
            عودةbtn.Location = new Point(397, 513);
            عودةbtn.Name = "عودةbtn";
            عودةbtn.Size = new Size(116, 46);
            عودةbtn.TabIndex = 8;
            عودةbtn.Text = "عودة";
            عودةbtn.UseVisualStyleBackColor = false;
            عودةbtn.Click += BackBtn_Click;
            // 
            // cashDateTimePicker
            // 
            cashDateTimePicker.Format = DateTimePickerFormat.Custom;
            cashDateTimePicker.Location = new Point(397, 266);
            cashDateTimePicker.Name = "cashDateTimePicker";
            cashDateTimePicker.Size = new Size(374, 26);
            cashDateTimePicker.TabIndex = 9;
            // 
            // cashRichTextBox1
            // 
            cashRichTextBox1.BorderStyle = BorderStyle.FixedSingle;
            cashRichTextBox1.Location = new Point(397, 330);
            cashRichTextBox1.Name = "cashRichTextBox1";
            cashRichTextBox1.Size = new Size(374, 114);
            cashRichTextBox1.TabIndex = 4;
            cashRichTextBox1.Text = "";
            // 
            // TypeComboBox
            // 
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Location = new Point(397, 205);
            TypeComboBox.Name = "TypeComboBox";
            TypeComboBox.Size = new Size(374, 27);
            TypeComboBox.TabIndex = 10;
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Font = new Font("Segoe UI", 15F);
            TypeLabel.Location = new Point(815, 204);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(116, 28);
            TypeLabel.TabIndex = 11;
            TypeLabel.Text = "نوع المعاملة";
            // 
            // LedgerCashForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1168, 654);
            Controls.Add(TypeLabel);
            Controls.Add(TypeComboBox);
            Controls.Add(cashDateTimePicker);
            Controls.Add(عودةbtn);
            Controls.Add(addBtn);
            Controls.Add(label3);
            Controls.Add(cashRichTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cashAmountTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LedgerCashForm";
            Text = "ledger_cash_form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox cashAmountTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button addBtn;
        private Button عودةbtn;
        private DateTimePicker cashDateTimePicker;
        private RichTextBox cashRichTextBox1;
        private ComboBox TypeComboBox;
        private Label TypeLabel;
    }
}