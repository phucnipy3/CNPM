using Data.BusinessLogic;
using Data.Common;
using Helper.Client;
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
    public partial class frmMainAdmin : Form
    {
        private BLUser bLUser;
        public frmMainAdmin()
        {
            bLUser = new BLUser();
            InitializeComponent();
        }

        private void btnMaintaince_Click(object sender, EventArgs e)
        {
            frmMaintaince maintaince = new frmMaintaince();
            maintaince.Show();
        }

        private void btnCreateNotify_Click(object sender, EventArgs e)
        {
            frmCreateNotify createNotify = new frmCreateNotify();
            createNotify.Show();

        }

        private void btnCheckFeedBack_Click(object sender, EventArgs e)
        {
            frmCheckFeedBack checkFeedBack = new frmCheckFeedBack();
            checkFeedBack.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUser manageUser = new frmManageUser();
            manageUser.Show();
        }

        private async void frmMainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {

                DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    await ClientHelper.LogoutAsync();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
