namespace WinformUI
{
    partial class frmChangePassword
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
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtInputConfirm = new System.Windows.Forms.TextBox();
            this.txtInputNew = new System.Windows.Forms.TextBox();
            this.lblForConfirm = new System.Windows.Forms.Label();
            this.txtInputOld = new System.Windows.Forms.TextBox();
            this.lblForPassword = new System.Windows.Forms.Label();
            this.lblForUsername = new System.Windows.Forms.Label();
            this.lblTextChange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(245, 176);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(85, 26);
            this.btnChange.TabIndex = 17;
            this.btnChange.Text = "Đổi mật khẩu";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(173, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 26);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtInputConfirm
            // 
            this.txtInputConfirm.Location = new System.Drawing.Point(159, 150);
            this.txtInputConfirm.Name = "txtInputConfirm";
            this.txtInputConfirm.Size = new System.Drawing.Size(171, 20);
            this.txtInputConfirm.TabIndex = 14;
            this.txtInputConfirm.UseSystemPasswordChar = true;
            // 
            // txtInputNew
            // 
            this.txtInputNew.Location = new System.Drawing.Point(159, 108);
            this.txtInputNew.Name = "txtInputNew";
            this.txtInputNew.Size = new System.Drawing.Size(171, 20);
            this.txtInputNew.TabIndex = 15;
            this.txtInputNew.UseSystemPasswordChar = true;
            // 
            // lblForConfirm
            // 
            this.lblForConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForConfirm.Location = new System.Drawing.Point(13, 138);
            this.lblForConfirm.Name = "lblForConfirm";
            this.lblForConfirm.Size = new System.Drawing.Size(154, 41);
            this.lblForConfirm.TabIndex = 10;
            this.lblForConfirm.Text = "Xác nhận mật khẩu";
            this.lblForConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInputOld
            // 
            this.txtInputOld.Location = new System.Drawing.Point(159, 67);
            this.txtInputOld.Name = "txtInputOld";
            this.txtInputOld.Size = new System.Drawing.Size(171, 20);
            this.txtInputOld.TabIndex = 16;
            this.txtInputOld.UseSystemPasswordChar = true;
            // 
            // lblForPassword
            // 
            this.lblForPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForPassword.Location = new System.Drawing.Point(12, 96);
            this.lblForPassword.Name = "lblForPassword";
            this.lblForPassword.Size = new System.Drawing.Size(97, 41);
            this.lblForPassword.TabIndex = 11;
            this.lblForPassword.Text = "Mật khẩu mới";
            this.lblForPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForUsername
            // 
            this.lblForUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForUsername.Location = new System.Drawing.Point(13, 55);
            this.lblForUsername.Name = "lblForUsername";
            this.lblForUsername.Size = new System.Drawing.Size(88, 41);
            this.lblForUsername.TabIndex = 12;
            this.lblForUsername.Text = "Mật khẩu cũ";
            this.lblForUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextChange
            // 
            this.lblTextChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTextChange.Location = new System.Drawing.Point(113, 9);
            this.lblTextChange.Name = "lblTextChange";
            this.lblTextChange.Size = new System.Drawing.Size(161, 41);
            this.lblTextChange.TabIndex = 13;
            this.lblTextChange.Text = "Đổi mật khẩu";
            this.lblTextChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChangePassword
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(356, 240);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtInputConfirm);
            this.Controls.Add(this.txtInputNew);
            this.Controls.Add(this.lblForConfirm);
            this.Controls.Add(this.txtInputOld);
            this.Controls.Add(this.lblForPassword);
            this.Controls.Add(this.lblForUsername);
            this.Controls.Add(this.lblTextChange);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtInputConfirm;
        private System.Windows.Forms.TextBox txtInputNew;
        private System.Windows.Forms.Label lblForConfirm;
        private System.Windows.Forms.TextBox txtInputOld;
        private System.Windows.Forms.Label lblForPassword;
        private System.Windows.Forms.Label lblForUsername;
        private System.Windows.Forms.Label lblTextChange;
    }
}