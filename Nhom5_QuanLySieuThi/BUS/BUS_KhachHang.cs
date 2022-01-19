﻿using Nhom5_QuanLySieuThi.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLySieuThi.BUS
{
    class BUS_KhachHang
    {
        private DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();

        public Customer GetCustomer(string phoneNumber)
        {
            return dAO_KhachHang.GetCustomer(phoneNumber);
        }
    }
}
