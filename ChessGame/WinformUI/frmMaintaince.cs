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
    public partial class frmMaintaince : Form
    {
        private BLMaintaince bLMaintaince;
        public frmMaintaince()
        {
            bLMaintaince = new BLMaintaince();
            InitializeComponent();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            string startTime = dateStart.Text.Trim().ToString();
            string endTime = dateEnd.Text.Trim().ToString();

            MaintainceInfomation maintaince = new MaintainceInfomation();
            maintaince.Content = "Bảo trì !";
            maintaince.StartTime = DateTime.Parse(startTime);
            maintaince.EndTime = DateTime.Parse(endTime);
            maintaince.Status = true;

            if (await bLMaintaince.AddMaintainceAsync(maintaince))
            {
                MessageBox.Show("Thành công!");
                Close();
            }
            else
            {
                MessageBox.Show("Thất bại!");
                btnConfirm.Enabled = true;
            }

        }
    }
}
