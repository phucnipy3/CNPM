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
    public partial class frmMainClient : Form
    {
        private BLUser bLUser;
        public frmMainClient()
        {
            bLUser = new BLUser();
            InitializeComponent();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmManageAccount manageAccount = new frmManageAccount();
            manageAccount.ShowDialog();
        }

        private async void frmMainClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {

                DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    await bLUser.ChangeActiveAsync(Constant.USERNAME, false);
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            frmManual manual = new frmManual();

            manual.Show();
        }

        private void btnFriend_Click(object sender, EventArgs e)
        {
            frmManageFriends manageFriends = new frmManageFriends();
            manageFriends.Show();
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            frmRank rank = new frmRank();
            rank.Show();
        }

        private void btnFeedBack_Click(object sender, EventArgs e)
        {
            frmFeedBack feedBack = new frmFeedBack();
            feedBack.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //frmInvite invite = new frmInvite();
            //invite.Show();
        }
    }
}
