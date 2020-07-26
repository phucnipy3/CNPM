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
                var user = await ClientHelper.RegisterAsync(username, pass);
                if (user != null)
                {
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
    }
}
