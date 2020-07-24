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
        private BLUser bLUser;
        private Encryptor encryptor;

        public frmSignup()
        {
            encryptor = new Encryptor();
            bLUser = new BLUser();
            InitializeComponent();
        }

        private async void btnSignup_Click(object sender, EventArgs e)
        {
            btnSignup.Enabled = false;
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
                    if (await CheckUserAsync(username))
                    {
                        User user = new User();
                        user.UserName = username;
                        user.Password = encryptor.MD5Hash(pass);
                        user.Experience = 0;
                        user.Active = false;
                        user.Status = true;
                        user.Permission = 2; //  2 là user

                        await bLUser.SignupAsync(user);
                        // MessageBox.Show("Đăng ký thành công!");
                        frmSignin signin = new frmSignin();
                        signin.txtInputUsername.Text = username;
                        signin.txtInputPassword.Text = pass;
                        signin.btnSignin_Click(null, null);
                        
                        Close();
                       
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại!");
                    }
                }
            }
        }

        private async Task<bool> CheckUserAsync(string username)
        {
            List<User> lstAllUser = await bLUser.GetAllUserAsync();
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
