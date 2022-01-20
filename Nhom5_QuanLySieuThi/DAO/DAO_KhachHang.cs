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

        public void suaThongTinKhachHang(Customer cm)
        {
            Customer c = db.Customers.Find(cm.PhoneCustomer);
            c.FirstName = cm.FirstName;
            c.LastName = cm.LastName;
            c.BirthDate = cm.BirthDate;
            c.Address = cm.Address;
            c.Notes = cm.Notes;
            db.SaveChanges();
        }
    }
}
