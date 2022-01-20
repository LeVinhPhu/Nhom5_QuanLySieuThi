using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom5_QuanLySieuThi.BUS;

namespace Nhom5_QuanLySieuThi
{
    public partial class FormSaleReport : Form
    {
        BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
        public FormSaleReport()
        {
            InitializeComponent();
            numYear.Maximum = DateTime.Now.Year;
            numYear.Value = DateTime.Now.Year;
            numMonth.Value = DateTime.Now.Month;
        }

        private void FormSaleReport_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            txtPhone.Text = GlobalConfigs.PhoneNumber;
            txtName.Text = bUS_NhanVien.GetEmployeeName(txtPhone.Text);
        }

        public void LoadDataGridView()
        {
            int month = (int)numMonth.Value;
            int year = (int)numYear.Value;
            dataGridView.DataSource = null;
            bUS_NhanVien.GetRevenueList(dataGridView, month, year);
            dataGridView.Columns[0].Width = 170;
            dataGridView.Columns[1].Width = 270;
            dataGridView.Columns[2].Width = 270;
            dataGridView.Columns[3].Width = 200;
        }

        private void numMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormReport f = new FormReport();
            f.month = (int)numMonth.Value;
            f.year = (int)numYear.Value;
            f.Show();
        }
    }
}