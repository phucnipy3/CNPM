using Data.BusinessLogic;
using Data.Common;
using System;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmSignin : Form
    {
        public static string USERNAME = "";
        public frmSignin()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string username = txtInputUsername.Text.Trim().ToString();
            string pass = txtInputPassword.Text.Trim().ToString();

            if (username != "" || pass != "")
            {
                if (BLUser.Login(username, Encryptor.MD5Hash(pass)))
                {
                    BLUser.ChangeActive(username);
                    USERNAME = username;
                    //MessageBox.Show("Đăng nhập thành công!");
                    frmManageAccount manageAccount = new frmManageAccount();
                    manageAccount.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Làm ơn điền thông tin đầy đủ!");
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            frmSignup signup = new frmSignup();
            signup.Show();
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            frmForgetPassword forgetPassword = new frmForgetPassword();
            forgetPassword.Show();
        }
    }
}
