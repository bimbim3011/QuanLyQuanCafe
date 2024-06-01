namespace QuanLyQuanCafe.Forms
{
    partial class frmBaoCaoHDN
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
            this.labelHDN = new System.Windows.Forms.Label();
            this.labelNgaykt = new System.Windows.Forms.Label();
            this.labelNgaybd = new System.Windows.Forms.Label();
            this.maskedNgaykt = new System.Windows.Forms.MaskedTextBox();
            this.maskedNgaybd = new System.Windows.Forms.MaskedTextBox();
            this.maskNgay = new System.Windows.Forms.MaskedTextBox();
            this.labelNgay = new System.Windows.Forms.Label();
            this.buttonDong = new System.Windows.Forms.Button();
            this.gbxThongtin = new System.Windows.Forms.GroupBox();
            this.textDongianhap = new System.Windows.Forms.TextBox();
            this.labelDongianhap = new System.Windows.Forms.Label();
            this.buttonTimkiem = new System.Windows.Forms.Button();
            this.comboMaNV = new System.Windows.Forms.ComboBox();
            this.comboMaNCC = new System.Windows.Forms.ComboBox();
            this.labelTenNV = new System.Windows.Forms.Label();
            this.labelNCC = new System.Windows.Forms.Label();
            this.comboMaSP = new System.Windows.Forms.ComboBox();
            this.labelTenSP = new System.Windows.Forms.Label();
            this.comboMaHD = new System.Windows.Forms.ComboBox();
            this.labelMaHD = new System.Windows.Forms.Label();
            this.buttonInBC = new System.Windows.Forms.Button();
            this.dataGridViewSanpham = new System.Windows.Forms.DataGridView();
            this.dataGridViewHoadon = new System.Windows.Forms.DataGridView();
            this.gbxThongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanpham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHDN
            // 
            this.labelHDN.AutoSize = true;
            this.labelHDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHDN.Location = new System.Drawing.Point(475, 37);
            this.labelHDN.Name = "labelHDN";
            this.labelHDN.Size = new System.Drawing.Size(477, 32);
            this.labelHDN.TabIndex = 241;
            this.labelHDN.Text = "BÁO CÁO HÓA ĐƠN NHẬP HÀNG";
            // 
            // labelNgaykt
            // 
            this.labelNgaykt.AutoSize = true;
            this.labelNgaykt.Location = new System.Drawing.Point(960, 96);
            this.labelNgaykt.Name = "labelNgaykt";
            this.labelNgaykt.Size = new System.Drawing.Size(32, 18);
            this.labelNgaykt.TabIndex = 249;
            this.labelNgaykt.Text = "đến";
            // 
            // labelNgaybd
            // 
            this.labelNgaybd.AutoSize = true;
            this.labelNgaybd.Location = new System.Drawing.Point(678, 96);
            this.labelNgaybd.Name = "labelNgaybd";
            this.labelNgaybd.Size = new System.Drawing.Size(95, 18);
            this.labelNgaybd.TabIndex = 248;
            this.labelNgaybd.Text = "Theo khoảng";
            // 
            // maskedNgaykt
            // 
            this.maskedNgaykt.Location = new System.Drawing.Point(1012, 93);
            this.maskedNgaykt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedNgaykt.Mask = "00/00/0000";
            this.maskedNgaykt.Name = "maskedNgaykt";
            this.maskedNgaykt.Size = new System.Drawing.Size(156, 24);
            this.maskedNgaykt.TabIndex = 256;
            this.maskedNgaykt.ValidatingType = typeof(System.DateTime);
            // 
            // maskedNgaybd
            // 
            this.maskedNgaybd.Location = new System.Drawing.Point(786, 93);
            this.maskedNgaybd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedNgaybd.Mask = "00/00/0000";
            this.maskedNgaybd.Name = "maskedNgaybd";
            this.maskedNgaybd.Size = new System.Drawing.Size(156, 24);
            this.maskedNgaybd.TabIndex = 255;
            this.maskedNgaybd.ValidatingType = typeof(System.DateTime);
            // 
            // maskNgay
            // 
            this.maskNgay.Location = new System.Drawing.Point(786, 38);
            this.maskNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskNgay.Mask = "00/00/0000";
            this.maskNgay.Name = "maskNgay";
            this.maskNgay.Size = new System.Drawing.Size(156, 24);
            this.maskNgay.TabIndex = 254;
            this.maskNgay.ValidatingType = typeof(System.DateTime);
            // 
            // labelNgay
            // 
            this.labelNgay.AutoSize = true;
            this.labelNgay.Location = new System.Drawing.Point(678, 41);
            this.labelNgay.Name = "labelNgay";
            this.labelNgay.Size = new System.Drawing.Size(77, 18);
            this.labelNgay.TabIndex = 247;
            this.labelNgay.Text = "Theo ngày";
            // 
            // buttonDong
            // 
            this.buttonDong.Location = new System.Drawing.Point(1270, 776);
            this.buttonDong.Name = "buttonDong";
            this.buttonDong.Size = new System.Drawing.Size(94, 43);
            this.buttonDong.TabIndex = 261;
            this.buttonDong.Text = "Đóng";
            this.buttonDong.UseVisualStyleBackColor = true;
            // 
            // gbxThongtin
            // 
            this.gbxThongtin.Controls.Add(this.textDongianhap);
            this.gbxThongtin.Controls.Add(this.labelNgaykt);
            this.gbxThongtin.Controls.Add(this.labelDongianhap);
            this.gbxThongtin.Controls.Add(this.labelNgaybd);
            this.gbxThongtin.Controls.Add(this.maskedNgaykt);
            this.gbxThongtin.Controls.Add(this.maskedNgaybd);
            this.gbxThongtin.Controls.Add(this.maskNgay);
            this.gbxThongtin.Controls.Add(this.labelNgay);
            this.gbxThongtin.Controls.Add(this.buttonTimkiem);
            this.gbxThongtin.Controls.Add(this.comboMaNV);
            this.gbxThongtin.Controls.Add(this.comboMaNCC);
            this.gbxThongtin.Controls.Add(this.labelTenNV);
            this.gbxThongtin.Controls.Add(this.labelNCC);
            this.gbxThongtin.Controls.Add(this.comboMaSP);
            this.gbxThongtin.Controls.Add(this.labelTenSP);
            this.gbxThongtin.Controls.Add(this.comboMaHD);
            this.gbxThongtin.Controls.Add(this.labelMaHD);
            this.gbxThongtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxThongtin.Location = new System.Drawing.Point(48, 83);
            this.gbxThongtin.Name = "gbxThongtin";
            this.gbxThongtin.Size = new System.Drawing.Size(1316, 225);
            this.gbxThongtin.TabIndex = 242;
            this.gbxThongtin.TabStop = false;
            this.gbxThongtin.Text = "Thông tin hóa đơn";
            // 
            // textDongianhap
            // 
            this.textDongianhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDongianhap.Location = new System.Drawing.Point(473, 147);
            this.textDongianhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDongianhap.Name = "textDongianhap";
            this.textDongianhap.Size = new System.Drawing.Size(162, 24);
            this.textDongianhap.TabIndex = 263;
            // 
            // labelDongianhap
            // 
            this.labelDongianhap.AutoSize = true;
            this.labelDongianhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDongianhap.Location = new System.Drawing.Point(333, 150);
            this.labelDongianhap.Name = "labelDongianhap";
            this.labelDongianhap.Size = new System.Drawing.Size(95, 18);
            this.labelDongianhap.TabIndex = 262;
            this.labelDongianhap.Text = "Đơn giá nhập";
            // 
            // buttonTimkiem
            // 
            this.buttonTimkiem.Location = new System.Drawing.Point(1200, 169);
            this.buttonTimkiem.Name = "buttonTimkiem";
            this.buttonTimkiem.Size = new System.Drawing.Size(89, 37);
            this.buttonTimkiem.TabIndex = 257;
            this.buttonTimkiem.Text = "Tìm kiếm";
            this.buttonTimkiem.UseVisualStyleBackColor = true;
            this.buttonTimkiem.Click += new System.EventHandler(this.buttonTimkiem_Click);
            // 
            // comboMaNV
            // 
            this.comboMaNV.FormattingEnabled = true;
            this.comboMaNV.Location = new System.Drawing.Point(473, 93);
            this.comboMaNV.Name = "comboMaNV";
            this.comboMaNV.Size = new System.Drawing.Size(162, 26);
            this.comboMaNV.TabIndex = 253;
            // 
            // comboMaNCC
            // 
            this.comboMaNCC.FormattingEnabled = true;
            this.comboMaNCC.Location = new System.Drawing.Point(473, 38);
            this.comboMaNCC.Name = "comboMaNCC";
            this.comboMaNCC.Size = new System.Drawing.Size(162, 26);
            this.comboMaNCC.TabIndex = 252;
            // 
            // labelTenNV
            // 
            this.labelTenNV.Location = new System.Drawing.Point(333, 96);
            this.labelTenNV.Name = "labelTenNV";
            this.labelTenNV.Size = new System.Drawing.Size(101, 18);
            this.labelTenNV.TabIndex = 246;
            this.labelTenNV.Text = "Mã nhân viên";
            // 
            // labelNCC
            // 
            this.labelNCC.Location = new System.Drawing.Point(333, 41);
            this.labelNCC.Name = "labelNCC";
            this.labelNCC.Size = new System.Drawing.Size(121, 17);
            this.labelNCC.TabIndex = 245;
            this.labelNCC.Text = "Mã nhà cung cấp";
            // 
            // comboMaSP
            // 
            this.comboMaSP.FormattingEnabled = true;
            this.comboMaSP.Location = new System.Drawing.Point(132, 93);
            this.comboMaSP.Name = "comboMaSP";
            this.comboMaSP.Size = new System.Drawing.Size(156, 26);
            this.comboMaSP.TabIndex = 251;
            // 
            // labelTenSP
            // 
            this.labelTenSP.Location = new System.Drawing.Point(25, 96);
            this.labelTenSP.Name = "labelTenSP";
            this.labelTenSP.Size = new System.Drawing.Size(101, 18);
            this.labelTenSP.TabIndex = 244;
            this.labelTenSP.Text = "Mã sản phẩm";
            // 
            // comboMaHD
            // 
            this.comboMaHD.FormattingEnabled = true;
            this.comboMaHD.Location = new System.Drawing.Point(132, 38);
            this.comboMaHD.Name = "comboMaHD";
            this.comboMaHD.Size = new System.Drawing.Size(156, 26);
            this.comboMaHD.TabIndex = 250;
            // 
            // labelMaHD
            // 
            this.labelMaHD.Location = new System.Drawing.Point(25, 41);
            this.labelMaHD.Name = "labelMaHD";
            this.labelMaHD.Size = new System.Drawing.Size(101, 18);
            this.labelMaHD.TabIndex = 243;
            this.labelMaHD.Text = "Mã hóa đơn";
            // 
            // buttonInBC
            // 
            this.buttonInBC.Location = new System.Drawing.Point(1130, 776);
            this.buttonInBC.Name = "buttonInBC";
            this.buttonInBC.Size = new System.Drawing.Size(113, 43);
            this.buttonInBC.TabIndex = 260;
            this.buttonInBC.Text = "In";
            this.buttonInBC.UseVisualStyleBackColor = true;
            this.buttonInBC.Click += new System.EventHandler(this.buttonInBC_Click);
            // 
            // dataGridViewSanpham
            // 
            this.dataGridViewSanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSanpham.Location = new System.Drawing.Point(962, 333);
            this.dataGridViewSanpham.Name = "dataGridViewSanpham";
            this.dataGridViewSanpham.RowHeadersWidth = 62;
            this.dataGridViewSanpham.RowTemplate.Height = 24;
            this.dataGridViewSanpham.Size = new System.Drawing.Size(402, 415);
            this.dataGridViewSanpham.TabIndex = 259;
            // 
            // dataGridViewHoadon
            // 
            this.dataGridViewHoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHoadon.Location = new System.Drawing.Point(48, 333);
            this.dataGridViewHoadon.Name = "dataGridViewHoadon";
            this.dataGridViewHoadon.RowHeadersWidth = 62;
            this.dataGridViewHoadon.RowTemplate.Height = 24;
            this.dataGridViewHoadon.Size = new System.Drawing.Size(887, 415);
            this.dataGridViewHoadon.TabIndex = 258;
            // 
            // frmBaoCaoHDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1412, 854);
            this.Controls.Add(this.labelHDN);
            this.Controls.Add(this.buttonDong);
            this.Controls.Add(this.gbxThongtin);
            this.Controls.Add(this.buttonInBC);
            this.Controls.Add(this.dataGridViewSanpham);
            this.Controls.Add(this.dataGridViewHoadon);
            this.Name = "frmBaoCaoHDN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Hóa Đơn Nhập";
            this.Load += new System.EventHandler(this.frmBaoCaoHDN_Load);
            this.gbxThongtin.ResumeLayout(false);
            this.gbxThongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanpham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoadon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHDN;
        private System.Windows.Forms.Label labelNgaykt;
        private System.Windows.Forms.Label labelNgaybd;
        private System.Windows.Forms.MaskedTextBox maskedNgaykt;
        private System.Windows.Forms.MaskedTextBox maskedNgaybd;
        private System.Windows.Forms.MaskedTextBox maskNgay;
        private System.Windows.Forms.Label labelNgay;
        private System.Windows.Forms.Button buttonDong;
        private System.Windows.Forms.GroupBox gbxThongtin;
        private System.Windows.Forms.Button buttonTimkiem;
        private System.Windows.Forms.ComboBox comboMaNV;
        private System.Windows.Forms.ComboBox comboMaNCC;
        private System.Windows.Forms.Label labelTenNV;
        private System.Windows.Forms.Label labelNCC;
        private System.Windows.Forms.ComboBox comboMaSP;
        private System.Windows.Forms.Label labelTenSP;
        private System.Windows.Forms.ComboBox comboMaHD;
        private System.Windows.Forms.Label labelMaHD;
        private System.Windows.Forms.Button buttonInBC;
        private System.Windows.Forms.DataGridView dataGridViewSanpham;
        private System.Windows.Forms.DataGridView dataGridViewHoadon;
        private System.Windows.Forms.TextBox textDongianhap;
        private System.Windows.Forms.Label labelDongianhap;
    }
}