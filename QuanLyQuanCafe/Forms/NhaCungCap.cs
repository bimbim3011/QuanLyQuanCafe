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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        DataTable tblNhaCungCap;

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql = "SELECT MaNCC, TenNCC, DiaChi, SDT FROM tblNhaCungCap";
            tblNhaCungCap = Class.Functions.GetDataToTable(sql);
            dgvNhaCungCap.DataSource = tblNhaCungCap;
            dgvNhaCungCap.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvNhaCungCap.Columns[2].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns[3].HeaderText = "Điện thoại";
            dgvNhaCungCap.Columns[0].Width = 100;
            dgvNhaCungCap.Columns[1].Width = 150;
            dgvNhaCungCap.Columns[2].Width = 150;
            dgvNhaCungCap.Columns[3].Width = 150;
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaNCC.Text = "";
            txtMaNCC.Enabled = true;
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            mskDienThoai.Text = "";
        }

        private void dgvNhaCungCap_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if (tblNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNCC.Text = dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNhaCungCap.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtDiaChi.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value.ToString();
            mskDienThoai.Text = dgvNhaCungCap.CurrentRow.Cells["SDT"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaNCC.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaNCC.Enabled = true;
            txtMaNCC.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
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
            sql = "UPDATE tblNhaCungCap SET TenNCC = N'" + txtTenNCC.Text.Trim().ToString() + "', DiaChi = N'" + txtDiaChi.Text.Trim().ToString() + "', SDT = '" + mskDienThoai.Text.ToString() + "' WHERE MaNCC = N'" + txtMaNCC.Text + "'";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNhaCungCap WHERE MaNCC = N'" + txtMaNCC.Text + "'";
                Class.Functions.RunSQL_Del(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập mã nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
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
            sql = "SELECT MaNCC FROM tblNhaCungCap WHERE MaNCC = N'" + txtMaNCC.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại, hãy nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                txtMaNCC.Text = "";
                return;
            }
            sql = "INSERT INTO tblNhaCungCap(MaNCC, TenNCC, DiaChi, SDT) VALUES (N'" + txtMaNCC.Text.Trim() + "', N'" + txtTenNCC.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + mskDienThoai.Text + "')";
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
            if ((txtMaNCC.Text == "") && (txtTenNCC.Text == "") && (txtDiaChi.Text == "") && (string.IsNullOrWhiteSpace(mskDienThoai.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""))))
            {
                MessageBox.Show("Hãy nhập điều kiện để tìm kiếm!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblNhaCungCap WHERE 1=1";
            if (txtMaNCC.Text != "")
                sql = sql + " AND MaNCC LIKE N'%" + txtMaNCC.Text + "%'";
            if (txtTenNCC.Text != "")
                sql = sql + " AND TenNCC LIKE N'%" + txtTenNCC.Text + "%'";
            if (txtDiaChi.Text != "")
                sql = sql + " AND DiaChi LIKE N'%" + txtDiaChi.Text + "%'";
            if (!string.IsNullOrWhiteSpace(mskDienThoai.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")))
                sql = sql + " AND SDT LIKE N'%" + mskDienThoai.Text.Trim() + "%'";
            tblNhaCungCap = Class.Functions.GetDataToTable(sql);
            if (tblNhaCungCap.Rows.Count == 0)
                MessageBox.Show("Không có nhân viên nào thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblNhaCungCap.Rows.Count + " nhân viên thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvNhaCungCap.DataSource = tblNhaCungCap;
            ResetValues();
        }

        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MaNCC, TenNCC, DiaChi, SDT FROM tblNhaCungCap";
            tblNhaCungCap = Class.Functions.GetDataToTable(sql);
            dgvNhaCungCap.DataSource = tblNhaCungCap;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaNCC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtTenNCC_KeyUp(object sender, KeyEventArgs e)
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