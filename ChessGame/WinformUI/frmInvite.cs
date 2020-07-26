﻿using System;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmInvite : Form
    {
        public event EventHandler<ReplyInviteEventArgs> ReplyInvite;
        public frmInvite(string message, string username)
        {
            InitializeComponent();
            lblMessage.Text = message;
            lblUsername.Text = username;
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
            OnReplyInvite(new ReplyInviteEventArgs() { Reply = true });
        }

        private void btnRefuse_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmInvitePlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnReplyInvite(new ReplyInviteEventArgs() { Reply = false });
        }
    }

    public class ReplyInviteEventArgs : EventArgs
    {
        public bool Reply { get; set; }
    }
}
