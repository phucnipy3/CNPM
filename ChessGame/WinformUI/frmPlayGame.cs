using Common.Constants;
using Common.Enums;
using Common.FormInterfaces;
using Common.Models;
using GameEngine.Client;
using Helper.Client;
using System.Drawing;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmPlayGame : Form, IPlayGameForm
    {
        private RoomInfomationModel roomInfo;

        private CaroClient caroClient;

        private int counter = 0;

        public frmPlayGame(RoomInfomationModel roomInfo)
        {
            this.roomInfo = roomInfo;
            InitializeComponent();

            caroClient = new CaroClient(ptbPlayGround.Width, ptbPlayGround.Height, CaroChessman.O);
            ptbPlayGround.Image = caroClient.BoardImage;
            caroClient.BoardUpdated += CaroClient_BoardUpdated;

            Cursor cur = new Cursor(Properties.Resources.pencil.Handle);
            ptbPlayGround.Cursor = cur;

        }

        private void CaroClient_BoardUpdated(object sender, BoardUpdatedEventArgs e)
        {
            ptbPlayGround.Image = e.BoardImage;

            Cursor cur = new Cursor(Properties.Resources.pencil.Handle);
            ptbPlayGround.Cursor = cur;
        }

        private void frmPlayGame_Load(object sender, System.EventArgs e)
        {
            int userId = ClientHelper.Client.User.Id;
            if (roomInfo.FirstPlayer != null && roomInfo.FirstPlayer.Id == userId)
            {
                lblPlayerName.Text = roomInfo.FirstPlayer.Name;
                if (roomInfo.Count == 2)
                    lblOpponentName.Text = roomInfo.SecondPlayer.Name;
            }
            else if (roomInfo.SecondPlayer != null && roomInfo.SecondPlayer.Id == userId)
            {
                lblPlayerName.Text = roomInfo.SecondPlayer.Name;
                if (roomInfo.Count == 2)
                    lblOpponentName.Text = roomInfo.FirstPlayer.Name;
            }
        }

        public void RefreshCurrentRoom(RoomInfomationModel roomInfo)
        {
            this.roomInfo = roomInfo;
            frmPlayGame_Load(this, null);
        }


        private void ptbPlayGround_MouseClick(object sender, MouseEventArgs e)
        {
            Cursor cur = new Cursor(Properties.Resources.pencil.Handle);
            ptbPlayGround.Cursor = cur;

            ClientHelper.MakeMove(e.Location, cur);

        }
    }
}
