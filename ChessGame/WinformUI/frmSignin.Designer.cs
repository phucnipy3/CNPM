namespace WinformUI
{
    partial class frmSignin
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
            this.lblTextSignin = new System.Windows.Forms.Label();
            this.lblForUsername = new System.Windows.Forms.Label();
            this.lblForPassword = new System.Windows.Forms.Label();
            this.txtInputUsername = new System.Windows.Forms.TextBox();
            this.txtInputPassword = new System.Windows.Forms.TextBox();
            this.btnSignin = new System.Windows.Forms.Button();
            this.btnSignup = new System.Windows.Forms.Button();
            this.btnForgetPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTextSignin
            // 
            this.lblTextSignin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTextSignin.Location = new System.Drawing.Point(206, 14);
            this.lblTextSignin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextSignin.Name = "lblTextSignin";
            this.lblTextSignin.Size = new System.Drawing.Size(206, 63);
            this.lblTextSignin.TabIndex = 0;
            this.lblTextSignin.Text = "Đăng nhập";
            this.lblTextSignin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblForUsername
            // 
            this.lblForUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForUsername.Location = new System.Drawing.Point(40, 100);
            this.lblForUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForUsername.Name = "lblForUsername";
            this.lblForUsername.Size = new System.Drawing.Size(132, 63);
            this.lblForUsername.TabIndex = 0;
            this.lblForUsername.Text = "Tài khoản";
            this.lblForUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblForPassword
            // 
            this.lblForPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForPassword.Location = new System.Drawing.Point(40, 163);
            this.lblForPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForPassword.Name = "lblForPassword";
            this.lblForPassword.Size = new System.Drawing.Size(132, 63);
            this.lblForPassword.TabIndex = 0;
            this.lblForPassword.Text = "Mật khẩu";
            this.lblForPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInputUsername
            // 
            this.txtInputUsername.Location = new System.Drawing.Point(182, 118);
            this.txtInputUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputUsername.Name = "txtInputUsername";
            this.txtInputUsername.Size = new System.Drawing.Size(332, 26);
            this.txtInputUsername.TabIndex = 1;
            // 
            // txtInputPassword
            // 
            this.txtInputPassword.Location = new System.Drawing.Point(182, 182);
            this.txtInputPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputPassword.Name = "txtInputPassword";
            this.txtInputPassword.Size = new System.Drawing.Size(332, 26);
            this.txtInputPassword.TabIndex = 1;
            this.txtInputPassword.UseSystemPasswordChar = true;
            // 
            // btnSignin
            // 
            this.btnSignin.Location = new System.Drawing.Point(394, 249);
            this.btnSignin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(122, 40);
            this.btnSignin.TabIndex = 2;
            this.btnSignin.Text = "Đăng nhập";
            this.btnSignin.UseVisualStyleBackColor = true;
            this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(264, 249);
            this.btnSignup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(122, 40);
            this.btnSignup.TabIndex = 2;
            this.btnSignup.Text = "Đăng ký";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // btnForgetPassword
            // 
            this.btnForgetPassword.Location = new System.Drawing.Point(94, 249);
            this.btnForgetPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnForgetPassword.Name = "btnForgetPassword";
            this.btnForgetPassword.Size = new System.Drawing.Size(162, 40);
            this.btnForgetPassword.TabIndex = 3;
            this.btnForgetPassword.Text = "Quên mật khẩu";
            this.btnForgetPassword.UseVisualStyleBackColor = true;
            this.btnForgetPassword.Click += new System.EventHandler(this.btnForgetPassword_Click);
            // 
            // frmSignin
            // 
            this.AcceptButton = this.btnSignin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 326);
            this.Controls.Add(this.btnForgetPassword);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnSignin);
            this.Controls.Add(this.txtInputPassword);
            this.Controls.Add(this.txtInputUsername);
            this.Controls.Add(this.lblForPassword);
            this.Controls.Add(this.lblForUsername);
            this.Controls.Add(this.lblTextSignin);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignin";
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSignin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextSignin;
        private System.Windows.Forms.Label lblForUsername;
        private System.Windows.Forms.Label lblForPassword;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Button btnForgetPassword;
        public System.Windows.Forms.TextBox txtInputUsername;
        public System.Windows.Forms.TextBox txtInputPassword;
    }
}

