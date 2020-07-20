namespace WinformUI
{
    partial class frmAddFriend
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
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.txtInputIngame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnAddFriend.Location = new System.Drawing.Point(390, 103);
            this.btnAddFriend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(105, 37);
            this.btnAddFriend.TabIndex = 6;
            this.btnAddFriend.Text = "Kết bạn";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // txtInputIngame
            // 
            this.txtInputIngame.Location = new System.Drawing.Point(194, 49);
            this.txtInputIngame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputIngame.Name = "txtInputIngame";
            this.txtInputIngame.Size = new System.Drawing.Size(300, 26);
            this.txtInputIngame.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(44, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ingame:";
            // 
            // frmAddFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 195);
            this.Controls.Add(this.btnAddFriend);
            this.Controls.Add(this.txtInputIngame);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddFriend";
            this.Text = "Kết bạn";
            this.Load += new System.EventHandler(this.frmAddFriend_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddFriend;
        private System.Windows.Forms.TextBox txtInputIngame;
        private System.Windows.Forms.Label label1;
    }
}