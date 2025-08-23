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
            label3 = new Label();
            label4 = new Label();
            amountTextBox = new TextBox();
            richTextBox1 = new RichTextBox();
            customersLedgerDataGridView = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            searchTextBox = new TextBox();
            xBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)customersLedgerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.FromArgb(14, 52, 65);
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(274, 538);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(94, 29);
            backBtn.TabIndex = 0;
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
            addBtn.Location = new Point(754, 538);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 29);
            addBtn.TabIndex = 1;
            addBtn.Text = "حفظ";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(923, 65);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 2;
            label1.Text = "المبلغ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(921, 121);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 3;
            label2.Text = "التاريخ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(921, 171);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 4;
            label3.Text = "القسط";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(923, 421);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 5;
            label4.Text = "ملاحظات";
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(274, 65);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(574, 27);
            amountTextBox.TabIndex = 6;
            amountTextBox.Enter += amountTextBox_Enter;
            amountTextBox.Leave += amountTextBox_Leave;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(274, 399);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(574, 120);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // customersLedgerDataGridView
            // 
            customersLedgerDataGridView.AllowUserToAddRows = false;
            customersLedgerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customersLedgerDataGridView.Location = new Point(274, 205);
            customersLedgerDataGridView.Name = "customersLedgerDataGridView";
            customersLedgerDataGridView.RightToLeft = RightToLeft.Yes;
            customersLedgerDataGridView.RowHeadersWidth = 51;
            customersLedgerDataGridView.Size = new Size(574, 188);
            customersLedgerDataGridView.TabIndex = 9;
            customersLedgerDataGridView.CellDoubleClick += customersLedgerDataGridView_CellDoubleClick;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 9F);
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(274, 114);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.RightToLeft = RightToLeft.No;
            dateTimePicker1.Size = new Size(574, 27);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.Value = new DateTime(2023, 7, 31, 0, 0, 0, 0);
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(274, 164);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(574, 27);
            searchTextBox.TabIndex = 11;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // xBtn
            // 
            xBtn.BackColor = Color.FromArgb(14, 52, 65);
            xBtn.FlatAppearance.BorderSize = 0;
            xBtn.FlatStyle = FlatStyle.Flat;
            xBtn.ForeColor = Color.White;
            xBtn.Location = new Point(241, 164);
            xBtn.Name = "xBtn";
            xBtn.Size = new Size(27, 27);
            xBtn.TabIndex = 12;
            xBtn.Text = "X";
            xBtn.UseVisualStyleBackColor = false;
            xBtn.Visible = false;
            xBtn.Click += xBtn_Click;
            // 
            // ledger_installments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 688);
            Controls.Add(xBtn);
            Controls.Add(searchTextBox);
            Controls.Add(dateTimePicker1);
            Controls.Add(customersLedgerDataGridView);
            Controls.Add(richTextBox1);
            Controls.Add(amountTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addBtn);
            Controls.Add(backBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ledger_installments";
            Text = "ledger_installments";
            ((System.ComponentModel.ISupportInitialize)customersLedgerDataGridView).EndInit();
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
        private TextBox searchTextBox;
        private Button xBtn;
    }
}