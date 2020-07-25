namespace WinformUI
{
    partial class frmPickGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPickGame));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputSearchRoom = new System.Windows.Forms.TextBox();
            this.btnNewRoom = new System.Windows.Forms.Button();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnVay = new System.Windows.Forms.Button();
            this.btnVua = new System.Windows.Forms.Button();
            this.btnTuong = new System.Windows.Forms.Button();
            this.btnCaro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(415, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm phòng";
            // 
            // txtInputSearchRoom
            // 
            this.txtInputSearchRoom.Location = new System.Drawing.Point(511, 9);
            this.txtInputSearchRoom.Name = "txtInputSearchRoom";
            this.txtInputSearchRoom.Size = new System.Drawing.Size(135, 20);
            this.txtInputSearchRoom.TabIndex = 2;
            this.txtInputSearchRoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputSearchRoom_KeyDown);
            // 
            // btnNewRoom
            // 
            this.btnNewRoom.Location = new System.Drawing.Point(672, 7);
            this.btnNewRoom.Name = "btnNewRoom";
            this.btnNewRoom.Size = new System.Drawing.Size(88, 25);
            this.btnNewRoom.TabIndex = 3;
            this.btnNewRoom.Text = "Tạo phòng";
            this.btnNewRoom.UseVisualStyleBackColor = true;
            this.btnNewRoom.Click += new System.EventHandler(this.btnNewRoom_Click);
            // 
            // dgvRoom
            // 
            this.dgvRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Status,
            this.Action});
            this.dgvRoom.Location = new System.Drawing.Point(417, 48);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.RowHeadersVisible = false;
            this.dgvRoom.Size = new System.Drawing.Size(378, 258);
            this.dgvRoom.TabIndex = 4;
            this.dgvRoom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoom_CellClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 59.80394F;
            this.Id.HeaderText = "Mã phòng";
            this.Id.Name = "Id";
            this.Id.Width = 80;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.FillWeight = 87.91179F;
            this.Status.HeaderText = "Trạng thái";
            this.Status.Name = "Status";
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Action.DataPropertyName = "Action";
            this.Action.FillWeight = 152.2843F;
            this.Action.HeaderText = "Thao tác";
            this.Action.Name = "Action";
            this.Action.Text = "Tham gia";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // btnVay
            // 
            this.btnVay.BackgroundImage = global::WinformUI.Properties.Resources.demoVay;
            this.btnVay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.btnVay.ForeColor = System.Drawing.Color.Black;
            this.btnVay.Location = new System.Drawing.Point(12, 249);
            this.btnVay.Name = "btnVay";
            this.btnVay.Size = new System.Drawing.Size(386, 57);
            this.btnVay.TabIndex = 0;
            this.btnVay.Tag = "4";
            this.btnVay.Text = "Cờ vây";
            this.btnVay.UseVisualStyleBackColor = true;
            this.btnVay.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnVua
            // 
            this.btnVua.BackgroundImage = global::WinformUI.Properties.Resources.demoVua;
            this.btnVua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVua.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.btnVua.ForeColor = System.Drawing.Color.Black;
            this.btnVua.Location = new System.Drawing.Point(12, 170);
            this.btnVua.Name = "btnVua";
            this.btnVua.Size = new System.Drawing.Size(386, 57);
            this.btnVua.TabIndex = 0;
            this.btnVua.Tag = "3";
            this.btnVua.Text = "Cờ vua";
            this.btnVua.UseVisualStyleBackColor = true;
            this.btnVua.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnTuong
            // 
            this.btnTuong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTuong.BackgroundImage")));
            this.btnTuong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.btnTuong.ForeColor = System.Drawing.Color.Black;
            this.btnTuong.Location = new System.Drawing.Point(12, 90);
            this.btnTuong.Name = "btnTuong";
            this.btnTuong.Size = new System.Drawing.Size(386, 57);
            this.btnTuong.TabIndex = 0;
            this.btnTuong.Tag = "2";
            this.btnTuong.Text = "Cờ tướng";
            this.btnTuong.UseVisualStyleBackColor = true;
            this.btnTuong.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnCaro
            // 
            this.btnCaro.BackgroundImage = global::WinformUI.Properties.Resources.demoCaro;
            this.btnCaro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCaro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.btnCaro.ForeColor = System.Drawing.Color.Black;
            this.btnCaro.Location = new System.Drawing.Point(12, 12);
            this.btnCaro.Name = "btnCaro";
            this.btnCaro.Size = new System.Drawing.Size(386, 57);
            this.btnCaro.TabIndex = 0;
            this.btnCaro.Tag = "1";
            this.btnCaro.Text = "Cờ caro";
            this.btnCaro.UseVisualStyleBackColor = true;
            this.btnCaro.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // frmPickGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 330);
            this.Controls.Add(this.dgvRoom);
            this.Controls.Add(this.btnNewRoom);
            this.Controls.Add(this.txtInputSearchRoom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVay);
            this.Controls.Add(this.btnVua);
            this.Controls.Add(this.btnTuong);
            this.Controls.Add(this.btnCaro);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPickGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn game";
            this.Load += new System.EventHandler(this.frmPickGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCaro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputSearchRoom;
        private System.Windows.Forms.Button btnNewRoom;
        private System.Windows.Forms.DataGridView dgvRoom;
        private System.Windows.Forms.Button btnTuong;
        private System.Windows.Forms.Button btnVua;
        private System.Windows.Forms.Button btnVay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}