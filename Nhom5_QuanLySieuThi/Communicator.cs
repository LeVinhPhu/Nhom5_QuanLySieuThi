using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi
{
    // this class handle the commnications between the [Home] and [GioHang] forms
    internal class Communicator
    {
        private static Communicator instance;

        public ObservableCollection<OrderedProduct> OrderedProducts { get; private set; }

        private Communicator()
        {
            OrderedProducts = new ObservableCollection<OrderedProduct>();
            OrderedProducts.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChanged);
        }

        public static Communicator Instance 
        {
            get 
            { 
                if (instance == null)
                    instance = new Communicator();
                return instance; 
            }
        }

        // this will be called when the ObservableCollection has its values changed
        public void OnCollectionChanged(Object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            MessageBox.Show("collection changed");
        }

        // this will be called when its containing objects has its [Quantity] property changed
        public void OnOrderedProductQuantityChanged(Object sender, EventArgs eventArgs)
        {
            MessageBox.Show("quantity changed: " + (sender as OrderedProduct).ProductName);
        }
    }
}
