using System;
using System.Linq;
using System.Windows.Forms;

namespace RealEstateAgency.Forms
{
    public partial class DealsForm : Form
    {
        public DealsForm()
        {
            InitializeComponent();
            dtpFrom.Value = DateTime.Today.AddMonths(-3);
            dtpTo.Value = DateTime.Today;
            LoadDeals();
        }

        private void LoadDeals()
        {
            var deals = Program.DealService.GetDealsByPeriod(dtpFrom.Value, dtpTo.Value);
            dgvDeals.DataSource = deals.ToList();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e) => LoadDeals();
        private void dtpTo_ValueChanged(object sender, EventArgs e) => LoadDeals();

        private void btnAddDeal_Click(object sender, EventArgs e)
        {
            var prop = SelectProperty();
            if (prop == null) return;
            var client = SelectClient();
            if (client == null) return;

            var deal = new Deal
            {
                PropertyId = prop.Id,
                ClientId = client.Id,
                RealtorId = Program.CurrentUser.Id,
                DealDate = DateTime.Today,
                Price = prop.Price,
                Commission = prop.Price * 0.03m,
                Status = "Завершена"
            };
            Program.DealService.CreateDeal(deal);
            LoadDeals();
            MessageBox.Show("Сделка оформлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Property SelectProperty()
        {
            var props = Program.PropertyService.GetAllProperties().Where(p => p.Status == "Свободен").ToList();
            if (props.Count == 0)
            {
                MessageBox.Show("Нет свободных объектов", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            var form = new Form
            {
                Text = "Выберите объект",
                Width = 700,
                Height = 450,
                StartPosition = FormStartPosition.CenterParent
            };

            var dgv = new DataGridView
            {
                DataSource = props,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                switch (col.Name)
                {
                    case "Address":
                        col.Visible = true;
                        col.HeaderText = "Адрес";
                        break;
                    case "Area":
                        col.Visible = true;
                        col.HeaderText = "Площадь";
                        break;
                    case "Rooms":
                        col.Visible = true;
                        col.HeaderText = "Комнат";
                        break;
                    case "Price":
                        col.Visible = true;
                        col.HeaderText = "Цена";
                        break;
                    case "DistrictName":
                        col.Visible = true;
                        col.HeaderText = "Район";
                        break;
                    default:
                        col.Visible = false;
                        break;
                }
            }

            var btn = new Button
            {
                Text = "Выбрать",
                Dock = DockStyle.Bottom,
                Height = 35,
                BackColor = System.Drawing.Color.DodgerBlue,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.Click += (s, ev) => { form.DialogResult = DialogResult.OK; form.Close(); };

            form.Controls.Add(dgv);
            form.Controls.Add(btn);

            if (form.ShowDialog() == DialogResult.OK && dgv.SelectedRows.Count > 0)
                return props[dgv.SelectedRows[0].Index];

            return null;
        }

        private User SelectClient()
        {
            var clients = Program.UserService.GetAllClients();
            if (clients.Count == 0)
            {
                MessageBox.Show("Нет клиентов", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

             var form = new Form
            {
                Text = "Выберите клиента",
                Width = 600,
                Height = 450,
                StartPosition = FormStartPosition.CenterParent
            };

            var dgv = new DataGridView
            {
                DataSource = clients,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                switch (col.Name)
                {
                    case "FullName":
                        col.Visible = true;
                        col.HeaderText = "ФИО";
                        break;
                    case "Phone":
                        col.Visible = true;
                        col.HeaderText = "Телефон";
                        break;
                    case "Email":
                        col.Visible = true;
                        col.HeaderText = "Email";
                        break;
                    default:
                        col.Visible = false;
                        break;
                }
            }

            var btn = new Button
            {
                Text = "Выбрать",
                Dock = DockStyle.Bottom,
                Height = 35,
                BackColor = System.Drawing.Color.DodgerBlue,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.Click += (s, ev) => { form.DialogResult = DialogResult.OK; form.Close(); };

            form.Controls.Add(dgv);
            form.Controls.Add(btn);

            if (form.ShowDialog() == DialogResult.OK && dgv.SelectedRows.Count > 0)
                return clients[dgv.SelectedRows[0].Index];

            return null;
        }
    }
}