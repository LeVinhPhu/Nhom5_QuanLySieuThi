using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi.DAO
{
    internal class DAO_DonHang
    {
        private QuanLySieuThiEntities db = new QuanLySieuThiEntities();

        public Order GetLatestOrder()
        {
            return db.Orders.OrderBy(o => o.OrderID).ToList().LastOrDefault();
        }

        private void AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        private void AddOrderDetail(Order_Detail order_Detail)
        {
            db.Order_Details.Add(order_Detail);
            db.SaveChanges();
        }
        public bool AddNewOrder(Order order, Collection<OrderedProduct> orderedProducts)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    AddOrder(order);
                    int orderID = GetLatestOrder().OrderID;
                    
                    foreach (OrderedProduct product in orderedProducts)
                    {
                        Order_Detail detail = new Order_Detail();
                        detail.OrderID = orderID;
                        detail.ProductID = product.ProductID;
                        detail.Discount = 0;
                        detail.UnitPrice = (decimal)product.UnitPrice;
                        detail.Quantity = (short)product.Quantity;
                        AddOrderDetail(detail);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Exception occurred when trying to add new Order: " + ex.Message, "Abort adding new order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        public Order GetOrder(int orderID)
        {
            return db.Orders.Where(o => o.OrderID == orderID).ToList().FirstOrDefault();
        }

        public List<Order> GetOrdersOf(string customerPhone)
        {
            return db.Orders.Where(o => o.CustomerPhone.Equals(customerPhone)).ToList();
        }

        public List<OrderedProduct> GetOrderedProducts(int orderID)
        {
            return db.Order_Details
                        .Where(od => od.OrderID == orderID)
                        .Select(od => new { od.ProductID, od.Quantity })
                        .ToList()
                        .Select(o => new OrderedProduct(
                            db.Products.Where(p => p.ProductID == o.ProductID).ToList().FirstOrDefault(),
                            o.Quantity))
                        .ToList();
        }

        private void RemoveOrderDetails(int orderID)
        {
            List<Order_Detail> list = db.Order_Details.Where(o => o.OrderID == orderID).ToList();
            foreach (Order_Detail detail in list)
                db.Order_Details.Remove(detail);
            db.SaveChanges();
        }

        public bool RemoveOrder(int orderID)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    RemoveOrderDetails(orderID);

                    Order order = db.Orders.Where(o => o.OrderID == orderID).ToList().FirstOrDefault();
                    db.Orders.Remove(order);
                    db.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Exception encountered: " + ex.Message, "Task failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
    }
}
