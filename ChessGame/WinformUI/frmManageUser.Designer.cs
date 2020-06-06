namespace WinformUI
{
    partial class frmManageUser
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lock = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Logout = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnAdd.Location = new System.Drawing.Point(15, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvUser
            // 
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Ingame,
            this.Lock,
            this.Logout});
            this.dgvUser.Location = new System.Drawing.Point(14, 58);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.Size = new System.Drawing.Size(441, 255);
            this.dgvUser.TabIndex = 1;
            this.dgvUser.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvUser_Paint);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Ingame
            // 
            this.Ingame.HeaderText = "Ingame";
            this.Ingame.Name = "Ingame";
            // 
            // Lock
            // 
            this.Lock.HeaderText = "Khóa/ Mở";
            this.Lock.Name = "Lock";
            this.Lock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Lock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Lock.Text = "Khóa/ Mở";
            this.Lock.UseColumnTextForButtonValue = true;
            // 
            // Logout
            // 
            this.Logout.HeaderText = "Đăng xuất";
            this.Logout.Name = "Logout";
            this.Logout.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Logout.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Logout.Text = "Đăng xuất";
            this.Logout.UseColumnTextForButtonValue = true;
            // 
            // frmManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 335);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageUser";
            this.Text = "Quản lý người dùng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingame;
        private System.Windows.Forms.DataGridViewButtonColumn Lock;
        private System.Windows.Forms.DataGridViewButtonColumn Logout;
    }
}