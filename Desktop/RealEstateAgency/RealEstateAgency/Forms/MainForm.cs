using System;
using System.Windows.Forms;
using RealEstateAgency.Forms;

namespace RealEstateAgency
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblWelcome.Text = $"Добро пожаловать, {Program.CurrentUser.FullName}";
        }

        private void btnProperties_Click(object sender, EventArgs e) => new PropertiesForm().ShowDialog();
        private void btnUsers_Click(object sender, EventArgs e) => new UsersForm().ShowDialog();
        private void btnDeals_Click(object sender, EventArgs e) => new DealsForm().ShowDialog();
        private void btnRequests_Click(object sender, EventArgs e) => new ViewingRequestsForm().ShowDialog();
        private void btnReports_Click(object sender, EventArgs e) => new ReportsForm().ShowDialog();
        private void btnDictionaries_Click(object sender, EventArgs e) => new DictionariesForm().ShowDialog();
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.CurrentUser = null;
            Close();
            Application.Restart();
        }
    }
}