using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
=======
using Microsoft.Reporting.WinForms;
using Nhom5_QuanLySieuThi.BUS;
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b

namespace Nhom5_QuanLySieuThi
{
    public partial class FormReport : Form
    {
<<<<<<< HEAD
=======
        BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b
        public int month, year;
        public FormReport()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không có máy in");
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLySieuThiDataSet.getRevenueListE' table. You can move, or remove it, as needed.
            this.getRevenueListETableAdapter.Fill(this.QuanLySieuThiDataSet.getRevenueListE, month, year);
=======
        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLySieuThiDataSet2.getRevenueListE' table. You can move, or remove it, as needed.
            this.getRevenueListETableAdapter.Fill(this.QuanLySieuThiDataSet2.getRevenueListE, month, year);
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Nhom5_QuanLySieuThi.Report1.rdlc";
            //ReportDataSource reportDataSource = new ReportDataSource();
            //reportDataSource.Name = "DataSet1";
            //reportDataSource.Value = ;
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b
            this.reportViewer1.RefreshReport();
        }
    }
}
