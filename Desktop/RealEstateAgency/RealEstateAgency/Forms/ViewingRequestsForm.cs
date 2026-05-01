using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RealEstateAgency.Forms
{
    public partial class ViewingRequestsForm : Form
    {
        public ViewingRequestsForm()
        {
            InitializeComponent();
            cmbFilter.Items.Add("Все");
            cmbFilter.Items.AddRange(new[] { "Новый", "Подтверждён", "Отклонён", "Выполнен" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadRequests();
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += (s, e) => { if (dgvRequests.SelectedRows.Count > 0) UpdateSelectedRequestStatus(); };
            LoadRequests();
        }

        private void LoadRequests()
        {
            var requests = Program.ViewingRequestService.GetAllRequests();
            string filter = cmbFilter.SelectedItem?.ToString();
            if (filter != null && filter != "Все")
                requests = requests.Where(r => r.Status == filter).ToList();
            dgvRequests.DataSource = requests.ToList();
        }

        private void UpdateSelectedRequestStatus()
        {
            int id = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
            string newStatus = cmbStatus.SelectedItem.ToString();
            Program.ViewingRequestService.UpdateStatus(id, newStatus);
            LoadRequests();
        }
    }
}