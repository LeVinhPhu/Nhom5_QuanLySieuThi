using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Windows.Forms;
using Nhom5_QuanLySieuThi.DAO;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Drawing;
using System.Threading;

namespace Nhom5_QuanLySieuThi
{
    // this class handle the commnications between the [Home] and [GioHang] forms
    public class Communicator
    {

        private static Communicator instance;
        private DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
        private DAO_SanPham dAO_SanPham = new DAO_SanPham();
        private System.Timers.Timer MainTimer;
        private ObservableCollection<OrderedProduct> orderedProducts;
        public ObservableCollection<OrderedProduct> OrderedProducts 
        { 
            get { return orderedProducts; }
            private set { orderedProducts = value; } 
        }

        public void StartDeserializeCart()
        {
            var iniList = DeserializeCart();
            if (iniList != null)
            {
                var tmpList = ResolveCart(iniList);
                if (tmpList != null)
                {
                    OrderedProducts = tmpList;
                    SyncChangesToCart();
                    foreach (var item in tmpList)
                        SyncChangesToHome(item);
                    OrderedProducts.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChanged);
                }
            }
        }

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
                {
                    instance = new Communicator();
                }
                return instance; 
            }
        }

        // this will be called when the ObservableCollection has inserted a new item
        // this will only be called from the FormHome form
        public void OnCollectionChanged(Object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            if (eventArgs.Action != NotifyCollectionChangedAction.Remove)
            {
                MessageBox.Show("collection changed: " + sender);
                SyncChangesToCart();
                StartSerializeCart();
            }
        }

        // this will be called when its containing objects has its [Quantity] property changed
        public void OnOrderedProductQuantityChanged(Object sender, EventArgs eventArgs)
        {
            MessageBox.Show("quantity changed: " + (sender as OrderedProduct).ProductName);
            SyncChangesToCart();
            SyncChangesToHome(sender as OrderedProduct);
            StartSerializeCart();
        }

        // this will be called when an ordered product is removed
        // the action can be done from both side: FormHome and FormGioHang
        public void OnRemovedOrderedProduct(Object sender, EventArgs eventArgs)
        {
            MessageBox.Show("removed product");
            SyncChangesToCart();
            (sender as OrderedProduct).SetQuantityNoNotify(0);
            SyncChangesToHome(sender as OrderedProduct);
            StartSerializeCart();
        }

        private void SyncChangesToHome(OrderedProduct product)
        {
            if (FormQLSieuThi.FHome != null)
                FormQLSieuThi.FHome.SyncChangesToOrderedProduct(product);
        }

        private void SyncChangesToCart()
        {
            if (FormQLSieuThi.FGioHang != null)
                FormQLSieuThi.FGioHang.LoadOrderedProducts();
        }

        // run serialization in a new thread
        private void StartSerializeCart()
        {
            Thread thread = new Thread(() => SerializeCart());
            thread.Start();
        }

        public void DeleteCartJson()
        {
            string fileName = "C_" + GlobalConfigs.PhoneNumber.GetHashCode().ToString() + ".json";
            if (File.Exists(fileName))
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
                File.Delete(fileName);
            }
        }

        public void EmptyCart()
        {
            if (OrderedProducts.Count > 0)
            {
                foreach (OrderedProduct product in OrderedProducts)
                {
                    product.SetQuantityNoNotify(0);
                    SyncChangesToHome(product);
                }

                OrderedProducts = new ObservableCollection<OrderedProduct>();
                OrderedProducts.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnCollectionChanged);
                SyncChangesToCart();
            }
        }

        public void SerializeCart()
        {
            if (GlobalConfigs.PhoneNumber != null)
            {
                string fileName = "C_" + GlobalConfigs.PhoneNumber.GetHashCode().ToString() + ".json";

                List<SimpleOrderedProduct> list = OrderedProducts.Select(p => new SimpleOrderedProduct(p.ProductID, p.Quantity)).ToList();
                if (list.Count > 0)
                {
                    DeleteCartJson();
                    using (StreamWriter file = File.CreateText(fileName))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, list);
                        // set file as read-only
                        FileInfo fileInfo = new FileInfo(fileName);
                        fileInfo.IsReadOnly = true;
                    }
                }
            }
            else
                throw new NullReferenceException("PhoneNumber is null, cannot perform serialization");
        }

        public List<SimpleOrderedProduct> DeserializeCart()
        {
            List<SimpleOrderedProduct> list = null;
            if (GlobalConfigs.PhoneNumber != null)
            {
                string fileName = "C_" + GlobalConfigs.PhoneNumber.GetHashCode().ToString() + ".json";
                if (File.Exists(fileName))
                {
                    list = new List<SimpleOrderedProduct>(JsonConvert.DeserializeObject<List<SimpleOrderedProduct>>(File.ReadAllText(fileName)));
                    return list;
                }

            }
            return list;
        }
        
        private ObservableCollection<OrderedProduct> ResolveCart(List<SimpleOrderedProduct> list)
        {
            List < OrderedProduct > newList = new List < OrderedProduct >();

            //MessageBox.Show(list.Count + ": list size");
            foreach(var simpleOrderedProduct in list)
            {
                Product product = dAO_SanPham.GetProduct(simpleOrderedProduct.ProductID);
                OrderedProduct orderedProduct = new OrderedProduct(product, simpleOrderedProduct.Quantity);
                orderedProduct.QuantityChanged += new EventHandler(this.OnOrderedProductQuantityChanged);
                newList.Add(orderedProduct);
            }

            if (newList.Count > 0)
                return new ObservableCollection<OrderedProduct>(newList);
            return null;
        }

    }
}
