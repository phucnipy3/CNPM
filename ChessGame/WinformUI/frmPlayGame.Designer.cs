namespace WinformUI
{
    partial class frmPlayGame
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
            this.rchTxtChat = new System.Windows.Forms.RichTextBox();
            this.rchTxtMessage = new System.Windows.Forms.RichTextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblOpponentName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInvite = new System.Windows.Forms.Button();
            this.btnReady = new System.Windows.Forms.Button();
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.ptbPlayGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayGround)).BeginInit();
            this.SuspendLayout();
            // 
            // rchTxtChat
            // 
            this.rchTxtChat.Location = new System.Drawing.Point(419, 12);
            this.rchTxtChat.Name = "rchTxtChat";
            this.rchTxtChat.Size = new System.Drawing.Size(204, 335);
            this.rchTxtChat.TabIndex = 1;
            this.rchTxtChat.Text = "";
            // 
            // rchTxtMessage
            // 
            this.rchTxtMessage.Location = new System.Drawing.Point(419, 353);
            this.rchTxtMessage.Name = "rchTxtMessage";
            this.rchTxtMessage.Size = new System.Drawing.Size(136, 59);
            this.rchTxtMessage.TabIndex = 2;
            this.rchTxtMessage.Text = "";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(561, 353);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(60, 58);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Gửi";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblPlayerName.Location = new System.Drawing.Point(12, 439);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(155, 37);
            this.lblPlayerName.TabIndex = 4;
            this.lblPlayerName.Text = "Tên người chơi ";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOpponentName
            // 
            this.lblOpponentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblOpponentName.Location = new System.Drawing.Point(246, 439);
            this.lblOpponentName.Name = "lblOpponentName";
            this.lblOpponentName.Size = new System.Drawing.Size(155, 37);
            this.lblOpponentName.TabIndex = 4;
            this.lblOpponentName.Text = "Tên đối thủ";
            this.lblOpponentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(173, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "VS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInvite
            // 
            this.btnInvite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnInvite.Location = new System.Drawing.Point(423, 442);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(92, 30);
            this.btnInvite.TabIndex = 5;
            this.btnInvite.Text = "Mời";
            this.btnInvite.UseVisualStyleBackColor = true;
            // 
            // btnReady
            // 
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnReady.Location = new System.Drawing.Point(529, 442);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(92, 30);
            this.btnReady.TabIndex = 5;
            this.btnReady.Text = "Sẵn sàng";
            this.btnReady.UseVisualStyleBackColor = true;
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddFriend.Location = new System.Drawing.Point(295, 479);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(72, 30);
            this.btnAddFriend.TabIndex = 5;
            this.btnAddFriend.Text = "Kết bạn";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            // 
            // ptbPlayGround
            // 
            this.ptbPlayGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayGround.Location = new System.Drawing.Point(13, 12);
            this.ptbPlayGround.Name = "ptbPlayGround";
            this.ptbPlayGround.Size = new System.Drawing.Size(400, 400);
            this.ptbPlayGround.TabIndex = 0;
            this.ptbPlayGround.TabStop = false;
            this.ptbPlayGround.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbPlayGround_MouseClick);
            // 
            // frmPlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 522);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.btnAddFriend);
            this.Controls.Add(this.btnInvite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOpponentName);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.rchTxtMessage);
            this.Controls.Add(this.rchTxtChat);
            this.Controls.Add(this.ptbPlayGround);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlayGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trò chơi";
            this.Load += new System.EventHandler(this.frmPlayGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbPlayGround;
        private System.Windows.Forms.RichTextBox rchTxtChat;
        private System.Windows.Forms.RichTextBox rchTxtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblOpponentName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Button btnAddFriend;
    }
}