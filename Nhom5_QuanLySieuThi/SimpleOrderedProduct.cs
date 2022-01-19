using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLySieuThi
{
    [Serializable]
    public struct SimpleOrderedProduct
    {
        public int Quantity { get; set; }
        public int ProductID { get; set; }

        public SimpleOrderedProduct(int productID, int quantity)
        {
            ProductID = productID;
            Quantity = quantity;
        }
    }
}
