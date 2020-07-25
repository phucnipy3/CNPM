namespace WinformUI
{
    partial class frmCheckFeedBack
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
            this.dgvFeedBack = new System.Windows.Forms.DataGridView();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedBack)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFeedBack
            // 
            this.dgvFeedBack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFeedBack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeedBack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sender,
            this.Content});
            this.dgvFeedBack.Location = new System.Drawing.Point(13, 13);
            this.dgvFeedBack.Name = "dgvFeedBack";
            this.dgvFeedBack.RowHeadersWidth = 62;
            this.dgvFeedBack.Size = new System.Drawing.Size(464, 282);
            this.dgvFeedBack.TabIndex = 0;
            this.dgvFeedBack.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFeedBack_CellClick);
            // 
            // Sender
            // 
            this.Sender.DataPropertyName = "Sender";
            this.Sender.FillWeight = 113.6364F;
            this.Sender.HeaderText = "Người gửi";
            this.Sender.MinimumWidth = 8;
            this.Sender.Name = "Sender";
            // 
            // Content
            // 
            this.Content.DataPropertyName = "Content";
            this.Content.FillWeight = 86.36364F;
            this.Content.HeaderText = "Nội dung";
            this.Content.MinimumWidth = 8;
            this.Content.Name = "Content";
            // 
            // frmCheckFeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 306);
            this.Controls.Add(this.dgvFeedBack);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckFeedBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Góp ý";
            this.Load += new System.EventHandler(this.frmCheckFeedBack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFeedBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
    }
}