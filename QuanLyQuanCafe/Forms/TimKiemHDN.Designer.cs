namespace QuanLyQuanCafe.Forms
{
    partial class frmTimKiemHDN
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
            this.btnTimLai = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvTimKiemHDN = new System.Windows.Forms.DataGridView();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblMaHDN = new System.Windows.Forms.Label();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.lblTKHoaDonNhap = new System.Windows.Forms.Label();
            this.gbxHoaDonNhap = new System.Windows.Forms.GroupBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.cboMaNCC = new System.Windows.Forms.ComboBox();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.cboMaHDN = new System.Windows.Forms.ComboBox();
            this.labelChuthich = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemHDN)).BeginInit();
            this.gbxHoaDonNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(750, 690);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(88, 40);
            this.btnDong.TabIndex = 137;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimLai
            // 
            this.btnTimLai.Location = new System.Drawing.Point(610, 690);
            this.btnTimLai.Name = "btnTimLai";
            this.btnTimLai.Size = new System.Drawing.Size(102, 40);
            this.btnTimLai.TabIndex = 136;
            this.btnTimLai.Text = "Tìm lại";
            this.btnTimLai.UseVisualStyleBackColor = true;
            this.btnTimLai.Click += new System.EventHandler(this.btnTimLai_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(471, 690);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(102, 40);
            this.btnTimKiem.TabIndex = 135;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvTimKiemHDN
            // 
            this.dgvTimKiemHDN.AllowUserToOrderColumns = true;
            this.dgvTimKiemHDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemHDN.Location = new System.Drawing.Point(32, 259);
            this.dgvTimKiemHDN.Name = "dgvTimKiemHDN";
            this.dgvTimKiemHDN.RowHeadersWidth = 51;
            this.dgvTimKiemHDN.RowTemplate.Height = 24;
            this.dgvTimKiemHDN.Size = new System.Drawing.Size(806, 389);
            this.dgvTimKiemHDN.TabIndex = 134;
            this.dgvTimKiemHDN.DoubleClick += new System.EventHandler(this.dgvTimKiemHDN_DoubleClick);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(560, 81);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(187, 22);
            this.txtTongTien.TabIndex = 133;
            this.txtTongTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongTien_KeyPress);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(466, 82);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(73, 18);
            this.lblTongTien.TabIndex = 128;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayNhap.Location = new System.Drawing.Point(466, 37);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(82, 18);
            this.lblNgayNhap.TabIndex = 127;
            this.lblNgayNhap.Text = "Ngày nhập:";
            // 
            // lblMaHDN
            // 
            this.lblMaHDN.AutoSize = true;
            this.lblMaHDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDN.Location = new System.Drawing.Point(36, 37);
            this.lblMaHDN.Name = "lblMaHDN";
            this.lblMaHDN.Size = new System.Drawing.Size(127, 18);
            this.lblMaHDN.TabIndex = 124;
            this.lblMaHDN.Text = "Mã hóa đơn nhập:";
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNCC.Location = new System.Drawing.Point(36, 128);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(125, 18);
            this.lblMaNCC.TabIndex = 126;
            this.lblMaNCC.Text = "Mã nhà cung cấp:";
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNhanVien.Location = new System.Drawing.Point(36, 82);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(99, 18);
            this.lblMaNhanVien.TabIndex = 125;
            this.lblMaNhanVien.Text = "Mã nhân viên:";
            // 
            // lblTKHoaDonNhap
            // 
            this.lblTKHoaDonNhap.AutoSize = true;
            this.lblTKHoaDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTKHoaDonNhap.Location = new System.Drawing.Point(288, 35);
            this.lblTKHoaDonNhap.Name = "lblTKHoaDonNhap";
            this.lblTKHoaDonNhap.Size = new System.Drawing.Size(306, 26);
            this.lblTKHoaDonNhap.TabIndex = 122;
            this.lblTKHoaDonNhap.Text = "TÌM KIẾM HÓA ĐƠN NHẬP";
            // 
            // gbxHoaDonNhap
            // 
            this.gbxHoaDonNhap.Controls.Add(this.dtpNgayNhap);
            this.gbxHoaDonNhap.Controls.Add(this.cboMaNCC);
            this.gbxHoaDonNhap.Controls.Add(this.cboMaNhanVien);
            this.gbxHoaDonNhap.Controls.Add(this.cboMaHDN);
            this.gbxHoaDonNhap.Controls.Add(this.lblMaHDN);
            this.gbxHoaDonNhap.Controls.Add(this.lblMaNhanVien);
            this.gbxHoaDonNhap.Controls.Add(this.lblMaNCC);
            this.gbxHoaDonNhap.Controls.Add(this.txtTongTien);
            this.gbxHoaDonNhap.Controls.Add(this.lblTongTien);
            this.gbxHoaDonNhap.Controls.Add(this.lblNgayNhap);
            this.gbxHoaDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxHoaDonNhap.Location = new System.Drawing.Point(32, 67);
            this.gbxHoaDonNhap.Name = "gbxHoaDonNhap";
            this.gbxHoaDonNhap.Size = new System.Drawing.Size(806, 177);
            this.gbxHoaDonNhap.TabIndex = 123;
            this.gbxHoaDonNhap.TabStop = false;
            this.gbxHoaDonNhap.Text = "Thông tin tìm kiếm";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(560, 34);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(187, 24);
            this.dtpNgayNhap.TabIndex = 132;
            // 
            // cboMaNCC
            // 
            this.cboMaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNCC.FormattingEnabled = true;
            this.cboMaNCC.Location = new System.Drawing.Point(176, 125);
            this.cboMaNCC.Name = "cboMaNCC";
            this.cboMaNCC.Size = new System.Drawing.Size(187, 24);
            this.cboMaNCC.TabIndex = 131;
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(176, 79);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(187, 24);
            this.cboMaNhanVien.TabIndex = 130;
            // 
            // cboMaHDN
            // 
            this.cboMaHDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaHDN.FormattingEnabled = true;
            this.cboMaHDN.Location = new System.Drawing.Point(176, 34);
            this.cboMaHDN.Name = "cboMaHDN";
            this.cboMaHDN.Size = new System.Drawing.Size(187, 24);
            this.cboMaHDN.TabIndex = 129;
            // 
            // labelChuthich
            // 
            this.labelChuthich.AutoSize = true;
            this.labelChuthich.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChuthich.Location = new System.Drawing.Point(61, 663);
            this.labelChuthich.Name = "labelChuthich";
            this.labelChuthich.Size = new System.Drawing.Size(413, 18);
            this.labelChuthich.TabIndex = 188;
            this.labelChuthich.Text = "* Kích đúp vào một hàng để xem chi tiết hóa đơn nhập";
            // 
            // frmTimKiemHDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 754);
            this.Controls.Add(this.labelChuthich);
            this.Controls.Add(this.gbxHoaDonNhap);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimLai);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgvTimKiemHDN);
            this.Controls.Add(this.lblTKHoaDonNhap);
            this.Name = "frmTimKiemHDN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Kiếm Hóa Đơn Nhập";
            this.Load += new System.EventHandler(this.frmTimKiemHDN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemHDN)).EndInit();
            this.gbxHoaDonNhap.ResumeLayout(false);
            this.gbxHoaDonNhap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimLai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTimKiemHDN;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblMaHDN;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.Label lblTKHoaDonNhap;
        private System.Windows.Forms.GroupBox gbxHoaDonNhap;
        private System.Windows.Forms.ComboBox cboMaNhanVien;
        private System.Windows.Forms.ComboBox cboMaHDN;
        private System.Windows.Forms.ComboBox cboMaNCC;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label labelChuthich;
    }
}