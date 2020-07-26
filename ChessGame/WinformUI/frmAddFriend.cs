using Common.Enums;
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
    public partial class frmAddFriend : Form
    {
        private BLUser bLUser;
        private BLFriend bLFriend;
        public frmAddFriend()
        {
            bLUser = new BLUser();
            bLFriend = new BLFriend();
            InitializeComponent();
        }

        private void frmAddFriend_Load(object sender, EventArgs e)
        {

        }

        private async void btnAddFriend_Click(object sender, EventArgs e)
        {
            string friendName = txtInputIngame.Text.Trim().ToString();
            MessageModel message = await ClientHelper.AddFriendAsync(friendName);
            if (message.Code == (int)MessageCode.Success)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else if (message.Code == (int)MessageCode.Error)
            {
                MessageBox.Show(message.Data.ToString());
            }
        }
    }
}
