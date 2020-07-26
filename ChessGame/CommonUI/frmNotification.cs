using System.Windows.Forms;

namespace CommonUI
{
    public partial class frmNotification : Form
    {
        public frmNotification(string message)
        {
            InitializeComponent();
            lblNotification.Text = message;
        }

        public static void ShowNotification(string message)
        {
            frmNotification frmNotificationForm = new frmNotification(message);
            frmNotificationForm.Show();
            frmNotificationForm.TopMost = true;
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
