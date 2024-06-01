using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            Forms.frmSanPham f = new Forms.frmSanPham();
            f.Show();
        }

        private void mnuCongDung_Click(object sender, EventArgs e)
        {
            Forms.frmCongDung f = new Forms.frmCongDung();
            f.Show();
        }

        private void mnuLoaiSanPham_Click(object sender, EventArgs e)
        {
            Forms.frmLoaiSanPham f = new Forms.frmLoaiSanPham();
            f.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            Forms.frmNhanVien f = new Forms.frmNhanVien();
            f.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            Forms.frmKhachHang f = new Forms.frmKhachHang();
            f.Show();
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            Forms.frmNhaCungCap f = new Forms.frmNhaCungCap();
            f.Show();
        }

        private void mnuHoaDonNhap_Click(object sender, EventArgs e)
        {
            Forms.frmHoaDonNhap f = new Forms.frmHoaDonNhap();
            f.Show();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            Forms.frmHoaDonBan f = new Forms.frmHoaDonBan();
            f.Show();
        }

        private void mnuTimKiemHDN_Click(object sender, EventArgs e)
        {
            Forms.frmTimKiemHDN f = new Forms.frmTimKiemHDN();
            f.Show();
        }

        private void mnuTimKiemHDB_Click(object sender, EventArgs e)
        {
            Forms.frmTimKiemHDB f = new Forms.frmTimKiemHDB();
            f.Show();
        }

        private void mnuBaoCaoHDN_Click(object sender, EventArgs e)
        {
            Forms.frmBaoCaoHDN f = new Forms.frmBaoCaoHDN();
            f.Show();
        }

        private void mnuBaoCaoHDB_Click(object sender, EventArgs e)
        {
            Forms.frmBaoCaoHDB f = new Forms.frmBaoCaoHDB();
            f.Show();
        }

        private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            Forms.frmBaoCaoDoanhThu f = new Forms.frmBaoCaoDoanhThu();
            f.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Class.Functions.Disconnect();
                Application.Exit();
            }
        }
    }
}