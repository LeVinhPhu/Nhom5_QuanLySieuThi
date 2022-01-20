using Nhom5_QuanLySieuThi.BUS;
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
    public partial class FormGioHang : Form
    {
        private Communicator communicator = Communicator.Instance;
        private BUS_DonHang bUS_DonHang = new BUS_DonHang();

        public FormGioHang()
        {
            InitializeComponent();
            LoadOrderedProducts();
        }
        
        private void LoadSimpleInvoice()
        {
            numberOfProducts.Text = communicator.OrderedProducts.Count.ToString();
            string price = communicator.OrderedProducts.Sum(od => od.Quantity * od.UnitPrice).ToString();
            totalPrice.Text = price.Split('.')[0] + " VND";

        }
        public void LoadOrderedProducts()
        {
            orderedProductsPanel.Controls.Clear();
            if (communicator.OrderedProducts.Count > 0)
            {
                purchaseButton.Enabled = true;
                foreach (var product in communicator.OrderedProducts)
                {
                    BoxView boxView = new BoxView(product);
                    boxView.Width = boxView.Width - 5;
                    orderedProductsPanel.Controls.Add(boxView);
                    LoadSimpleInvoice();
                }
            }
            else
            {
                numberOfProducts.Text = "0";
                totalPrice.Text = "0 VND";
                purchaseButton.Enabled = false;
            }

        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            if (GlobalConfigs.IsCustomer && GlobalConfigs.PhoneNumber != null)
            {
                if (communicator.OrderedProducts.Count > 0)
                {
                    Order order = new Order();
                    order.CustomerPhone = GlobalConfigs.PhoneNumber;
                    order.OrderDate = DateTime.Now;
                    order.EmployeePhone = null;
                    order.Freight = null;

                    if (bUS_DonHang.AddNewOrder(order, communicator.OrderedProducts))
                    {
                        MessageBox.Show("Added new order successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        communicator.EmptyCart();
                        communicator.DeleteCartJson();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new order", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void emptyCart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to remove " + communicator.OrderedProducts.Count + " products?", "Confirmation prompt", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                communicator.EmptyCart();
                communicator.DeleteCartJson();
            }
        }

        private void viewHistoryButton_Click(object sender, EventArgs e)
        {
            new FormHistory().ShowDialog();
        }
    }
}
