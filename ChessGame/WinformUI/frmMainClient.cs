using Common.FormInterfaces;
using Common.Models;
using Helper.Client;
using System;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmMainClient : Form, IPlayGame
    {
        private bool loggingOut = false;

        public frmMainClient()
        {
            InitializeComponent();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmManageAccount manageAccount = new frmManageAccount();
            if (manageAccount.ShowDialog() == DialogResult.Abort)
            {
                loggingOut = true;
                Close();
            }
        }

        private async void frmMainClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loggingOut && e.CloseReason != CloseReason.ApplicationExitCall)
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

        private void btnManual_Click(object sender, EventArgs e)
        {
            frmManual manual = new frmManual();
            manual.ShowDialog();
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
            frmPickGame frmPickGame = new frmPickGame();
            Hide();
            frmPickGame.FormClosed += FrmPickGame_FormClosed;
            frmPickGame.Show();
        }

        private void FrmPickGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        public void PlayGame(RoomInfomationModel roomInfo)
        {
            if (roomInfo != null)
            {
                frmPlayGame frmPlayGame = new frmPlayGame(roomInfo);
                frmPlayGame.FormClosed += FrmPlayGame_FormClosed;
                Hide();
                frmPlayGame.Show();
            }
            else MessageBox.Show("Lỗi không xác định! Vui lòng thử lại");
        }

        private void FrmPlayGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}
