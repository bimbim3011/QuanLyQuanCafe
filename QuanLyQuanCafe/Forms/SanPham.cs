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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        DataTable tblSanPham;

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
            Class.Functions.FillCombo("SELECT MaLoai, TenLoai FROM tblLoai", cboMaLoai, "MaLoai", "TenLoai");
            cboMaLoai.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT MaCongDung, TenCongDung FROM tblCongDung", cboMaCongDung, "MaCongDung", "TenCongDung");
            cboMaCongDung.SelectedIndex = -1;
            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaSP, TenSP, MaLoai, GiaNhap, GiaBan, SoLuong, MaCongDung, HinhAnh FROM tblSanPham";
            tblSanPham = Class.Functions.GetDataToTable(sql);
            dgvSanPham.DataSource = tblSanPham;
            dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[2].HeaderText = "Loại";
            dgvSanPham.Columns[3].HeaderText = "Đơn giá nhập";
            dgvSanPham.Columns[4].HeaderText = "Đơn giá bán";
            dgvSanPham.Columns[5].HeaderText = "Số lượng";
            dgvSanPham.Columns[6].HeaderText = "Công dụng";
            dgvSanPham.Columns[7].HeaderText = "Ảnh";
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaSanPham.Text = "";
            txtMaSanPham.Enabled = true;
            txtTenSanPham.Text = "";
            cboMaLoai.Text = "";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtSoLuong.Enabled = false;
            cboMaCongDung.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSanPham.Focus();
                return;
            }
            if (tblSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSanPham.Text = dgvSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSanPham.Text = dgvSanPham.CurrentRow.Cells["TenSP"].Value.ToString();
            ma = dgvSanPham.CurrentRow.Cells["MaLoai"].Value.ToString();
            cboMaLoai.Text = Class.Functions.GetFieldValues("SELECT TenLoai FROM tblLoai WHERE MaLoai = N'" + ma + "'");
            txtDonGiaNhap.Text = dgvSanPham.CurrentRow.Cells["GiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvSanPham.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtSoLuong.Text = dgvSanPham.CurrentRow.Cells["SoLuong"].Value.ToString();
            ma = dgvSanPham.CurrentRow.Cells["MaCongDung"].Value.ToString();
            cboMaCongDung.Text = Class.Functions.GetFieldValues("SELECT TenCongDung FROM tblCongDung WHERE MaCongDung = N'" + ma + "'");
            txtAnh.Text = Class.Functions.GetFieldValues("SELECT HinhAnh FROM tblSanPham WHERE MaSP = N'" + txtMaSanPham.Text + "'");
            picAnh.Image = Image.FromFile(txtAnh.Text);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaSanPham.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaSanPham.Enabled = true;
            txtMaSanPham.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return;
            }
            if (cboMaLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaLoai.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập đơn giá nhập sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }
            if (txtDonGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập đơn giá bán sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập số lượng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }
            if (cboMaCongDung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập công dụng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaCongDung.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy chọn ảnh minh họa sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE tblSanPham SET TenSP = N'" + txtTenSanPham.Text.Trim().ToString() + "', MaLoai = N'" + cboMaLoai.SelectedValue.ToString() + "', MaCongDung = N'" + cboMaCongDung.SelectedValue.ToString() + "', HinhAnh = '" + txtAnh.Text + "' WHERE MaSP = N'" + txtMaSanPham.Text + "'";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblSanPham WHERE MaSP = N'" + txtMaSanPham.Text + "'";
                Class.Functions.RunSQL_Del(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập mã sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSanPham.Focus();
                return;
            }
            if (txtTenSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return;
            }
            if (cboMaLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaLoai.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập đơn giá nhập sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }
            if (txtDonGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập đơn giá bán sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập số lượng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }
            if (cboMaCongDung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập công dụng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaCongDung.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy chọn hình ảnh minh họa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }
            sql = "SELECT MaSP FROM tblSanPham WHERE MaSP = N'" + txtMaSanPham.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại, hãy nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSanPham.Focus();
                txtMaSanPham.Text = "";
                return;
            }
            sql = "INSERT INTO tblSanPham(MaSP, TenSP, MaLoai, GiaNhap, GiaBan, SoLuong, MaCongDung, HinhAnh) VALUES(N'" + txtMaSanPham.Text.Trim() + "', N'" + txtTenSanPham.Text.Trim() + "', N'" + cboMaLoai.SelectedValue.ToString() + "', " + txtDonGiaNhap.Text + ", " + txtDonGiaBan.Text + ", " + txtSoLuong.Text.Trim() + ", N'" + cboMaCongDung.SelectedValue.ToString()+ "', '" + txtAnh.Text + "')";
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

        private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "JPEG(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "C:\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn hình ảnh để hiển thị";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaSanPham.Text == "") && (txtTenSanPham.Text == "") && (cboMaLoai.Text == "") && (cboMaCongDung.Text == ""))
            {
                MessageBox.Show("Hãy nhập điều kiện để tìm kiếm!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblSanPham WHERE 1=1";
            if (txtMaSanPham.Text != "")
                sql = sql + " AND MaSP LIKE N'%" + txtMaSanPham.Text + "%'";
            if (txtTenSanPham.Text != "")
                sql = sql + " AND TenSP LIKE N'%" + txtTenSanPham.Text + "%'";
            if (cboMaLoai.Text != "")
                sql = sql + " AND MaLoai LIKE N'%" + cboMaLoai.SelectedValue + "%'";
            if (cboMaCongDung.Text != "")
                sql = sql + " AND MaCongDung LIKE N'%" + cboMaCongDung.SelectedValue + "%'";
            tblSanPham = Class.Functions.GetDataToTable(sql);
            if (tblSanPham.Rows.Count == 0)
                MessageBox.Show("Không có sản phẩm nào thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblSanPham.Rows.Count + " sản phẩm thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvSanPham.DataSource = tblSanPham;
            ResetValues();
        }

        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MaSP, TenSP, MaLoai, GiaNhap, GiaBan, SoLuong, MaCongDung, HinhAnh FROM tblSanPham";
            tblSanPham = Class.Functions.GetDataToTable(sql);
            dgvSanPham.DataSource = tblSanPham;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaSanPham_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtTenSanPham_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void cboMaLoai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDonGiaNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDonGiaBan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}