using Data.BusinessLogic;
using Data.Common;
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
    public partial class frmManageAccount : Form
    {
        private BLUser bLUser;
        public frmManageAccount()
        {
            bLUser = new BLUser();
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword();
            changePassword.Show();
            Close();
        }

        //private void btnForgetPassword_Click(object sender, EventArgs e)
        //{
        //    frmForgetPassword forgetPassword = new frmForgetPassword();
        //    forgetPassword.Show();
        //    Close();
        //}

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await bLUser.ChangeActiveAsync(Constant.USERNAME, false);
            //Close();
            Application.Exit();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile();
            profile.Show();
            Close();
        }
    }
}
