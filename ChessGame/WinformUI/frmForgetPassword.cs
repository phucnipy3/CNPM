using Common.SendMail;
using Data.BusinessLogic;
using Data.Common;
using Helper.Client;
using System;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmForgetPassword : Form
    {
        public frmForgetPassword()
        {
            InitializeComponent();
        }

        private async void btnGetPassword_Click(object sender, EventArgs e)
        {
            btnGetPassword.Enabled = false;
            string username = txtInputUsername.Text.Trim().ToString();

            string message = await ClientHelper.ForgetPasswordAsync(username);
            MessageBox.Show(message);
            btnGetPassword.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
