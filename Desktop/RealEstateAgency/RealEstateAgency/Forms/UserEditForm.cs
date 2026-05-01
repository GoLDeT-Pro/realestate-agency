using System;
using System.Windows.Forms;

namespace RealEstateAgency.Forms
{
    public partial class UserEditForm : Form
    {
        private string _type;
        private int? _id;

        public UserEditForm(string type, int? id = null)
        {
            InitializeComponent();
            _type = type;
            _id = id;
            SetupForm();
            if (id.HasValue) LoadUser();
        }

        private void SetupForm()
        {
            lblLogin.Visible = txtLogin.Visible = _type == "Realtor";
            lblPassword.Visible = txtPassword.Visible = _type == "Realtor" && !_id.HasValue;
            lblRole.Visible = cmbRole.Visible = _type == "Realtor";
            lblPassport.Visible = txtPassport.Visible = _type == "Owner";
            lblAddress.Visible = txtAddress.Visible = _type == "Owner";
            if (_type == "Realtor") { cmbRole.Items.AddRange(new[] { "admin", "realtor" }); cmbRole.SelectedIndex = 1; }
            Text = (_id.HasValue ? "Редактирование" : "Добавление") + " " +
                   (_type == "Client" ? "клиента" : _type == "Owner" ? "собственника" : "риэлтора");
        }

        private void LoadUser()
        {
            User user = null;
            if (_type == "Client") user = Program.UserService.GetAllClients().Find(c => c.Id == _id);
            else if (_type == "Owner") user = Program.UserService.GetAllOwners().Find(o => o.Id == _id);
            else if (_type == "Realtor") user = Program.UserService.GetAllRealtors().Find(r => r.Id == _id);
            if (user == null) return;
            txtFullName.Text = user.FullName;
            txtPhone.Text = user.Phone;
            txtEmail.Text = user.Email;
            if (_type == "Realtor") { txtLogin.Text = user.Login; cmbRole.Text = user.Role; }
            if (_type == "Owner") { txtPassport.Text = user.PassportData; txtAddress.Text = user.Address; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Id = _id ?? 0,
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Role = cmbRole.Text,
                Login = txtLogin.Text,
                PassportData = txtPassport.Text,
                Address = txtAddress.Text
            };
            if (_type == "Client")
            {
                if (_id.HasValue) Program.UserService.UpdateClient(user); else Program.UserService.AddClient(user);
            }
            else if (_type == "Owner")
            {
                if (_id.HasValue) Program.UserService.UpdateOwner(user); else Program.UserService.AddOwner(user);
            }
            else if (_type == "Realtor")
            {
                if (_id.HasValue) Program.UserService.UpdateRealtor(user);
                else Program.UserService.AddRealtor(user, txtPassword.Text);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}