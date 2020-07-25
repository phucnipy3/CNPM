namespace WinformUI
{
    partial class frmInvite
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
            this.dgvInvite = new System.Windows.Forms.DataGridView();
            this.Ingame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvite)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInvite
            // 
            this.dgvInvite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvite.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ingame,
            this.Action});
            this.dgvInvite.Location = new System.Drawing.Point(20, 11);
            this.dgvInvite.Name = "dgvInvite";
            this.dgvInvite.RowHeadersWidth = 62;
            this.dgvInvite.Size = new System.Drawing.Size(295, 247);
            this.dgvInvite.TabIndex = 0;
            this.dgvInvite.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvite_CellClick);
            this.dgvInvite.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvite_CellContentClick);
            // 
            // Ingame
            // 
            this.Ingame.DataPropertyName = "ingame";
            this.Ingame.HeaderText = "Ingame";
            this.Ingame.MinimumWidth = 8;
            this.Ingame.Name = "Ingame";
            // 
            // Action
            // 
            this.Action.HeaderText = "Thao tác";
            this.Action.MinimumWidth = 8;
            this.Action.Name = "Action";
            this.Action.Text = "Mời";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // frmInvite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 272);
            this.Controls.Add(this.dgvInvite);
            this.Name = "frmInvite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mời người chơi";
            this.Load += new System.EventHandler(this.frmInvite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingame;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}