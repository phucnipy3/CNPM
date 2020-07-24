namespace WinformUI
{
    partial class frmAddUser
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtInputPassword = new System.Windows.Forms.TextBox();
            this.txtInputUsername = new System.Windows.Forms.TextBox();
            this.lblForPassword = new System.Windows.Forms.Label();
            this.lblForUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(372, 162);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 40);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Tạo tài khoản";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtInputPassword
            // 
            this.txtInputPassword.Location = new System.Drawing.Point(159, 106);
            this.txtInputPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputPassword.Name = "txtInputPassword";
            this.txtInputPassword.Size = new System.Drawing.Size(332, 26);
            this.txtInputPassword.TabIndex = 5;
            this.txtInputPassword.UseSystemPasswordChar = true;
            // 
            // txtInputUsername
            // 
            this.txtInputUsername.Location = new System.Drawing.Point(159, 43);
            this.txtInputUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputUsername.Name = "txtInputUsername";
            this.txtInputUsername.Size = new System.Drawing.Size(332, 26);
            this.txtInputUsername.TabIndex = 6;
            // 
            // lblForPassword
            // 
            this.lblForPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForPassword.Location = new System.Drawing.Point(18, 88);
            this.lblForPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForPassword.Name = "lblForPassword";
            this.lblForPassword.Size = new System.Drawing.Size(132, 63);
            this.lblForPassword.TabIndex = 3;
            this.lblForPassword.Text = "Mật khẩu";
            this.lblForPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblForUsername
            // 
            this.lblForUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForUsername.Location = new System.Drawing.Point(18, 25);
            this.lblForUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForUsername.Name = "lblForUsername";
            this.lblForUsername.Size = new System.Drawing.Size(132, 63);
            this.lblForUsername.TabIndex = 4;
            this.lblForUsername.Text = "Tài khoản";
            this.lblForUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 220);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtInputPassword);
            this.Controls.Add(this.txtInputUsername);
            this.Controls.Add(this.lblForPassword);
            this.Controls.Add(this.lblForUsername);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUser";
            this.Text = "Thêm mới user";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtInputPassword;
        private System.Windows.Forms.TextBox txtInputUsername;
        private System.Windows.Forms.Label lblForPassword;
        private System.Windows.Forms.Label lblForUsername;
    }
}