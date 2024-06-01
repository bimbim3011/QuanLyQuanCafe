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
    public partial class frmLoaiSanPham : Form
    {
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        DataTable tblLoai;

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            txtMaLoai.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql = "SELECT MaLoai, TenLoai FROM tblLoai";
            tblLoai = Class.Functions.GetDataToTable(sql);
            dgvLoaiSanPham.DataSource = tblLoai;
            dgvLoaiSanPham.Columns[0].HeaderText = "Mã loại";
            dgvLoaiSanPham.Columns[1].HeaderText = "Tên loại";
            dgvLoaiSanPham.AllowUserToAddRows = false;
            dgvLoaiSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoai.Focus();
                return;
            }
            if (tblLoai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLoai.Text = dgvLoaiSanPham.CurrentRow.Cells["MaLoai"].Value.ToString();
            txtTenLoai.Text = dgvLoaiSanPham.CurrentRow.Cells["TenLoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void ResetValue()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaLoai.Enabled = true;
            txtMaLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLoai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn loại sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }
            sql = "UPDATE tblLoai SET TenLoai = N'" + txtTenLoai.Text.ToString() + "' WHERE MaLoai = N'" + txtMaLoai.Text + "'";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLoai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn loại sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblLoai WHERE MaLoai = N'" + txtMaLoai.Text + "'";
                Class.Functions.RunSQL_Del(sql);
                Load_DataGridView();
                ResetValue();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaLoai.Text == "")
            {
                MessageBox.Show("Hãy nhập mã loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                return;
            }
            if (txtTenLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }
            sql = "SELECT MaLoai FROM tblLoai WHERE MaLoai = N'" + txtMaLoai.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại sản phẩm này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                txtMaLoai.Text = "";
                return;
            }
            sql = "INSERT INTO tblLoai(MaLoai, TenLoai) VALUES(N'" + txtMaLoai.Text + "', N'" + txtTenLoai.Text + "')";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValue();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaLoai.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaLoai.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaLoai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}