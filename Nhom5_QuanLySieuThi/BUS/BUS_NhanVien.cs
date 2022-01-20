using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom5_QuanLySieuThi.DAO;

namespace Nhom5_QuanLySieuThi.BUS
{
    class BUS_NhanVien
    {
        DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
        public void GetRevenueList(DataGridView dg, int month, int year)
        {
            dg.DataSource = dAO_NhanVien.GetRevenueList(month, year);
        }
        public String GetEmployeeName(String phone)
        {
            return dAO_NhanVien.GetEmployeeName(phone);
        }
    }
}