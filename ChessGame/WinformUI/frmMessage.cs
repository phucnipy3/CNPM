using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Data.Common;
using Data.BusinessLogic;
using Common.Models;
using Helper.Client;
using Common.Enums;

namespace WinformUI
{
    public partial class frmMessage : Form
    {
        private BLMesssage bLMesssage;
        public frmMessage()
        {
            bLMesssage = new BLMesssage();
            InitializeComponent();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            btnSendMessage.Enabled = false;
            SendMessageModel sendMessage = new SendMessageModel();
            sendMessage.SenderName = ClientHelper.Client.User.Username; ;
            sendMessage.ReceiverName = Constant.FRIENDNAME;
            sendMessage.Content = txtInputMessage.Text.Trim().ToString();

            var message = await ClientHelper.AddMessageAsync(sendMessage);
            if (message.Code == (int)MessageCode.Success)
            {
                MessageBox.Show("Gửi thành công!");
                Close();
            }
            else if (message.Code == (int)MessageCode.Error)
            {
                MessageBox.Show("Gửi thất bại!");

                btnSendMessage.Enabled = true;
            }
            
        }
    }
}
