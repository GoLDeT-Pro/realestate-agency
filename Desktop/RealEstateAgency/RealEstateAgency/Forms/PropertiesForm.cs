using System;
using System.Linq;
using System.Windows.Forms;

namespace RealEstateAgency.Forms
{
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var properties = Program.PropertyService.GetAllProperties();
            dgvProperties.DataSource = properties.ToList();
            dgvProperties.Columns["Id"].Visible = false;
            dgvProperties.Columns["OwnerId"].Visible = false;
            dgvProperties.Columns["DistrictId"].Visible = false;
            dgvProperties.Columns["PropertyTypeId"].Visible = false;
            dgvProperties.Columns["Description"].Visible = false;
            dgvProperties.Columns["CreatedAt"].Visible = false;
            dgvProperties.Columns["MainPhotoPath"].Visible = false;
            dgvProperties.Columns["OwnerPhone"].Visible = false;
            dgvProperties.Columns["Floor"].Visible = false;
            dgvProperties.Columns["TotalFloors"].Visible = false;
            dgvProperties.Columns["PropertyTypeName"].Visible = false;

            dgvProperties.Columns["Address"].HeaderText = "Адрес";
            dgvProperties.Columns["Area"].HeaderText = "Площадь, м²";
            dgvProperties.Columns["Rooms"].HeaderText = "Комнат";
            dgvProperties.Columns["Price"].HeaderText = "Цена, ₽";
            dgvProperties.Columns["Status"].HeaderText = "Статус";
            dgvProperties.Columns["DistrictName"].HeaderText = "Район";
            dgvProperties.Columns["OwnerName"].HeaderText = "Собственник";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new PropertyEditForm().ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProperties.SelectedRows.Count == 0) return;
            int id = (int)dgvProperties.SelectedRows[0].Cells["Id"].Value;
            new PropertyEditForm(id).ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProperties.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Удалить объект?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = (int)dgvProperties.SelectedRows[0].Cells["Id"].Value;
                Program.PropertyService.DeleteProperty(id);
                LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}