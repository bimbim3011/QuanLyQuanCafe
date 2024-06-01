using QuanLyQuanCafe.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        DataTable tblDT;
        private void baocaodoanhthu_Load(object sender, EventArgs e)
        {
            Load_DataGridView("SELECT tblHoaDonBan.NgayBan, tblSanPham.TenSP, tblChiTietHDB.SoLuong AS SoLuongBan, tblSanPham.GiaBan AS DonGiaBan, (tblChiTietHDB.SoLuong * tblSanPham.GiaBan) AS DoanhThu FROM tblHoaDonBan JOIN tblChiTietHDB ON tblHoaDonBan.MaHDB = tblChiTietHDB.MaHDB, JOIN tblSanPham ON tblChiTietHDB.MaSP = tblSanPham.MaSP;");
            Functions.FillCombo("SELECT TenSP from tblSanPham", cboTenSP, "TenSP", "TenSP");
            cboTenSP.SelectedIndex = -1;
            txtTongTien.Text = Functions.GetFieldValues("SELECT (tblChiTietHDB.SoLuong * tblSanPham.GiaBan) AS DoanhThu FROM tblHoaDonBan");
            mskTheoNgay.Enabled = false;
            grbKhoang.Enabled = false;
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongTien.Text);
            txtSoLuong.Text = Functions.GetFieldValues("SELECT tblChiTietHDB.SoLuong AS SoLuongBan FROM tblHoaDonBan");
            txtTongTien.Enabled = false;
            txtSoLuong.Enabled = false;
        }
        private void Load_DataGridView(string sql)
        {
            tblDT = Functions.GetDataToTable(sql);
            dgvBaoCaoDoanhThu.DataSource = tblDT;
            dgvBaoCaoDoanhThu.Columns[0].HeaderText = "Ngày bán";

            dgvBaoCaoDoanhThu.Columns[1].HeaderText = "Tên sản phẩm";
            dgvBaoCaoDoanhThu.Columns[2].HeaderText = "Số lượng bán";
            dgvBaoCaoDoanhThu.Columns[3].HeaderText = "Đơn giá bán";
            dgvBaoCaoDoanhThu.Columns[4].HeaderText = "Doanh thu";
            dgvBaoCaoDoanhThu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Reset()
        {
            mskTheoNgay.Text = "";
            cboTenSP.Text = "";
            txtTongTien.Text = "";
            txtSoLuong.Text = "0";
            txtGiaBan.Text = "0";
            txtSoLuong.Enabled = false;
            txtGiaBan.Enabled = false;
            txtDoanhThu.Text = "0";
            txtDoanhThu.Enabled = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboTenSP.SelectedValue == null && txtGiaBan.Text == "" && mskTheoNgay.Text == "  /  /" && txtDoanhThu.Text == null && mskTheoKhoang1.Text == "  /  /" && mskTheoKhoang2.Text == "  /  /")
            {
                MessageBox.Show("Hãy nhập ít nhất 1 dữ liệu để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "select * from tbl_doanhthu where 1=1";
            if (cboTenSP.SelectedValue != null)
            {
                sql += " and tensanpham = N'" + cboTenSP.Text + "'";
            }

            if (txtGiaBan.Text != "")
            {
                sql += " and gia_san_pham = " + txtGiaBan.Text;
            }
            if (mskTheoNgay.Text != "  /  /")
            {
                if (!Functions.IsDate(mskTheoNgay.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskTheoNgay.Focus();
                    mskTheoNgay.Text = "";
                    return;
                }
                sql += " and ngayban = '" + Functions.ConvertDateTime(mskTheoNgay.Text) + "'";
            }
            if (mskTheoKhoang1.Text != "  /  /" && mskTheoKhoang2.Text != "  /  /")
            {
                if (!Functions.IsDate(mskTheoKhoang2.Text) || !Functions.IsDate(mskTheoKhoang1.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskTheoKhoang2.Focus();
                    mskTheoKhoang2.Text = "";
                    mskTheoKhoang1.Text = "";
                    return;
                }
                if (DateTime.ParseExact(mskTheoKhoang1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(mskTheoKhoang2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskTheoKhoang2.Text = "";
                    mskTheoKhoang1.Text = "";
                    return;
                }
                sql += " and ngayban between '" + Functions.ConvertDateTime(mskTheoKhoang1.Text) + "' and '" + Functions.ConvertDateTime(mskTheoKhoang2.Text) + "'";
            }
            if (txtDoanhThu.Text != "")
            {
                sql += " and doanhthusanpham >= " + txtDoanhThu.Text;
            }

            Load_DataGridView(sql);
            txtTongTien.Text = Functions.GetFieldValues("SELECT (tblChiTietHDB.SoLuong * tblSanPham.GiaBan) AS DoanhThu FROM tblHoaDonBan WHERE " + sql.Substring(sql.IndexOf("where") + 5));
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongTien.Text);
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            string sql = "SELECT tblHoaDonBan.NgayBan, tblSanPham.TenSP, tblChiTietHDB.SoLuong AS SoLuongBan, tblSanPham.GiaBan AS DonGiaBan, (tblChiTietHDB.SoLuong * tblSanPham.GiaBan) AS DoanhThu FROM tblHoaDonBan JOIN tblChiTietHDB ON tblHoaDonBan.MaHDB = tblChiTietHDB.MaHDB, JOIN tblSanPham ON tblChiTietHDB.MaSP = tblSanPham.MaSP;";
            Load_DataGridView(sql);
            Functions.FillCombo("SELECT TenSP FROM tblSanPham", cboTenSP, "TenSP", "TenSP");
            cboTenSP.SelectedIndex = -1;
            txtGiaBan.Text = "";
            mskTheoNgay.Text = "";
            txtSoLuong.Text = "";
            txtDoanhThu.Text = "";
            txtTongTien.Text = Functions.GetFieldValues("SELECT (tblChiTietHDB.SoLuong * tblSanPham.GiaBan) AS DoanhThu FROM tblHoaDonBan");
            rdTheoKhoang.Checked = false;
            rdTheoNgay.Checked = false;
            mskTheoNgay.Enabled = false;
            grbKhoang.Enabled = false;
            mskTheoKhoang1.Text = "";
            mskTheoKhoang2.Text = "";
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongTien.Text);
        }

        private void dgvBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            string ma;

            if (tblDT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            mskTheoNgay.Text = dgvBaoCaoDoanhThu.CurrentRow.Cells["ngayban"].Value.ToString();

            ma = dgvBaoCaoDoanhThu.CurrentRow.Cells["TenSP"].Value.ToString();
            cboTenSP.Text = Functions.GetFieldValues("SELECT TenSP FROM tblSanPham WHERE TenSP = N'" + ma + "'");

            txtSoLuong.Text = dgvBaoCaoDoanhThu.CurrentRow.Cells["SoLuongBan"].Value.ToString();
            txtGiaBan.Text = dgvBaoCaoDoanhThu.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtDoanhThu.Text = dgvBaoCaoDoanhThu.CurrentRow.Cells["DoanhThu"].Value.ToString();
        }
    }
}
