namespace HappyHouse_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            headerPanel = new Panel();
            title_text = new Label();
            colse_btn = new Button();
            maxmize_btn = new Button();
            minimize_btn = new Button();
            logoPictureBox = new PictureBox();
            panel2 = new Panel();
            button1 = new Button();
            التقاريرbtn = new Button();
            عملاءBtn = new Button();
            logoPanel = new Panel();
            label1 = new Label();
            الخزنةbtn = new Button();
            اليوميةbtn = new Button();
            الأقساطbtn = new Button();
            mainpanel = new Panel();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            panel2.SuspendLayout();
            logoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel.BackColor = Color.FromArgb(14, 52, 65);
            headerPanel.Controls.Add(title_text);
            headerPanel.Controls.Add(colse_btn);
            headerPanel.Controls.Add(maxmize_btn);
            headerPanel.Controls.Add(minimize_btn);
            headerPanel.Location = new Point(220, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1147, 77);
            headerPanel.TabIndex = 0;
            headerPanel.MouseDown += headerPanel_MouseDown;
            headerPanel.MouseMove += headerPanel_MouseMove;
            // 
            // title_text
            // 
            title_text.Anchor = AnchorStyles.None;
            title_text.AutoSize = true;
            title_text.Font = new Font("Goudy Stout", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title_text.ForeColor = Color.White;
            title_text.Location = new Point(506, 12);
            title_text.Name = "title_text";
            title_text.RightToLeft = RightToLeft.Yes;
            title_text.Size = new Size(114, 41);
            title_text.TabIndex = 6;
            title_text.Text = "الرئيسية";
            title_text.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // colse_btn
            // 
            colse_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            colse_btn.BackgroundImage = Properties.Resources.close;
            colse_btn.BackgroundImageLayout = ImageLayout.Stretch;
            colse_btn.FlatAppearance.BorderSize = 0;
            colse_btn.FlatStyle = FlatStyle.Flat;
            colse_btn.ForeColor = SystemColors.ControlText;
            colse_btn.Location = new Point(1093, 15);
            colse_btn.Name = "colse_btn";
            colse_btn.Size = new Size(32, 32);
            colse_btn.TabIndex = 5;
            colse_btn.UseVisualStyleBackColor = true;
            colse_btn.Click += colse_btn_Click;
            // 
            // maxmize_btn
            // 
            maxmize_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maxmize_btn.BackgroundImage = Properties.Resources.maxmize;
            maxmize_btn.BackgroundImageLayout = ImageLayout.Stretch;
            maxmize_btn.FlatAppearance.BorderSize = 0;
            maxmize_btn.FlatStyle = FlatStyle.Flat;
            maxmize_btn.Location = new Point(1043, 15);
            maxmize_btn.Name = "maxmize_btn";
            maxmize_btn.Size = new Size(32, 32);
            maxmize_btn.TabIndex = 2;
            maxmize_btn.UseVisualStyleBackColor = true;
            maxmize_btn.Click += maxmize_btn_Click;
            // 
            // minimize_btn
            // 
            minimize_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minimize_btn.BackgroundImage = Properties.Resources.minimize;
            minimize_btn.BackgroundImageLayout = ImageLayout.Stretch;
            minimize_btn.FlatAppearance.BorderSize = 0;
            minimize_btn.FlatStyle = FlatStyle.Flat;
            minimize_btn.Location = new Point(995, 15);
            minimize_btn.Name = "minimize_btn";
            minimize_btn.RightToLeft = RightToLeft.No;
            minimize_btn.Size = new Size(32, 32);
            minimize_btn.TabIndex = 3;
            minimize_btn.UseVisualStyleBackColor = true;
            minimize_btn.Click += minimize_btn_Click;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = Properties.Resources.logo;
            logoPictureBox.Location = new Point(12, 3);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(72, 74);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(14, 52, 65);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(التقاريرbtn);
            panel2.Controls.Add(عملاءBtn);
            panel2.Controls.Add(logoPanel);
            panel2.Controls.Add(الخزنةbtn);
            panel2.Controls.Add(اليوميةbtn);
            panel2.Controls.Add(الأقساطbtn);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 747);
            panel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Goudy Stout", 13.8F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 628);
            button1.Name = "button1";
            button1.Size = new Size(217, 105);
            button1.TabIndex = 4;
            button1.Text = "  الديون";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            // 
            // التقاريرbtn
            // 
            التقاريرbtn.FlatAppearance.BorderSize = 0;
            التقاريرbtn.FlatStyle = FlatStyle.Flat;
            التقاريرbtn.Font = new Font("Goudy Stout", 13.8F, FontStyle.Bold);
            التقاريرbtn.ForeColor = Color.White;
            التقاريرbtn.Image = (Image)resources.GetObject("التقاريرbtn.Image");
            التقاريرbtn.ImageAlign = ContentAlignment.MiddleLeft;
            التقاريرbtn.Location = new Point(-3, 519);
            التقاريرbtn.Name = "التقاريرbtn";
            التقاريرbtn.Size = new Size(217, 105);
            التقاريرbtn.TabIndex = 3;
            التقاريرbtn.Text = "  التقارير";
            التقاريرbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            التقاريرbtn.UseVisualStyleBackColor = true;
            التقاريرbtn.Click += التقاريرbtn_Click;
            // 
            // عملاءBtn
            // 
            عملاءBtn.FlatAppearance.BorderSize = 0;
            عملاءBtn.FlatStyle = FlatStyle.Flat;
            عملاءBtn.Font = new Font("Goudy Stout", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            عملاءBtn.ForeColor = Color.WhiteSmoke;
            عملاءBtn.Image = (Image)resources.GetObject("عملاءBtn.Image");
            عملاءBtn.ImageAlign = ContentAlignment.MiddleLeft;
            عملاءBtn.Location = new Point(3, 83);
            عملاءBtn.Name = "عملاءBtn";
            عملاءBtn.Size = new Size(217, 105);
            عملاءBtn.TabIndex = 2;
            عملاءBtn.Text = "  العملاء";
            عملاءBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            عملاءBtn.UseVisualStyleBackColor = true;
            عملاءBtn.Click += عملاءBtn_Click;
            // 
            // logoPanel
            // 
            logoPanel.BackColor = Color.FromArgb(9, 36, 45);
            logoPanel.Controls.Add(label1);
            logoPanel.Controls.Add(logoPictureBox);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(220, 77);
            logoPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(90, 12);
            label1.Name = "label1";
            label1.Size = new Size(104, 59);
            label1.TabIndex = 1;
            label1.Text = "Happy House";
            // 
            // الخزنةbtn
            // 
            الخزنةbtn.FlatAppearance.BorderSize = 0;
            الخزنةbtn.FlatStyle = FlatStyle.Flat;
            الخزنةbtn.Font = new Font("Goudy Stout", 13.8F, FontStyle.Bold);
            الخزنةbtn.ForeColor = Color.White;
            الخزنةbtn.Image = Properties.Resources.safebox;
            الخزنةbtn.ImageAlign = ContentAlignment.MiddleLeft;
            الخزنةbtn.Location = new Point(3, 410);
            الخزنةbtn.Name = "الخزنةbtn";
            الخزنةbtn.Size = new Size(217, 105);
            الخزنةbtn.TabIndex = 1;
            الخزنةbtn.Text = "  الخزنة";
            الخزنةbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            الخزنةbtn.UseVisualStyleBackColor = true;
            الخزنةbtn.Click += الخزنةbtn_Click;
            // 
            // اليوميةbtn
            // 
            اليوميةbtn.FlatAppearance.BorderSize = 0;
            اليوميةbtn.FlatStyle = FlatStyle.Flat;
            اليوميةbtn.Font = new Font("Goudy Stout", 13.8F, FontStyle.Bold);
            اليوميةbtn.ForeColor = Color.White;
            اليوميةbtn.Image = Properties.Resources.ledger;
            اليوميةbtn.ImageAlign = ContentAlignment.MiddleLeft;
            اليوميةbtn.Location = new Point(0, 301);
            اليوميةbtn.Name = "اليوميةbtn";
            اليوميةbtn.Size = new Size(217, 105);
            اليوميةbtn.TabIndex = 1;
            اليوميةbtn.Text = "  اليومية";
            اليوميةbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            اليوميةbtn.UseVisualStyleBackColor = true;
            اليوميةbtn.Click += اليوميةbtn_Click;
            // 
            // الأقساطbtn
            // 
            الأقساطbtn.FlatAppearance.BorderSize = 0;
            الأقساطbtn.FlatStyle = FlatStyle.Flat;
            الأقساطbtn.Font = new Font("Goudy Stout", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            الأقساطbtn.ForeColor = Color.WhiteSmoke;
            الأقساطbtn.Image = Properties.Resources.instalment;
            الأقساطbtn.ImageAlign = ContentAlignment.MiddleLeft;
            الأقساطbtn.Location = new Point(3, 192);
            الأقساطbtn.Name = "الأقساطbtn";
            الأقساطbtn.Size = new Size(217, 105);
            الأقساطbtn.TabIndex = 1;
            الأقساطbtn.Text = "  الأقساط";
            الأقساطbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            الأقساطbtn.UseVisualStyleBackColor = true;
            الأقساطbtn.Click += الأقساطbtn_Click;
            // 
            // mainpanel
            // 
            mainpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainpanel.BackColor = SystemColors.ControlLight;
            mainpanel.BackgroundImageLayout = ImageLayout.Stretch;
            mainpanel.Location = new Point(220, 76);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1147, 671);
            mainpanel.TabIndex = 1;
            mainpanel.Paint += mainpanel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1367, 747);
            Controls.Add(mainpanel);
            Controls.Add(panel2);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            panel2.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Panel panel2;
        private Button الأقساطbtn;
        private Button الخزنةbtn;
        private Button اليوميةbtn;
        private Button minimize_btn;
        private Button maxmize_btn;
        private Panel mainpanel;
        private PictureBox logoPictureBox;
        private Panel logoPanel;
        private Label label1;
        private Button colse_btn;
        public Label title_text;
        private Button عملاءBtn;
        private Button التقاريرbtn;
        private Button button1;
    }
}
