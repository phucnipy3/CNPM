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
            //Offsets to adjust the position of the merged Header.
            int heightOffset = -5;
            int widthOffset = -2;
            int xOffset = 0;
            int yOffset = 4;

            //Index of Header column from where the merging will start.
            int columnIndex = 2;

            //Number of Header columns to be merged.
            int columnCount = 3;

            //Get the position of the Header Cell.
            Rectangle headerCellRectangle = dgvFriends.GetCellDisplayRectangle(columnIndex, 0, true);

            //X coordinate of the merged Header Column.
            int xCord = headerCellRectangle.Location.X + xOffset;

            //Y coordinate of the merged Header Column.
            int yCord = headerCellRectangle.Location.Y - headerCellRectangle.Height + yOffset;

            //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
            int mergedHeaderWidth = dgvFriends.Columns[columnIndex].Width + dgvFriends.Columns[columnIndex + columnCount - 1].Width +  dgvFriends.Columns[columnIndex + columnCount - 2].Width + widthOffset;

            //Generate the merged Header Column Rectangle.
            Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset);

            //Draw the merged Header Column Rectangle.
            e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);

            //Draw the merged Header Column Text.
            e.Graphics.DrawString("Thao tác", dgvFriends.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 2, yCord + 3);
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            frmAddFriend addFriend = new frmAddFriend();
            addFriend.Show();
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
                User friend = await bLUser.GetJustUserAsync(dgv.Rows[row_index].Cells[3].Value.ToString());

                //MessageBox.Show(user.ID.ToString());
                int friend_ID = friend.ID;

                if (dgv.Columns[e.ColumnIndex].Name == "Action")
                {
                    MessageBox.Show("Mời");
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Message")
                {
                    Constant.FRIENDNAME = dgv.Rows[row_index].Cells[3].Value.ToString();
                    Constant.FRIEND_ID = friend_ID;
                    frmMessage message = new frmMessage();
                    message.Show();
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Delete")
                {

                    await ClientHelper.DeleteFriendshipAsync(friend_ID);
                    await LoadFriendAsync();

                }  
            }
        }

        public async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadFriendAsync();
        }

        private async void frmManageFriends_Activated(object sender, EventArgs e)
        {
            await LoadFriendAsync();
        }
    }
}
