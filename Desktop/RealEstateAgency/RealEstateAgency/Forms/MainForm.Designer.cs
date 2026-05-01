using System;
using System.Windows.Forms;

namespace RealEstateAgency
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnDeals;
        private System.Windows.Forms.Button btnRequests;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnDictionaries;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnDictionaries = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnRequests = new System.Windows.Forms.Button();
            this.btnDeals = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnProperties = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnDictionaries);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnRequests);
            this.panelSidebar.Controls.Add(this.btnDeals);
            this.panelSidebar.Controls.Add(this.btnUsers);
            this.panelSidebar.Controls.Add(this.btnProperties);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(230, 600);

            // lblLogo
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(10, 15);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(210, 40);
            this.lblLogo.Text = "REAL ESTATE";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnProperties (и остальные) создаются в цикле для упрощения – здесь явно
            this.btnProperties = AddSidebarButton("🏠  Объекты", 70, btnProperties_Click);
            this.btnUsers = AddSidebarButton("👥  Клиенты", 110, btnUsers_Click);
            this.btnDeals = AddSidebarButton("💰  Сделки", 150, btnDeals_Click);
            this.btnRequests = AddSidebarButton("📋  Запросы", 190, btnRequests_Click);
            this.btnReports = AddSidebarButton("📊  Отчёты", 230, btnReports_Click);
            this.btnDictionaries = AddSidebarButton("📚  Справочники", 270, btnDictionaries_Click);
            this.btnLogout = AddSidebarButton("🚪  Выход", 500, btnLogout_Click);

            // lblWelcome
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // MainForm
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRM Агентства недвижимости";
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button AddSidebarButton(string text, int y, EventHandler handler)
        {
            var btn = new System.Windows.Forms.Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(10, y),
                Size = new System.Drawing.Size(210, 40),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += handler;
            this.panelSidebar.Controls.Add(btn);
            return btn;
        }
    }
}