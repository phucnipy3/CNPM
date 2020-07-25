using Common.Enums;
using Common.Models;
using Helper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmPickGame : Form
    {
        private int gameId = (int)GameType.Caro;
        List<RoomModel> rooms;

        public frmPickGame()
        {
            InitializeComponent();
        }

        private async void frmPickGame_Load(object sender, EventArgs e)
        {
            rooms = await ClientHelper.GetRoomsAsync(gameId);
            if (rooms.Count > 0)
                dgvRoom.DataSource = rooms.Select(x => new {
                    Id = x.RoomId,
                    Status = GetStatus(x),
                    Action = true
                }).ToList();
        }

        private string GetStatus(RoomModel room)
        {
            if (room.FirstPlayerId.HasValue && room.SecondPlayerId.HasValue)
                return "Playing...";
            if (room.FirstPlayerId.HasValue || room.SecondPlayerId.HasValue)
                return "Waiting second player...";
            return "No action";
        }
    }
}
