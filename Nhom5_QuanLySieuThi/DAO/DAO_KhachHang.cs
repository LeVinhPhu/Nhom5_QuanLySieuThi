using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLySieuThi.DAO
{
    class DAO_KhachHang
    {
        private QuanLySieuThiEntities db = new QuanLySieuThiEntities();

        public Customer GetCustomer(string phoneNumber)
        {
            return db.Customers.Where(c => c.PhoneCustomer.Equals(phoneNumber)).FirstOrDefault();
        }
    }
}
