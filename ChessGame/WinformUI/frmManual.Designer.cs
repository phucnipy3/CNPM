namespace WinformUI
{
    partial class frmManual
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
            this.rchTxtManual = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hướng dẫn chơi game";
            // 
            // rchTxtManual
            // 
            this.rchTxtManual.Enabled = false;
            this.rchTxtManual.Location = new System.Drawing.Point(26, 74);
            this.rchTxtManual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rchTxtManual.Name = "rchTxtManual";
            this.rchTxtManual.Size = new System.Drawing.Size(508, 350);
            this.rchTxtManual.TabIndex = 1;
            this.rchTxtManual.Text = "";
            // 
            // frmManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 445);
            this.Controls.Add(this.rchTxtManual);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManual";
            this.Text = "Hướng dẫn";
            this.Load += new System.EventHandler(this.frmManual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchTxtManual;
    }
}