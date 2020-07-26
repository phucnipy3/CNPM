using Common.Constants;
using Common.Enums;
using Common.FormInterfaces;
using Common.Models;
using GameEngine.Client;
using Helper.Client;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmPlayGame : Form, IPlayGameForm
    {
        private RoomInfomationModel roomInfo;
        private CaroClient caroClient;
        private int counter = 0;
        private bool isFirstPlayer = true;

        public frmPlayGame(RoomInfomationModel roomInfo)
        {
            InitializeComponent();
            RefreshCurrentRoom(roomInfo);

            Cursor cur = new Cursor(Properties.Resources.pencil.Handle);
            ptbPlayGround.Cursor = cur;

        }

        private void CaroClient_BoardUpdated(object sender, BoardUpdatedEventArgs e)
        {
            ptbPlayGround.Image = e.BoardImage;

            Cursor cur = new Cursor(Properties.Resources.pencil.Handle);
            ptbPlayGround.Cursor = cur;
        }

        private void frmPlayGame_Load(object sender, EventArgs e)
        {
            int userId = ClientHelper.Client.User.Id;
            if (roomInfo.FirstPlayer != null && roomInfo.FirstPlayer.Id == userId)
            {
                lblPlayerName.Text = roomInfo.FirstPlayer.Name;
                ChangeReady(roomInfo.FirstPlayerReady);
                if (roomInfo.Count == 2)
                    lblOpponentName.Text = roomInfo.SecondPlayer.Name;
            }
            else if (roomInfo.SecondPlayer != null && roomInfo.SecondPlayer.Id == userId)
            {
                lblPlayerName.Text = roomInfo.SecondPlayer.Name;
                isFirstPlayer = false;
                ChangeReady(roomInfo.SecondPlayerReady);
                if (roomInfo.Count == 2)
                    lblOpponentName.Text = roomInfo.FirstPlayer.Name;
            }
        }

        public void RefreshCurrentRoom(RoomInfomationModel roomInfo)
        {
            this.roomInfo = roomInfo;
            btnReady.Enabled = !roomInfo.IsInGame;
            btnInvite.Enabled = roomInfo.Count < 2;
            frmPlayGame_Load(this, null);
        }


        private void ptbPlayGround_MouseClick(object sender, MouseEventArgs e)
        {
            Cursor cur = new Cursor(Properties.Resources.pencil.Handle);
            ptbPlayGround.Cursor = cur;

            ClientHelper.MakeMove(e.Location, cur);

        }

        private async void btnReady_Click(object sender, EventArgs e)
        {
            await ClientHelper.ChangeReadyStateAsync(roomInfo.RoomId);
        }

        private void ChangeReady(bool ready)
        {
            if (ready)
                btnReady.Text = "Hủy bỏ";
            else btnReady.Text = "Sẵn sàng";
        }

        private async void frmPlayGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                if (roomInfo.IsInGame)
                {
                    DialogResult result = MessageBox.Show("Trận đấu chưa kết thúc. Bạn sẽ bị xử thua?", "Thoát", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        await ClientHelper.OutRoom(roomInfo.RoomId);
                    else e.Cancel = true;
                }
                else await ClientHelper.OutRoom(roomInfo.RoomId);
            }
        }
    }
}
