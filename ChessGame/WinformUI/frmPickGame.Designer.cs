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
            this.Game = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // 
            // btnNewRoom
            // 
            this.btnNewRoom.Location = new System.Drawing.Point(672, 7);
            this.btnNewRoom.Name = "btnNewRoom";
            this.btnNewRoom.Size = new System.Drawing.Size(88, 25);
            this.btnNewRoom.TabIndex = 3;
            this.btnNewRoom.Text = "Tạo phòng";
            this.btnNewRoom.UseVisualStyleBackColor = true;
            // 
            // dgvRoom
            // 
            this.dgvRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Game,
            this.Status,
            this.Action});
            this.dgvRoom.Location = new System.Drawing.Point(417, 48);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.Size = new System.Drawing.Size(378, 258);
            this.dgvRoom.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Game
            // 
            this.Game.HeaderText = "Game";
            this.Game.Name = "Game";
            // 
            // Status
            // 
            this.Status.HeaderText = "Trạng thái";
            this.Status.Name = "Status";
            // 
            // Action
            // 
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
            this.btnVay.Text = "Cờ vây";
            this.btnVay.UseVisualStyleBackColor = true;
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
            this.btnVua.Text = "Cờ vua";
            this.btnVua.UseVisualStyleBackColor = true;
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
            this.btnTuong.Text = "Cờ tướng";
            this.btnTuong.UseVisualStyleBackColor = true;
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
            this.btnCaro.Text = "Cờ caro";
            this.btnCaro.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Game;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.Button btnTuong;
        private System.Windows.Forms.Button btnVua;
        private System.Windows.Forms.Button btnVay;
    }
}