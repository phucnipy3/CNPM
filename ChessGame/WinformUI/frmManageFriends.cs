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
    public partial class frmManageFriends : Form
    {
        private BLFriend bLFriend;
        private BLUser bLUser;
        public frmManageFriends()
        {
            bLUser = new BLUser();
            bLFriend = new BLFriend();
            InitializeComponent();
        }

        private async void frmManageFriends_Load(object sender, EventArgs e)
        {
            await LoadFriendAsync();
        }

        private async Task LoadFriendAsync()
        {
            List<Friend> lstFriends = await ClientHelper.GetListFriendAsync();
            dgvFriends.DataSource = lstFriends;
        }
        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
            int heightOffset = -3;
            int widthOffset = 0;
            int xOffset = 0;
            int yOffset = 0;

            int columnIndex = 0;

            int columnCount = 3;

            Rectangle headerCellRectangle = dgvFriends.GetCellDisplayRectangle(columnIndex, -1, true);

            int xCord = headerCellRectangle.Location.X + xOffset;

            int yCord = headerCellRectangle.Location.Y + yOffset;

            int mergedHeaderWidth = dgvFriends.Columns[columnIndex].Width + dgvFriends.Columns[columnIndex + columnCount - 1].Width + dgvFriends.Columns[columnIndex + columnCount - 2].Width + widthOffset;

            Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset);

            e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);

            e.Graphics.DrawString("Thao tác", dgvFriends.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 2, yCord + 3);
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            frmAddFriend addFriend = new frmAddFriend();
            if (addFriend.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Gửi lời mời kết bạn thành công!");
                frmManageFriends_Load(this, null);
            }    

            
        }

        private void dgvFriends_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void dgvFriends_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            int row_index = e.RowIndex;
            if (row_index != -1)
            {
               
                int friend_ID = int.Parse(dgv.Rows[row_index].Cells["ID"].Value.ToString());
                string opponentName = dgv.Rows[row_index].Cells["Ingame"].Value.ToString();
                if (dgv.Columns[e.ColumnIndex].Name == "Action")
                {
                    MessageModel message = await ClientHelper.InvitePlayAsync(opponentName);
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
                else if (dgv.Columns[e.ColumnIndex].Name == "Message")
                {
                    Constant.FRIENDNAME = dgv.Rows[row_index].Cells["Ingame"].Value.ToString();
                    Constant.FRIEND_ID = friend_ID;
                    frmMessage message = new frmMessage();
                    message.Show();
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Delete")
                {

                    var result = MessageBox.Show("Bạn có muôn xóa người bạn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        await ClientHelper.DeleteFriendshipAsync(friend_ID);
                        await LoadFriendAsync();
                    }    
                    


                }  
            }
        }

        public async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadFriendAsync();
        }

        private async void frmManageFriends_Activated(object sender, EventArgs e)
        {
            //await LoadFriendAsync();
        }
    }
}
