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

        public void OnCollectionChanged(Object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            MessageBox.Show("collection changed");
        }

        public void OnOrderedProductQuantityChanged(Object sender, EventArgs eventArgs)
        {
            MessageBox.Show("quantity changed: " + (sender as OrderedProduct).ProductName);
        }
    }
}
