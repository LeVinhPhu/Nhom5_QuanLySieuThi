using Nhom5_QuanLySieuThi.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi
{
    public class EntryPoint
    {
        public EntryPoint()
        {
            if (!TryLoggingIn())
                Application.Run(new FormDangNhap());
        }

        public bool TryLoggingIn()
        {
            bool result = AuthenticatorService.TryLoggingIn();
            if (result)
            {
                if (GlobalConfigs.IsCustomer)
                    LaunchForm(new FormQLSieuThi());
                else
                    LaunchForm(new FormQLNhanVien());
            }
            return result;
        }

        private void LaunchForm(Form form)
        {
            Thread thread = new Thread(() => Application.Run(form));
            thread.Start();
        }
    }
}
