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
    public partial class frmInvite : Form
    {
        private BLUser bLUser;
        public frmInvite()
        {
            bLUser = new BLUser();
            InitializeComponent();
        }

        private async void frmInvite_Load(object sender, EventArgs e)
        {
            List<InviteUser> lstUsers = await bLUser.InviteUserAsync(Constant.USER_ID);
            dgvInvite.DataSource = lstUsers;
        }

        private async void dgvInvite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            int row_index = e.RowIndex;
            if (row_index != -1)
            {
                User user = await bLUser.GetJustUserAsync(dgv.Rows[row_index].Cells[1].Value.ToString());

                //MessageBox.Show(user.ID.ToString());

                if (dgv.Columns[e.ColumnIndex].Name == "Action")
                {
                    MessageBox.Show("Mời tài khoản " + user.UserName);
                }
               
            }
        }

        private void dgvInvite_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
