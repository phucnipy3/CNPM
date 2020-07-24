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
    public partial class frmProfile : Form
    {
        private BLUser bLUser;

        public frmProfile()
        {
            bLUser = new BLUser();
            InitializeComponent();
        }

        private async void frmProfile_Load(object sender, EventArgs e)
        {
            User user = await bLUser.GetJustUserAsync(Constant.USERNAME);
            lblIngame.Text = user.UserName.Trim().ToString();
            lblname.Text = user.Name.Trim().ToString();
            lblPhone.Text = user.Phone.Trim().ToString();
            lblExperince.Text = user.Experience.ToString();
            lblEmail.Text = user.Email.Trim().ToString();
        }
    }
}
