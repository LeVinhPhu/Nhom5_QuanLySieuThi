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
            throw new NotImplementedException();
        }
    }
}
