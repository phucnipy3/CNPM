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
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label2.Location = new System.Drawing.Point(39, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nội dung:";
            // 
            // txtInputEmail
            // 
            this.txtInputEmail.Location = new System.Drawing.Point(139, 41);
            this.txtInputEmail.Name = "txtInputEmail";
            this.txtInputEmail.Size = new System.Drawing.Size(201, 20);
            this.txtInputEmail.TabIndex = 1;
            // 
            // rchTxtInputFeedBack
            // 
            this.rchTxtInputFeedBack.Location = new System.Drawing.Point(139, 85);
            this.rchTxtInputFeedBack.Name = "rchTxtInputFeedBack";
            this.rchTxtInputFeedBack.Size = new System.Drawing.Size(202, 125);
            this.rchTxtInputFeedBack.TabIndex = 2;
            this.rchTxtInputFeedBack.Text = "";
            // 
            // btnSendFeedBack
            // 
            this.btnSendFeedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnSendFeedBack.Location = new System.Drawing.Point(270, 220);
            this.btnSendFeedBack.Name = "btnSendFeedBack";
            this.btnSendFeedBack.Size = new System.Drawing.Size(70, 24);
            this.btnSendFeedBack.TabIndex = 3;
            this.btnSendFeedBack.Text = "Gửi";
            this.btnSendFeedBack.UseVisualStyleBackColor = true;
            // 
            // frmFeedBack
            // 
            this.AcceptButton = this.btnSendFeedBack;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 261);
            this.Controls.Add(this.btnSendFeedBack);
            this.Controls.Add(this.rchTxtInputFeedBack);
            this.Controls.Add(this.txtInputEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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