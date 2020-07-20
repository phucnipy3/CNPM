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
    public partial class frmFeedBack : Form
    {
        private BLFeedback bLFeedback;
        public frmFeedBack()
        {
            bLFeedback = new BLFeedback();
            InitializeComponent();
        }

        private async void btnSendFeedBack_Click(object sender, EventArgs e)
        {
            btnSendFeedBack.Enabled = false;
            string email = txtInputEmail.Text.Trim().ToString();
            string content = rchTxtInputFeedBack.Text.Trim().ToString();

            Feedback feedback = new Feedback();
            feedback.UserID = Constant.USER_ID;
            feedback.Email = email;
            feedback.Content = content;
            feedback.SendTime = DateTime.Now;
            feedback.Seen = false;
            feedback.Status = true;

            if (await bLFeedback.AddFeedbackAsync(feedback))
            {
                MessageBox.Show("Gửi góp ý thành công!");
                Close();
            }
            else
            {
                MessageBox.Show("Gửi góp ý thất bại!");
                btnSendFeedBack.Enabled = true;
            }
        }
    }
}
