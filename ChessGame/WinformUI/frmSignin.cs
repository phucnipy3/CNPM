using Data.BusinessLogic;
using Data.Common;
using Data.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmSignin : Form
    {
        //public static string USERNAME = "";
        private BLUser bLUser;
        private Encryptor encryptor;

        public frmSignin()
        {
            encryptor = new Encryptor();
            bLUser = new BLUser();
            InitializeComponent();
        }

        public async void btnSignin_Click(object sender, EventArgs e)
        {
            btnSignin.Enabled = false;
            string username = txtInputUsername.Text.Trim().ToString();
            string pass = txtInputPassword.Text.Trim().ToString();

            if (username != "" || pass != "")
            {
                if (await bLUser.LoginAsync(username, pass) == 2)
                {
                    await bLUser.ChangeActiveAsync(username, true);
                    Constant.USERNAME = username;
                    User user = await bLUser.GetJustUserAsync(username);
                    Constant.USER_ID = user.ID;

                    Hide();
                    frmMainClient mainClient = new frmMainClient();
                    mainClient.Show();
                }

                else if (await bLUser.LoginAsync(username, pass) == 1)
                {
                    await bLUser.ChangeActiveAsync(username, true);
                    Constant.ADMINNAME = username;
                    User admin = await bLUser.GetJustUserAsync(username);
                    Constant.ADMIN_ID = admin.ID;

                    Hide();

                    frmMainAdmin mainAdmin = new frmMainAdmin();
                    mainAdmin.Show();
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

            btnSignin.Enabled = true;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            frmSignup signup = new frmSignup();
            signup.Show();
            //Close();
            Hide();
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            frmForgetPassword forgetPassword = new frmForgetPassword();
            forgetPassword.ShowDialog();
            //Hide();
        }

        private async void frmSignin_FormClosing(object sender, FormClosingEventArgs e)
        {
            await bLUser.ChangeActiveAsync(Constant.USERNAME,false);
            Application.Exit();
        }
    }
}
