using Nhom5_QuanLySieuThi.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLySieuThi.BUS
{
    internal class BUS_Authentication
    {
        private DAO_Authentication dAO_Authentication = new DAO_Authentication();
        
        public bool LogIn(string phoneNumber, string password, bool asCustomer)
        {
            if (asCustomer)
            {
                return dAO_Authentication.LogInAsCustomer(phoneNumber, password);
            }
            else
            {
                // as employee
                return dAO_Authentication.LogInAsEmployee(phoneNumber, password);
            }
        }

        public bool Register(Customer customer)
        {
            if (customer == null)
                return false;
            else
                return dAO_Authentication.AddNewCustomer(customer);
        }
    }
}
