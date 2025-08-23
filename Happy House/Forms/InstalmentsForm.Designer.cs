namespace HappyHouse_Client
{
    partial class Installment_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installment_form));
            customersInstallmentsDataGridView = new DataGridView();
            searchTextBox = new TextBox();
            month_installments_btn = new Button();
            xBtn = new Button();
            new_insta_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)customersInstallmentsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // customersInstallmentsDataGridView
            // 
            customersInstallmentsDataGridView.AllowUserToAddRows = false;
            customersInstallmentsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(14, 52, 65);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            customersInstallmentsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            customersInstallmentsDataGridView.ColumnHeadersHeight = 45;
            customersInstallmentsDataGridView.EnableHeadersVisualStyles = false;
            customersInstallmentsDataGridView.Location = new Point(212, 118);
            customersInstallmentsDataGridView.Name = "customersInstallmentsDataGridView";
            customersInstallmentsDataGridView.RightToLeft = RightToLeft.Yes;
            customersInstallmentsDataGridView.RowHeadersWidth = 51;
            customersInstallmentsDataGridView.Size = new Size(762, 347);
            customersInstallmentsDataGridView.TabIndex = 1;
            customersInstallmentsDataGridView.CellDoubleClick += dataGridView1_CellDoubleClick;
            customersInstallmentsDataGridView.CellFormatting += customersInstallmentsDataGridView_CellFormatting;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Location = new Point(212, 69);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(762, 26);
            searchTextBox.TabIndex = 2;
            searchTextBox.TextAlign = HorizontalAlignment.Right;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // month_installments_btn
            // 
            month_installments_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            month_installments_btn.BackColor = Color.FromArgb(14, 52, 65);
            month_installments_btn.FlatAppearance.BorderSize = 0;
            month_installments_btn.FlatStyle = FlatStyle.Flat;
            month_installments_btn.ForeColor = Color.White;
            month_installments_btn.Location = new Point(762, 503);
            month_installments_btn.Name = "month_installments_btn";
            month_installments_btn.Size = new Size(133, 38);
            month_installments_btn.TabIndex = 3;
            month_installments_btn.Text = "أقساط هذا الشهر";
            month_installments_btn.UseVisualStyleBackColor = false;
            month_installments_btn.Click += month_installments_btn_Click;
            // 
            // xBtn
            // 
            xBtn.BackColor = Color.FromArgb(14, 52, 65);
            xBtn.FlatAppearance.BorderSize = 0;
            xBtn.FlatStyle = FlatStyle.Flat;
            xBtn.ForeColor = Color.White;
            xBtn.Location = new Point(179, 69);
            xBtn.Name = "xBtn";
            xBtn.Size = new Size(27, 26);
            xBtn.TabIndex = 4;
            xBtn.Text = "X";
            xBtn.UseVisualStyleBackColor = false;
            xBtn.Visible = false;
            xBtn.Click += xBtn_Click;
            // 
            // new_insta_btn
            // 
            new_insta_btn.Anchor = AnchorStyles.None;
            new_insta_btn.BackColor = Color.FromArgb(14, 52, 65);
            new_insta_btn.FlatAppearance.BorderSize = 0;
            new_insta_btn.FlatStyle = FlatStyle.Flat;
            new_insta_btn.Font = new Font("Segoe UI", 11F);
            new_insta_btn.ForeColor = Color.White;
            new_insta_btn.Image = (Image)resources.GetObject("new_insta_btn.Image");
            new_insta_btn.ImageAlign = ContentAlignment.MiddleLeft;
            new_insta_btn.Location = new Point(382, 503);
            new_insta_btn.Name = "new_insta_btn";
            new_insta_btn.Size = new Size(131, 38);
            new_insta_btn.TabIndex = 6;
            new_insta_btn.Text = "قسط جديد";
            new_insta_btn.TextAlign = ContentAlignment.MiddleRight;
            new_insta_btn.UseVisualStyleBackColor = false;
            new_insta_btn.Click += new_insta_btn_Click;
            // 
            // Installment_form
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1147, 637);
            Controls.Add(new_insta_btn);
            Controls.Add(xBtn);
            Controls.Add(month_installments_btn);
            Controls.Add(searchTextBox);
            Controls.Add(customersInstallmentsDataGridView);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Installment_form";
            Text = "instalment_form";
            ((System.ComponentModel.ISupportInitialize)customersInstallmentsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView customersInstallmentsDataGridView;
        private TextBox searchTextBox;
        private Button month_installments_btn;
        private Button xBtn;
        private Button new_insta_btn;
    }
}