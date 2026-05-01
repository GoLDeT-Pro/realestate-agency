namespace RealEstateAgency.Forms
{
    partial class DealsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDeals;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnAddDeal;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvDeals = new System.Windows.Forms.DataGridView();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnAddDeal = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeals)).BeginInit();
            this.SuspendLayout();

            this.dgvDeals.AllowUserToAddRows = false;
            this.dgvDeals.AllowUserToDeleteRows = false;
            this.dgvDeals.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeals.ColumnHeadersHeight = 40;
            this.dgvDeals.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.dgvDeals.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDeals.EnableHeadersVisualStyles = false;
            this.dgvDeals.Location = new System.Drawing.Point(12, 50);
            this.dgvDeals.Name = "dgvDeals";
            this.dgvDeals.ReadOnly = true;
            this.dgvDeals.RowHeadersVisible = false;
            this.dgvDeals.Size = new System.Drawing.Size(860, 400);

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(50, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 23);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(220, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 23);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);

            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(12, 16);
            this.lblFrom.Text = "От:";

            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(185, 16);
            this.lblTo.Text = "до:";

            this.btnAddDeal.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddDeal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDeal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddDeal.ForeColor = System.Drawing.Color.White;
            this.btnAddDeal.Location = new System.Drawing.Point(12, 460);
            this.btnAddDeal.Name = "btnAddDeal";
            this.btnAddDeal.Size = new System.Drawing.Size(150, 35);
            this.btnAddDeal.Text = "Новая сделка";
            this.btnAddDeal.UseVisualStyleBackColor = false;
            this.btnAddDeal.Click += new System.EventHandler(this.btnAddDeal_Click);

            this.btnClose.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(772, 460);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += (s, e) => this.Close();

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(884, 510);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddDeal);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dgvDeals);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "DealsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сделки";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}