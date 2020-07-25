using Helper.Client;
using System;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmManageAccount : Form
    {
        public frmManageAccount()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword();
            Hide();
            changePassword.ShowDialog();
            Close();
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await ClientHelper.LogoutAsync();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile();
            profile.Show();
            Close();
        }
    }
}
