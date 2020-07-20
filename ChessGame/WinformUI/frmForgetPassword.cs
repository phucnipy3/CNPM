using Data.BusinessLogic;
using Data.Common;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmForgetPassword : Form
    {
        private BLUser bLUser;
        private SendEmail sendEmail;
        private Encryptor encryptor;
        public frmForgetPassword()
        {
            encryptor = new Encryptor();
            sendEmail = new SendEmail();
            bLUser = new BLUser();
            InitializeComponent();
        }

        private async void btnGetPassword_Click(object sender, EventArgs e)
        {
            btnGetPassword.Enabled = false;
            string username = txtInputUsername.Text.Trim().ToString();

            if (await ForgotPasswordAsync(username))
            {
                MessageBox.Show("Kiểm tra email để lấy lại mật khẩu!");
                Close();
            }
            else
            {
                
                btnGetPassword.Enabled = true;
            }
            
        }

        private async Task<bool> ForgotPasswordAsync(string username)
        {

            string pass = Random(8);
            if (await bLUser.Exists(username))
            {
                User user = await bLUser.GetJustUserAsync(username);
                string email = user.Email;
                if (await sendEmail.SendEmailAsync(email, pass.ToString()))
                {

                    //MessageBox.Show("Kiểm tra email để lấy lại mật khẩu!");
                    await bLUser.ChangePasswordAsync(username, encryptor.MD5Hash(pass.ToString()));
                    return true;
                }
                else
                {
                    MessageBox.Show("Tạm thời không thể gửi mail!");
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại tài khoản!");
            }

            return false;
        }

        public string Random(int lenght)
        {
            string res = "";
            Random random = new Random();
            while (lenght > 0)
            {
                char key = (char) random.Next(48, 123);
                if (Char.IsLetterOrDigit(key))
                {
                    res += key;
                    lenght--;
                }
            }
            return res;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
