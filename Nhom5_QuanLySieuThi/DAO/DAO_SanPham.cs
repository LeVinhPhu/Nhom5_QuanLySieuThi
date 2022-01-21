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

        public dynamic ListProducts()
        {
            var ds = db.Products.Select(s => new
            {
                s.ProductID,
                s.ProductName,
                s.CategoryID,
                s.DonViTinh,
                s.UnitPrice,
                s.Category.CategoryName
            }).ToList();
            return ds;
        }
        //Lấy ds loại sản phẩm
        public dynamic ListCategory()
        {
            dynamic ds = db.Categories.Select(s => new
            {
                s.CategoryID,
                s.CategoryName
            }).ToList();
            return ds;
        }
        public bool CheckProducts(Product product)
        {
            Product p = db.Products.Find(product.ProductID);
            // tìm đơn hàng có trong database không
            if (p != null)
            {
                return true;
            }
            else
                return false;
        }
        //public Product GetProduct2(int productID)
        //{

        //    Product p = db.Products.FirstOrDefault(s => s.ProductID == productID);
        //    return p;
        //}
        public Product FindProduct(int ProductID)
        {
            Product product1 = db.Products.FirstOrDefault(s => s.ProductID == ProductID);
            return product1;
        }


        public void AddProduct(Product product)
        {
            //cập nhật giá trị cho sản phẩm
            db.Products.Add(product);
            //cập nhật xuống db
            db.SaveChanges();

        }

        public void UpdateProduct(Product product)
        {
            //Lấy thông tin sản phẩm cần sửa
            Product product1 = db.Products.Find(product.ProductID);
            //cập nhật thông tin mới
            product1.ProductName = product.ProductName;
            product1.CategoryID = product.CategoryID;
            product1.UnitPrice = product.UnitPrice;
            product1.DonViTinh = product.DonViTinh;
            product1.Discontinued = product.Discontinued;
            product1.Imgage = product.Imgage;
            //cập nhật xuống database
            db.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            Product product1 = db.Products.Find(product.ProductID);
            //xóa sản phẩm
            db.Products.Remove(product1);
            //cập nhật xuống db
            db.SaveChanges();

        }
        public bool CheckProductInOrederDetail(int productID)
        {
            return db.Order_Details.Any(s => s.ProductID == productID);
        }
    }
}
