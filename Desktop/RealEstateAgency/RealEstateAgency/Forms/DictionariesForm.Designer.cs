namespace RealEstateAgency.Forms
{
    partial class DictionariesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDistricts;
        private System.Windows.Forms.TabPage tabPropertyTypes;
        private System.Windows.Forms.DataGridView dgvDistricts;
        private System.Windows.Forms.DataGridView dgvPropertyTypes;
        private System.Windows.Forms.Button btnAddDistrict;
        private System.Windows.Forms.Button btnEditDistrict;
        private System.Windows.Forms.Button btnDeleteDistrict;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.Button btnEditType;
        private System.Windows.Forms.Button btnDeleteType;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDistricts = new System.Windows.Forms.TabPage();
            this.dgvDistricts = new System.Windows.Forms.DataGridView();
            this.btnAddDistrict = new System.Windows.Forms.Button();
            this.btnEditDistrict = new System.Windows.Forms.Button();
            this.btnDeleteDistrict = new System.Windows.Forms.Button();
            this.tabPropertyTypes = new System.Windows.Forms.TabPage();
            this.dgvPropertyTypes = new System.Windows.Forms.DataGridView();
            this.btnAddType = new System.Windows.Forms.Button();
            this.btnEditType = new System.Windows.Forms.Button();
            this.btnDeleteType = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropertyTypes)).BeginInit();
            this.SuspendLayout();

            this.tabControl.Controls.Add(this.tabDistricts);
            this.tabControl.Controls.Add(this.tabPropertyTypes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new System.Drawing.Size(580, 380);

            this.tabDistricts.Controls.Add(this.dgvDistricts);
            this.tabDistricts.Controls.Add(this.btnAddDistrict);
            this.tabDistricts.Controls.Add(this.btnEditDistrict);
            this.tabDistricts.Controls.Add(this.btnDeleteDistrict);
            this.tabDistricts.Text = "Районы";

            this.dgvDistricts.AllowUserToAddRows = false;
            this.dgvDistricts.AllowUserToDeleteRows = false;
            this.dgvDistricts.BackgroundColor = System.Drawing.Color.White;
            this.dgvDistricts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistricts.Location = new System.Drawing.Point(6, 6);
            this.dgvDistricts.Name = "dgvDistricts";
            this.dgvDistricts.ReadOnly = true;
            this.dgvDistricts.Size = new System.Drawing.Size(420, 338);

            this.btnAddDistrict.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDistrict.ForeColor = System.Drawing.Color.White;
            this.btnAddDistrict.Location = new System.Drawing.Point(435, 6);
            this.btnAddDistrict.Name = "btnAddDistrict";
            this.btnAddDistrict.Size = new System.Drawing.Size(130, 32);
            this.btnAddDistrict.Text = "Добавить";
            this.btnAddDistrict.UseVisualStyleBackColor = false;
            this.btnAddDistrict.Click += new System.EventHandler(this.btnAddDistrict_Click);

            this.btnEditDistrict.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDistrict.ForeColor = System.Drawing.Color.White;
            this.btnEditDistrict.Location = new System.Drawing.Point(435, 44);
            this.btnEditDistrict.Name = "btnEditDistrict";
            this.btnEditDistrict.Size = new System.Drawing.Size(130, 32);
            this.btnEditDistrict.Text = "Изменить";
            this.btnEditDistrict.UseVisualStyleBackColor = false;
            this.btnEditDistrict.Click += new System.EventHandler(this.btnEditDistrict_Click);

            this.btnDeleteDistrict.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDistrict.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDistrict.Location = new System.Drawing.Point(435, 82);
            this.btnDeleteDistrict.Name = "btnDeleteDistrict";
            this.btnDeleteDistrict.Size = new System.Drawing.Size(130, 32);
            this.btnDeleteDistrict.Text = "Удалить";
            this.btnDeleteDistrict.UseVisualStyleBackColor = false;
            this.btnDeleteDistrict.Click += new System.EventHandler(this.btnDeleteDistrict_Click);

            this.tabPropertyTypes.Controls.Add(this.dgvPropertyTypes);
            this.tabPropertyTypes.Controls.Add(this.btnAddType);
            this.tabPropertyTypes.Controls.Add(this.btnEditType);
            this.tabPropertyTypes.Controls.Add(this.btnDeleteType);
            this.tabPropertyTypes.Text = "Типы";

            this.dgvPropertyTypes.AllowUserToAddRows = false;
            this.dgvPropertyTypes.AllowUserToDeleteRows = false;
            this.dgvPropertyTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPropertyTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropertyTypes.Location = new System.Drawing.Point(6, 6);
            this.dgvPropertyTypes.Name = "dgvPropertyTypes";
            this.dgvPropertyTypes.ReadOnly = true;
            this.dgvPropertyTypes.Size = new System.Drawing.Size(420, 338);

            this.btnAddType.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddType.ForeColor = System.Drawing.Color.White;
            this.btnAddType.Location = new System.Drawing.Point(435, 6);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(130, 32);
            this.btnAddType.Text = "Добавить";
            this.btnAddType.UseVisualStyleBackColor = false;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);

            this.btnEditType.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditType.ForeColor = System.Drawing.Color.White;
            this.btnEditType.Location = new System.Drawing.Point(435, 44);
            this.btnEditType.Name = "btnEditType";
            this.btnEditType.Size = new System.Drawing.Size(130, 32);
            this.btnEditType.Text = "Изменить";
            this.btnEditType.UseVisualStyleBackColor = false;
            this.btnEditType.Click += new System.EventHandler(this.btnEditType_Click);

            this.btnDeleteType.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteType.ForeColor = System.Drawing.Color.White;
            this.btnDeleteType.Location = new System.Drawing.Point(435, 82);
            this.btnDeleteType.Name = "btnDeleteType";
            this.btnDeleteType.Size = new System.Drawing.Size(130, 32);
            this.btnDeleteType.Text = "Удалить";
            this.btnDeleteType.UseVisualStyleBackColor = false;
            this.btnDeleteType.Click += new System.EventHandler(this.btnDeleteType_Click);

            this.btnClose.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(490, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += (s, e) => this.Close();

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(604, 441);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "DictionariesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочники";
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropertyTypes)).EndInit();
            this.ResumeLayout(false);
        }
    }
}