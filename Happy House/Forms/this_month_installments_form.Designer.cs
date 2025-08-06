namespace HappyHouse_Client
{
    partial class this_month_installments_form
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
            monthInstallmentsDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)monthInstallmentsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // monthInstallmentsDataGridView
            // 
            monthInstallmentsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            monthInstallmentsDataGridView.Location = new Point(137, 134);
            monthInstallmentsDataGridView.Name = "monthInstallmentsDataGridView";
            monthInstallmentsDataGridView.RowHeadersWidth = 51;
            monthInstallmentsDataGridView.Size = new Size(841, 188);
            monthInstallmentsDataGridView.TabIndex = 0;
            // 
            // this_month_installments_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1147, 671);
            Controls.Add(monthInstallmentsDataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "this_month_installments_form";
            Text = "this_month_installments_form";
            ((System.ComponentModel.ISupportInitialize)monthInstallmentsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView monthInstallmentsDataGridView;
    }
}