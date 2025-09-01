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
            searchTextBox = new TextBox();
            customersDataGridView = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)customersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.None;
            searchTextBox.Location = new Point(242, 122);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(542, 27);
            searchTextBox.TabIndex = 0;
            searchTextBox.TextAlign = HorizontalAlignment.Right;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            searchTextBox.Enter += searchTextBox_Enter;
            searchTextBox.Leave += searchTextBox_Leave;
            // 
            // customersDataGridView
            // 
            customersDataGridView.AllowUserToAddRows = false;
            customersDataGridView.Anchor = AnchorStyles.None;
            customersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customersDataGridView.Location = new Point(242, 174);
            customersDataGridView.Name = "customersDataGridView";
            customersDataGridView.RightToLeft = RightToLeft.Yes;
            customersDataGridView.RowHeadersWidth = 51;
            customersDataGridView.Size = new Size(542, 320);
            customersDataGridView.TabIndex = 12;
            customersDataGridView.Visible = false;
            customersDataGridView.CellDoubleClick += customersDataGridView_CellDoubleClick;
            // 
            // xBtn
            // 
            xBtn.Anchor = AnchorStyles.None;
            xBtn.BackColor = Color.FromArgb(14, 52, 65);
            xBtn.FlatAppearance.BorderSize = 0;
            xBtn.FlatStyle = FlatStyle.Flat;
            xBtn.ForeColor = Color.White;
            xBtn.Location = new Point(209, 122);
            xBtn.Name = "xBtn";
            xBtn.Size = new Size(27, 27);
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
            durationTextBox.Location = new Point(242, 465);
            durationTextBox.Name = "durationTextBox";
            durationTextBox.Size = new Size(196, 29);
            durationTextBox.TabIndex = 6;
            durationTextBox.TextAlign = HorizontalAlignment.Right;
            durationTextBox.Leave += durationTextBox_Leave;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(453, 465);
            label9.Name = "label9";
            label9.Size = new Size(115, 28);
            label9.TabIndex = 33;
            label9.Text = "المدة بالشهر";
            // 
            // installmentAmountTextBox
            // 
            installmentAmountTextBox.Anchor = AnchorStyles.None;
            installmentAmountTextBox.Font = new Font("Segoe UI", 9.5F);
            installmentAmountTextBox.Location = new Point(588, 465);
            installmentAmountTextBox.Name = "installmentAmountTextBox";
            installmentAmountTextBox.Size = new Size(196, 29);
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
            label8.Location = new Point(820, 466);
            label8.Name = "label8";
            label8.Size = new Size(177, 28);
            label8.TabIndex = 32;
            label8.Text = "قيمه القسط الشهري";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.None;
            dateTimePicker1.DropDownAlign = LeftRightAlignment.Right;
            dateTimePicker1.Font = new Font("Segoe UI", 9.5F);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(242, 174);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.RightToLeft = RightToLeft.No;
            dateTimePicker1.Size = new Size(542, 29);
            dateTimePicker1.TabIndex = 1;
            // 
            // totalAmountTextBox
            // 
            totalAmountTextBox.Anchor = AnchorStyles.None;
            totalAmountTextBox.Font = new Font("Segoe UI", 9.5F);
            totalAmountTextBox.Location = new Point(242, 402);
            totalAmountTextBox.Name = "totalAmountTextBox";
            totalAmountTextBox.Size = new Size(542, 29);
            totalAmountTextBox.TabIndex = 5;
            totalAmountTextBox.TextAlign = HorizontalAlignment.Right;
            totalAmountTextBox.Enter += totalAmountTextBox_Enter;
            totalAmountTextBox.Leave += totalAmountTextBox_Leave;
            // 
            // advanceTextBox
            // 
            advanceTextBox.Anchor = AnchorStyles.None;
            advanceTextBox.Font = new Font("Segoe UI", 9.5F);
            advanceTextBox.Location = new Point(242, 345);
            advanceTextBox.Name = "advanceTextBox";
            advanceTextBox.Size = new Size(542, 29);
            advanceTextBox.TabIndex = 4;
            advanceTextBox.TextAlign = HorizontalAlignment.Right;
            advanceTextBox.Enter += advanceTextBox_Enter;
            advanceTextBox.Leave += advanceTextBox_Leave;
            // 
            // percentageTextBox
            // 
            percentageTextBox.Anchor = AnchorStyles.None;
            percentageTextBox.Font = new Font("Segoe UI", 9.5F);
            percentageTextBox.Location = new Point(242, 288);
            percentageTextBox.Name = "percentageTextBox";
            percentageTextBox.Size = new Size(542, 29);
            percentageTextBox.TabIndex = 3;
            percentageTextBox.TextAlign = HorizontalAlignment.Right;
            percentageTextBox.Enter += percentageTextBox_Enter;
            percentageTextBox.Leave += percentageTextBox_Leave;
            // 
            // amountTextBox
            // 
            amountTextBox.Anchor = AnchorStyles.None;
            amountTextBox.Font = new Font("Segoe UI", 9.5F);
            amountTextBox.Location = new Point(242, 231);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(542, 29);
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
            label7.Location = new Point(820, 402);
            label7.Name = "label7";
            label7.Size = new Size(185, 28);
            label7.TabIndex = 31;
            label7.Text = "المبلغ المراد تقسيطه";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(878, 346);
            label6.Name = "label6";
            label6.Size = new Size(68, 28);
            label6.TabIndex = 30;
            label6.Text = "المقدم";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(880, 289);
            label5.Name = "label5";
            label5.Size = new Size(65, 28);
            label5.TabIndex = 29;
            label5.Text = "النسبة";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(881, 232);
            label4.Name = "label4";
            label4.Size = new Size(62, 28);
            label4.TabIndex = 28;
            label4.Text = "المبلغ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(880, 175);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 27;
            label3.Text = "التاريخ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(880, 130);
            label1.Name = "label1";
            label1.Size = new Size(68, 28);
            label1.TabIndex = 34;
            label1.Text = "العميل";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(868, 522);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 35;
            label2.Text = "ملاحظات";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Anchor = AnchorStyles.None;
            descriptionTextBox.Font = new Font("Segoe UI", 9.5F);
            descriptionTextBox.Location = new Point(242, 521);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(542, 29);
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
            addBtn.Location = new Point(690, 586);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 32);
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
            backBtn.Location = new Point(242, 586);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(94, 32);
            backBtn.TabIndex = 10;
            backBtn.Text = "عودة";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // new_installment_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 671);
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
            Controls.Add(searchTextBox);
            Controls.Add(customersDataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "new_installment_form";
            Text = "new_installment_form";
            Click += new_installment_form_Click;
            ((System.ComponentModel.ISupportInitialize)customersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchTextBox;
        private DataGridView customersDataGridView;
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
    }
}