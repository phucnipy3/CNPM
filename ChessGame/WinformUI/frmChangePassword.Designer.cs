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
            this.btnChange.Location = new System.Drawing.Point(368, 271);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(128, 40);
            this.btnChange.TabIndex = 17;
            this.btnChange.Text = "Đổi mật khẩu";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(260, 271);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 40);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtInputConfirm
            // 
            this.txtInputConfirm.Location = new System.Drawing.Point(238, 231);
            this.txtInputConfirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputConfirm.Name = "txtInputConfirm";
            this.txtInputConfirm.Size = new System.Drawing.Size(254, 26);
            this.txtInputConfirm.TabIndex = 14;
            this.txtInputConfirm.UseSystemPasswordChar = true;
            // 
            // txtInputNew
            // 
            this.txtInputNew.Location = new System.Drawing.Point(238, 166);
            this.txtInputNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputNew.Name = "txtInputNew";
            this.txtInputNew.Size = new System.Drawing.Size(254, 26);
            this.txtInputNew.TabIndex = 15;
            this.txtInputNew.UseSystemPasswordChar = true;
            // 
            // lblForConfirm
            // 
            this.lblForConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForConfirm.Location = new System.Drawing.Point(20, 212);
            this.lblForConfirm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForConfirm.Name = "lblForConfirm";
            this.lblForConfirm.Size = new System.Drawing.Size(231, 63);
            this.lblForConfirm.TabIndex = 10;
            this.lblForConfirm.Text = "Xác nhận mật khẩu";
            this.lblForConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInputOld
            // 
            this.txtInputOld.Location = new System.Drawing.Point(238, 103);
            this.txtInputOld.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputOld.Name = "txtInputOld";
            this.txtInputOld.Size = new System.Drawing.Size(254, 26);
            this.txtInputOld.TabIndex = 16;
            // 
            // lblForPassword
            // 
            this.lblForPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForPassword.Location = new System.Drawing.Point(18, 148);
            this.lblForPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForPassword.Name = "lblForPassword";
            this.lblForPassword.Size = new System.Drawing.Size(146, 63);
            this.lblForPassword.TabIndex = 11;
            this.lblForPassword.Text = "Mật khẩu mới";
            this.lblForPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForUsername
            // 
            this.lblForUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForUsername.Location = new System.Drawing.Point(20, 85);
            this.lblForUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForUsername.Name = "lblForUsername";
            this.lblForUsername.Size = new System.Drawing.Size(132, 63);
            this.lblForUsername.TabIndex = 12;
            this.lblForUsername.Text = "Mật khẩu cũ";
            this.lblForUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextChange
            // 
            this.lblTextChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTextChange.Location = new System.Drawing.Point(170, 14);
            this.lblTextChange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextChange.Name = "lblTextChange";
            this.lblTextChange.Size = new System.Drawing.Size(242, 63);
            this.lblTextChange.TabIndex = 13;
            this.lblTextChange.Text = "Đổi mật khẩu";
            this.lblTextChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChangePassword
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(534, 369);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtInputConfirm);
            this.Controls.Add(this.txtInputNew);
            this.Controls.Add(this.lblForConfirm);
            this.Controls.Add(this.txtInputOld);
            this.Controls.Add(this.lblForPassword);
            this.Controls.Add(this.lblForUsername);
            this.Controls.Add(this.lblTextChange);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
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