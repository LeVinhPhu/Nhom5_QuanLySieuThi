using Nhom5_QuanLySieuThi.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi
{
    public partial class FormDangKy : Form
    {
        private bool passwordVisible = false;
        private bool passwordsMatched = false;
        private Form source;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private BUS_Authentication bUS_Authentication = new BUS_Authentication();

        #region Form_Controller
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void Form_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion Form_Controller

        public FormDangKy()
        {
            InitializeComponent();
            confirmationStatus.Text = "Re-enter your password";
            password.PasswordChar = '\u25CF';
            confirmPassword.PasswordChar = '\u25CF';
            DateTime now = DateTime.Now;
            birthDate.Value = new DateTime(now.Year - 13, now.Month, now.Day);
        }

        public void Launch(Form source)
        {
            this.source = source;
            this.ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.source.Close();
        }

        private void switchModeButton_Click(object sender, EventArgs e)
        {
            if (source != null)
            {
                source.Show();
                this.Hide();
            }
            else
                throw new NullReferenceException();

        }

        private bool Validate()
        {
            string _fName = firstName.Text.Trim();
            string _lName = lastName.Text.Trim();
            string _address = address.Text.Trim();
            string _pNumber = phoneNumber.Text;
            string _password = password.Text;

            if (!_fName.Equals("") && !_lName.Equals("") && !_address.Equals("")
                && _pNumber.Length >= 10 && _password.Length >= 6 && passwordsMatched)
                return true;
            return false;
        }

        private Customer ExtractCustomer()
        {
            if (Validate())
            {
                Customer customer = new Customer();
                customer.FirstName = firstName.Text.Trim();
                customer.LastName = lastName.Text.Trim();
                customer.Address = address.Text.Trim();
                customer.BirthDate = birthDate.Value;
                customer.PhoneCustomer = phoneNumber.Text;
                customer.PassWord = password.Text;
                return customer;
            }
            else
                return null;
        }
        private void signUpButton_Click(object sender, EventArgs e)
        {
            // add new customer
            Customer customer = ExtractCustomer();
            if (customer != null)
            {
                if (bUS_Authentication.Register(customer))
                {
                    GlobalConfigs.PhoneNumber = customer.PhoneCustomer;
                    GlobalConfigs.IsCustomer = true;

                    new Thread(() => Application.Run(new FormQLSieuThi())).Start();
                    this.source.Close();
                }
                else
                    MessageBox.Show("Cannot create new account", "Register aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
            else
                MessageBox.Show("Invalid information detected", "Register aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
        }

        private void confirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!confirmPassword.Text.Equals(password.Text))
            {
                confirmationStatus.Text = "Password does not match";
                confirmationStatus.ForeColor = Color.Red;
                passwordsMatched = false;
            }
            else
            {
                confirmationStatus.Text = "Password matches";
                confirmationStatus.ForeColor = Color.Green;
                passwordsMatched = true;
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
 
        }

        private void passwordView_Click(object sender, EventArgs e)
        {
            if (passwordVisible)
            {
                password.PasswordChar = '\u25CF';
                passwordVisible = false;
            }
            else
            {
                password.PasswordChar = '\0';
                passwordVisible = true;
            }
        }

        private void phoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void birthDate_ValueChanged(object sender, EventArgs e)
        {
            if (birthDate.Value.AddYears(13).CompareTo(DateTime.Now) > 0)
            {
                DateTime now = DateTime.Now;
                birthDate.Value = new DateTime(now.Year - 13, now.Month, now.Day);
                MessageBox.Show("You have to be older than 13 years to register", "Info Violation Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void viewRules_Click(object sender, EventArgs e)
        {
            RegisterRules registerRules = new RegisterRules();
            registerRules.ShowDialog();
            registerRules.Dispose();
        }
    }
}
