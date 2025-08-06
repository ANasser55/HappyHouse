namespace HappyHouse_Client
{
    partial class ledger_form
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
            ledعملية_جديدةbtn = new Button();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateXBtn = new Button();
            ledgerDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ledgerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ledعملية_جديدةbtn
            // 
            ledعملية_جديدةbtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ledعملية_جديدةbtn.BackColor = Color.FromArgb(14, 52, 65);
            ledعملية_جديدةbtn.FlatAppearance.BorderSize = 0;
            ledعملية_جديدةbtn.FlatStyle = FlatStyle.Flat;
            ledعملية_جديدةbtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ledعملية_جديدةbtn.ForeColor = Color.White;
            ledعملية_جديدةbtn.Location = new Point(311, 502);
            ledعملية_جديدةbtn.Name = "ledعملية_جديدةbtn";
            ledعملية_جديدةbtn.Size = new Size(500, 62);
            ledعملية_جديدةbtn.TabIndex = 0;
            ledعملية_جديدةbtn.Text = "عملية جديدة";
            ledعملية_جديدةbtn.UseVisualStyleBackColor = false;
            ledعملية_جديدةbtn.Click += ledعملية_جديدةbtn_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(340, 84);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(632, 27);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(183, 84);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(151, 27);
            dateTimePicker1.TabIndex = 3;
            dateTimePicker1.Value = new DateTime(2023, 12, 4, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateXBtn
            // 
            dateXBtn.BackColor = Color.FromArgb(14, 52, 65);
            dateXBtn.FlatAppearance.BorderSize = 0;
            dateXBtn.FlatStyle = FlatStyle.Flat;
            dateXBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateXBtn.ForeColor = Color.White;
            dateXBtn.Location = new Point(148, 84);
            dateXBtn.Name = "dateXBtn";
            dateXBtn.Size = new Size(29, 27);
            dateXBtn.TabIndex = 5;
            dateXBtn.Text = "X";
            dateXBtn.UseVisualStyleBackColor = false;
            dateXBtn.Visible = false;
            dateXBtn.Click += dateXBtn_Click;
            // 
            // ledgerDataGridView
            // 
            ledgerDataGridView.AllowUserToAddRows = false;
            ledgerDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(14, 52, 65);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ledgerDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ledgerDataGridView.ColumnHeadersHeight = 45;
            ledgerDataGridView.EnableHeadersVisualStyles = false;
            ledgerDataGridView.Location = new Point(203, 162);
            ledgerDataGridView.Name = "ledgerDataGridView";
            ledgerDataGridView.RightToLeft = RightToLeft.Yes;
            ledgerDataGridView.RowHeadersWidth = 51;
            ledgerDataGridView.Size = new Size(762, 293);
            ledgerDataGridView.TabIndex = 6;
            ledgerDataGridView.CellDoubleClick += ledgerDataGridView_CellDoubleClick;
            // 
            // ledger_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1168, 688);
            Controls.Add(ledgerDataGridView);
            Controls.Add(dateXBtn);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(ledعملية_جديدةbtn);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "ledger_form";
            Text = "ledger_form";
            ((System.ComponentModel.ISupportInitialize)ledgerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ledعملية_جديدةbtn;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private Button dateXBtn;
        private DataGridView ledgerDataGridView;
    }
}