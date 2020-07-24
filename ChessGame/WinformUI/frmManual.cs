using Data.BusinessLogic;
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
    public partial class frmManual : Form
    {
        private BLGame bLGame;
        public frmManual()
        {
            bLGame = new BLGame();
            InitializeComponent();
        }

        private async void frmManual_Load(object sender, EventArgs e)
        {
            List<Game> lstGames = await bLGame.GetAllGameAsync();
            for (int i =0; i < lstGames.Count; i ++)
            {
                rchTxtManual.Text += lstGames[i].Name;
                rchTxtManual.Text += "\n";
                rchTxtManual.Text += lstGames[i].Describe;
                rchTxtManual.Text += "\n";
            }
        }
    }
}
