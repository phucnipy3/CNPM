﻿namespace WinformUI
{
    partial class frmManageAccount
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnForgetPassword = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnLogout.Location = new System.Drawing.Point(54, 263);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(164, 48);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnForgetPassword
            // 
            this.btnForgetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnForgetPassword.Location = new System.Drawing.Point(54, 186);
            this.btnForgetPassword.Name = "btnForgetPassword";
            this.btnForgetPassword.Size = new System.Drawing.Size(164, 48);
            this.btnForgetPassword.TabIndex = 3;
            this.btnForgetPassword.Text = "Quên mật khẩu";
            this.btnForgetPassword.UseVisualStyleBackColor = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnChangePassword.Location = new System.Drawing.Point(54, 113);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(164, 48);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnProfile.Location = new System.Drawing.Point(54, 43);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(164, 48);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "Thông tin cá nhân";
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // frmManageAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 361);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnForgetPassword);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnProfile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageAccount";
            this.Text = "Quản lý tài khoản";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnForgetPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnProfile;
    }
}