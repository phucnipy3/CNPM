namespace WinformUI
{
    partial class frmProfile
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
            this.lblTextProfile = new System.Windows.Forms.Label();
            this.lblForIngame = new System.Windows.Forms.Label();
            this.lblIngame = new System.Windows.Forms.Label();
            this.lblForLevel = new System.Windows.Forms.Label();
            this.lblForElo = new System.Windows.Forms.Label();
            this.lblForEmail = new System.Windows.Forms.Label();
            this.lblExperince = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTextProfile
            // 
            this.lblTextProfile.AutoSize = true;
            this.lblTextProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTextProfile.Location = new System.Drawing.Point(12, 19);
            this.lblTextProfile.Name = "lblTextProfile";
            this.lblTextProfile.Size = new System.Drawing.Size(185, 25);
            this.lblTextProfile.TabIndex = 0;
            this.lblTextProfile.Text = "Thông tin cá nhân";
            // 
            // lblForIngame
            // 
            this.lblForIngame.Location = new System.Drawing.Point(17, 54);
            this.lblForIngame.Name = "lblForIngame";
            this.lblForIngame.Size = new System.Drawing.Size(61, 30);
            this.lblForIngame.TabIndex = 1;
            this.lblForIngame.Text = "Ingame: ";
            this.lblForIngame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIngame
            // 
            this.lblIngame.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lblIngame.Location = new System.Drawing.Point(92, 54);
            this.lblIngame.Name = "lblIngame";
            this.lblIngame.Size = new System.Drawing.Size(220, 30);
            this.lblIngame.TabIndex = 1;
            this.lblIngame.Text = "phucni";
            this.lblIngame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForLevel
            // 
            this.lblForLevel.Location = new System.Drawing.Point(17, 84);
            this.lblForLevel.Name = "lblForLevel";
            this.lblForLevel.Size = new System.Drawing.Size(61, 30);
            this.lblForLevel.TabIndex = 1;
            this.lblForLevel.Text = "Name:";
            this.lblForLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForElo
            // 
            this.lblForElo.Location = new System.Drawing.Point(17, 114);
            this.lblForElo.Name = "lblForElo";
            this.lblForElo.Size = new System.Drawing.Size(61, 30);
            this.lblForElo.TabIndex = 1;
            this.lblForElo.Text = "Phone:";
            this.lblForElo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForEmail
            // 
            this.lblForEmail.Location = new System.Drawing.Point(17, 188);
            this.lblForEmail.Name = "lblForEmail";
            this.lblForEmail.Size = new System.Drawing.Size(61, 30);
            this.lblForEmail.TabIndex = 1;
            this.lblForEmail.Text = "Email: ";
            this.lblForEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExperince
            // 
            this.lblExperince.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lblExperince.Location = new System.Drawing.Point(92, 151);
            this.lblExperince.Name = "lblExperince";
            this.lblExperince.Size = new System.Drawing.Size(220, 30);
            this.lblExperince.TabIndex = 2;
            this.lblExperince.Text = "50";
            this.lblExperince.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Experience:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(96, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(288, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(96, 120);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(288, 20);
            this.txtPhone.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(96, 194);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(288, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(309, 235);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(228, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmProfile
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(401, 274);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblExperince);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblForEmail);
            this.Controls.Add(this.lblForElo);
            this.Controls.Add(this.lblForLevel);
            this.Controls.Add(this.lblIngame);
            this.Controls.Add(this.lblForIngame);
            this.Controls.Add(this.lblTextProfile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin cá nhân";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextProfile;
        private System.Windows.Forms.Label lblForIngame;
        private System.Windows.Forms.Label lblIngame;
        private System.Windows.Forms.Label lblForLevel;
        private System.Windows.Forms.Label lblForElo;
        private System.Windows.Forms.Label lblForEmail;
        private System.Windows.Forms.Label lblExperince;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
    }
}