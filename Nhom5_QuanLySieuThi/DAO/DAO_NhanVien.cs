
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLySieuThi.DAO
{

    class DAO_NhanVien
    {
        QuanLySieuThiEntities db = new QuanLySieuThiEntities();
        public dynamic GetRevenueList(int month, int year)
        {
            dynamic ds = db.getRevenueListE(month, year);
            return ds;
        }

        public String GetEmployeeName(String phone)
        {
            Employee employee = db.Employees.Find(phone);
            String name = employee.FirstName + " " + employee.LastName;
            return name;
        }
    }
}