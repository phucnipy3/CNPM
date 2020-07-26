using Common.Models;
using Data.BusinessLogic;
using Data.Common;
using Data.Entities;
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
            var lstGame = await ClientHelper.GetGameAsync();
            cmbGames.DisplayMember = "Name";
            cmbGames.ValueMember = "Id";
            cmbGames.DataSource = lstGame;

            await LoadDataAsync(int.Parse(cmbGames.SelectedValue.ToString()));
        }


        private async Task LoadDataAsync(int GameId)
        {
            RankConditionModel rankCondition = new RankConditionModel();
            rankCondition.GameId = GameId;
            rankCondition.UserId = ClientHelper.Client.User.Id;

            List<RankTable> lstRank = await ClientHelper.GetRankAsync(rankCondition);
            if (lstRank != null)
            {
                for (int i = 0; i < lstRank.Count; i++)
                {
                    if (i > 9)
                    {
                        lstRank[i].Rank = "10+";
                    }
                    lstRank[i].Rank = (i+1).ToString();
                }


                dgvRank.DataSource = lstRank;

                foreach (DataGridViewRow row in dgvRank.Rows)
                {
                    if (row.Cells["Id"].Value.ToString() == rankCondition.UserId.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.SkyBlue;
                        row.DefaultCellStyle.ForeColor = Color.Black;

                    }
                }
            }
            else
            {
                dgvRank.DataSource = new List<RankTable>(); 
            }
               
        }

        private async void cmbGames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ComboBox senderComboBox = (ComboBox)sender;

            //if (senderComboBox.SelectionLength > 0)
            //{
            //    int Id = int.Parse(senderComboBox.SelectedValue.ToString());
            //    await LoadDataAsync(Id);
            //}
        }

        private void dgvRank_SelectionChanged(object sender, EventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }

        private async void cmbGames_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;

            if (senderComboBox.SelectedValue != null)
            {
                int Id = int.Parse(senderComboBox.SelectedValue.ToString());
                await LoadDataAsync(Id);
            }
        }

        private void cmbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
