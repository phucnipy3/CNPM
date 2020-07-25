using Helper.Client;
using System;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmManual : Form
    {
        public frmManual()
        {
            InitializeComponent();
        }

        private async void frmManual_Load(object sender, EventArgs e)
        {
            var lstGames = await ClientHelper.GameGuideAsync();

            foreach (var game in lstGames)
            {
                rchTxtManual.AppendText(game.Name + "\n" + game.Description + "\n");
                rchTxtManual.AppendText("\n-------------------------------------------------\n");
            }
        }
    }
}
