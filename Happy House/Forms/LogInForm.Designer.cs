namespace HappyHouse_Client.Forms
{
    partial class LogInForm
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
            LogoPictureBox = new PictureBox();
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            LogInBtn = new Button();
            ColseBtn = new Button();
            MaxmizeBtn = new Button();
            MinimizeBtn = new Button();
            HeaderPanel = new Panel();
            title_text = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            HeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.BackColor = Color.Transparent;
            LogoPictureBox.BackgroundImage = Properties.Resources.big_logo;
            LogoPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            LogoPictureBox.Location = new Point(156, 137);
            LogoPictureBox.Name = "LogoPictureBox";
            LogoPictureBox.Size = new Size(368, 150);
            LogoPictureBox.TabIndex = 0;
            LogoPictureBox.TabStop = false;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(216, 347);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(222, 26);
            UsernameTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(216, 400);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(222, 26);
            PasswordTextBox.TabIndex = 3;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.BackColor = Color.Transparent;
            UsernameLabel.ForeColor = Color.White;
            UsernameLabel.Location = new Point(462, 354);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(153, 19);
            UsernameLabel.TabIndex = 4;
            UsernameLabel.Text = "إسم المستخدم أو الإيميل";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.ForeColor = Color.White;
            PasswordLabel.Location = new Point(462, 400);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(75, 19);
            PasswordLabel.TabIndex = 5;
            PasswordLabel.Text = "كلمة المرور";
            // 
            // LogInBtn
            // 
            LogInBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogInBtn.BackColor = Color.FromArgb(14, 52, 65);
            LogInBtn.FlatAppearance.BorderSize = 0;
            LogInBtn.FlatStyle = FlatStyle.Flat;
            LogInBtn.ForeColor = Color.White;
            LogInBtn.Location = new Point(216, 497);
            LogInBtn.Name = "LogInBtn";
            LogInBtn.Size = new Size(222, 30);
            LogInBtn.TabIndex = 4;
            LogInBtn.Text = "تسجيل الدخول";
            LogInBtn.UseVisualStyleBackColor = false;
            LogInBtn.Click += LogInBtn_Click;
            // 
            // ColseBtn
            // 
            ColseBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ColseBtn.BackgroundImage = Properties.Resources.close;
            ColseBtn.BackgroundImageLayout = ImageLayout.Stretch;
            ColseBtn.FlatAppearance.BorderSize = 0;
            ColseBtn.FlatStyle = FlatStyle.Flat;
            ColseBtn.ForeColor = SystemColors.ControlText;
            ColseBtn.Location = new Point(636, 12);
            ColseBtn.Name = "ColseBtn";
            ColseBtn.Size = new Size(25, 25);
            ColseBtn.TabIndex = 8;
            ColseBtn.UseVisualStyleBackColor = true;
            ColseBtn.Click += ColseBtn_Click;
            // 
            // MaxmizeBtn
            // 
            MaxmizeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MaxmizeBtn.BackgroundImage = Properties.Resources.maxmize;
            MaxmizeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            MaxmizeBtn.FlatAppearance.BorderSize = 0;
            MaxmizeBtn.FlatStyle = FlatStyle.Flat;
            MaxmizeBtn.Location = new Point(586, 12);
            MaxmizeBtn.Name = "MaxmizeBtn";
            MaxmizeBtn.Size = new Size(25, 25);
            MaxmizeBtn.TabIndex = 6;
            MaxmizeBtn.UseVisualStyleBackColor = true;
            MaxmizeBtn.Click += MaxmizeBtn_Click;
            // 
            // MinimizeBtn
            // 
            MinimizeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MinimizeBtn.BackgroundImage = Properties.Resources.minimize;
            MinimizeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            MinimizeBtn.FlatAppearance.BorderSize = 0;
            MinimizeBtn.FlatStyle = FlatStyle.Flat;
            MinimizeBtn.Location = new Point(538, 12);
            MinimizeBtn.Name = "MinimizeBtn";
            MinimizeBtn.RightToLeft = RightToLeft.No;
            MinimizeBtn.Size = new Size(25, 25);
            MinimizeBtn.TabIndex = 7;
            MinimizeBtn.UseVisualStyleBackColor = true;
            MinimizeBtn.Click += MinimizeBtn_Click;
            // 
            // HeaderPanel
            // 
            HeaderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HeaderPanel.BackColor = Color.FromArgb(14, 52, 65);
            HeaderPanel.Controls.Add(title_text);
            HeaderPanel.Controls.Add(ColseBtn);
            HeaderPanel.Controls.Add(MaxmizeBtn);
            HeaderPanel.Controls.Add(button1);
            HeaderPanel.Controls.Add(MinimizeBtn);
            HeaderPanel.Controls.Add(button2);
            HeaderPanel.Controls.Add(button3);
            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(682, 61);
            HeaderPanel.TabIndex = 9;
            HeaderPanel.MouseDown += HeaderPanel_MouseDown;
            HeaderPanel.MouseMove += HeaderPanel_MouseMove;
            // 
            // title_text
            // 
            title_text.Anchor = AnchorStyles.None;
            title_text.AutoSize = true;
            title_text.Font = new Font("Goudy Stout", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title_text.ForeColor = Color.White;
            title_text.Location = new Point(747, -9);
            title_text.Name = "title_text";
            title_text.RightToLeft = RightToLeft.Yes;
            title_text.Size = new Size(91, 32);
            title_text.TabIndex = 6;
            title_text.Text = "الرئيسية";
            title_text.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackgroundImage = Properties.Resources.close;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(1575, 14);
            button1.Name = "button1";
            button1.Size = new Size(32, 30);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackgroundImage = Properties.Resources.maxmize;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(1525, 14);
            button2.Name = "button2";
            button2.Size = new Size(32, 30);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackgroundImage = Properties.Resources.minimize;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(1477, 14);
            button3.Name = "button3";
            button3.RightToLeft = RightToLeft.No;
            button3.Size = new Size(32, 30);
            button3.TabIndex = 3;
            button3.UseVisualStyleBackColor = true;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Untitled;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(680, 670);
            Controls.Add(HeaderPanel);
            Controls.Add(LogInBtn);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Controls.Add(LogoPictureBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LogInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogInForm";
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox LogoPictureBox;
        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private Button LogInBtn;
        private Button ColseBtn;
        private Button MaxmizeBtn;
        private Button MinimizeBtn;
        private Panel HeaderPanel;
        public Label title_text;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}