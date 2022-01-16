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
    public partial class FormQLSieuThi : Form, ILaunchable
    {
        public FormQLSieuThi()
        {
            InitializeComponent();
        }

        // Load Form
        private void FormQLSieuThi_Load(object sender, EventArgs e)
        {
            LoadFormHome();
        }


        //----------------------------------------------------------------------------------

        // Đóng Form trên panel
        private void CloseForm()
        {
            panelLoadForm.Controls.Clear();
        }

        // Form Home
        private void LoadFormHome ()
        {
            FormHome fHome = new FormHome();
            fHome.TopLevel = false;
            panelLoadForm.Controls.Add(fHome);
            fHome.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fHome.Dock = DockStyle.Fill;
            fHome.Show();
        }


        // Form Thông Báo
        private void LoadFormThongBao()
        {
            FormThongBao fThongBao = new FormThongBao();
            fThongBao.TopLevel = false;
            panelLoadForm.Controls.Add(fThongBao);
            fThongBao.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fThongBao.Dock = DockStyle.Fill;
            fThongBao.Show();
        }


        // Form Tôi (Trang thông tin khách hàng)
        private void LoadFormToi()
        {
            FormToi fToi = new FormToi();
            fToi.TopLevel = false;
            panelLoadForm.Controls.Add(fToi);
            fToi.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fToi.Dock = DockStyle.Fill;
            fToi.Show();
        }

        
        // Form Giỏ Hàng
        private void LoadFormGioHang()
        {
            FormGioHang fGioHang = new FormGioHang(); 
            fGioHang.TopLevel = false;
            panelLoadForm.Controls.Add(fGioHang);
            fGioHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fGioHang.Dock = DockStyle.Fill;
            fGioHang.Show();
        }

        // Các Hàng Thực Thi
        private void btGioHang_Click(object sender, EventArgs e)
        {
            CloseForm();
            LoadFormGioHang();
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            CloseForm();
            LoadFormHome();
        }

        private void btThongBao_Click(object sender, EventArgs e)
        {
            CloseForm();
            LoadFormThongBao();
        }

        private void btTaiKhoan_Click(object sender, EventArgs e)
        {
            CloseForm();
            LoadFormToi();
        }

        public void Launch(Form source)
        {
            source.Hide();
            this.ShowDialog();
        }

        private void FormQLSieuThi_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
