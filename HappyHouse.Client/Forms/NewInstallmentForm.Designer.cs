namespace HappyHouse_Client
{
    partial class NewInstallmentForm
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
            xBtn = new Button();
            durationTextBox = new TextBox();
            label9 = new Label();
            installmentAmountTextBox = new TextBox();
            label8 = new Label();
            dateTimePicker1 = new DateTimePicker();
            totalAmountTextBox = new TextBox();
            advanceTextBox = new TextBox();
            percentageTextBox = new TextBox();
            amountTextBox = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            descriptionTextBox = new TextBox();
            addBtn = new Button();
            backBtn = new Button();
            CustomerComboBox = new ComboBox();
            SuspendLayout();
            // 
            // xBtn
            // 
            xBtn.Anchor = AnchorStyles.None;
            xBtn.BackColor = Color.FromArgb(14, 52, 65);
            xBtn.FlatAppearance.BorderSize = 0;
            xBtn.FlatStyle = FlatStyle.Flat;
            xBtn.ForeColor = Color.White;
            xBtn.Location = new Point(209, 116);
            xBtn.Name = "xBtn";
            xBtn.Size = new Size(27, 26);
            xBtn.TabIndex = 14;
            xBtn.Text = "X";
            xBtn.UseVisualStyleBackColor = false;
            xBtn.Visible = false;
            xBtn.Click += xBtn_Click;
            // 
            // durationTextBox
            // 
            durationTextBox.Anchor = AnchorStyles.None;
            durationTextBox.Font = new Font("Segoe UI", 9.5F);
            durationTextBox.Location = new Point(242, 442);
            durationTextBox.Name = "durationTextBox";
            durationTextBox.Size = new Size(196, 24);
            durationTextBox.TabIndex = 6;
            durationTextBox.TextAlign = HorizontalAlignment.Right;
            durationTextBox.Leave += durationTextBox_Leave;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(453, 442);
            label9.Name = "label9";
            label9.Size = new Size(90, 21);
            label9.TabIndex = 33;
            label9.Text = "المدة بالشهر";
            // 
            // installmentAmountTextBox
            // 
            installmentAmountTextBox.Anchor = AnchorStyles.None;
            installmentAmountTextBox.Font = new Font("Segoe UI", 9.5F);
            installmentAmountTextBox.Location = new Point(588, 442);
            installmentAmountTextBox.Name = "installmentAmountTextBox";
            installmentAmountTextBox.Size = new Size(196, 24);
            installmentAmountTextBox.TabIndex = 7;
            installmentAmountTextBox.TextAlign = HorizontalAlignment.Right;
            installmentAmountTextBox.Enter += installmentAmountTextBox_Enter;
            installmentAmountTextBox.Leave += installmentAmountTextBox_Leave;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(820, 443);
            label8.Name = "label8";
            label8.Size = new Size(139, 21);
            label8.TabIndex = 32;
            label8.Text = "قيمه القسط الشهري";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.None;
            dateTimePicker1.DropDownAlign = LeftRightAlignment.Right;
            dateTimePicker1.Font = new Font("Segoe UI", 9.5F);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(242, 165);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.RightToLeft = RightToLeft.No;
            dateTimePicker1.Size = new Size(542, 24);
            dateTimePicker1.TabIndex = 1;
            // 
            // totalAmountTextBox
            // 
            totalAmountTextBox.Anchor = AnchorStyles.None;
            totalAmountTextBox.Font = new Font("Segoe UI", 9.5F);
            totalAmountTextBox.Location = new Point(242, 382);
            totalAmountTextBox.Name = "totalAmountTextBox";
            totalAmountTextBox.Size = new Size(542, 24);
            totalAmountTextBox.TabIndex = 5;
            totalAmountTextBox.TextAlign = HorizontalAlignment.Right;
            totalAmountTextBox.Enter += totalAmountTextBox_Enter;
            totalAmountTextBox.Leave += totalAmountTextBox_Leave;
            // 
            // advanceTextBox
            // 
            advanceTextBox.Anchor = AnchorStyles.None;
            advanceTextBox.Font = new Font("Segoe UI", 9.5F);
            advanceTextBox.Location = new Point(242, 328);
            advanceTextBox.Name = "advanceTextBox";
            advanceTextBox.Size = new Size(542, 24);
            advanceTextBox.TabIndex = 4;
            advanceTextBox.TextAlign = HorizontalAlignment.Right;
            advanceTextBox.Enter += advanceTextBox_Enter;
            advanceTextBox.Leave += advanceTextBox_Leave;
            // 
            // percentageTextBox
            // 
            percentageTextBox.Anchor = AnchorStyles.None;
            percentageTextBox.Font = new Font("Segoe UI", 9.5F);
            percentageTextBox.Location = new Point(242, 274);
            percentageTextBox.Name = "percentageTextBox";
            percentageTextBox.Size = new Size(542, 24);
            percentageTextBox.TabIndex = 3;
            percentageTextBox.TextAlign = HorizontalAlignment.Right;
            percentageTextBox.Enter += percentageTextBox_Enter;
            percentageTextBox.Leave += percentageTextBox_Leave;
            // 
            // amountTextBox
            // 
            amountTextBox.Anchor = AnchorStyles.None;
            amountTextBox.Font = new Font("Segoe UI", 9.5F);
            amountTextBox.Location = new Point(242, 219);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(542, 24);
            amountTextBox.TabIndex = 2;
            amountTextBox.TextAlign = HorizontalAlignment.Right;
            amountTextBox.Enter += amountTextBox_Enter;
            amountTextBox.Leave += amountTextBox_Leave;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(820, 382);
            label7.Name = "label7";
            label7.Size = new Size(143, 21);
            label7.TabIndex = 31;
            label7.Text = "المبلغ المراد تقسيطه";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(878, 329);
            label6.Name = "label6";
            label6.Size = new Size(53, 21);
            label6.TabIndex = 30;
            label6.Text = "المقدم";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(880, 275);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 29;
            label5.Text = "النسبة";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(881, 220);
            label4.Name = "label4";
            label4.Size = new Size(47, 21);
            label4.TabIndex = 28;
            label4.Text = "المبلغ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(880, 166);
            label3.Name = "label3";
            label3.Size = new Size(50, 21);
            label3.TabIndex = 27;
            label3.Text = "التاريخ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(880, 124);
            label1.Name = "label1";
            label1.Size = new Size(53, 21);
            label1.TabIndex = 34;
            label1.Text = "العميل";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(868, 496);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 35;
            label2.Text = "ملاحظات";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Anchor = AnchorStyles.None;
            descriptionTextBox.Font = new Font("Segoe UI", 9.5F);
            descriptionTextBox.Location = new Point(242, 495);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(542, 24);
            descriptionTextBox.TabIndex = 8;
            descriptionTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.None;
            addBtn.BackColor = Color.FromArgb(14, 52, 65);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 10F);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(690, 557);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 30);
            addBtn.TabIndex = 9;
            addBtn.Text = "إضافة";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Anchor = AnchorStyles.None;
            backBtn.BackColor = Color.FromArgb(14, 52, 65);
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.Font = new Font("Segoe UI", 10F);
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(242, 557);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(94, 30);
            backBtn.TabIndex = 10;
            backBtn.Text = "عودة";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // CustomerComboBox
            // 
            CustomerComboBox.FormattingEnabled = true;
            CustomerComboBox.Location = new Point(242, 115);
            CustomerComboBox.Name = "CustomerComboBox";
            CustomerComboBox.RightToLeft = RightToLeft.Yes;
            CustomerComboBox.Size = new Size(542, 27);
            CustomerComboBox.TabIndex = 0;
            // 
            // NewInstallmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 637);
            Controls.Add(CustomerComboBox);
            Controls.Add(addBtn);
            Controls.Add(backBtn);
            Controls.Add(descriptionTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(durationTextBox);
            Controls.Add(label9);
            Controls.Add(installmentAmountTextBox);
            Controls.Add(label8);
            Controls.Add(dateTimePicker1);
            Controls.Add(totalAmountTextBox);
            Controls.Add(advanceTextBox);
            Controls.Add(percentageTextBox);
            Controls.Add(amountTextBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(xBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewInstallmentForm";
            Text = "new_installment_form";
            Click += new_installment_form_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button xBtn;
        private TextBox durationTextBox;
        private Label label9;
        private TextBox installmentAmountTextBox;
        private Label label8;
        private DateTimePicker dateTimePicker1;
        private TextBox totalAmountTextBox;
        private TextBox advanceTextBox;
        private TextBox percentageTextBox;
        private TextBox amountTextBox;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private TextBox descriptionTextBox;
        private Button addBtn;
        private Button backBtn;
        private ComboBox CustomerComboBox;
    }
}