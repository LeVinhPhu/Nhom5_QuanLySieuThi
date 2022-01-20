﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi
{
    static class Program
    {

        //Tắng độ hiển thi trên winform
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Tăng độ hiển thị trên winform
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new EntryPoint());
            new EntryPoint();
        }
        
    }
}
