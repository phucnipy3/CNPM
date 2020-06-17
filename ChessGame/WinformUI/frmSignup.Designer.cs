namespace WinformUI
{
    partial class frmSignup
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
            this.btnSignup = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtInputPassword = new System.Windows.Forms.TextBox();
            this.txtInputUsername = new System.Windows.Forms.TextBox();
            this.lblForPassword = new System.Windows.Forms.Label();
            this.lblForUsername = new System.Windows.Forms.Label();
            this.lblTextSignup = new System.Windows.Forms.Label();
            this.lblForConfirm = new System.Windows.Forms.Label();
            this.txtInputConfirm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(284, 186);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(65, 26);
            this.btnSignup.TabIndex = 8;
            this.btnSignup.Text = "Đăng ký";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(212, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 26);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtInputPassword
            // 
            this.txtInputPassword.Location = new System.Drawing.Point(178, 118);
            this.txtInputPassword.Name = "txtInputPassword";
            this.txtInputPassword.Size = new System.Drawing.Size(171, 20);
            this.txtInputPassword.TabIndex = 6;
            this.txtInputPassword.UseSystemPasswordChar = true;
            // 
            // txtInputUsername
            // 
            this.txtInputUsername.Location = new System.Drawing.Point(178, 77);
            this.txtInputUsername.Name = "txtInputUsername";
            this.txtInputUsername.Size = new System.Drawing.Size(171, 20);
            this.txtInputUsername.TabIndex = 7;
            // 
            // lblForPassword
            // 
            this.lblForPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForPassword.Location = new System.Drawing.Point(32, 106);
            this.lblForPassword.Name = "lblForPassword";
            this.lblForPassword.Size = new System.Drawing.Size(88, 41);
            this.lblForPassword.TabIndex = 3;
            this.lblForPassword.Text = "Mật khẩu";
            this.lblForPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblForUsername
            // 
            this.lblForUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForUsername.Location = new System.Drawing.Point(32, 65);
            this.lblForUsername.Name = "lblForUsername";
            this.lblForUsername.Size = new System.Drawing.Size(88, 41);
            this.lblForUsername.TabIndex = 4;
            this.lblForUsername.Text = "Tài khoản";
            this.lblForUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTextSignup
            // 
            this.lblTextSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTextSignup.Location = new System.Drawing.Point(142, 9);
            this.lblTextSignup.Name = "lblTextSignup";
            this.lblTextSignup.Size = new System.Drawing.Size(137, 41);
            this.lblTextSignup.TabIndex = 5;
            this.lblTextSignup.Text = "Đăng nhập";
            this.lblTextSignup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblForConfirm
            // 
            this.lblForConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForConfirm.Location = new System.Drawing.Point(32, 148);
            this.lblForConfirm.Name = "lblForConfirm";
            this.lblForConfirm.Size = new System.Drawing.Size(154, 41);
            this.lblForConfirm.TabIndex = 3;
            this.lblForConfirm.Text = "Xác nhận mật khẩu";
            this.lblForConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInputConfirm
            // 
            this.txtInputConfirm.Location = new System.Drawing.Point(178, 160);
            this.txtInputConfirm.Name = "txtInputConfirm";
            this.txtInputConfirm.Size = new System.Drawing.Size(171, 20);
            this.txtInputConfirm.TabIndex = 6;
            this.txtInputConfirm.UseSystemPasswordChar = true;
            // 
            // frmSignup
            // 
            this.AcceptButton = this.btnSignup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 241);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtInputConfirm);
            this.Controls.Add(this.txtInputPassword);
            this.Controls.Add(this.lblForConfirm);
            this.Controls.Add(this.txtInputUsername);
            this.Controls.Add(this.lblForPassword);
            this.Controls.Add(this.lblForUsername);
            this.Controls.Add(this.lblTextSignup);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignup";
            this.Text = "Đăng kí";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtInputPassword;
        private System.Windows.Forms.TextBox txtInputUsername;
        private System.Windows.Forms.Label lblForPassword;
        private System.Windows.Forms.Label lblForUsername;
        private System.Windows.Forms.Label lblTextSignup;
        private System.Windows.Forms.Label lblForConfirm;
        private System.Windows.Forms.TextBox txtInputConfirm;
    }
}