using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi.DAO
{
    class DAO_SanPham
    {
        private QuanLySieuThiEntities db = new QuanLySieuThiEntities();

        public List<Category> RetrieveCategories()
        {
            List<Category> categories = db.Categories.Select(c => c).ToList();
            return categories;
        }


        public List<Product> ProductsOfCategory(int categoryID)
        {
            List<Product> products = db.Products.Where(p => p.CategoryID == categoryID).ToList();
            return products;
        }

        public Category GetCategory(int? categoryID)
        {
            return db.Categories.Where(c => c.CategoryID == categoryID).FirstOrDefault();
        }

        public Product GetProduct(int productID)
        {
            Product product = db.Products.Where(pd => pd.ProductID == productID).FirstOrDefault();

            Product p = new Product();
            p.ProductID = product.ProductID;
            p.CategoryID = product.CategoryID;
            p.ProductName = product.ProductName;
            p.Discontinued = product.Discontinued;
            p.UnitPrice = product.UnitPrice;
            p.DonViTinh = product.DonViTinh;
            p.Imgage = new string(product.Imgage.ToCharArray());
            return p;
        }
    }
}
