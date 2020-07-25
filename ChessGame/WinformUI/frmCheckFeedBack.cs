using Data.BusinessLogic;
using Data.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmCheckFeedBack : Form
    {
        private BLFeedback bLFeedback;
        public frmCheckFeedBack()
        {
            bLFeedback = new BLFeedback();
            InitializeComponent();
        }

        private async void frmCheckFeedBack_Load(object sender, EventArgs e)
        {
            List<CheckFeedback> lstcheckFeedbacks = await bLFeedback.CheckFeedbackAsync();
            dgvFeedBack.DataSource = lstcheckFeedbacks;
        }

        private void dgvFeedBack_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            int row_index = e.RowIndex;
            if (row_index != -1)
            {

                if (dgv.Columns[e.ColumnIndex].Name == "Content")
                {
                    MessageBox.Show(dgv.Rows[row_index].Cells[1].Value.ToString());
                }

            }
        }
    }
}
