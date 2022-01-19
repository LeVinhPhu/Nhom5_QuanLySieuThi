using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi
{
    public partial class RegisterRules : Form
    {
        public RegisterRules()
        {
            InitializeComponent();
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.DarkRed;
            exitButton.ForeColor = Color.White;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.White;
            exitButton.ForeColor = Color.Black;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
