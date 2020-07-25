using Common.Enums;
using Helper.Client;
using System;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmSignin : Form
    {
        public frmSignin()
        {
            InitializeComponent();
        }

        public async void btnSignin_Click(object sender, EventArgs e)
        {
            btnSignin.Enabled = false;
            string username = txtInputUsername.Text.Trim().ToString();
            string pass = txtInputPassword.Text.Trim().ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Làm ơn điền thông tin đầy đủ!");
                btnSignin.Enabled = true;
                return;
            }

            var user = await ClientHelper.LoginAsync(username, pass);
            if (user == null)
                MessageBox.Show("Đăng nhập thất bại!");
            else
            {
                if (user.Permission == (int)UserRole.Player)
                {
                    Hide();
                    frmMainClient mainClient = new frmMainClient();
                    mainClient.FormClosed += FormChild_FormClosed;
                    mainClient.Show();
                }
                else if (user.Permission == (int)UserRole.Admin)
                {
                    Hide();
                    frmMainAdmin mainAdmin = new frmMainAdmin();
                    mainAdmin.FormClosed += FormChild_FormClosed;
                    mainAdmin.Show();
                }
                else MessageBox.Show("Lỗi hệ thống phân quyền!");
            }
            btnSignin.Enabled = true;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Hide();
            frmSignup signup = new frmSignup();
            signup.FormClosed += FormChild_FormClosed;
            signup.Show();
        }

        private void FormChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
                Show();
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            frmForgetPassword forgetPassword = new frmForgetPassword();
            forgetPassword.ShowDialog();
        }

        private async void frmSignin_FormClosing(object sender, FormClosingEventArgs e)
        {
            await ClientHelper.LogoutAsync();
            Application.Exit();
        }
    }
}
