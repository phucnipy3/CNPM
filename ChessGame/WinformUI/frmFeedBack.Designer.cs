namespace WinformUI
{
    partial class frmFeedBack
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputEmail = new System.Windows.Forms.TextBox();
            this.rchTxtInputFeedBack = new System.Windows.Forms.RichTextBox();
            this.btnSendFeedBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(58, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label2.Location = new System.Drawing.Point(58, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nội dung:";
            // 
            // txtInputEmail
            // 
            this.txtInputEmail.Location = new System.Drawing.Point(208, 63);
            this.txtInputEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputEmail.Name = "txtInputEmail";
            this.txtInputEmail.Size = new System.Drawing.Size(300, 26);
            this.txtInputEmail.TabIndex = 1;
            // 
            // rchTxtInputFeedBack
            // 
            this.rchTxtInputFeedBack.Location = new System.Drawing.Point(208, 131);
            this.rchTxtInputFeedBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rchTxtInputFeedBack.Name = "rchTxtInputFeedBack";
            this.rchTxtInputFeedBack.Size = new System.Drawing.Size(301, 190);
            this.rchTxtInputFeedBack.TabIndex = 2;
            this.rchTxtInputFeedBack.Text = "";
            // 
            // btnSendFeedBack
            // 
            this.btnSendFeedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnSendFeedBack.Location = new System.Drawing.Point(405, 338);
            this.btnSendFeedBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSendFeedBack.Name = "btnSendFeedBack";
            this.btnSendFeedBack.Size = new System.Drawing.Size(105, 37);
            this.btnSendFeedBack.TabIndex = 3;
            this.btnSendFeedBack.Text = "Gửi";
            this.btnSendFeedBack.UseVisualStyleBackColor = true;
            this.btnSendFeedBack.Click += new System.EventHandler(this.btnSendFeedBack_Click);
            // 
            // frmFeedBack
            // 
            this.AcceptButton = this.btnSendFeedBack;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 402);
            this.Controls.Add(this.btnSendFeedBack);
            this.Controls.Add(this.rchTxtInputFeedBack);
            this.Controls.Add(this.txtInputEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFeedBack";
            this.Text = "Gửi góp ý";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInputEmail;
        private System.Windows.Forms.RichTextBox rchTxtInputFeedBack;
        private System.Windows.Forms.Button btnSendFeedBack;
    }
}