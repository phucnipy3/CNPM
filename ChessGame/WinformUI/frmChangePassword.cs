using Data.BusinessLogic;
using Data.Common;
using Data.Entities;
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
    public partial class frmChangePassword : Form
    {
        private BLUser bLUser;
        private Encryptor encryptor;
        public frmChangePassword()
        {
            encryptor = new Encryptor();
            bLUser = new BLUser();
            InitializeComponent();
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            btnChange.Enabled = false;
            string oldpass = txtInputOld.Text.Trim().ToString();
            string newpass = txtInputNew.Text.Trim().ToString();
            string confirm = txtInputConfirm.Text.Trim().ToString();

            if (oldpass == "" || newpass == "" || confirm == "")
            {
                MessageBox.Show("Làm ơn điền thông tin đầy đủ!");
                
            }
            else
            {
                if (newpass == confirm)
                {
                    string passEncrypt = await Task.Run(() => encryptor.MD5Hash(oldpass));
                    User user = await bLUser.GetJustUserAsync(Constant.USERNAME);
                    if (passEncrypt == user.Password)
                    {
                        await bLUser.ChangePasswordAsync(Constant.USERNAME, encryptor.MD5Hash(newpass));
                        //MessageBox.Show("Đổi mật khẩu thành công!");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không trùng khớp!");
                    }
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
