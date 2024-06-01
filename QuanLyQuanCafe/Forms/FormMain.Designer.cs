namespace QuanLyQuanCafe
{
    partial class frmMain
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
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoHDN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoHDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiemHDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiemHDN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDonNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDonBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhaCungCap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCongDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoaiSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyQuanCafe = new System.Windows.Forms.MenuStrip();
            this.mnuQuanLyQuanCafe.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(61, 24);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBaoCaoHDN,
            this.mnuBaoCaoHDB,
            this.mnuBaoCaoDoanhThu});
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(77, 24);
            this.mnuBaoCao.Text = "Báo cáo";
            // 
            // mnuBaoCaoHDN
            // 
            this.mnuBaoCaoHDN.Name = "mnuBaoCaoHDN";
            this.mnuBaoCaoHDN.Size = new System.Drawing.Size(187, 26);
            this.mnuBaoCaoHDN.Text = "Hóa đơn nhập";
            this.mnuBaoCaoHDN.Click += new System.EventHandler(this.mnuBaoCaoHDN_Click);
            // 
            // mnuBaoCaoHDB
            // 
            this.mnuBaoCaoHDB.Name = "mnuBaoCaoHDB";
            this.mnuBaoCaoHDB.Size = new System.Drawing.Size(187, 26);
            this.mnuBaoCaoHDB.Text = "Hóa đơn bán";
            this.mnuBaoCaoHDB.Click += new System.EventHandler(this.mnuBaoCaoHDB_Click);
            // 
            // mnuBaoCaoDoanhThu
            // 
            this.mnuBaoCaoDoanhThu.Name = "mnuBaoCaoDoanhThu";
            this.mnuBaoCaoDoanhThu.Size = new System.Drawing.Size(187, 26);
            this.mnuBaoCaoDoanhThu.Text = "Doanh thu";
            this.mnuBaoCaoDoanhThu.Click += new System.EventHandler(this.mnuBaoCaoDoanhThu_Click);
            // 
            // mnuTimKiemHDB
            // 
            this.mnuTimKiemHDB.Name = "mnuTimKiemHDB";
            this.mnuTimKiemHDB.Size = new System.Drawing.Size(187, 26);
            this.mnuTimKiemHDB.Text = "Hóa đơn bán";
            this.mnuTimKiemHDB.Click += new System.EventHandler(this.mnuTimKiemHDB_Click);
            // 
            // mnuTimKiem
            // 
            this.mnuTimKiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimKiemHDN,
            this.mnuTimKiemHDB});
            this.mnuTimKiem.Name = "mnuTimKiem";
            this.mnuTimKiem.Size = new System.Drawing.Size(84, 24);
            this.mnuTimKiem.Text = "Tìm kiếm";
            // 
            // mnuTimKiemHDN
            // 
            this.mnuTimKiemHDN.Name = "mnuTimKiemHDN";
            this.mnuTimKiemHDN.Size = new System.Drawing.Size(187, 26);
            this.mnuTimKiemHDN.Text = "Hóa đơn nhập";
            this.mnuTimKiemHDN.Click += new System.EventHandler(this.mnuTimKiemHDN_Click);
            // 
            // mnuHoaDon
            // 
            this.mnuHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoaDonNhap,
            this.mnuHoaDonBan});
            this.mnuHoaDon.Name = "mnuHoaDon";
            this.mnuHoaDon.Size = new System.Drawing.Size(81, 24);
            this.mnuHoaDon.Text = "Hóa đơn";
            // 
            // mnuHoaDonNhap
            // 
            this.mnuHoaDonNhap.Name = "mnuHoaDonNhap";
            this.mnuHoaDonNhap.Size = new System.Drawing.Size(187, 26);
            this.mnuHoaDonNhap.Text = "Hóa đơn nhập";
            this.mnuHoaDonNhap.Click += new System.EventHandler(this.mnuHoaDonNhap_Click);
            // 
            // mnuHoaDonBan
            // 
            this.mnuHoaDonBan.Name = "mnuHoaDonBan";
            this.mnuHoaDonBan.Size = new System.Drawing.Size(187, 26);
            this.mnuHoaDonBan.Text = "Hóa đơn bán";
            this.mnuHoaDonBan.Click += new System.EventHandler(this.mnuHoaDonBan_Click);
            // 
            // mnuNhaCungCap
            // 
            this.mnuNhaCungCap.Name = "mnuNhaCungCap";
            this.mnuNhaCungCap.Size = new System.Drawing.Size(183, 26);
            this.mnuNhaCungCap.Text = "Nhà cung cấp";
            this.mnuNhaCungCap.Click += new System.EventHandler(this.mnuNhaCungCap_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(183, 26);
            this.mnuKhachHang.Text = "Khách hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(183, 26);
            this.mnuNhanVien.Text = "Nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuSanPham
            // 
            this.mnuSanPham.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCongDung,
            this.mnuLoaiSanPham});
            this.mnuSanPham.Name = "mnuSanPham";
            this.mnuSanPham.Size = new System.Drawing.Size(183, 26);
            this.mnuSanPham.Text = "Sản phẩm";
            this.mnuSanPham.Click += new System.EventHandler(this.mnuSanPham_Click);
            // 
            // mnuCongDung
            // 
            this.mnuCongDung.Name = "mnuCongDung";
            this.mnuCongDung.Size = new System.Drawing.Size(188, 26);
            this.mnuCongDung.Text = "Công dụng";
            this.mnuCongDung.Click += new System.EventHandler(this.mnuCongDung_Click);
            // 
            // mnuLoaiSanPham
            // 
            this.mnuLoaiSanPham.Name = "mnuLoaiSanPham";
            this.mnuLoaiSanPham.Size = new System.Drawing.Size(188, 26);
            this.mnuLoaiSanPham.Text = "Loại sản phẩm";
            this.mnuLoaiSanPham.Click += new System.EventHandler(this.mnuLoaiSanPham_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSanPham,
            this.mnuNhanVien,
            this.mnuKhachHang,
            this.mnuNhaCungCap});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(90, 24);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuQuanLyQuanCafe
            // 
            this.mnuQuanLyQuanCafe.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuQuanLyQuanCafe.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMuc,
            this.mnuHoaDon,
            this.mnuTimKiem,
            this.mnuBaoCao,
            this.mnuThoat});
            this.mnuQuanLyQuanCafe.Location = new System.Drawing.Point(0, 0);
            this.mnuQuanLyQuanCafe.Name = "mnuQuanLyQuanCafe";
            this.mnuQuanLyQuanCafe.Size = new System.Drawing.Size(800, 28);
            this.mnuQuanLyQuanCafe.TabIndex = 9;
            this.mnuQuanLyQuanCafe.Text = "Menu Quản Lý Quán Cafe";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mnuQuanLyQuanCafe);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Quán Cafe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuQuanLyQuanCafe.ResumeLayout(false);
            this.mnuQuanLyQuanCafe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiemHDB;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDonBan;
        private System.Windows.Forms.ToolStripMenuItem mnuNhaCungCap;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuSanPham;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.MenuStrip mnuQuanLyQuanCafe;
        private System.Windows.Forms.ToolStripMenuItem mnuCongDung;
        private System.Windows.Forms.ToolStripMenuItem mnuLoaiSanPham;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDonNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiemHDN;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoHDB;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoHDN;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoDoanhThu;
    }
}

