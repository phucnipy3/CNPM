namespace WinformUI
{
    partial class frmInvite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnRefuse = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblMessage.Location = new System.Drawing.Point(18, 38);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(555, 49);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Bạn có một lời mời từ người chơi:";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblUsername.Location = new System.Drawing.Point(18, 88);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(555, 49);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Tên người chơi";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefuse
            // 
            this.btnRefuse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRefuse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnRefuse.Location = new System.Drawing.Point(117, 180);
            this.btnRefuse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefuse.Name = "btnRefuse";
            this.btnRefuse.Size = new System.Drawing.Size(138, 48);
            this.btnRefuse.TabIndex = 1;
            this.btnRefuse.Text = "Từ chối";
            this.btnRefuse.UseVisualStyleBackColor = true;
            this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnAccept.Location = new System.Drawing.Point(332, 180);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(138, 48);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Chấp nhận";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmInvitePlay
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnRefuse;
            this.ClientSize = new System.Drawing.Size(580, 283);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnRefuse);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblMessage);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvitePlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lời mời chơi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInvitePlay_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnRefuse;
        private System.Windows.Forms.Button btnAccept;
    }
}