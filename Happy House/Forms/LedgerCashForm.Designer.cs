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
            SuspendLayout();
            // 
            // cashAmountTextBox
            // 
            cashAmountTextBox.Location = new Point(397, 156);
            cashAmountTextBox.Name = "cashAmountTextBox";
            cashAmountTextBox.Size = new Size(374, 27);
            cashAmountTextBox.TabIndex = 0;
            cashAmountTextBox.Enter += cashAmountTextBox_Enter;
            cashAmountTextBox.Leave += cashAmountTextBox_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(817, 147);
            label1.Name = "label1";
            label1.Size = new Size(75, 35);
            label1.TabIndex = 2;
            label1.Text = "المبلغ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(800, 298);
            label2.Name = "label2";
            label2.Size = new Size(109, 35);
            label2.TabIndex = 3;
            label2.Text = "ملاحظات";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(815, 222);
            label3.Name = "label3";
            label3.Size = new Size(78, 35);
            label3.TabIndex = 6;
            label3.Text = "التاريخ";
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(14, 52, 65);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(655, 492);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(116, 48);
            addBtn.TabIndex = 7;
            addBtn.Text = "حفظ";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // عودةbtn
            // 
            عودةbtn.BackColor = Color.FromArgb(14, 52, 65);
            عودةbtn.FlatAppearance.BorderSize = 0;
            عودةbtn.FlatStyle = FlatStyle.Flat;
            عودةbtn.ForeColor = Color.White;
            عودةbtn.Location = new Point(397, 492);
            عودةbtn.Name = "عودةbtn";
            عودةbtn.Size = new Size(116, 48);
            عودةbtn.TabIndex = 8;
            عودةbtn.Text = "عودة";
            عودةbtn.UseVisualStyleBackColor = false;
            عودةbtn.Click += عودةbtn_Click;
            // 
            // cashDateTimePicker
            // 
            cashDateTimePicker.Format = DateTimePickerFormat.Custom;
            cashDateTimePicker.Location = new Point(397, 232);
            cashDateTimePicker.Name = "cashDateTimePicker";
            cashDateTimePicker.Size = new Size(374, 27);
            cashDateTimePicker.TabIndex = 9;
            // 
            // cashRichTextBox1
            // 
            cashRichTextBox1.BorderStyle = BorderStyle.FixedSingle;
            cashRichTextBox1.Location = new Point(397, 299);
            cashRichTextBox1.Name = "cashRichTextBox1";
            cashRichTextBox1.Size = new Size(374, 120);
            cashRichTextBox1.TabIndex = 4;
            cashRichTextBox1.Text = "";
            // 
            // ledger_cash_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1168, 688);
            Controls.Add(cashDateTimePicker);
            Controls.Add(عودةbtn);
            Controls.Add(addBtn);
            Controls.Add(label3);
            Controls.Add(cashRichTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cashAmountTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ledger_cash_form";
            Text = "ledger_cash_form";
            Click += ledger_cash_form_Click;
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
    }
}