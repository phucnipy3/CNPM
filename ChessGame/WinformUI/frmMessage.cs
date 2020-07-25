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
            Data.Entities.Message message = new Data.Entities.Message();
            message.SenderId = Constant.USER_ID;
            message.ReceiverId = Constant.FRIEND_ID;
            message.Content = txtInputMessage.Text.Trim().ToString();
            message.SendTime = DateTime.Now;

            if (await bLMesssage.AddMessageAsync(message))
            {
                MessageBox.Show("Gửi thành công!");
                Close();
            }
            else
            {
                MessageBox.Show("Gửi thất bại!");

                btnSendMessage.Enabled = true;
            }
            
        }
    }
}
