using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLySieuThi.DAO
{
    internal class DAO_Authentication
    {
        private QuanLySieuThiEntities db = new QuanLySieuThiEntities();

        public bool LogInAsCustomer(string phoneNumber, string password)
        {
            return db.Customers.Any(c => c.PhoneCustomer.Equals(phoneNumber) && c.PassWord.Equals(password));
        }

        public bool LogInAsEmployee(string phoneNumber, string password)
        {
            return db.Employees.Any(e => e.PhoneEmployee.Equals(phoneNumber) && e.PassWord.Equals(password));
        }

        public bool AddNewCustomer(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                if (db.SaveChanges() > 0)
                    return true;
            }
            catch (Exception) { }
            return false;
        }
    }
}
