namespace WinformUI
{
    partial class frmRank
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
            this.dgvRank = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGames = new System.Windows.Forms.ComboBox();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Elo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRank)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRank
            // 
            this.dgvRank.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rank,
            this.Ingame,
            this.Elo});
            this.dgvRank.Location = new System.Drawing.Point(18, 58);
            this.dgvRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRank.Name = "dgvRank";
            this.dgvRank.RowHeadersVisible = false;
            this.dgvRank.RowHeadersWidth = 62;
            this.dgvRank.Size = new System.Drawing.Size(564, 348);
            this.dgvRank.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game:";
            // 
            // cmbGames
            // 
            this.cmbGames.FormattingEnabled = true;
            this.cmbGames.Items.AddRange(new object[] {
            "caro"});
            this.cmbGames.Location = new System.Drawing.Point(400, 8);
            this.cmbGames.Name = "cmbGames";
            this.cmbGames.Size = new System.Drawing.Size(182, 28);
            this.cmbGames.TabIndex = 2;
            this.cmbGames.SelectionChangeCommitted += new System.EventHandler(this.cmbGames_SelectionChangeCommitted);
            // 
            // Rank
            // 
            this.Rank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Rank.DataPropertyName = "rank";
            this.Rank.HeaderText = "Hạng";
            this.Rank.MinimumWidth = 8;
            this.Rank.Name = "Rank";
            this.Rank.Width = 80;
            // 
            // Ingame
            // 
            this.Ingame.DataPropertyName = "ingame";
            this.Ingame.HeaderText = "Ingame";
            this.Ingame.MinimumWidth = 8;
            this.Ingame.Name = "Ingame";
            // 
            // Elo
            // 
            this.Elo.DataPropertyName = "point";
            this.Elo.HeaderText = "Điểm Elo";
            this.Elo.MinimumWidth = 8;
            this.Elo.Name = "Elo";
            // 
            // frmRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 417);
            this.Controls.Add(this.cmbGames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRank);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bảng xếp hạng";
            this.Load += new System.EventHandler(this.frmRank_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Elo;
    }
}