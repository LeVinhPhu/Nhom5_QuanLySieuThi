using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom5_QuanLySieuThi.BUS;

namespace Nhom5_QuanLySieuThi
{
    public partial class FormSalesReport : Form
    {
        BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
        public FormSalesReport()
        {
            InitializeComponent();
            txtEmployeeName.Text = bUS_NhanVien.GetEmployeeName(GlobalConfigs.PhoneNumber);
            dateReport.Value = DateTime.Now;
            numYear.Maximum = DateTime.Now.Year;
            numYear.Value = DateTime.Now.Year;
        }

        private void FormSalesReport_Load(object sender, EventArgs e)
        {
            LoadRevenueList();
        }

        public void LoadRevenueList()
        {
            int month = (int)numMonth.Value;
            int year = (int)numYear.Value;
            gV.DataSource = null;
            bUS_NhanVien.LoadDataGridView(gV, month, year);
            gV.Columns[0].Width = 120;
            gV.Columns[1].Width = 250;
            gV.Columns[2].Width = 250;
            gV.Columns[3].Width = 150;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            LoadRevenueList();
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            //LaunchForm(new FormReport());
            FormReport f = new FormReport();
            f.month = (int)numMonth.Value;
            f.year = (int)numYear.Value;
            f.Show();
        }

        private void LaunchForm(Form form)
        {
            Thread thread = new Thread(() => Application.Run(form));
            thread.Start();
            this.Close();
        }
    }
}
