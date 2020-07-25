namespace WinformUI
{
    partial class frmMainAdmin
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
            this.btnMaintaince = new System.Windows.Forms.Button();
            this.btnCheckFeedBack = new System.Windows.Forms.Button();
            this.btnCreateNotify = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnManageAccout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMaintaince
            // 
            this.btnMaintaince.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnMaintaince.Location = new System.Drawing.Point(12, 269);
            this.btnMaintaince.Name = "btnMaintaince";
            this.btnMaintaince.Size = new System.Drawing.Size(179, 48);
            this.btnMaintaince.TabIndex = 5;
            this.btnMaintaince.Text = "Bảo trì server";
            this.btnMaintaince.UseVisualStyleBackColor = true;
            this.btnMaintaince.Click += new System.EventHandler(this.btnMaintaince_Click);
            // 
            // btnCheckFeedBack
            // 
            this.btnCheckFeedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnCheckFeedBack.Location = new System.Drawing.Point(12, 192);
            this.btnCheckFeedBack.Name = "btnCheckFeedBack";
            this.btnCheckFeedBack.Size = new System.Drawing.Size(179, 48);
            this.btnCheckFeedBack.TabIndex = 6;
            this.btnCheckFeedBack.Text = "Xem góp ý";
            this.btnCheckFeedBack.UseVisualStyleBackColor = true;
            this.btnCheckFeedBack.Click += new System.EventHandler(this.btnCheckFeedBack_Click);
            // 
            // btnCreateNotify
            // 
            this.btnCreateNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnCreateNotify.Location = new System.Drawing.Point(12, 119);
            this.btnCreateNotify.Name = "btnCreateNotify";
            this.btnCreateNotify.Size = new System.Drawing.Size(179, 48);
            this.btnCreateNotify.TabIndex = 7;
            this.btnCreateNotify.Text = "Tạo thông báo";
            this.btnCreateNotify.UseVisualStyleBackColor = true;
            this.btnCreateNotify.Click += new System.EventHandler(this.btnCreateNotify_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnManageUsers.Location = new System.Drawing.Point(12, 49);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(179, 48);
            this.btnManageUsers.TabIndex = 8;
            this.btnManageUsers.Text = "Quản lý người dùng";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnManageAccout
            // 
            this.btnManageAccout.BackgroundImage = global::WinformUI.Properties.Resources.user;
            this.btnManageAccout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnManageAccout.Location = new System.Drawing.Point(163, 12);
            this.btnManageAccout.Name = "btnManageAccout";
            this.btnManageAccout.Size = new System.Drawing.Size(28, 25);
            this.btnManageAccout.TabIndex = 2;
            this.btnManageAccout.UseVisualStyleBackColor = true;
            // 
            // frmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 339);
            this.Controls.Add(this.btnMaintaince);
            this.Controls.Add(this.btnCheckFeedBack);
            this.Controls.Add(this.btnCreateNotify);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnManageAccout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainAdmin_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMaintaince;
        private System.Windows.Forms.Button btnCheckFeedBack;
        private System.Windows.Forms.Button btnCreateNotify;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManageAccout;
    }
}