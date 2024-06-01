namespace QuanLyQuanCafe.Forms
{
    partial class frmCongDung
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
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvCongDung = new System.Windows.Forms.DataGridView();
            this.txtTenCongDung = new System.Windows.Forms.TextBox();
            this.txtMaCongDung = new System.Windows.Forms.TextBox();
            this.lblTenCongDung = new System.Windows.Forms.Label();
            this.lblMaCongDung = new System.Windows.Forms.Label();
            this.lblDMCongDung = new System.Windows.Forms.Label();
            this.gbxCongDung = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongDung)).BeginInit();
            this.gbxCongDung.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(631, 547);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(88, 40);
            this.btnDong.TabIndex = 22;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(522, 547);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(88, 40);
            this.btnBoQua.TabIndex = 21;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(411, 547);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(88, 40);
            this.btnLuu.TabIndex = 20;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(189, 547);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 40);
            this.btnSua.TabIndex = 18;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(302, 547);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 40);
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(81, 547);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 40);
            this.btnThem.TabIndex = 17;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvCongDung
            // 
            this.dgvCongDung.AllowUserToOrderColumns = true;
            this.dgvCongDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongDung.Location = new System.Drawing.Point(51, 196);
            this.dgvCongDung.Name = "dgvCongDung";
            this.dgvCongDung.RowHeadersWidth = 51;
            this.dgvCongDung.RowTemplate.Height = 24;
            this.dgvCongDung.Size = new System.Drawing.Size(703, 333);
            this.dgvCongDung.TabIndex = 16;
            this.dgvCongDung.Click += new System.EventHandler(this.dgvCongDung_Click);
            // 
            // txtTenCongDung
            // 
            this.txtTenCongDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenCongDung.Location = new System.Drawing.Point(155, 72);
            this.txtTenCongDung.Name = "txtTenCongDung";
            this.txtTenCongDung.Size = new System.Drawing.Size(187, 22);
            this.txtTenCongDung.TabIndex = 15;
            // 
            // txtMaCongDung
            // 
            this.txtMaCongDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCongDung.Location = new System.Drawing.Point(155, 32);
            this.txtMaCongDung.Name = "txtMaCongDung";
            this.txtMaCongDung.Size = new System.Drawing.Size(187, 22);
            this.txtMaCongDung.TabIndex = 14;
            this.txtMaCongDung.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMaCongDung_KeyUp);
            // 
            // lblTenCongDung
            // 
            this.lblTenCongDung.AutoSize = true;
            this.lblTenCongDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCongDung.Location = new System.Drawing.Point(30, 73);
            this.lblTenCongDung.Name = "lblTenCongDung";
            this.lblTenCongDung.Size = new System.Drawing.Size(110, 18);
            this.lblTenCongDung.TabIndex = 13;
            this.lblTenCongDung.Text = "Tên công dụng:";
            // 
            // lblMaCongDung
            // 
            this.lblMaCongDung.AutoSize = true;
            this.lblMaCongDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaCongDung.Location = new System.Drawing.Point(30, 33);
            this.lblMaCongDung.Name = "lblMaCongDung";
            this.lblMaCongDung.Size = new System.Drawing.Size(106, 18);
            this.lblMaCongDung.TabIndex = 12;
            this.lblMaCongDung.Text = "Mã công dụng:";
            // 
            // lblDMCongDung
            // 
            this.lblDMCongDung.AutoSize = true;
            this.lblDMCongDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDMCongDung.Location = new System.Drawing.Point(259, 29);
            this.lblDMCongDung.Name = "lblDMCongDung";
            this.lblDMCongDung.Size = new System.Drawing.Size(292, 26);
            this.lblDMCongDung.TabIndex = 10;
            this.lblDMCongDung.Text = "DANH MỤC CÔNG DỤNG";
            // 
            // gbxCongDung
            // 
            this.gbxCongDung.Controls.Add(this.txtTenCongDung);
            this.gbxCongDung.Controls.Add(this.lblMaCongDung);
            this.gbxCongDung.Controls.Add(this.lblTenCongDung);
            this.gbxCongDung.Controls.Add(this.txtMaCongDung);
            this.gbxCongDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCongDung.Location = new System.Drawing.Point(51, 71);
            this.gbxCongDung.Name = "gbxCongDung";
            this.gbxCongDung.Size = new System.Drawing.Size(703, 110);
            this.gbxCongDung.TabIndex = 11;
            this.gbxCongDung.TabStop = false;
            this.gbxCongDung.Text = "Thông tin chi tiết";
            // 
            // frmCongDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 616);
            this.Controls.Add(this.gbxCongDung);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvCongDung);
            this.Controls.Add(this.lblDMCongDung);
            this.Name = "frmCongDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công Dụng";
            this.Load += new System.EventHandler(this.frmCongDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongDung)).EndInit();
            this.gbxCongDung.ResumeLayout(false);
            this.gbxCongDung.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvCongDung;
        private System.Windows.Forms.TextBox txtTenCongDung;
        private System.Windows.Forms.TextBox txtMaCongDung;
        private System.Windows.Forms.Label lblTenCongDung;
        private System.Windows.Forms.Label lblMaCongDung;
        private System.Windows.Forms.Label lblDMCongDung;
        private System.Windows.Forms.GroupBox gbxCongDung;
    }
}