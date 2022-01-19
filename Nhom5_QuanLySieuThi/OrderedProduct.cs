using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLySieuThi
{
    public class OrderedProduct : Product
    {
        //Communicator communicator = Communicator.Instance;
        private int quantity;
        public int Quantity 
        { 
            get { return quantity; }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Quantity cannot be negative");
                quantity = value;
                TriggerChangeEvent();
            }
        }

        public event EventHandler QuantityChanged;
        public OrderedProduct() : base() 
        { 
            quantity = 1; 
            //QuantityChanged += new EventHandler(communicator.OnOrderedProductQuantityChanged);
        }

        public OrderedProduct(Product product, int quantity) : base()
        {
            this.ProductID = product.ProductID;
            this.ProductName = product.ProductName;
            this.Imgage = product.Imgage;
            this.UnitPrice = product.UnitPrice;
            this.Discontinued = product.Discontinued;
            this.DonViTinh = product.DonViTinh;
            this.CategoryID = product.CategoryID;
            this.quantity = quantity;

            //QuantityChanged += new EventHandler(communicator.OnOrderedProductQuantityChanged);
        }

        public void SetQuantityNoNotify(int quantity)
        {
            this.quantity = quantity;
        }

        private void TriggerChangeEvent()
        {
            if (QuantityChanged != null)
                QuantityChanged(this, null);
        }

    }
}
