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
            //Offsets to adjust the position of the merged Header.
            int heightOffset = -5;
            int widthOffset = -2;
            int xOffset = 0;
            int yOffset = 4;

            //Index of Header column from where the merging will start.
            int columnIndex = 2;

            //Number of Header columns to be merged.
            int columnCount = 2;

            //Get the position of the Header Cell.
            Rectangle headerCellRectangle = dgvUser.GetCellDisplayRectangle(columnIndex, 0, true);

            //X coordinate of the merged Header Column.
            int xCord = headerCellRectangle.Location.X + xOffset;

            //Y coordinate of the merged Header Column.
            int yCord = headerCellRectangle.Location.Y - headerCellRectangle.Height + yOffset;

            //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
            int mergedHeaderWidth = dgvUser.Columns[columnIndex].Width + dgvUser.Columns[columnIndex + columnCount - 1].Width + widthOffset;

            //Generate the merged Header Column Rectangle.
            Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset);

            //Draw the merged Header Column Rectangle.
            e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);

            //Draw the merged Header Column Text.
            e.Graphics.DrawString("Thao tác", dgvUser.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 2, yCord + 3);
        }
    }
}
