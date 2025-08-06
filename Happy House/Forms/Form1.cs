namespace HappyHouse_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x = 0;
        public Point mouse_location;
        public int oldTitleX = 0;
        public int oldTitleWidth = 0;

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        public List<int> darken(double factor, int r, int g, int b)
        {
            List<int> dark_color = new List<int>();
            r = (int)(r * factor);
            g = (int)(g * factor);
            b = (int)(b * factor);

            dark_color.Add(r);
            dark_color.Add(g);
            dark_color.Add(b);


            return dark_color;

        }

        public void ChangeTitle(string title)
        {
            title_text.Text = title;
            int newX = ((this.ClientSize.Width - title_text.Width) / 2) - 110;
            title_text.Location = new Point(newX, title_text.Location.Y);
        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void عملاءBtn_Click(object sender, EventArgs e)
        {
            ChangeTitle("العملاء");
            عملاءBtn.BackColor = Color.FromArgb(19, 74, 93);
            الأقساطbtn.BackColor = Color.FromArgb(14, 52, 65);
            اليوميةbtn.BackColor = Color.FromArgb(14, 52, 65);
            الخزنةbtn.BackColor = Color.FromArgb(14, 52, 65);


            loadform(new customers_form());
        }
        private void الأقساطbtn_Click(object sender, EventArgs e)
        {
            ChangeTitle("الأقساط");
            عملاءBtn.BackColor = Color.FromArgb(14, 52, 65);
            الأقساطbtn.BackColor = Color.FromArgb(19, 74, 93);
            اليوميةbtn.BackColor = Color.FromArgb(14, 52, 65);
            الخزنةbtn.BackColor = Color.FromArgb(14, 52, 65);

            loadform(new instalment_form());
        }

        private void اليوميةbtn_Click(object sender, EventArgs e)
        {
            ChangeTitle("اليومية");
            عملاءBtn.BackColor = Color.FromArgb(14, 52, 65);
            الأقساطbtn.BackColor = Color.FromArgb(14, 52, 65);
            اليوميةbtn.BackColor = Color.FromArgb(19, 74, 93);
            الخزنةbtn.BackColor = Color.FromArgb(14, 52, 65);


            loadform(new ledger_form());
        }

        private void الخزنةbtn_Click(object sender, EventArgs e)
        {
            ChangeTitle("الخزنة");
            عملاءBtn.BackColor = Color.FromArgb(14, 52, 65);
            الأقساطbtn.BackColor = Color.FromArgb(14, 52, 65);
            اليوميةbtn.BackColor = Color.FromArgb(14, 52, 65);
            الخزنةbtn.BackColor = Color.FromArgb(19, 74, 93);





            loadform(new safebox_form());
        }


        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {
            if (x == 0)
            {
                x = 1;
                loadform(new home_form());
            }

        }

        private void maxmize_btn_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
                maxmize_btn.BackgroundImage = Properties.Resources.normal;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                maxmize_btn.BackgroundImage = Properties.Resources.maxmize;
            }


        }

        private void colse_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_location = new Point(-e.X - 220, -e.Y);

        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouse_position = Control.MousePosition;
                mouse_position.Offset(mouse_location.X, mouse_location.Y);
                Location = mouse_position;
            }
        }

        private void التقاريرbtn_Click(object sender, EventArgs e)
        {
            
            loadform(new reports_form());
            ChangeTitle("التقارير السنوية");

            //DateTime d = dao.getm();

            //string dd = d.ToString("MM");
            //MessageBox.Show(dd);
        }
    }
}
