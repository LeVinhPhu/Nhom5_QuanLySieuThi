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
    public partial class FormQLNhanVien : Form
    {
        public FormQLNhanVien()
        {
            InitializeComponent();
        }

        private void CloseForm()
        {
            panelLoadForm.Controls.Clear();
        }

        // Form Home
        private void LoadFormHome()
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


        // Form Thêm Sửa Xóa NV
        private void LoadFormThemSuaXoaNhanVien()
        {
            FormThemSuaXoaNhanVien fThenSuaXoa = new FormThemSuaXoaNhanVien();
            fThenSuaXoa.TopLevel = false;
            panelLoadForm.Controls.Add(fThenSuaXoa);
            fThenSuaXoa.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fThenSuaXoa.Dock = DockStyle.Fill;
            fThenSuaXoa.Show();
        }


        // Form Thêm Sửa Xoa SP
        private void LoadFormThemSuaXoaSanPham()
        {
            FormThemSuaXoaSanPham fThenSuaXoaSP = new FormThemSuaXoaSanPham();
            fThenSuaXoaSP.TopLevel = false;
            panelLoadForm.Controls.Add(fThenSuaXoaSP);
            fThenSuaXoaSP.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fThenSuaXoaSP.Dock = DockStyle.Fill;
            fThenSuaXoaSP.Show();
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


        private void FormQLNhanVien_Load(object sender, EventArgs e)
        {
            CloseForm();
            LoadFormHome();
        }

        private void btQLNhanVien_Click(object sender, EventArgs e)
        {
            CloseForm();
            LoadFormThemSuaXoaNhanVien();
        }

        private void btQLSanPham_Click(object sender, EventArgs e)
        {
            CloseForm();
            LoadFormThemSuaXoaSanPham();
        }

    }
}
