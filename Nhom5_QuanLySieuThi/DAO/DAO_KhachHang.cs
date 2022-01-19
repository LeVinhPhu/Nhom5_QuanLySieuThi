﻿using System;
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
            Customer c = new Customer();
            c = db.Customers.Where(s => s.PhoneCustomer.Equals(cm.PhoneCustomer)).FirstOrDefault();
            c.FirstName = cm.FirstName;
            c.LastName = cm.LastName;
            c.BirthDate = cm.BirthDate;
            c.Address = cm.Address;
            c.Notes = cm.Notes;
            db.SaveChanges();
        }
    }
}
