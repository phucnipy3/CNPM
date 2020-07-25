using Common.FormInterfaces;
using Common.Models;
using Helper.Client;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmPlayGame : Form, IPlayGameForm
    {
        private RoomInfomationModel roomInfo;

        public frmPlayGame(RoomInfomationModel roomInfo)
        {
            this.roomInfo = roomInfo;
            InitializeComponent();
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
    }
}
