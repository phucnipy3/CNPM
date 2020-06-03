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
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblForElo = new System.Windows.Forms.Label();
            this.lblElo = new System.Windows.Forms.Label();
            this.lblForEmail = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
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
            this.lblIngame.Location = new System.Drawing.Point(84, 54);
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
            this.lblForLevel.Text = "Level: ";
            this.lblForLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLevel
            // 
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lblLevel.Location = new System.Drawing.Point(84, 84);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(220, 30);
            this.lblLevel.TabIndex = 1;
            this.lblLevel.Text = "80";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForElo
            // 
            this.lblForElo.Location = new System.Drawing.Point(17, 114);
            this.lblForElo.Name = "lblForElo";
            this.lblForElo.Size = new System.Drawing.Size(61, 30);
            this.lblForElo.TabIndex = 1;
            this.lblForElo.Text = "Elo point: ";
            this.lblForElo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblElo
            // 
            this.lblElo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lblElo.Location = new System.Drawing.Point(84, 114);
            this.lblElo.Name = "lblElo";
            this.lblElo.Size = new System.Drawing.Size(220, 30);
            this.lblElo.TabIndex = 1;
            this.lblElo.Text = "1900";
            this.lblElo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForEmail
            // 
            this.lblForEmail.Location = new System.Drawing.Point(17, 144);
            this.lblForEmail.Name = "lblForEmail";
            this.lblForEmail.Size = new System.Drawing.Size(61, 30);
            this.lblForEmail.TabIndex = 1;
            this.lblForEmail.Text = "Email: ";
            this.lblForEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lblEmail.Location = new System.Drawing.Point(84, 144);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(239, 30);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "phucnipy3@gmail.com";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 204);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblForEmail);
            this.Controls.Add(this.lblElo);
            this.Controls.Add(this.lblForElo);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblForLevel);
            this.Controls.Add(this.lblIngame);
            this.Controls.Add(this.lblForIngame);
            this.Controls.Add(this.lblTextProfile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProfile";
            this.Text = "Thông tin cá nhân";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextProfile;
        private System.Windows.Forms.Label lblForIngame;
        private System.Windows.Forms.Label lblIngame;
        private System.Windows.Forms.Label lblForLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblForElo;
        private System.Windows.Forms.Label lblElo;
        private System.Windows.Forms.Label lblForEmail;
        private System.Windows.Forms.Label lblEmail;
    }
}