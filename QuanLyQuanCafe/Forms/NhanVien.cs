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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        DataTable tblNhanVien;

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
            Class.Functions.FillCombo("SELECT MaQue, TenQue FROM tblQue", cboMaQue, "MaQue", "TenQue");
            cboMaQue.SelectedIndex = -1;
            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaNV, TenNV, DiaChi, GioiTinh, NgaySinh, MaQue, SDT FROM tblNhanVien";
            tblNhanVien = Class.Functions.GetDataToTable(sql);
            dgvNhanVien.DataSource = tblNhanVien;
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[3].HeaderText = "Giới tính";
            dgvNhanVien.Columns[4].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[5].HeaderText = "Mã quê";
            dgvNhanVien.Columns[6].HeaderText = "Số điện thoại";
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaNhanVien.Text = "";
            txtMaNhanVien.Enabled = true;
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            rdoGioiTinhNam.Checked = false;
            rdoGioiTinhNu.Checked = false;
            dtpNgaySinh.Checked = false;
            mskDienThoai.Text = "";
            cboMaQue.Text = "";
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            if (tblNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
            {
                rdoGioiTinhNam.Checked = true;
                rdoGioiTinhNu.Checked = false;
            }
            else
            {
                rdoGioiTinhNam.Checked = false;
                rdoGioiTinhNu.Checked = true;
            }
            dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            ma = dgvNhanVien.CurrentRow.Cells["MaQue"].Value.ToString();
            cboMaQue.Text = Class.Functions.GetFieldValues("SELECT TenQue FROM tblQue WHERE MaQue = N'" + ma + "'");
            mskDienThoai.Text = dgvNhanVien.CurrentRow.Cells["SDT"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaNhanVien.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaNhanVien.Enabled = true;
            txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (rdoGioiTinhNam.Checked)
                gt = "Nam";
            else if (rdoGioiTinhNu.Checked)
                gt = "Nữ";
            else
            {
                MessageBox.Show("Hãy chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!dtpNgaySinh.Checked)
            {
                MessageBox.Show("Hãy nhập ngày sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            if (!Class.Functions.IsDate(dtpNgaySinh.Value.ToString("dd/MM/yyyy")))
            {
                MessageBox.Show("Hãy nhập lại ngày sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            if (cboMaQue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập quê quán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaQue.Focus();
                return;
            }
            if (mskDienThoai.Text == "(   )     -")
            {
                MessageBox.Show("Hãy nhập điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienThoai.Focus();
                return;
            }
            sql = "UPDATE tblNhanVien SET TenNV = N'" + txtTenNhanVien.Text.Trim() + "', DiaChi = N'" + txtDiaChi.Text.Trim() + "', GioiTinh = N'" + gt + "', NgaySinh = '" + dtpNgaySinh.Value.ToString("yyyy-MM-dd") + "', MaQue = N'" + cboMaQue.SelectedValue.ToString() + "', SDT = '" + mskDienThoai.Text.ToString() + "' WHERE MaNV = N'" + txtMaNhanVien.Text + "'";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNhanVien WHERE MaNV = N'" + txtMaNhanVien.Text + "'";
                Class.Functions.RunSQL_Del(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (rdoGioiTinhNam.Checked)
                gt = "Nam";
            else if (rdoGioiTinhNu.Checked)
                gt = "Nữ";
            else
            {
                MessageBox.Show("Hãy chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Class.Functions.IsDate(dtpNgaySinh.Value.ToString("dd/MM/yyyy")))
            {
                MessageBox.Show("Hãy nhập lại ngày sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            if (cboMaQue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập quê quán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaQue.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(mskDienThoai.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")))
            {
                MessageBox.Show("Hãy nhập điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienThoai.Focus();
                return;
            }
            sql = "SELECT MaNV FROM tblNhanVien WHERE MaNV = N'" + txtMaNhanVien.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại, hãy nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                txtMaNhanVien.Text = "";
                return;
            }
            sql = "INSERT INTO tblNhanVien(MaNV, TenNV, DiaChi, GioiTinh, NgaySinh, MaQue, SDT) VALUES(N'" + txtMaNhanVien.Text.Trim() + "', N'" + txtTenNhanVien.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', N'" + gt + "', '" + dtpNgaySinh.Value.ToString("yyyy-MM-dd") + "', N'" + cboMaQue.SelectedValue.ToString() + "', '" + mskDienThoai.Text + "')";
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
            string sql, gt = "";
            if ((txtMaNhanVien.Text == "") && (txtTenNhanVien.Text == "") && (txtDiaChi.Text == "") && (cboMaQue.Text == "") && (!dtpNgaySinh.Checked) && (string.IsNullOrWhiteSpace(mskDienThoai.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""))) && (!rdoGioiTinhNam.Checked) && (!rdoGioiTinhNu.Checked))
            {
                MessageBox.Show("Hãy nhập điều kiện để tìm kiếm!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblNhanVien WHERE 1=1";
            if (txtMaNhanVien.Text != "")
                sql = sql + " AND MaNV LIKE N'%" + txtMaNhanVien.Text + "%'";
            if (txtTenNhanVien.Text != "")
                sql = sql + " AND TenNV LIKE N'%" + txtTenNhanVien.Text + "%'";
            if (txtDiaChi.Text != "")
                sql = sql + " AND DiaChi LIKE N'%" + txtDiaChi.Text + "%'";
            if (cboMaQue.Text != "")
                sql = sql + " AND MaQue LIKE N'%" + cboMaQue.SelectedValue + "%'";
            if (dtpNgaySinh.Checked)
                sql = sql + " AND NgaySinh = '" + dtpNgaySinh.Value.ToString("yyyy-MM-dd") + "'";
            if (!string.IsNullOrWhiteSpace(mskDienThoai.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")))
                sql = sql + " AND SDT LIKE N'%" + mskDienThoai.Text.Trim() + "%'";
            if (rdoGioiTinhNam.Checked)
                gt = "Nam";
            else if (rdoGioiTinhNu.Checked)
                gt = "Nữ";
            sql = sql + " AND GioiTinh = N'" + gt + "'";
            tblNhanVien = Class.Functions.GetDataToTable(sql);
            if (tblNhanVien.Rows.Count == 0)
                MessageBox.Show("Không có nhân viên nào thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblNhanVien.Rows.Count + " nhân viên thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvNhanVien.DataSource = tblNhanVien;
            ResetValues();
        }

        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MaNV, TenNV, DiaChi, GioiTinh, NgaySinh, MaQue, SDT FROM tblNhanVien";
            tblNhanVien = Class.Functions.GetDataToTable(sql);
            dgvNhanVien.DataSource = tblNhanVien;
        }

        private void txtMaNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtTenNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void chkGioiTinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void dtpNgaySinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void cboMaQue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}