using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLySieuThi
{
    internal class OrderedProduct : Product
    {
        Communicator communicator = Communicator.Instance;
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
            QuantityChanged += new EventHandler(communicator.OnOrderedProductQuantityChanged);
        }


        private void TriggerChangeEvent()
        {
            if (QuantityChanged != null)
                QuantityChanged(this, null);
        }

    }
}
