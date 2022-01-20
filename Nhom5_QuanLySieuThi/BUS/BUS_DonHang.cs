using Nhom5_QuanLySieuThi.CustomizedControls;
using Nhom5_QuanLySieuThi.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi.BUS
{
    internal class BUS_DonHang
    {
        private DAO_DonHang dAO_DonHang = new DAO_DonHang();

        public bool AddNewOrder(Order order, Collection<OrderedProduct> orderedProducts)
        {
            if (orderedProducts.Count > 0)
                return dAO_DonHang.AddNewOrder(order, orderedProducts);
            return false;

        }

        public List<Order> GetOrdersOfCustomer(string customerPhone)
        {
            return dAO_DonHang.GetOrdersOf(customerPhone);
        }

        public List<OrderedProduct> GetOrderedProducts(int orderID)
        {
            return dAO_DonHang.GetOrderedProducts(orderID);
        }
    }
}
