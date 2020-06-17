using ChessGame.Data;
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
    public partial class frmSignin : Form
    {
        public frmSignin()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            if (BLUser.Login(txtInputUsername.Text.Trim(), txtInputPassword.Text.Trim()))
                MessageBox.Show("Thành công");
            else MessageBox.Show("Thất bại");
        }
    }
}
