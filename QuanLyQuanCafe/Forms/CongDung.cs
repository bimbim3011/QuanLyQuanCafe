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
    public partial class frmCongDung : Form
    {
        public frmCongDung()
        {
            InitializeComponent();
        }

        DataTable tblCongDung;

        private void frmCongDung_Load(object sender, EventArgs e)
        {
            txtMaCongDung.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaCongDung, TenCongDung FROM tblCongDung";
            tblCongDung = Class.Functions.GetDataToTable(sql);
            dgvCongDung.DataSource = tblCongDung;
            dgvCongDung.Columns[0].HeaderText = "Mã công dụng";
            dgvCongDung.Columns[1].HeaderText = "Tên công dụng";
            dgvCongDung.AllowUserToAddRows = false;
            dgvCongDung.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvCongDung_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCongDung.Focus();
                return;
            }
            if (tblCongDung.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaCongDung.Text = dgvCongDung.CurrentRow.Cells["MaCongDung"].Value.ToString();
            txtTenCongDung.Text = dgvCongDung.CurrentRow.Cells["TenCongDung"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void ResetValue()
        {
            txtMaCongDung.Text = "";
            txtTenCongDung.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaCongDung.Enabled = true;
            txtMaCongDung.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCongDung.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCongDung.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn công dụng sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenCongDung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên công dụng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCongDung.Focus();
                return;
            }
            sql = "UPDATE tblCongDung SET TenCongDung = N'" + txtTenCongDung.Text.ToString() + "' WHERE MaCongDung = N'" + txtMaCongDung.Text + "'";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCongDung.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCongDung.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn công dụng sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblCongDung WHERE MaCongDung = N'" + txtMaCongDung.Text + "'";
                Class.Functions.RunSQL_Del(sql);
                Load_DataGridView();
                ResetValue();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaCongDung.Text == "")
            {
                MessageBox.Show("Hãy nhập mã công dụng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCongDung.Focus();
                return;
            }
            if (txtTenCongDung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tên công dụng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCongDung.Focus();
                return;
            }
            sql = "SELECT MaCongDung FROM tblCongDung WHERE MaCongDung = N'" + txtMaCongDung.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã công dụng sản phẩm này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCongDung.Focus();
                txtMaCongDung.Text = "";
                return;
            }
            sql = "INSERT INTO tblCongDung(MaCongDung, TenCongDung) VALUES(N'" + txtMaCongDung.Text + "', N'" + txtTenCongDung.Text + "')";
            Class.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValue();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaCongDung.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaCongDung.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaCongDung_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}