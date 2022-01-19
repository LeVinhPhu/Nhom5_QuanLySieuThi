using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Nhom5_QuanLySieuThi.BUS;

namespace Nhom5_QuanLySieuThi
{
    public partial class FormReport : Form
    {
        BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
        public int month, year;
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLySieuThiDataSet2.getRevenueListE' table. You can move, or remove it, as needed.
            this.getRevenueListETableAdapter.Fill(this.QuanLySieuThiDataSet2.getRevenueListE, month, year);
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Nhom5_QuanLySieuThi.Report1.rdlc";
            //ReportDataSource reportDataSource = new ReportDataSource();
            //reportDataSource.Name = "DataSet1";
            //reportDataSource.Value = ;
            this.reportViewer1.RefreshReport();
        }
    }
}
