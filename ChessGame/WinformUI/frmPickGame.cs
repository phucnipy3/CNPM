using Common.Enums;
using Common.FormInterfaces;
using Common.Models;
using Helper.Client;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmPickGame : Form, IPickGameForm
    {
        private int gameId = (int)GameType.Caro;
        private List<RoomInfomationModel> rooms;
        private string search = "";

        public frmPickGame()
        {
            InitializeComponent();
        }

        private async void frmPickGame_Load(object sender, EventArgs e)
        {
            rooms = await ClientHelper.GetRoomsAsync(gameId, search);

            if (rooms != null)
                dgvRoom.DataSource = rooms.Select(x => new
                {
                    Id = x.RoomId,
                    Status = GetStatus(x)
                }).ToList();
        }

        private string GetStatus(RoomInfomationModel room)
        {
            if (room.Count == 2)
                return "Playing...";
            if (room.Count == 1)
                return "Waiting second player...";
            return "No action";
        }

        private void txtInputSearchRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search = (sender as TextBox).Text;
                frmPickGame_Load(this, null);
            }
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            gameId = int.Parse((sender as Button).Tag.ToString());
            frmPickGame_Load(this, null);
        }

        private async void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var dgv = sender as DataGridView;
                if (dgv.Columns[e.ColumnIndex].Name == "Action")
                {
                    var roomId = int.Parse(dgv.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    var roomInfo = await ClientHelper.JoinRoom(roomId);
                    PlayGame(roomInfo);
                }
            }
        }

        private async void btnNewRoom_Click(object sender, EventArgs e)
        {
            var roomInfo = await ClientHelper.CreateRoom(gameId);
            PlayGame(roomInfo);
        }

        private void FrmPlayGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
            frmPickGame_Load(this, null);
        }

        private void PlayGame(RoomInfomationModel roomInfo)
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

        public void RefreshRooms()
        {
            frmPickGame_Load(this, null);
        }
    }
}
