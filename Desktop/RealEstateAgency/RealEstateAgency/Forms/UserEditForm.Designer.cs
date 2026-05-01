namespace RealEstateAgency.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.Label lblAddress;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPassport = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();

            int y = 20;
            this.lblFullName.AutoSize = true; this.lblFullName.Location = new System.Drawing.Point(20, y); this.lblFullName.Text = "ФИО:"; this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(130, y); this.txtFullName.Size = new System.Drawing.Size(280, 23); this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);

            y += 35;
            this.lblPhone.AutoSize = true; this.lblPhone.Location = new System.Drawing.Point(20, y); this.lblPhone.Text = "Телефон:"; this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(130, y); this.txtPhone.Size = new System.Drawing.Size(200, 23); this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);

            y += 35;
            this.lblEmail.AutoSize = true; this.lblEmail.Location = new System.Drawing.Point(20, y); this.lblEmail.Text = "Email:"; this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(130, y); this.txtEmail.Size = new System.Drawing.Size(280, 23); this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);

            y += 35;
            this.lblLogin.AutoSize = true; this.lblLogin.Location = new System.Drawing.Point(20, y); this.lblLogin.Text = "Логин:"; this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLogin.Location = new System.Drawing.Point(130, y); this.txtLogin.Size = new System.Drawing.Size(200, 23); this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 10F);

            y += 35;
            this.lblPassword.AutoSize = true; this.lblPassword.Location = new System.Drawing.Point(20, y); this.lblPassword.Text = "Пароль:"; this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(130, y); this.txtPassword.Size = new System.Drawing.Size(200, 23); this.txtPassword.UseSystemPasswordChar = true; this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);

            y += 35;
            this.lblRole.AutoSize = true; this.lblRole.Location = new System.Drawing.Point(20, y); this.lblRole.Text = "Роль:"; this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(130, y); this.cmbRole.Size = new System.Drawing.Size(150, 23); this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);

            y += 35;
            this.lblPassport.AutoSize = true; this.lblPassport.Location = new System.Drawing.Point(20, y); this.lblPassport.Text = "Паспорт:"; this.lblPassport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassport.Location = new System.Drawing.Point(130, y); this.txtPassport.Size = new System.Drawing.Size(200, 23); this.txtPassport.Font = new System.Drawing.Font("Segoe UI", 10F);

            y += 35;
            this.lblAddress.AutoSize = true; this.lblAddress.Location = new System.Drawing.Point(20, y); this.lblAddress.Text = "Адрес:"; this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(130, y); this.txtAddress.Multiline = true; this.txtAddress.Size = new System.Drawing.Size(280, 50); this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(180, 320);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(300, 320);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += (s, e) => this.Close();

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(430, 375);
            this.Controls.Add(this.lblFullName); this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblPhone); this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail); this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblLogin); this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblPassword); this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblRole); this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblPassport); this.Controls.Add(this.txtPassport);
            this.Controls.Add(this.lblAddress); this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пользователь";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}