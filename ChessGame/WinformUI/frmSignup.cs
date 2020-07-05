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
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtInputUsername.Text.Trim().ToString();
            string pass = txtInputPassword.Text.Trim().ToString();
            string confirm = txtInputConfirm.Text.Trim().ToString();

            if (username == "" || pass == "" || confirm == "")
            {
                MessageBox.Show("Làm ơn điền thông tin đầy đủ!");
            }
            else
            {
                if (pass != confirm)
                {
                    MessageBox.Show("Xác nhận mật khẩu không chính xác!");
                }
                else
                {
                    if (CheckUser(username))
                    {
                        User user = new User();
                        user.UserName = username;
                        user.Password = Encryptor.MD5Hash(pass);
                        user.Experience = 0;
                        user.Active = false;
                        user.Status = true;

                        BLUser.Signup(user);
                        MessageBox.Show("Đăng ký thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại!");
                    }
                }
            }
        }

        private bool CheckUser(string username)
        {
            List<User> lstAllUser = BLUser.GetAllUser();
            for (int i = 0; i < lstAllUser.Count; i++)
            {
                if (username == lstAllUser[i].UserName)
                {
                    return false;
                }
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
