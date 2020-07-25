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
    public partial class frmRank : Form
    {
        private BLGame bLGame;
        private BLElo bLElo;
        public frmRank()
        {
            bLElo = new BLElo();
            bLGame = new BLGame();

            InitializeComponent();
        }

        private async void frmRank_Load(object sender, EventArgs e)
        {
            var lstGame = await bLGame.GetGamesAsync();
            cmbGames.DataSource = lstGame;
            cmbGames.DisplayMember = "Name";
            cmbGames.ValueMember = "Name";
            cmbGames.Text = lstGame[0].Name.ToString();

            await LoadDataAsync(cmbGames.Text.Trim().ToString());
        }


        private async Task LoadDataAsync(string name)
        {
            Game game = await bLGame.GetJustGameByNameAsync(name);
            int id = game.ID;

            List<RankTable> lstRank = await bLElo.GetRankTableAsync(id);

            dgvRank.DataSource = lstRank;
        }

        private async void cmbGames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;

            if (senderComboBox.SelectionLength > 0)
            {
                string name = senderComboBox.GetItemText(senderComboBox.SelectedItem);
                await LoadDataAsync(name);
            }
        }
    }
}
