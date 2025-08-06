namespace HappyHouse_Client
{
    partial class customers_form
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            newCustomerBtn = new Button();
            xBtn = new Button();
            searchTextBox = new TextBox();
            customersDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)customersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // newCustomerBtn
            // 
            newCustomerBtn.Anchor = AnchorStyles.Bottom;
            newCustomerBtn.BackColor = Color.FromArgb(14, 52, 65);
            newCustomerBtn.FlatAppearance.BorderSize = 0;
            newCustomerBtn.FlatStyle = FlatStyle.Flat;
            newCustomerBtn.ForeColor = Color.White;
            newCustomerBtn.Image = Properties.Resources.add_customer;
            newCustomerBtn.ImageAlign = ContentAlignment.MiddleLeft;
            newCustomerBtn.Location = new Point(666, 532);
            newCustomerBtn.Name = "newCustomerBtn";
            newCustomerBtn.Size = new Size(133, 40);
            newCustomerBtn.TabIndex = 6;
            newCustomerBtn.Text = "عميل جديد ";
            newCustomerBtn.TextAlign = ContentAlignment.MiddleRight;
            newCustomerBtn.UseVisualStyleBackColor = false;
            newCustomerBtn.Click += newCustomerBtn_Click;
            // 
            // xBtn
            // 
            xBtn.BackColor = Color.FromArgb(14, 52, 65);
            xBtn.FlatAppearance.BorderSize = 0;
            xBtn.FlatStyle = FlatStyle.Flat;
            xBtn.ForeColor = Color.White;
            xBtn.Location = new Point(155, 74);
            xBtn.Name = "xBtn";
            xBtn.Size = new Size(27, 27);
            xBtn.TabIndex = 9;
            xBtn.Text = "X";
            xBtn.UseVisualStyleBackColor = false;
            xBtn.Visible = false;
            xBtn.Click += xBtn_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Location = new Point(188, 74);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(762, 27);
            searchTextBox.TabIndex = 8;
            searchTextBox.TextAlign = HorizontalAlignment.Right;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // customersDataGridView
            // 
            customersDataGridView.AllowUserToAddRows = false;
            customersDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(14, 52, 65);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            customersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            customersDataGridView.ColumnHeadersHeight = 40;
            customersDataGridView.EnableHeadersVisualStyles = false;
            customersDataGridView.GridColor = Color.Black;
            customersDataGridView.Location = new Point(188, 136);
            customersDataGridView.Name = "customersDataGridView";
            customersDataGridView.RightToLeft = RightToLeft.Yes;
            customersDataGridView.RowHeadersWidth = 51;
            customersDataGridView.Size = new Size(762, 366);
            customersDataGridView.TabIndex = 7;
            customersDataGridView.CellDoubleClick += customersDataGridView_CellDoubleClick;
            // 
            // customers_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 671);
            Controls.Add(customersDataGridView);
            Controls.Add(xBtn);
            Controls.Add(searchTextBox);
            Controls.Add(newCustomerBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "customers_form";
            Text = "customers_form";
            ((System.ComponentModel.ISupportInitialize)customersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button newCustomerBtn;
        private Button xBtn;
        private TextBox searchTextBox;
        private DataGridView customersDataGridView;
    }
}