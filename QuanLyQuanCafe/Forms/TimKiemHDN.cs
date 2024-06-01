using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmTimKiemHDN : Form
    {
        public frmTimKiemHDN()
        {
            InitializeComponent();
        }

        DataTable tblHoaDonNhap;

        private void frmTimKiemHDN_Load(object sender, EventArgs e)
        {
            ResetValues();
            Class.Functions.FillCombo("SELECT MaHDN FROM tblHoaDonNhap", cboMaHDN, "MaHDN", "MaHDN");
            cboMaHDN.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT MaNV FROM tblHoaDonNhap", cboMaNhanVien, "MaNV", "MaNV");
            cboMaNhanVien.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT MaNCC FROM tblHoaDonNhap", cboMaNCC, "MaNCC", "MaNCC");
            cboMaNCC.SelectedIndex = -1;
            dgvTimKiemHDN.DataSource = null;
        }

        private void Load_DataGridView()
        {
            dgvTimKiemHDN.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dgvTimKiemHDN.Columns[1].HeaderText = "Ngày bán";
            dgvTimKiemHDN.Columns[2].HeaderText = "Mã nhân viên";
            dgvTimKiemHDN.Columns[3].HeaderText = "Mã nhà cung cấp";
            dgvTimKiemHDN.Columns[4].HeaderText = "Tổng tiền";
            dgvTimKiemHDN.AllowUserToAddRows = false;
            dgvTimKiemHDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            cboMaHDN.Text = "";
            cboMaNhanVien.Text = "";
            cboMaNCC.Text = "";
            dtpNgayNhap.Checked = false;
            txtTongTien.Text = "";
            cboMaHDN.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboMaHDN.Text == "") && (cboMaNhanVien.Text == "") && (cboMaNCC.Text == "") && (txtTongTien.Text == "") && (!dtpNgayNhap.Checked))
            {
                MessageBox.Show("Hãy nhập điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHoaDonNhap WHERE 1=1";
            if (cboMaHDN.Text != "")
                sql = sql + " AND MaHDN LIKE N'%" + cboMaHDN.Text + "%'";
            if (cboMaNhanVien.Text != "")
                sql = sql + " AND MaNV LIKE N'%" + cboMaNhanVien.Text + "%'";
            if (cboMaNCC.Text != "")
                sql = sql + " AND MaNCC LIKE N'%" + cboMaNCC.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND TongTien <=" + txtTongTien.Text;
            if (dtpNgayNhap.Checked)
                sql = sql + " AND NgaySinh = '" + dtpNgayNhap.Value.ToString("yyyy-MM-dd") + "'";
            tblHoaDonNhap = Class.Functions.GetDataToTable(sql);
            if (tblHoaDonNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nhập nào thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblHoaDonNhap.Rows.Count + " hóa đơn nhập thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvTimKiemHDN.DataSource = tblHoaDonNhap;
            Load_DataGridView();
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemHDN.DataSource = null;
        }

        private void dgvTimKiemHDN_DoubleClick(object sender, EventArgs e)
        {
            string mahdn;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết hóa đơn nhập này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                mahdn = dgvTimKiemHDN.CurrentRow.Cells["MaHDN"].Value.ToString();
                frmHoaDonNhap f = new frmHoaDonNhap();
                f.textMaHDN.Text = mahdn;
                f.ShowDialog();
            }
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}