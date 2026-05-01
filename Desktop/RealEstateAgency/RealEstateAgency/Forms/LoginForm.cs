using System;
using System.Windows.Forms;

namespace RealEstateAgency.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = Program.UserService.AuthenticateRealtor(txtLogin.Text.Trim(), txtPassword.Text);
            if (user != null)
            {
                Program.CurrentUser = user;
                Hide();
                new MainForm().ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}