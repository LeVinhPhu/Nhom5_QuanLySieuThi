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
    public partial class FormQLSieuThi : Form
    {
        public static FormHome FHome { get; private set; }
        public static FormToi FToi { get; private set; }
        public static FormGioHang FGioHang { get; private set; }
        public static FormThongBao FThongBao { get; private set; }
        private Form currentForm;
        public TextBox SearchBar
        {
            get { return txtTimKiem; }
        }


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
            if (FHome == null)
            {
                FHome = new FormHome();
                FHome.TopLevel = false;
                FHome.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                FHome.Dock = DockStyle.Fill;
                FHome.MainCommunicator.StartDeserializeCart();
            }
            currentForm = FHome;
            panelLoadForm.Controls.Add(FHome);
            txtTimKiem.Enabled = true;
            txtTimKiem.Text = "";
            FHome.Show();
        }


        // Form Thông Báo
        private void LoadFormThongBao()
        {
            if (FThongBao == null)
            {
                FThongBao = new FormThongBao();
                FThongBao.TopLevel = false;
                FThongBao.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                FThongBao.Dock = DockStyle.Fill;
            }
            currentForm = FThongBao;
            panelLoadForm.Controls.Add(FThongBao);
            FThongBao.Show();
        }


        // Form Tôi (Trang thông tin khách hàng)
        private void LoadFormToi()
        {
            if (FToi == null)
            {
                FToi = new FormToi();
                FToi.TopLevel = false;
                FToi.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                FToi.Dock = DockStyle.Fill;
            }
            currentForm = FToi;
            panelLoadForm.Controls.Add(FToi);
            FToi.Show();
        }

        
        // Form Giỏ Hàng
        private void LoadFormGioHang()
        {
            if (FGioHang == null)
            {
                FGioHang = new FormGioHang();
                FGioHang.TopLevel = false;
                FGioHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                FGioHang.Dock = DockStyle.Fill;
            }
            currentForm = FGioHang;
            panelLoadForm.Controls.Add(FGioHang);
            txtTimKiem.Enabled = false;
            txtTimKiem.Text = "Search is disable when is in cart view";
            FGioHang.Show();
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


        private void FormQLSieuThi_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                PerformFilter_Home();
            }
        }

        private void PerformFilter_Home()
        {
            if (currentForm == FHome)
                FHome.Filter = txtTimKiem.Text.Trim();

        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }
    }
}
