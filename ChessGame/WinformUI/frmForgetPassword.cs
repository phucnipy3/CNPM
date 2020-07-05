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
        public frmForgetPassword()
        {
            InitializeComponent();
        }

        private void btnGetPassword_Click(object sender, EventArgs e)
        {
            string username = txtInputUsername.Text.Trim().ToString();

            if (ForgotPassword(username))
            {
                MessageBox.Show("Kiểm tra email để lấy lại mật khẩu!");
                Close();
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
        }

        private bool ForgotPassword(string username)
        {
            List<User> lstUser = BLUser.GetAllUser();
            for (int i = 0; i < lstUser.Count; i++)
            {
                Random random = new Random();
                //byte[] ch = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
                int pass = random.Next(10000000, 99999999);
                if (username == lstUser[i].UserName)
                {
                    if (SendEmail.Send_Email(lstUser[i].Email, pass.ToString()))
                    {
                        //MessageBox.Show("Kiểm tra email để lấy lại mật khẩu!");
                        BLUser.ChangePassword(username, Encryptor.MD5Hash(pass.ToString()));
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
