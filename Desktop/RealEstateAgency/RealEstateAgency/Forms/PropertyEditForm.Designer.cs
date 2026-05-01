namespace RealEstateAgency.Forms
{
    partial class PropertyEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.NumericUpDown numArea;
        private System.Windows.Forms.NumericUpDown numRooms;
        private System.Windows.Forms.NumericUpDown numFloor;
        private System.Windows.Forms.NumericUpDown numTotalFloors;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.ComboBox cmbPropertyType;
        private System.Windows.Forms.ComboBox cmbOwner;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.Label lblTotalFloors;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblPropertyType;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FlowLayoutPanel panelPhotos;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.Button btnDeletePhoto;
        private System.Windows.Forms.Button btnSetMainPhoto;
        private System.Windows.Forms.Label lblPhotos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.numRooms = new System.Windows.Forms.NumericUpDown();
            this.numFloor = new System.Windows.Forms.NumericUpDown();
            this.numTotalFloors = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.cmbPropertyType = new System.Windows.Forms.ComboBox();
            this.cmbOwner = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblRooms = new System.Windows.Forms.Label();
            this.lblFloor = new System.Windows.Forms.Label();
            this.lblTotalFloors = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblPropertyType = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelPhotos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.btnDeletePhoto = new System.Windows.Forms.Button();
            this.btnSetMainPhoto = new System.Windows.Forms.Button();
            this.lblPhotos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();

            // txtAddress
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(140, 20);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(350, 25);

            // numArea
            this.numArea.DecimalPlaces = 2;
            this.numArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numArea.Location = new System.Drawing.Point(140, 55);
            this.numArea.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(100, 25);

            // numRooms
            this.numRooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numRooms.Location = new System.Drawing.Point(140, 90);
            this.numRooms.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numRooms.Name = "numRooms";
            this.numRooms.Size = new System.Drawing.Size(100, 25);

            // numFloor
            this.numFloor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numFloor.Location = new System.Drawing.Point(140, 125);
            this.numFloor.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numFloor.Name = "numFloor";
            this.numFloor.Size = new System.Drawing.Size(100, 25);

            // numTotalFloors
            this.numTotalFloors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTotalFloors.Location = new System.Drawing.Point(340, 125);
            this.numTotalFloors.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numTotalFloors.Name = "numTotalFloors";
            this.numTotalFloors.Size = new System.Drawing.Size(100, 25);

            // numPrice
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrice.Location = new System.Drawing.Point(140, 160);
            this.numPrice.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(150, 25);
            this.numPrice.ThousandsSeparator = true;

            // cmbDistrict
            this.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrict.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDistrict.Location = new System.Drawing.Point(140, 195);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(200, 25);

            // cmbPropertyType
            this.cmbPropertyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropertyType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPropertyType.Location = new System.Drawing.Point(140, 230);
            this.cmbPropertyType.Name = "cmbPropertyType";
            this.cmbPropertyType.Size = new System.Drawing.Size(200, 25);

            // cmbOwner
            this.cmbOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOwner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbOwner.Location = new System.Drawing.Point(140, 265);
            this.cmbOwner.Name = "cmbOwner";
            this.cmbOwner.Size = new System.Drawing.Size(280, 25);

            // txtDescription
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(140, 300);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(350, 60);

            // cmbStatus
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Items.AddRange(new object[] { "Свободен", "Забронирован", "Продан" });
            this.cmbStatus.Location = new System.Drawing.Point(140, 370);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.SelectedIndex = 0;
            this.cmbStatus.Size = new System.Drawing.Size(150, 25);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(200, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(340, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += (s, e) => this.Close();

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.Location = new System.Drawing.Point(25, 23);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Адрес:";

            // lblArea
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArea.Location = new System.Drawing.Point(25, 58);
            this.lblArea.Name = "lblArea";
            this.lblArea.Text = "Площадь, м²:";

            // lblRooms
            this.lblRooms.AutoSize = true;
            this.lblRooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRooms.Location = new System.Drawing.Point(25, 93);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Text = "Комнат:";

            // lblFloor
            this.lblFloor.AutoSize = true;
            this.lblFloor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFloor.Location = new System.Drawing.Point(25, 128);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Text = "Этаж:";

            // lblTotalFloors
            this.lblTotalFloors.AutoSize = true;
            this.lblTotalFloors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalFloors.Location = new System.Drawing.Point(260, 128);
            this.lblTotalFloors.Name = "lblTotalFloors";
            this.lblTotalFloors.Text = "Этажность:";

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(25, 163);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Цена, ₽:";

            // lblDistrict
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDistrict.Location = new System.Drawing.Point(25, 198);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Text = "Район:";

            // lblPropertyType
            this.lblPropertyType.AutoSize = true;
            this.lblPropertyType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPropertyType.Location = new System.Drawing.Point(25, 233);
            this.lblPropertyType.Name = "lblPropertyType";
            this.lblPropertyType.Text = "Тип объекта:";

            // lblOwner
            this.lblOwner.AutoSize = true;
            this.lblOwner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOwner.Location = new System.Drawing.Point(25, 268);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Text = "Собственник:";

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(25, 303);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Text = "Описание:";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.Location = new System.Drawing.Point(25, 373);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Статус:";

            // panelPhotos
            this.panelPhotos.AutoScroll = true;
            this.panelPhotos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPhotos.Location = new System.Drawing.Point(530, 20);
            this.panelPhotos.Name = "panelPhotos";
            this.panelPhotos.Size = new System.Drawing.Size(200, 300);

            // btnAddPhoto
            this.btnAddPhoto.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPhoto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPhoto.ForeColor = System.Drawing.Color.White;
            this.btnAddPhoto.Location = new System.Drawing.Point(530, 330);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(95, 30);
            this.btnAddPhoto.Text = "Добавить";
            this.btnAddPhoto.UseVisualStyleBackColor = false;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);

            // btnDeletePhoto
            this.btnDeletePhoto.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeletePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePhoto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeletePhoto.ForeColor = System.Drawing.Color.White;
            this.btnDeletePhoto.Location = new System.Drawing.Point(635, 330);
            this.btnDeletePhoto.Name = "btnDeletePhoto";
            this.btnDeletePhoto.Size = new System.Drawing.Size(95, 30);
            this.btnDeletePhoto.Text = "Удалить";
            this.btnDeletePhoto.UseVisualStyleBackColor = false;
            this.btnDeletePhoto.Click += new System.EventHandler(this.btnDeletePhoto_Click);

            // btnSetMainPhoto
            this.btnSetMainPhoto.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSetMainPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetMainPhoto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSetMainPhoto.ForeColor = System.Drawing.Color.White;
            this.btnSetMainPhoto.Location = new System.Drawing.Point(530, 370);
            this.btnSetMainPhoto.Name = "btnSetMainPhoto";
            this.btnSetMainPhoto.Size = new System.Drawing.Size(200, 30);
            this.btnSetMainPhoto.Text = "Сделать главным";
            this.btnSetMainPhoto.UseVisualStyleBackColor = false;
            this.btnSetMainPhoto.Click += new System.EventHandler(this.btnSetMainPhoto_Click);

            // lblPhotos
            this.lblPhotos.AutoSize = true;
            this.lblPhotos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhotos.Location = new System.Drawing.Point(530, 0);
            this.lblPhotos.Name = "lblPhotos";
            this.lblPhotos.Text = "Фотографии";

            // PropertyEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(750, 475);
            this.Controls.Add(this.lblPhotos);
            this.Controls.Add(this.panelPhotos);
            this.Controls.Add(this.btnAddPhoto);
            this.Controls.Add(this.btnDeletePhoto);
            this.Controls.Add(this.btnSetMainPhoto);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.cmbOwner);
            this.Controls.Add(this.lblPropertyType);
            this.Controls.Add(this.cmbPropertyType);
            this.Controls.Add(this.lblDistrict);
            this.Controls.Add(this.cmbDistrict);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblTotalFloors);
            this.Controls.Add(this.numTotalFloors);
            this.Controls.Add(this.lblFloor);
            this.Controls.Add(this.numFloor);
            this.Controls.Add(this.lblRooms);
            this.Controls.Add(this.numRooms);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.numArea);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PropertyEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование объекта";
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}