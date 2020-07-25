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
            string friend_name = txtInputIngame.Text.Trim().ToString();
            if (await bLUser.Exists(friend_name))
            {
               
                User friend = await bLUser.GetJustUserAsync(friend_name);
                if (! await bLFriend.ExistsFriendship(Constant.USER_ID, friend.Id))
                {
                    Friendship friendship = new Friendship();
                    friendship.UserId = Constant.USER_ID;
                    friendship.FriendId = friend.Id;
                    friendship.AddTime = DateTime.Now;

                    await bLFriend.AddFriendAsync(friendship);

                    MessageBox.Show("Kết bạn thành công!");


                    frmManageFriends manageFriends = new frmManageFriends();
                    manageFriends.btnRefresh_Click(null, null);

                    Close();
                }
                
            }
            else
            {
                MessageBox.Show("Kết bạn thất bại!");
            }
        }
    }
}
