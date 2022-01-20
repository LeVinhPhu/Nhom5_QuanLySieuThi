using Nhom5_QuanLySieuThi.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi.CustomizedControls
{
    public partial class OrderView : UserControl
    {
        private Order mainOrder;
        public List<OrderedProduct> mainProducts;


        private FlowLayoutPanel exapandedPanel;
        private bool isCollapsed = true;
        public event EventHandler OrderRemoved;

        public OrderView(Order order, List<OrderedProduct> products)
        {
            mainOrder = order;
            mainProducts = products;
            InitializeComponent();
            AddExpandedPanel();
            LoadOrder();
            AddProducts();
        }

        private void LoadOrder()
        {
            orderID.Text = mainOrder.OrderID.ToString();
            date.Text = mainOrder.OrderDate.ToString();
            numberOfProducts.Text = mainProducts.Count.ToString();
            int tPrice = (int)mainProducts.Select(x => x.UnitPrice * x.Quantity).Sum();
            totalPrice.Text = tPrice.ToString();
        }

        private void AddProducts()
        {
            exapandedPanel.Controls.Clear();
            foreach (var product in mainProducts)
                exapandedPanel.Controls.Add(new OrderDetailView(product));

        }

        private void AddExpandedPanel()
        {
            exapandedPanel = new FlowLayoutPanel();
            exapandedPanel.BackColor = Color.WhiteSmoke;
            exapandedPanel.Dock = DockStyle.Bottom;
            exapandedPanel.Location = new Point(0, defaultPanel.Height);
            exapandedPanel.Height = 300;
            exapandedPanel.AutoScroll = true;
            exapandedPanel.WrapContents = true;
            exapandedPanel.BorderStyle = BorderStyle.FixedSingle;
           
        }

        private void Expand()
        {
            this.Height += exapandedPanel.Height;
            this.Controls.Add(exapandedPanel);
            this.expandButton.BackgroundImage = Properties.Resources.collapse;
        }

        private void Collapse()
        {
            this.Height -= exapandedPanel.Height;
            this.Controls.Remove(exapandedPanel);
            this.expandButton.BackgroundImage = Properties.Resources.expand;
        }

        private void expandButton_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                Expand();
                isCollapsed = false;
            }
            else
            {
                Collapse();
                isCollapsed = true;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Proceed to remove this order?", "Confirmation prompt", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                DAO_DonHang dAO_DonHang = new DAO_DonHang();
                if (dAO_DonHang.RemoveOrder(this.mainOrder.OrderID))
                {
                    MessageBox.Show("Removed order successfully", "Task done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (OrderRemoved != null)
                        OrderRemoved(this, EventArgs.Empty);
                }
                else
                    MessageBox.Show("Failed to remove order", "Aborted task", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
