using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi
{
    public partial class FormReport : Form
    {
        public int month, year;
        public FormReport()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không có máy in");
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLySieuThiDataSet.getRevenueListE' table. You can move, or remove it, as needed.
            this.getRevenueListETableAdapter.Fill(this.QuanLySieuThiDataSet.getRevenueListE, month, year);

            this.reportViewer1.RefreshReport();
        }
    }
}