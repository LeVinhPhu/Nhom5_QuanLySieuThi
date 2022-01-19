using Nhom5_QuanLySieuThi.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi.BUS
{
    class BUS_KhachHang
    {
        private DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();

        public Customer GetCustomer(string phoneNumber)
        {
            return dAO_KhachHang.GetCustomer(phoneNumber);
        }

        public void suaThongTinKhachHang(Customer c)
        {
            try
            {
                dAO_KhachHang.suaThongTinKhachHang(c);
            }
            catch (DbUpdateException ex) // bat loi lien quan den database (rang buoc, ...)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
