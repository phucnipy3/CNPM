namespace WinformUI
{
    partial class frmManageFriends
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
            this.dgvFriends = new System.Windows.Forms.DataGridView();
            this.Ingame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Message = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriends)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnAddFriend.Location = new System.Drawing.Point(12, 12);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(91, 31);
            this.btnAddFriend.TabIndex = 0;
            this.btnAddFriend.Text = "Thêm bạn";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // dgvFriends
            // 
            this.dgvFriends.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFriends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ingame,
            this.Active,
            this.Action,
            this.Message,
            this.Delete});
            this.dgvFriends.Location = new System.Drawing.Point(13, 57);
            this.dgvFriends.Name = "dgvFriends";
            this.dgvFriends.RowHeadersWidth = 62;
            this.dgvFriends.Size = new System.Drawing.Size(565, 194);
            this.dgvFriends.TabIndex = 1;
            this.dgvFriends.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFriends_CellClick);
            this.dgvFriends.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFriends_CellContentClick);
            this.dgvFriends.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView2_Paint);
            // 
            // Ingame
            // 
            this.Ingame.DataPropertyName = "UserName";
            this.Ingame.HeaderText = "Ingame";
            this.Ingame.MinimumWidth = 8;
            this.Ingame.Name = "Ingame";
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Trạng thái";
            this.Active.MinimumWidth = 8;
            this.Active.Name = "Active";
            // 
            // Action
            // 
            this.Action.HeaderText = "Mời";
            this.Action.MinimumWidth = 8;
            this.Action.Name = "Action";
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Action.Text = "Mời chơi";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // Message
            // 
            this.Message.HeaderText = "Tin nhắn";
            this.Message.MinimumWidth = 8;
            this.Message.Name = "Message";
            this.Message.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Message.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Message.Text = "Gửi tin nhắn";
            this.Message.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Xóa";
            this.Delete.MinimumWidth = 8;
            this.Delete.Name = "Delete";
            this.Delete.Text = "Xóa";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(489, 12);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmManageFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 266);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvFriends);
            this.Controls.Add(this.btnAddFriend);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageFriends";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bạn bè";
            this.Activated += new System.EventHandler(this.frmManageFriends_Activated);
            this.Load += new System.EventHandler(this.frmManageFriends_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriends)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFriend;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.DataGridViewButtonColumn Message;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.DataGridView dgvFriends;
    }
}