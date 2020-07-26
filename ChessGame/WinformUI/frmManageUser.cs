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
    public partial class frmManageUser : Form
    {
        public frmManageUser()
        {
            InitializeComponent();
        }

        private void dgvUser_Paint(object sender, PaintEventArgs e)
        {
            int heightOffset = -3;
            int widthOffset = 0;
            int xOffset = 0;
            int yOffset = 0;

            int columnIndex = 0;

            int columnCount = 3;

            Rectangle headerCellRectangle = dgvUser.GetCellDisplayRectangle(columnIndex, -1, true);

            int xCord = headerCellRectangle.Location.X + xOffset;

            int yCord = headerCellRectangle.Location.Y + yOffset;

            int mergedHeaderWidth = dgvUser.Columns[columnIndex].Width + dgvUser.Columns[columnIndex + columnCount - 1].Width + dgvUser.Columns[columnIndex + columnCount - 2].Width + widthOffset;

            Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset);

            e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);

            e.Graphics.DrawString("Thao tác", dgvUser.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 2, yCord + 3);
        }

        private async void frmManageUser_Load(object sender, EventArgs e)
        {
            List<ManagerUser> managerUsers = await ClientHelper.GetManagerUserAsync();
            dgvUser.DataSource = managerUsers;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUser frmAddUser = new frmAddUser();
            
            if (frmAddUser.ShowDialog() == DialogResult.OK)
            {
                frmManageUser_Load(this, null);
            }
        }

        private async void frmManageUser_Activated(object sender, EventArgs e)
        {
            //List<ManagerUser> managerUsers = await ClientHelper.GetManagerUserAsync(ClientHelper.Client.User.Id);
            //dgvUser.DataSource = managerUsers;
        }

        private async void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            int row_index = e.RowIndex;
            if (row_index != -1)
            {
                if (dgv.Columns[e.ColumnIndex].Name == "Lock")
                {
                    string Status = dgv.Rows[row_index].Cells["Status"].Value.ToString();
                    string userName = dgv.Rows[row_index].Cells["Ingame"].Value.ToString();
                    bool status;
                    if (Status == "True")
                    {
                        status = false;
                    }
                    else
                    {
                        status = true;
                    }
                    
                    var changeStatus = await ClientHelper.ChangeStatusAsync(userName, status);
                    if (changeStatus.Code == (int)MessageCode.Success)
                    {
                        if (status)
                        {
                            MessageBox.Show("Bạn vừa mở tài khoản " + userName);
                        }
                        else
                        {
                            MessageBox.Show("Bạn vừa khóa tài khoản " + userName);
                        }
                        frmManageUser_Load(this, null);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi không xác định!");
                    }
                    
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Logout")
                {
                    string id = dgv.Rows[row_index].Cells["Id"].Value.ToString();
                    string userName = dgv.Rows[row_index].Cells["Ingame"].Value.ToString();
                    MessageModel message = await ClientHelper.ForceLogout(id);
                    if (message.Code == (int)MessageCode.Success)
                    {
                        MessageBox.Show("Tài khoản " + userName + " đã đăng xuất!");
                    }
                    else if (message.Code == (int)MessageCode.Error)
                    {
                        MessageBox.Show(message.Data.ToString());
                    }
                }
            }
        }
    }
}
