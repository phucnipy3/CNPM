using Data.BusinessLogic;
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
    public partial class frmCreateNotify : Form
    {
        private BLNotification bLNotification;
        public frmCreateNotify()
        {
            bLNotification = new BLNotification();
            InitializeComponent();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            string content = rchTxtInputNotify.Text.Trim().ToString();
            string timeBegin = dateStart.Text.Trim().ToString();
            string timeEnd = dateEnd.Text.Trim().ToString();

            if (content == "")
            {
                MessageBox.Show("Điền nội dung thông báo!");
                btnConfirm.Enabled = true;
            }
            else
            {
                Notification notification = new Notification();
                notification.Content = content;
                notification.TimeBegin = DateTime.Parse(timeBegin);
                notification.TimeEnd = DateTime.Parse(timeEnd);
                notification.Status = true;

                await ClientHelper.AddNotificationAsync(notification);
                MessageBox.Show("Đã cập nhật thông báo!");
                Close();
            }
        }
    }
}
