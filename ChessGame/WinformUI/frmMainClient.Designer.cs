namespace WinformUI
{
    partial class frmMainClient
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnFriend = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.btnFeedBack = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnManageAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnPlay.Location = new System.Drawing.Point(76, 83);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(224, 74);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Chơi game";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnManual
            // 
            this.btnManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnManual.Location = new System.Drawing.Point(76, 191);
            this.btnManual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(224, 74);
            this.btnManual.TabIndex = 1;
            this.btnManual.Text = "Hướng dẫn";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnFriend
            // 
            this.btnFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnFriend.Location = new System.Drawing.Point(76, 303);
            this.btnFriend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFriend.Name = "btnFriend";
            this.btnFriend.Size = new System.Drawing.Size(224, 74);
            this.btnFriend.TabIndex = 1;
            this.btnFriend.Text = "Bạn bè";
            this.btnFriend.UseVisualStyleBackColor = true;
            this.btnFriend.Click += new System.EventHandler(this.btnFriend_Click);
            // 
            // btnRank
            // 
            this.btnRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnRank.Location = new System.Drawing.Point(76, 422);
            this.btnRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(224, 74);
            this.btnRank.TabIndex = 1;
            this.btnRank.Text = "Bảng xếp hạng";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btnFeedBack
            // 
            this.btnFeedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnFeedBack.Location = new System.Drawing.Point(76, 540);
            this.btnFeedBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFeedBack.Name = "btnFeedBack";
            this.btnFeedBack.Size = new System.Drawing.Size(224, 74);
            this.btnFeedBack.TabIndex = 1;
            this.btnFeedBack.Text = "Góp ý";
            this.btnFeedBack.UseVisualStyleBackColor = true;
            this.btnFeedBack.Click += new System.EventHandler(this.btnFeedBack_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImage = global::WinformUI.Properties.Resources.cog;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSetting.Location = new System.Drawing.Point(309, 18);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(42, 38);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnManageAccount
            // 
            this.btnManageAccount.BackgroundImage = global::WinformUI.Properties.Resources.user;
            this.btnManageAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnManageAccount.Location = new System.Drawing.Point(258, 18);
            this.btnManageAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManageAccount.Name = "btnManageAccount";
            this.btnManageAccount.Size = new System.Drawing.Size(42, 38);
            this.btnManageAccount.TabIndex = 0;
            this.btnManageAccount.UseVisualStyleBackColor = true;
            // 
            // frmMainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 649);
            this.Controls.Add(this.btnFeedBack);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.btnFriend);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnManageAccount);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainClient_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageAccount;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnFriend;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnFeedBack;
    }
}