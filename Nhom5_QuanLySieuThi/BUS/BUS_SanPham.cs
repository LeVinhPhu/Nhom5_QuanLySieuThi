using Nhom5_QuanLySieuThi.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi.BUS
{
    class BUS_SanPham
    {
        private DAO_SanPham dAO_SanPham = new DAO_SanPham();

        public void LoadCategories(Dictionary<Button, List<BoxView>> map)
        {
            List<Category> categories = dAO_SanPham.RetrieveCategories();
            
            foreach (Category category in categories)
            {
                List<Product> products = dAO_SanPham.ProductsOfCategory(category.CategoryID);
                List<BoxView> boxViews = new List<BoxView>();

                foreach (Product product in products)
                    boxViews.Add(new BoxView(product));

                Button button = new Button();
                button.Text = category.CategoryName;
                map.Add(button, boxViews);
            }
        }

        public Category GetCategory(int? categoryID)
        {
            return dAO_SanPham.GetCategory(categoryID);
        }

        public void ListProducts(DataGridView dg)
        {
            //xử lý lỗi nếu có
            dg.DataSource = dAO_SanPham.ListProducts();
        }
        //lấy categoryID
        public void ListCategoryName(ComboBox cb)
        {
            //xử lý lỗi nếu có
            cb.DataSource = dAO_SanPham.ListCategory();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }

        public bool AddProduct(Product product)
        {
            bool kq = false;
            try
            {
                dAO_SanPham.AddProduct(product);
                kq = true;
            }
            catch (Exception ex)
            {
                kq = false;
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        public bool UpdateProduct(Product p)
        {
            if (dAO_SanPham.CheckProducts(p) && !dAO_SanPham.CheckProductInOrederDetail(p.ProductID))
            {
                try
                {
                    dAO_SanPham.UpdateProduct(p);
                    return true;
                    //MessageBox.Show("Sửa thành công ");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;

                }
            }
            else
            {
                return false;
                //MessageBox.Show("Sửa thất bại");

            }
        }
        public bool DeleteProduct(Product p)
        {
            if (dAO_SanPham.CheckProducts(p) && !dAO_SanPham.CheckProductInOrederDetail(p.ProductID))
            {
                try
                {
                    dAO_SanPham.DeleteProduct(p);
                    return true;
                    //MessageBox.Show("Xóa thành công ");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;

                }
            }
            else
            {
                return false;
                //MessageBox.Show("Xóa thất bại");

            }
        }
    }
}
