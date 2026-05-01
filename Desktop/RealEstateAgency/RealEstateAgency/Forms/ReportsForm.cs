using System;
using System.Linq;
using System.Windows.Forms;
using Dapper;

namespace RealEstateAgency.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            LoadDealsReport();
            LoadDistrictsReport();
        }

        private void LoadDealsReport()
        {
            var conn = Program.DbService.GetConnection();
            var data = conn.Query(@"
                SELECT d.deal_date AS Дата, p.address AS Объект, c.full_name AS Клиент,
                       d.price AS Цена, d.commission AS Комиссия
                FROM deals d
                JOIN properties p ON d.property_id = p.id
                JOIN clients c ON d.client_id = c.id
                ORDER BY d.deal_date DESC").ToList();
            dgvDeals.DataSource = data;
        }

        private void LoadDistrictsReport()
        {
            var conn = Program.DbService.GetConnection();
            var data = conn.Query(@"
                SELECT d.name AS Район, COUNT(p.id) AS Объектов,
                       COALESCE(AVG(p.price), 0) AS СредняяЦена,
                       COALESCE(MIN(p.price), 0) AS МинЦена,
                       COALESCE(MAX(p.price), 0) AS МаксЦена
                FROM districts d
                LEFT JOIN properties p ON d.id = p.district_id AND p.status = 'Свободен'
                GROUP BY d.name
                ORDER BY Объектов DESC").ToList();
            dgvDistricts.DataSource = data;
        }
    }
}