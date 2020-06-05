namespace WinformUI
{
    partial class frmSetting
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.switchNotify = new ChessGame.WinformUI.Toggle.CeLearningToggle();
            this.switchSound = new ChessGame.WinformUI.Toggle.CeLearningToggle();
            this.switchMusic = new ChessGame.WinformUI.Toggle.CeLearningToggle();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhạc nền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Âm thanh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thông báo";
            // 
            // switchNotify
            // 
            this.switchNotify.BorderColor = System.Drawing.Color.LightGray;
            this.switchNotify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchNotify.ForeColor = System.Drawing.Color.White;
            this.switchNotify.IsOn = false;
            this.switchNotify.Location = new System.Drawing.Point(164, 133);
            this.switchNotify.Name = "switchNotify";
            this.switchNotify.OffColor = System.Drawing.Color.DarkGray;
            this.switchNotify.OffText = "OFF";
            this.switchNotify.OnColor = System.Drawing.Color.Green;
            this.switchNotify.OnText = "ON";
            this.switchNotify.Size = new System.Drawing.Size(50, 27);
            this.switchNotify.TabIndex = 2;
            this.switchNotify.Text = "ceLearningToggle1";
            this.switchNotify.TextEnabled = true;
            // 
            // switchSound
            // 
            this.switchSound.BorderColor = System.Drawing.Color.LightGray;
            this.switchSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchSound.ForeColor = System.Drawing.Color.White;
            this.switchSound.IsOn = false;
            this.switchSound.Location = new System.Drawing.Point(164, 83);
            this.switchSound.Name = "switchSound";
            this.switchSound.OffColor = System.Drawing.Color.DarkGray;
            this.switchSound.OffText = "OFF";
            this.switchSound.OnColor = System.Drawing.Color.Green;
            this.switchSound.OnText = "ON";
            this.switchSound.Size = new System.Drawing.Size(50, 27);
            this.switchSound.TabIndex = 2;
            this.switchSound.Text = "ceLearningToggle1";
            this.switchSound.TextEnabled = true;
            // 
            // switchMusic
            // 
            this.switchMusic.BorderColor = System.Drawing.Color.LightGray;
            this.switchMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchMusic.ForeColor = System.Drawing.Color.White;
            this.switchMusic.IsOn = false;
            this.switchMusic.Location = new System.Drawing.Point(164, 36);
            this.switchMusic.Name = "switchMusic";
            this.switchMusic.OffColor = System.Drawing.Color.DarkGray;
            this.switchMusic.OffText = "OFF";
            this.switchMusic.OnColor = System.Drawing.Color.Green;
            this.switchMusic.OnText = "ON";
            this.switchMusic.Size = new System.Drawing.Size(50, 27);
            this.switchMusic.TabIndex = 2;
            this.switchMusic.Text = "ceLearningToggle1";
            this.switchMusic.TextEnabled = true;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 195);
            this.Controls.Add(this.switchNotify);
            this.Controls.Add(this.switchSound);
            this.Controls.Add(this.switchMusic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.Text = "Cài đặt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ChessGame.WinformUI.Toggle.CeLearningToggle switchMusic;
        private ChessGame.WinformUI.Toggle.CeLearningToggle switchSound;
        private ChessGame.WinformUI.Toggle.CeLearningToggle switchNotify;
    }
}