using System;
using System.Linq;
using System.Windows.Forms;

namespace RealEstateAgency.Forms
{
    public partial class DictionariesForm : Form
    {
        public DictionariesForm()
        {
            InitializeComponent();
            LoadDistricts();
            LoadPropertyTypes();
        }

        private void LoadDistricts() => dgvDistricts.DataSource = Program.DictionaryService.GetAllDistricts().ToList();
        private void LoadPropertyTypes() => dgvPropertyTypes.DataSource = Program.DictionaryService.GetAllPropertyTypes().ToList();

        private void btnAddDistrict_Click(object sender, EventArgs e)
        {
            string name = ShowInputDialog("Добавить район", "Название:");
            if (!string.IsNullOrWhiteSpace(name)) { Program.DictionaryService.AddDistrict(name); LoadDistricts(); }
        }

        private void btnEditDistrict_Click(object sender, EventArgs e)
        {
            if (dgvDistricts.CurrentRow == null) return;
            var d = (District)dgvDistricts.CurrentRow.DataBoundItem;
            string name = ShowInputDialog("Изменить район", "Название:", d.Name);
            if (!string.IsNullOrWhiteSpace(name)) { d.Name = name; Program.DictionaryService.UpdateDistrict(d); LoadDistricts(); }
        }

        private void btnDeleteDistrict_Click(object sender, EventArgs e)
        {
            if (dgvDistricts.CurrentRow == null) return;
            int id = (int)dgvDistricts.CurrentRow.Cells["Id"].Value;
            Program.DictionaryService.DeleteDistrict(id);
            LoadDistricts();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            string name = ShowInputDialog("Добавить тип", "Название:");
            if (!string.IsNullOrWhiteSpace(name)) { Program.DictionaryService.AddPropertyType(name); LoadPropertyTypes(); }
        }

        private void btnEditType_Click(object sender, EventArgs e)
        {
            if (dgvPropertyTypes.CurrentRow == null) return;
            var pt = (PropertyType)dgvPropertyTypes.CurrentRow.DataBoundItem;
            string name = ShowInputDialog("Изменить тип", "Название:", pt.Name);
            if (!string.IsNullOrWhiteSpace(name)) { pt.Name = name; Program.DictionaryService.UpdatePropertyType(pt); LoadPropertyTypes(); }
        }

        private void btnDeleteType_Click(object sender, EventArgs e)
        {
            if (dgvPropertyTypes.CurrentRow == null) return;
            int id = (int)dgvPropertyTypes.CurrentRow.Cells["Id"].Value;
            Program.DictionaryService.DeletePropertyType(id);
            LoadPropertyTypes();
        }

        private string ShowInputDialog(string title, string prompt, string defaultValue = "")
        {
            var form = new Form { Text = title, Width = 350, Height = 150, StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false };
            var label = new Label { Text = prompt, Location = new System.Drawing.Point(10, 10), Width = 300 };
            var textBox = new TextBox { Location = new System.Drawing.Point(10, 30), Width = 300, Text = defaultValue };
            var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(120, 65), Width = 80, BackColor = System.Drawing.Color.DodgerBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnOk.Click += (s, ev) => { form.DialogResult = DialogResult.OK; form.Close(); };
            var btnCancel = new Button { Text = "Отмена", Location = new System.Drawing.Point(210, 65), Width = 80, BackColor = System.Drawing.Color.DodgerBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnCancel.Click += (s, ev) => { form.DialogResult = DialogResult.Cancel; form.Close(); };
            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(btnOk);
            form.Controls.Add(btnCancel);
            return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}