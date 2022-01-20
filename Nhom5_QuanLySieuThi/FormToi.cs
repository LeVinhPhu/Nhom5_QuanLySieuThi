using Nhom5_QuanLySieuThi.BUS;
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
    public partial class FormToi : Form
    {
        BUS_KhachHang bUS_KhachHang;
        bool flag = true;
        public FormToi()
        {
            InitializeComponent();
            bUS_KhachHang = new BUS_KhachHang();
        }

        private void FormToi_Load(object sender, EventArgs e)
        {
            txtSĐT.Text = GlobalConfigs.PhoneNumber.ToString();
            layThongTinKhachHang(txtSĐT.Text);
        }

        public void layThongTinKhachHang(string sdt)
        {
            Customer c = new Customer();
            c = bUS_KhachHang.GetCustomer(sdt);
            txtHo.Text = c.LastName.ToString();
            txtTen.Text = c.FirstName.ToString();
            dTNgaySinh.Text = c.BirthDate.ToString();
            txtDiachi.Text = c.Address.ToString();
            txtGhiChu.Text = c.Notes;
            txtPass.Text = c.PassWord;
        }

        private void btSuaTT_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                btSuaTT.Text = "Lưu";
                txtHo.ReadOnly = false;
                txtTen.ReadOnly = false;
                txtGhiChu.ReadOnly = false;
                txtDiachi.ReadOnly = false;
                txtPass.ReadOnly = false;
                flag = false;
            }
            else
            {
                Customer c = new Customer();
                c.PhoneCustomer = txtSĐT.Text;
                c.LastName = txtHo.Text;
                c.FirstName = txtTen.Text;
                c.BirthDate = dTNgaySinh.Value;
                c.Address = txtDiachi.Text;
                c.Notes = txtGhiChu.Text;
                c.PassWord = txtPass.Text;

                bUS_KhachHang.suaThongTinKhachHang(c);

                btSuaTT.Text = "Sửa TT";
                txtHo.ReadOnly = true;
                txtTen.ReadOnly = true;
                txtGhiChu.ReadOnly = true;
                txtDiachi.ReadOnly = true;
                txtPass.ReadOnly = true;
                flag = true;
            }
        }
    }
}
