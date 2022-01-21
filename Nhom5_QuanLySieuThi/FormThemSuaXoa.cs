using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom5_QuanLySieuThi.BUS;
using Nhom5_QuanLySieuThi.DAO;

namespace Nhom5_QuanLySieuThi
{
    public partial class FormThemSuaXoa : Form
    {
        BUS_SanPham bSanPham;
        public FormThemSuaXoa()
        {
            InitializeComponent();
            bSanPham = new BUS_SanPham();
        }

        public void HienThiDSSanPham()
        {
            //định dạng các cột 
            gVSanPham.DataSource = null;
            bSanPham.ListProducts(gVSanPham);
            //gVSanPham.DataSource = dTProducts;
            gVSanPham.Columns[0].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[1].Width = (int)(gVSanPham.Width * 0.25);
            gVSanPham.Columns[2].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[3].Width = (int)(gVSanPham.Width * 0.20);
            gVSanPham.Columns[4].Width = (int)(gVSanPham.Width * 0.20);

        }
        private void FormThemSuaXoa_Load(object sender, EventArgs e)
        {
            FormatGridView();
            HienThiDSSanPham();
            bSanPham.ListCategoryName(cbLoai);
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            if (txtTenSP.Text == "" || txtDonGia.Text == "" || txtDonVi.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu");
                return;
            }
            product.ProductName = txtTenSP.Text;
            product.UnitPrice = decimal.Parse(txtDonGia.Text);
            product.DonViTinh = txtDonVi.Text;
            product.CategoryID = int.Parse(cbLoai.SelectedValue.ToString());

            if (bSanPham.AddProduct(product))
            {
                MessageBox.Show("Thêm thành công!");
                bSanPham.ListProducts(gVSanPham); //cập nhật lại DataGridView
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "" || txtDonGia.Text == "" || txtDonVi.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu");
                return;
            }
            Product product = new Product();
            product.ProductID = int.Parse(txtMaSP.Text);
            product.ProductName = txtTenSP.Text;
            product.DonViTinh = txtDonVi.Text;
            product.UnitPrice = decimal.Parse(txtDonGia.Text);
            product.CategoryID = int.Parse(cbLoai.SelectedValue.ToString());

            //gọi sự kiện từ BUS
            if (bSanPham.UpdateProduct(product))
            {
                MessageBox.Show("Sửa thành công!");
                HienThiDSSanPham(); //cập nhật lại DataGridView
            }
            else
                MessageBox.Show("Sửa thất bại");
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Chưa chọn mã sản phẩm để xóa ");
                return;
            }
            p.ProductID = int.Parse(txtMaSP.Text);/// lấy mã sản phẩm
            if (bSanPham.DeleteProduct(p))
            {
                MessageBox.Show("Xóa thành công!");
                HienThiDSSanPham(); //cập nhật lại DataGridView
            }
            else
                MessageBox.Show("Xóa thất bại");
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVSanPham.Rows.Count)
            {
                txtMaSP.Text = gVSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSP.Text = gVSanPham.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtDonVi.Text = gVSanPham.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDonGia.Text = gVSanPham.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbLoai.Text = gVSanPham.Rows[e.RowIndex].Cells[5].Value.ToString();


                //foreach (Category category in cbLoaiSP.Items)
                //    if (category.CategoryName.Equals(row.Cells["CategoryName"].Value.ToString()))
                //    {
                //        cbLoaiSP.SelectedItem = category;
                //        break;
                //    }
            }
        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFile.FileName);
                picSP.Image = img;
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            picSP.Image = null;
        }
        public void FormatGridView()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.gVSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gVSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gVSanPham.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.gVSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gVSanPham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gVSanPham.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(117)))), ((int)(((byte)(144)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gVSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gVSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Tai Le", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkOrchid;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gVSanPham.DefaultCellStyle = dataGridViewCellStyle3;
            this.gVSanPham.EnableHeadersVisualStyles = false;
            this.gVSanPham.GridColor = System.Drawing.Color.White;
            //this.gVSanPham.Location = new System.Drawing.Point(24, 227);
            //this.gVSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gVSanPham.Name = "gVSanPham";
            this.gVSanPham.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gVSanPham.RowHeadersWidth = 62;
            this.gVSanPham.RowTemplate.Height = 28;
            //this.gVSanPham.Size = new System.Drawing.Size(907, 267);
            this.gVSanPham.TabIndex = 15;
        }
    }

}

