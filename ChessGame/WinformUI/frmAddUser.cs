using Data.BusinessLogic;
using Data.Common;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmAddUser : Form
    {
        private BLUser bLUser;
        public frmAddUser()
        {
            bLUser = new BLUser();
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            string username = txtInputUsername.Text.Trim().ToString();
            string pass = txtInputPassword.Text.Trim().ToString();


            if (username == "" || pass == "")
            {
                btnAdd.Enabled = true;
                MessageBox.Show("Làm ơn điền thông tin đầy đủ!");
            }
            else
            {

                if (await CheckUserAsync(username))
                {
                    User user = new User();
                    user.Username = username;
                    user.Password = Encryptor.MD5Hash(pass);
                    user.Experience = 0;
                    user.Active = false;
                    user.Status = true;
                    user.Permission = 2;

                    await bLUser.SignupAsync(user);
                    MessageBox.Show("Đăng ký thành công!");

                    Close();
                }
                else
                {
                    btnAdd.Enabled = true;
                    MessageBox.Show("Tên tài khoản đã tồn tại!");
                }

            }
        }

        private async Task<bool> CheckUserAsync(string username)
        {
            List<User> lstAllUser = await BLUser.GetAllUserAsync();
            for (int i = 0; i < lstAllUser.Count; i++)
            {
                if (username == lstAllUser[i].Username)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
