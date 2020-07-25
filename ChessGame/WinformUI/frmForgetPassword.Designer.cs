namespace WinformUI
{
    partial class frmForgetPassword
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGetPassword = new System.Windows.Forms.Button();
            this.txtInputUsername = new System.Windows.Forms.TextBox();
            this.lblForUsername = new System.Windows.Forms.Label();
            this.lblTextForget = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(168, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGetPassword
            // 
            this.btnGetPassword.Location = new System.Drawing.Point(254, 79);
            this.btnGetPassword.Name = "btnGetPassword";
            this.btnGetPassword.Size = new System.Drawing.Size(81, 26);
            this.btnGetPassword.TabIndex = 7;
            this.btnGetPassword.Text = "Lấy mật khẩu";
            this.btnGetPassword.UseVisualStyleBackColor = true;
            this.btnGetPassword.Click += new System.EventHandler(this.btnGetPassword_Click);
            // 
            // txtInputUsername
            // 
            this.txtInputUsername.Location = new System.Drawing.Point(112, 53);
            this.txtInputUsername.Name = "txtInputUsername";
            this.txtInputUsername.Size = new System.Drawing.Size(223, 20);
            this.txtInputUsername.TabIndex = 5;
            // 
            // lblForUsername
            // 
            this.lblForUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForUsername.Location = new System.Drawing.Point(18, 43);
            this.lblForUsername.Name = "lblForUsername";
            this.lblForUsername.Size = new System.Drawing.Size(88, 41);
            this.lblForUsername.TabIndex = 3;
            this.lblForUsername.Text = "Tài khoản";
            this.lblForUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTextForget
            // 
            this.lblTextForget.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTextForget.Location = new System.Drawing.Point(128, 9);
            this.lblTextForget.Name = "lblTextForget";
            this.lblTextForget.Size = new System.Drawing.Size(177, 41);
            this.lblTextForget.TabIndex = 4;
            this.lblTextForget.Text = "Quên mật khẩu";
            this.lblTextForget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmForgetPassword
            // 
            this.AcceptButton = this.btnGetPassword;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 124);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGetPassword);
            this.Controls.Add(this.txtInputUsername);
            this.Controls.Add(this.lblForUsername);
            this.Controls.Add(this.lblTextForget);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForgetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quên mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGetPassword;
        private System.Windows.Forms.TextBox txtInputUsername;
        private System.Windows.Forms.Label lblForUsername;
        private System.Windows.Forms.Label lblTextForget;
    }
}