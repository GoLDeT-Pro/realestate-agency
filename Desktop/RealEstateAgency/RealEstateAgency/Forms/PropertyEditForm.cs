using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RealEstateAgency.Forms
{
    public partial class PropertyEditForm : Form
    {
        private int? _propertyId;
        private List<PropertyPhoto> _photos = new List<PropertyPhoto>();
        private readonly string _photoFolder = Path.Combine(Application.StartupPath, "Photos");

        public PropertyEditForm(int? id = null)
        {
            InitializeComponent();
            _propertyId = id;
            if (!Directory.Exists(_photoFolder)) Directory.CreateDirectory(_photoFolder);
            LoadComboboxes();
            if (id.HasValue) LoadProperty(id.Value);
        }

        private void LoadComboboxes()
        {
            cmbDistrict.DataSource = Program.DictionaryService.GetAllDistricts();
            cmbDistrict.DisplayMember = "Name";
            cmbDistrict.ValueMember = "Id";

            cmbPropertyType.DataSource = Program.DictionaryService.GetAllPropertyTypes();
            cmbPropertyType.DisplayMember = "Name";
            cmbPropertyType.ValueMember = "Id";

            cmbOwner.DataSource = Program.UserService.GetAllOwners();
            cmbOwner.DisplayMember = "FullName";
            cmbOwner.ValueMember = "Id";

            cmbStatus.SelectedIndex = 0;
        }

        private void LoadProperty(int id)
        {
            var prop = Program.PropertyService.GetPropertyById(id);
            if (prop == null) return;
            txtAddress.Text = prop.Address;
            numArea.Value = prop.Area;
            numRooms.Value = prop.Rooms;
            numFloor.Value = prop.Floor ?? 0;
            numTotalFloors.Value = prop.TotalFloors ?? 0;
            numPrice.Value = prop.Price;
            cmbDistrict.SelectedValue = prop.DistrictId;
            cmbPropertyType.SelectedValue = prop.PropertyTypeId;
            cmbOwner.SelectedValue = prop.OwnerId;
            txtDescription.Text = prop.Description;
            cmbStatus.Text = prop.Status;
            LoadPhotos();
        }

        private void LoadPhotos()
        {
            panelPhotos.Controls.Clear();
            if (!_propertyId.HasValue) return;
            _photos = Program.PropertyService.GetPhotos(_propertyId.Value).OrderBy(p => !p.IsMain).ToList();
            foreach (var photo in _photos)
            {
                var pb = new PictureBox
                {
                    Size = new Size(80, 80),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = File.Exists(photo.PhotoPath) ? Image.FromFile(photo.PhotoPath) : null,
                    Tag = photo
                };
                pb.Click += Photo_Click;
                panelPhotos.Controls.Add(pb);
            }
        }

        private void Photo_Click(object sender, EventArgs e)
        {
            foreach (Control c in panelPhotos.Controls) c.BackColor = Color.Transparent;
            if (sender is PictureBox pb) pb.BackColor = Color.DodgerBlue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var prop = new Property
            {
                Id = _propertyId ?? 0,
                Address = txtAddress.Text,
                Area = numArea.Value,
                Rooms = (int)numRooms.Value,
                Floor = numFloor.Value > 0 ? (int?)numFloor.Value : null,
                TotalFloors = numTotalFloors.Value > 0 ? (int?)numTotalFloors.Value : null,
                Price = numPrice.Value,
                DistrictId = (int)cmbDistrict.SelectedValue,
                PropertyTypeId = (int)cmbPropertyType.SelectedValue,
                OwnerId = (int)cmbOwner.SelectedValue,
                Description = txtDescription.Text,
                Status = cmbStatus.Text
            };
            if (_propertyId.HasValue)
                Program.PropertyService.UpdateProperty(prop);
            else
                _propertyId = Program.PropertyService.AddProperty(prop);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            if (!_propertyId.HasValue)
            {
                MessageBox.Show("Сначала сохраните объект", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var ofd = new OpenFileDialog { Filter = "Изображения|*.jpg;*.jpeg;*.png" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(ofd.FileName)}";
                var destPath = Path.Combine(_photoFolder, fileName);
                File.Copy(ofd.FileName, destPath);
                var photo = new PropertyPhoto { PropertyId = _propertyId.Value, PhotoPath = destPath, IsMain = _photos.Count == 0 };
                Program.PropertyService.AddPhoto(photo);
                LoadPhotos();
            }
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            var selected = panelPhotos.Controls.OfType<PictureBox>().FirstOrDefault(p => p.BackColor == Color.DodgerBlue);
            if (selected?.Tag is PropertyPhoto photo)
            {
                Program.PropertyService.DeletePhoto(photo.Id);
                if (File.Exists(photo.PhotoPath)) File.Delete(photo.PhotoPath);
                _photos.Remove(photo);
                if (photo.IsMain && _photos.Count > 0)
                {
                    var newMain = _photos[0];
                    Program.PropertyService.SetMainPhoto(newMain.Id, _propertyId.Value);
                }
                LoadPhotos();
            }
        }

        private void btnSetMainPhoto_Click(object sender, EventArgs e)
        {
            var selected = panelPhotos.Controls.OfType<PictureBox>().FirstOrDefault(p => p.BackColor == Color.DodgerBlue);
            if (selected?.Tag is PropertyPhoto photo && !photo.IsMain)
            {
                Program.PropertyService.SetMainPhoto(photo.Id, _propertyId.Value);
                LoadPhotos();
            }
        }
    }
}