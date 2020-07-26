using System;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmInvite : Form
    {
        private object data;
        public event EventHandler<ReplyInviteEventArgs> ReplyInvite;
        private bool reply = false;
        public frmInvite(string message, string username, object data)
        {
            this.data = data;
            InitializeComponent();
            lblMessage.Text = message;
            lblUsername.Text = username;
            TopMost = true;
        }

        protected virtual void OnReplyInvite(ReplyInviteEventArgs e)
        {
            EventHandler<ReplyInviteEventArgs> handler = ReplyInvite;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            reply = true;
            Close();
        }

        private void btnRefuse_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmInvitePlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnReplyInvite(new ReplyInviteEventArgs() { Reply = reply, Data = data });
        }
    }

    public class ReplyInviteEventArgs : EventArgs
    {
        public bool Reply { get; set; }
        public object Data { get; set; }
    }
}
