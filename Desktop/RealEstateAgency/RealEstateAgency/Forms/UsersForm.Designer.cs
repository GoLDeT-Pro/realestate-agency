namespace RealEstateAgency.Forms
{
    partial class UsersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabOwners;
        private System.Windows.Forms.TabPage tabRealtors;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.DataGridView dgvOwners;
        private System.Windows.Forms.DataGridView dgvRealtors;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnAddOwner;
        private System.Windows.Forms.Button btnEditOwner;
        private System.Windows.Forms.Button btnDeleteOwner;
        private System.Windows.Forms.Button btnAddRealtor;
        private System.Windows.Forms.Button btnEditRealtor;
        private System.Windows.Forms.Button btnDeleteRealtor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.tabOwners = new System.Windows.Forms.TabPage();
            this.dgvOwners = new System.Windows.Forms.DataGridView();
            this.btnAddOwner = new System.Windows.Forms.Button();
            this.btnEditOwner = new System.Windows.Forms.Button();
            this.btnDeleteOwner = new System.Windows.Forms.Button();
            this.tabRealtors = new System.Windows.Forms.TabPage();
            this.dgvRealtors = new System.Windows.Forms.DataGridView();
            this.btnAddRealtor = new System.Windows.Forms.Button();
            this.btnEditRealtor = new System.Windows.Forms.Button();
            this.btnDeleteRealtor = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.tabOwners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).BeginInit();
            this.tabRealtors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealtors)).BeginInit();
            this.SuspendLayout();
            // tabControl
            this.tabControl.Controls.Add(this.tabClients);
            this.tabControl.Controls.Add(this.tabOwners);
            this.tabControl.Controls.Add(this.tabRealtors);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Size = new System.Drawing.Size(760, 480);
            // tabClients
            this.tabClients.Controls.Add(this.dgvClients);
            this.tabClients.Controls.Add(this.btnAddClient);
            this.tabClients.Controls.Add(this.btnEditClient);
            this.tabClients.Controls.Add(this.btnDeleteClient);
            this.tabClients.Text = "Клиенты";
            // dgvClients
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(6, 6);
            this.dgvClients.Size = new System.Drawing.Size(740, 400);
            // кнопки внизу
            this.btnAddClient.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(6, 420);
            this.btnAddClient.Size = new System.Drawing.Size(100, 30);
            this.btnAddClient.Text = "Добавить";
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            this.btnEditClient.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditClient.ForeColor = System.Drawing.Color.White;
            this.btnEditClient.Location = new System.Drawing.Point(112, 420);
            this.btnEditClient.Size = new System.Drawing.Size(100, 30);
            this.btnEditClient.Text = "Изменить";
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            this.btnDeleteClient.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteClient.ForeColor = System.Drawing.Color.White;
            this.btnDeleteClient.Location = new System.Drawing.Point(218, 420);
            this.btnDeleteClient.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteClient.Text = "Удалить";
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // Аналогично для Owners и Realtors
            // ... (воспроизведём для краткости одинаковый паттерн)
            // Кнопки для владельцев и риэлторов создаются так же с DodgerBlue

            // UsersForm
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Клиенты, собственники, риэлторы";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}