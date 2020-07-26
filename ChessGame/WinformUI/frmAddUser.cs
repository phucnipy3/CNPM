using Common.Models;
using Data.BusinessLogic;
using Data.Common;
using Data.Entities;
using Helper.Client;
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
                    await ClientHelper.RegisterAsync(username, pass);
                    MessageBox.Show("Đăng ký thành công!");

                    DialogResult = DialogResult.OK;
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
            List<UserModel> lstAllUser = await ClientHelper.GetAllManageUserAsync();
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
