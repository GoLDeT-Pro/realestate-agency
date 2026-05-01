using System;
using System.Linq;
using System.Windows.Forms;

namespace RealEstateAgency.Forms
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            LoadClients();
            LoadOwners();
            LoadRealtors();
        }

        private void LoadClients() => dgvClients.DataSource = Program.UserService.GetAllClients().ToList();
        private void LoadOwners() => dgvOwners.DataSource = Program.UserService.GetAllOwners().ToList();
        private void LoadRealtors() => dgvRealtors.DataSource = Program.UserService.GetAllRealtors().ToList();

        private void btnAddClient_Click(object sender, EventArgs e) { new UserEditForm("Client").ShowDialog(); LoadClients(); }
        private void btnEditClient_Click(object sender, EventArgs e) { if (dgvClients.CurrentRow != null) new UserEditForm("Client", (int)dgvClients.CurrentRow.Cells["Id"].Value).ShowDialog(); LoadClients(); }
        private void btnDeleteClient_Click(object sender, EventArgs e) { if (dgvClients.CurrentRow != null) { Program.UserService.DeleteClient((int)dgvClients.CurrentRow.Cells["Id"].Value); LoadClients(); } }

        private void btnAddOwner_Click(object sender, EventArgs e) { new UserEditForm("Owner").ShowDialog(); LoadOwners(); }
        private void btnEditOwner_Click(object sender, EventArgs e) { if (dgvOwners.CurrentRow != null) new UserEditForm("Owner", (int)dgvOwners.CurrentRow.Cells["Id"].Value).ShowDialog(); LoadOwners(); }
        private void btnDeleteOwner_Click(object sender, EventArgs e) { if (dgvOwners.CurrentRow != null) { Program.UserService.DeleteOwner((int)dgvOwners.CurrentRow.Cells["Id"].Value); LoadOwners(); } }

        private void btnAddRealtor_Click(object sender, EventArgs e) { new UserEditForm("Realtor").ShowDialog(); LoadRealtors(); }
        private void btnEditRealtor_Click(object sender, EventArgs e) { if (dgvRealtors.CurrentRow != null) new UserEditForm("Realtor", (int)dgvRealtors.CurrentRow.Cells["Id"].Value).ShowDialog(); LoadRealtors(); }
        private void btnDeleteRealtor_Click(object sender, EventArgs e) { if (dgvRealtors.CurrentRow != null) { Program.UserService.DeleteRealtor((int)dgvRealtors.CurrentRow.Cells["Id"].Value); LoadRealtors(); } }
    }
}