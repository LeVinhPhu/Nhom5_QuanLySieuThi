using Nhom5_QuanLySieuThi.BUS;
using Nhom5_QuanLySieuThi.CustomizedControls;
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
    public partial class FormHistory : Form
    {
        private BUS_DonHang bUS_DonHang = new BUS_DonHang();

        public FormHistory()
        {
            InitializeComponent();
            if (GlobalConfigs.PhoneNumber != null)
                LoadHistory(GlobalConfigs.PhoneNumber, orderViewsPanel);
        }

        public void ReloadHistory(Object sender, EventArgs eventArgs)
        {
            LoadHistory(GlobalConfigs.PhoneNumber, orderViewsPanel);
        }

        public void LoadHistory(string customerPhone, Panel panel)
        {
            panel.Controls.Clear();
            List<Order> orders = bUS_DonHang.GetOrdersOfCustomer(customerPhone);
            foreach (Order order in orders)
            {
                var list = bUS_DonHang.GetOrderedProducts(order.OrderID);
                OrderView orderView = new OrderView(order, list);
                orderView.OrderRemoved += new EventHandler(ReloadHistory);
                panel.Controls.Add(orderView);
            }
        }

    }
}
