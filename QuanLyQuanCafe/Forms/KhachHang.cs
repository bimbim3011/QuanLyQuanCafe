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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        DataTable tblKhachHang;

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql = "SELECT MaKH, TenKH, DiaChi, SDT FROM tblKhachHang";
            tblKhachHang = Class.Functions.GetDataToTable(sql);
            dgvKhachHang.DataSource = tblKhachHang;
            dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
            dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 150;
            dgvKhachHang.Columns[2].Width = 150;
            dgvKhachHang.Columns[3].Width = 150;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaKhachHang.Text = "";
            txtMaKhachHang.Enabled = true;
            txtTenKhachHang.Text = "";
            txtDiaChi.Text = "";
            mskDienThoai.Text = "";
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhachHang.Focus();
                return;
            }
            if (tblKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKhachHang.Text = dgvKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKhachHang.Text = dgvKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            mskDienThoai.Text = dgvKhachHang.CurrentRow.Cells["SDT"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaKhachHang.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaKhachHang.Enabled = true;
            txtMaKhachHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhachHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhachHang.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mskDienThoai.Text == "(   )     -")
            {
                MessageBox.Show("Hãy nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienThoai.Focus();
                return;
            }
            sql = "UPDATE tblKhachHang SET TenKH = N'" + txtTenKhachHang.Text.Trim().ToString() + "', DiaChi = N'" + txtDiaChi.Text.Trim().ToString() + "', SDT = '" + mskDienThoai.Text.ToString() + "' WHERE MaKH = N'" + txtMaKhachHang.Text + "'";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhachHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblKhachHang WHERE MaKH = N'" + txtMaKhachHang.Text + "'";
                Class.Functions.RunSQL_Del(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhachHang.Focus();
                return;
            }
            if (txtTenKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhachHang.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mskDienThoai.Text == "(   )     -")
            {
                MessageBox.Show("Hãy nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienThoai.Focus();
                return;
            }
            sql = "SELECT MaKH FROM tblKhachHang WHERE MaKH = N'" + txtMaKhachHang.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại, hãy nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhachHang.Focus();
                txtMaKhachHang.Text = "";
                return;
            }
            sql = "INSERT INTO tblKhachHang(MaKH, TenKH, DiaChi, SDT) VALUES (N'" + txtMaKhachHang.Text.Trim() + "', N'" + txtTenKhachHang.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + mskDienThoai.Text + "')";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaKhachHang.Text == "") && (txtTenKhachHang.Text == "") && (txtDiaChi.Text == "") && (string.IsNullOrWhiteSpace(mskDienThoai.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""))))
            {
                MessageBox.Show("Hãy nhập điều kiện để tìm kiếm!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblKhachHang WHERE 1=1";
            if (txtMaKhachHang.Text != "")
                sql = sql + " AND MaKH LIKE N'%" + txtMaKhachHang.Text + "%'";
            if (txtTenKhachHang.Text != "")
                sql = sql + " AND TenKH LIKE N'%" + txtTenKhachHang.Text + "%'";
            if (txtDiaChi.Text != "")
                sql = sql + " AND DiaChi LIKE N'%" + txtDiaChi.Text + "%'";
            if (!string.IsNullOrWhiteSpace(mskDienThoai.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")))
                sql = sql + " AND SDT LIKE N'%" + mskDienThoai.Text.Trim() + "%'";
            tblKhachHang = Class.Functions.GetDataToTable(sql);
            if (tblKhachHang.Rows.Count == 0)
                MessageBox.Show("Không có nhân viên nào thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblKhachHang.Rows.Count + " nhân viên thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvKhachHang.DataSource = tblKhachHang;
            ResetValues();
        }

        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MaKH, TenKH, DiaChi, SDT FROM tblKhachHang";
            tblKhachHang = Class.Functions.GetDataToTable(sql);
            dgvKhachHang.DataSource = tblKhachHang;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaKhachHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtTenKhachHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}