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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
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
                    if (Encryptor.MD5Hash(oldpass) == BLUser.GetJustUser(frmSignin.USERNAME).Password)
                    {
                        BLUser.ChangePassword(frmSignin.USERNAME, Encryptor.MD5Hash(newpass));
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
