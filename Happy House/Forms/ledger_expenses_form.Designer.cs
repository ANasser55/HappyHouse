namespace HappyHouse_Client
{
    partial class ledger_expenses_form
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
            dateTimePicker1 = new DateTimePicker();
            backBtn = new Button();
            addBtn = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            amountTextBox = new TextBox();
            checkBox1 = new CheckBox();
            descriptionTextBox = new TextBox();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(364, 231);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(374, 27);
            dateTimePicker1.TabIndex = 2;
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.FromArgb(14, 52, 65);
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(392, 408);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(116, 48);
            backBtn.TabIndex = 5;
            backBtn.Text = "عودة";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(14, 52, 65);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(622, 408);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(116, 48);
            addBtn.TabIndex = 4;
            addBtn.Text = "حفظ";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(782, 221);
            label3.Name = "label3";
            label3.Size = new Size(78, 35);
            label3.TabIndex = 14;
            label3.Text = "التاريخ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(751, 298);
            label2.Name = "label2";
            label2.Size = new Size(109, 35);
            label2.TabIndex = 12;
            label2.Text = "ملاحظات";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(784, 146);
            label1.Name = "label1";
            label1.Size = new Size(75, 35);
            label1.TabIndex = 11;
            label1.Text = "المبلغ";
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(364, 155);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(374, 27);
            amountTextBox.TabIndex = 0;
            amountTextBox.Enter += amountTextBox_Enter;
            amountTextBox.Leave += amountTextBox_Leave;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F);
            checkBox1.Location = new Point(245, 150);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(104, 32);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "إبقاء دين";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(364, 306);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(374, 27);
            descriptionTextBox.TabIndex = 3;
            // 
            // ledger_expenses_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 671);
            Controls.Add(descriptionTextBox);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(backBtn);
            Controls.Add(addBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(amountTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ledger_expenses_form";
            Text = "ledger_expenses_form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Button backBtn;
        private Button addBtn;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox amountTextBox;
        private CheckBox checkBox1;
        private TextBox descriptionTextBox;
    }
}