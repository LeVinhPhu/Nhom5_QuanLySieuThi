using Nhom5_QuanLySieuThi.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi
{
    public partial class FormDangNhap : Form
    {
        private bool passwordVisible = false;
        private bool isCustomer = true;
        private bool rememberedMe = false;
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

        public FormDangNhap()
        {
            InitializeComponent();
            toggleSwitch.Image = Properties.Resources.toggle_button_off;
            rememberMe.Image = Properties.Resources.toggle_button_off;
            logInRole.Text = "Customer";
            rememberMeLabel.Text = "No";
            password.PasswordChar = '\u25CF';
            errorMessage.Visible = false;
        }

        

        private void toggleSwitch_MouseClick(object sender, MouseEventArgs e)
        {
            errorMessage.Visible = false;
            if (isCustomer)
            {
                toggleSwitch.Image = Properties.Resources.toggle_button_on;
                logInRole.Text = "Employee";
                isCustomer = false;
            }
            else
            {
                toggleSwitch.Image = Properties.Resources.toggle_button_off;
                logInRole.Text = "Customer";
                isCustomer = true;            
            }

        }

        private string TryGetPhoneNumber()
        {
            string phone = phoneNumber.Text.Trim();

            if (phone.Length >= 10)
                foreach (char c in phone)
                    if (!char.IsDigit(c))
                        return null;

            return phone;
        }

        private string TryGetPassword()
        {
            if (password.Text.Length < 6)
                return null;
            return password.Text;
        }

        

        private void LaunchForm(Form form)
        {
            Thread thread = new Thread(() => Application.Run(form));
            thread.Start();
            this.Close();
        }

        private void TrySavingLogin(string phone, string password)
        {
            if (rememberedMe)
            {
                if (AuthenticatorService.SaveLogin(isCustomer, phone, password))
                    MessageBox.Show("Login Information saved successfully", "Authenticator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to save Login Information", "Authenticator", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
                AuthenticatorService.RemoveSavedLogin();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            string phone = TryGetPhoneNumber();
            string password = TryGetPassword();

            if (phone != null && password != null)
            {
                if (bUS_Authentication.LogIn(phone, password, isCustomer))
                {
                    // log in successfully
                    errorMessage.Visible = false;
                    GlobalConfigs.IsCustomer = isCustomer;
                    GlobalConfigs.PhoneNumber = phone;
                    
                    TrySavingLogin(phone, password);

                    if (isCustomer)
                        LaunchForm(new FormQLSieuThi());
                    else
                        LaunchForm(new FormQLNhanVien());
                }
                else
                {
                    ShowErrorMessage("Incorrect Phone Number or Password");
                }
            }
            else
                ShowErrorMessage("Please enter your Phone Number AND Password");

        }

        private void ShowErrorMessage(string message)
        {
            errorMessage.Visible = true;
            errorMessage.Text = message;
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void switchModeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormDangKy().Launch(this);
        }

        private void phoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
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

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

        }

        private void rememberMe_MouseClick(object sender, MouseEventArgs e)
        {
            if (!rememberedMe)
            {
                rememberMe.Image = Properties.Resources.toggle_button_on;
                rememberMeLabel.Text = "Yes";
                rememberedMe = true;
            }
            else
            {
                rememberMe.Image = Properties.Resources.toggle_button_off;
                rememberMeLabel.Text = "No";
                rememberedMe = false;
            }
        }
    }

}
