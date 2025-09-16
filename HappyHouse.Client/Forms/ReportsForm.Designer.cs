namespace HappyHouse_Client
{
    partial class ReportsForm
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
            reportsDataGridView = new DataGridView();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)reportsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // reportsDataGridView
            // 
            reportsDataGridView.AllowUserToAddRows = false;
            reportsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(14, 52, 65);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            reportsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            reportsDataGridView.ColumnHeadersHeight = 40;
            reportsDataGridView.EnableHeadersVisualStyles = false;
            reportsDataGridView.Location = new Point(38, 122);
            reportsDataGridView.Name = "reportsDataGridView";
            reportsDataGridView.RightToLeft = RightToLeft.Yes;
            reportsDataGridView.RowHeadersWidth = 51;
            reportsDataGridView.Size = new Size(1074, 472);
            reportsDataGridView.TabIndex = 0;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.Location = new Point(286, 60);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(108, 27);
            dateTimePickerFrom.TabIndex = 1;
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.Location = new Point(107, 60);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(108, 27);
            dateTimePickerTo.TabIndex = 2;
            dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(413, 62);
            label1.Name = "label1";
            label1.Size = new Size(31, 23);
            label1.TabIndex = 3;
            label1.Text = "من";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(231, 62);
            label2.Name = "label2";
            label2.Size = new Size(34, 23);
            label2.TabIndex = 4;
            label2.Text = "الى";
            // 
            // reports_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 671);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerTo);
            Controls.Add(dateTimePickerFrom);
            Controls.Add(reportsDataGridView);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "reports_form";
            Text = "reports_form";
            Click += reports_form_Click;
            ((System.ComponentModel.ISupportInitialize)reportsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView reportsDataGridView;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private Label label1;
        private Label label2;
    }
}