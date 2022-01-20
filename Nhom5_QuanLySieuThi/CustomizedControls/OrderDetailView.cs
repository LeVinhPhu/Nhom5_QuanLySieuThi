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

namespace Nhom5_QuanLySieuThi.CustomizedControls
{
    public partial class OrderDetailView : UserControl
    {
        private OrderedProduct product;
        public OrderedProduct Product 
        { 
            get { return product; } 
            private set { product = value; }
        }

        public OrderDetailView(OrderedProduct orderedProduct)
        {
            Product = orderedProduct;
            InitializeComponent();
            LoadProduct();
        }

        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void LoadProduct()
        {
            if (Product.Imgage != null)
                MainImage.Image = ByteToImg(Product.Imgage);
            productName.Text = Product.ProductName;
            quantity.Text = Product.Quantity.ToString();
            price.Text = ((int)(Product.UnitPrice * Product.Quantity)).ToString() + " VND";
        }


    }
}
