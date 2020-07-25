using Common.Enums;
using Common.Models;
using Data.BusinessLogic;
using Data.Common;
using Data.Entities;
using Helper.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmChangePassword : Form
    {
        private BLUser bLUser;
        public frmChangePassword()
        {
            bLUser = new BLUser();
            InitializeComponent();
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            btnChange.Enabled = false;
            string oldpass = txtInputOld.Text.Trim().ToString();
            string newpass = txtInputNew.Text.Trim().ToString();
            string confirm = txtInputConfirm.Text.Trim().ToString();

            if (string.IsNullOrEmpty(oldpass) || string.IsNullOrEmpty(newpass) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Làm ơn điền thông tin đầy đủ!");
            }
            else
            {
                if (newpass == confirm)
                {
                    MessageModel messageModel = await ClientHelper.ChangePasswordAsync(oldpass, newpass);
                    if (messageModel.Code == (int)MessageCode.Success)
                        Close();
                    MessageBox.Show(messageModel.Data.ToString());
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu không chính xác!");
                }
            }
            btnChange.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
