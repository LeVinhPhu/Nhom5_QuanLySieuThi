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

        public Customer TryMatchingCustomer(string hash)
        {
            List<Customer> list = db.Customers.Select(i => i).ToList();
            foreach (Customer customer in list)
            {
                string str = customer.PhoneCustomer + customer.PassWord;
                string hashed = HashingService.ComputeSHA256(str);
                if (hashed.Equals(hash))
                    return customer;
            }
            return null;
        }

        public Employee TryMatchingEmployee(string hash)
        {
            List<Employee> list = db.Employees.Select(i => i).ToList();
            foreach (Employee employee in list)
            {
                string str = employee.PhoneEmployee + employee.PassWord;
                string hashed = HashingService.ComputeSHA256(str);
                if (hashed.Equals(hash))
                    return employee;
            }
            return null;
        }
    }
}
