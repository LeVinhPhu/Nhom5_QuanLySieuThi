using Nhom5_QuanLySieuThi.DAO;
using System;
using System.Collections.Generic;
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
    }
}
