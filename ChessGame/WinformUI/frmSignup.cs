using Common.Enums;
using Common.Models;
using Helper.Client;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private async void btnSignup_Click(object sender, EventArgs e)
        {
            btnSignup.Enabled = false;
            string username = txtInputUsername.Text.Trim().ToString();
            string pass = txtInputPassword.Text.Trim().ToString();
            string confirm = txtInputConfirm.Text.Trim().ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(username))
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
                    UserModel userModel = await ClientHelper.RegisterAsync(username, pass);
                    if (userModel != null)
                    {
                        if (userModel.Permission == (int)UserRole.Player)
                        {
                            Hide();
                            frmMainClient mainClient = new frmMainClient();
                            mainClient.Show();
                        }
                        else if (userModel.Permission == (int)UserRole.Admin)
                        {
                            Hide();
                            frmMainAdmin mainAdmin = new frmMainAdmin();
                            mainAdmin.Show();
                        }
                        else MessageBox.Show("Lỗi hệ thống phân quyền!");
                        OnFormClosed(new FormClosedEventArgs(CloseReason.FormOwnerClosing));
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký không thành công!");
                    }
                }
            }
            btnSignup.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
