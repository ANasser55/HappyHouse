namespace HappyHouse_Client
{
    partial class NewCustomerForm
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
            nameTextBox = new TextBox();
            phoneTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            amountTextBox = new TextBox();
            percentageTextBox = new TextBox();
            advanceTextBox = new TextBox();
            totalAmountTextBox = new TextBox();
            backBtn = new Button();
            addBtn = new Button();
            InstallmentDateTimePicker = new DateTimePicker();
            installmentAmountTextBox = new TextBox();
            label8 = new Label();
            durationTextBox = new TextBox();
            label9 = new Label();
            label10 = new Label();
            descriptionTextBox = new TextBox();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.None;
            nameTextBox.Font = new Font("Segoe UI", 9.5F);
            nameTextBox.Location = new Point(304, 44);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(451, 24);
            nameTextBox.TabIndex = 0;
            nameTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Anchor = AnchorStyles.None;
            phoneTextBox.Font = new Font("Segoe UI", 9.5F);
            phoneTextBox.Location = new Point(304, 98);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.RightToLeft = RightToLeft.No;
            phoneTextBox.Size = new Size(451, 24);
            phoneTextBox.TabIndex = 1;
            phoneTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(828, 45);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 11;
            label1.Text = "*اسم العميل";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(832, 99);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 12;
            label2.Text = "رقم الهاتف";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(849, 153);
            label3.Name = "label3";
            label3.Size = new Size(50, 21);
            label3.TabIndex = 13;
            label3.Text = "التاريخ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(850, 207);
            label4.Name = "label4";
            label4.Size = new Size(47, 21);
            label4.TabIndex = 14;
            label4.Text = "المبلغ";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(849, 261);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 15;
            label5.Text = "النسبة";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(847, 315);
            label6.Name = "label6";
            label6.Size = new Size(53, 21);
            label6.TabIndex = 16;
            label6.Text = "المقدم";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(789, 369);
            label7.Name = "label7";
            label7.Size = new Size(150, 21);
            label7.TabIndex = 17;
            label7.Text = "*المبلغ المراد تقسيطه";
            // 
            // amountTextBox
            // 
            amountTextBox.Anchor = AnchorStyles.None;
            amountTextBox.Font = new Font("Segoe UI", 9.5F);
            amountTextBox.Location = new Point(304, 206);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(451, 24);
            amountTextBox.TabIndex = 3;
            amountTextBox.TextAlign = HorizontalAlignment.Right;
            amountTextBox.Enter += AmountTextBox_Enter;
            amountTextBox.Leave += AmountTextBox_Leave;
            // 
            // percentageTextBox
            // 
            percentageTextBox.Anchor = AnchorStyles.None;
            percentageTextBox.Font = new Font("Segoe UI", 9.5F);
            percentageTextBox.Location = new Point(304, 260);
            percentageTextBox.Name = "percentageTextBox";
            percentageTextBox.Size = new Size(451, 24);
            percentageTextBox.TabIndex = 4;
            percentageTextBox.TextAlign = HorizontalAlignment.Right;
            percentageTextBox.Enter += PercentageTextBox_Enter;
            percentageTextBox.Leave += PercentageTextBox_Leave;
            // 
            // advanceTextBox
            // 
            advanceTextBox.Anchor = AnchorStyles.None;
            advanceTextBox.Font = new Font("Segoe UI", 9.5F);
            advanceTextBox.Location = new Point(304, 314);
            advanceTextBox.Name = "advanceTextBox";
            advanceTextBox.Size = new Size(451, 24);
            advanceTextBox.TabIndex = 5;
            advanceTextBox.TextAlign = HorizontalAlignment.Right;
            advanceTextBox.Enter += AdvanceTextBox_Enter;
            advanceTextBox.Leave += AdvanceTextBox_Leave;
            // 
            // totalAmountTextBox
            // 
            totalAmountTextBox.Anchor = AnchorStyles.None;
            totalAmountTextBox.Font = new Font("Segoe UI", 9.5F);
            totalAmountTextBox.Location = new Point(304, 369);
            totalAmountTextBox.Name = "totalAmountTextBox";
            totalAmountTextBox.Size = new Size(451, 24);
            totalAmountTextBox.TabIndex = 6;
            totalAmountTextBox.TextAlign = HorizontalAlignment.Right;
            totalAmountTextBox.Enter += TotalAmountTextBox_Enter;
            totalAmountTextBox.Leave += TotalAmountTextBox_Leave;
            // 
            // backBtn
            // 
            backBtn.Anchor = AnchorStyles.None;
            backBtn.BackColor = Color.FromArgb(14, 52, 65);
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.Font = new Font("Segoe UI", 10F);
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(304, 529);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(94, 30);
            backBtn.TabIndex = 11;
            backBtn.Text = "عودة";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += BackBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.None;
            addBtn.BackColor = Color.FromArgb(14, 52, 65);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 10F);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(661, 529);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 30);
            addBtn.TabIndex = 10;
            addBtn.Text = "إضافة";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += AddBtn_Click;
            // 
            // InstallmentDateTimePicker
            // 
            InstallmentDateTimePicker.Anchor = AnchorStyles.None;
            InstallmentDateTimePicker.DropDownAlign = LeftRightAlignment.Right;
            InstallmentDateTimePicker.Font = new Font("Segoe UI", 9.5F);
            InstallmentDateTimePicker.Format = DateTimePickerFormat.Custom;
            InstallmentDateTimePicker.Location = new Point(304, 152);
            InstallmentDateTimePicker.Name = "InstallmentDateTimePicker";
            InstallmentDateTimePicker.RightToLeft = RightToLeft.No;
            InstallmentDateTimePicker.Size = new Size(451, 24);
            InstallmentDateTimePicker.TabIndex = 2;
            // 
            // installmentAmountTextBox
            // 
            installmentAmountTextBox.Anchor = AnchorStyles.None;
            installmentAmountTextBox.Font = new Font("Segoe UI", 9.5F);
            installmentAmountTextBox.Location = new Point(590, 428);
            installmentAmountTextBox.Name = "installmentAmountTextBox";
            installmentAmountTextBox.Size = new Size(165, 24);
            installmentAmountTextBox.TabIndex = 8;
            installmentAmountTextBox.TextAlign = HorizontalAlignment.Right;
            installmentAmountTextBox.Enter += InstallmentAmountTextBox_Enter;
            installmentAmountTextBox.Leave += InstallmentAmountTextBox_Leave;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(789, 429);
            label8.Name = "label8";
            label8.Size = new Size(146, 21);
            label8.TabIndex = 18;
            label8.Text = "*قيمه القسط الشهري";
            // 
            // durationTextBox
            // 
            durationTextBox.Anchor = AnchorStyles.None;
            durationTextBox.Font = new Font("Segoe UI", 9.5F);
            durationTextBox.Location = new Point(304, 428);
            durationTextBox.Name = "durationTextBox";
            durationTextBox.Size = new Size(165, 24);
            durationTextBox.TabIndex = 7;
            durationTextBox.TextAlign = HorizontalAlignment.Right;
            durationTextBox.Leave += DurationTextBox_Leave;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(472, 429);
            label9.Name = "label9";
            label9.Size = new Size(90, 21);
            label9.TabIndex = 19;
            label9.Text = "المدة بالشهر";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(843, 484);
            label10.Name = "label10";
            label10.Size = new Size(69, 21);
            label10.TabIndex = 20;
            label10.Text = "ملاحظات";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Anchor = AnchorStyles.None;
            descriptionTextBox.Font = new Font("Segoe UI", 9.5F);
            descriptionTextBox.Location = new Point(304, 483);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(451, 24);
            descriptionTextBox.TabIndex = 9;
            descriptionTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // NewCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 637);
            Controls.Add(descriptionTextBox);
            Controls.Add(label10);
            Controls.Add(durationTextBox);
            Controls.Add(label9);
            Controls.Add(installmentAmountTextBox);
            Controls.Add(label8);
            Controls.Add(InstallmentDateTimePicker);
            Controls.Add(addBtn);
            Controls.Add(backBtn);
            Controls.Add(totalAmountTextBox);
            Controls.Add(advanceTextBox);
            Controls.Add(percentageTextBox);
            Controls.Add(amountTextBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(phoneTextBox);
            Controls.Add(nameTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewCustomerForm";
            Text = "new_customer_form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox phoneTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox amountTextBox;
        private TextBox percentageTextBox;
        private TextBox advanceTextBox;
        private TextBox totalAmountTextBox;
        private Button backBtn;
        private Button addBtn;
        private DateTimePicker InstallmentDateTimePicker;
        private TextBox installmentAmountTextBox;
        private Label label8;
        private TextBox durationTextBox;
        private Label label9;
        private Label label10;
        private TextBox descriptionTextBox;
    }
}