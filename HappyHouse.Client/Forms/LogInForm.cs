using HappyHouse.Application.DTOs;
using HappyHouse_Client.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace HappyHouse_Client.Forms
{
    public partial class LogInForm : Form
    {
        private Point mouseLocation;
        private readonly HttpClient _client = new HttpClient();

        public LogInForm()
        {
            InitializeComponent();
        }

        private void ColseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaxmizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
                MaxmizeBtn.BackgroundImage = Properties.Resources.normal;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                MaxmizeBtn.BackgroundImage = Properties.Resources.maxmize;
            }
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);

        }

        private void HeaderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouse_position = MousePosition;
                mouse_position.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mouse_position;
            }
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text.IsNullOrEmpty() || PasswordTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("الرجاء ادخال البيانات");
            }
            else
            {
                async void HandleCLick()
                {
                    await AuthenticateUserAsync();
                }

                HandleCLick();
            }
        }

        public async Task AuthenticateUserAsync()
        {
            var user = new UserDTO
            {
                Username = this.UsernameTextBox.Text,
                Password = this.PasswordTextBox.Text,
            };


            var url = "https://localhost:7298/api/Authentication/authenticate";
            try
            {
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    SessionManager.Token = token;

                    MessageBox.Show("تم تسجيل الدخول");
                    this.Hide();
                    MainForm main = new MainForm();
                    main.ShowDialog();
                }
                else
                    MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
