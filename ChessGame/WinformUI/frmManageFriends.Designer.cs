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
            this.button1 = new System.Windows.Forms.Button();
            this.dgvFriends = new System.Windows.Forms.DataGridView();
            this.Ingame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Message = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriends)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thêm bạn";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgvFriends
            // 
            this.dgvFriends.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFriends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ingame,
            this.Status,
            this.Action,
            this.Message,
            this.Delete});
            this.dgvFriends.Location = new System.Drawing.Point(13, 57);
            this.dgvFriends.Name = "dgvFriends";
            this.dgvFriends.Size = new System.Drawing.Size(544, 194);
            this.dgvFriends.TabIndex = 1;
            this.dgvFriends.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView2_Paint);
            // 
            // Ingame
            // 
            this.Ingame.HeaderText = "Ingame";
            this.Ingame.Name = "Ingame";
            // 
            // Status
            // 
            this.Status.HeaderText = "Trạng thái";
            this.Status.Name = "Status";
            // 
            // Action
            // 
            this.Action.HeaderText = "Mời";
            this.Action.Name = "Action";
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Action.Text = "Mời chơi";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // Message
            // 
            this.Message.HeaderText = "Tin nhắn";
            this.Message.Name = "Message";
            this.Message.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Message.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Message.Text = "Gửi tin nhắn";
            this.Message.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Xóa";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Xóa";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // frmManageFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 266);
            this.Controls.Add(this.dgvFriends);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageFriends";
            this.Text = "Bạn bè";
            this.Load += new System.EventHandler(this.frmManageFriends_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriends)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvFriends;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.DataGridViewButtonColumn Message;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}