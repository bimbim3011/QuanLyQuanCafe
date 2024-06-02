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
using COMExcel = Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        DataTable tblDT;

        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT TenSP FROM tblSanPham", cboTenSP, "TenSP", "TenSP");
            cboTenSP.SelectedIndex = -1;
            txtTongTien.Text = Functions.GetFieldValues("SELECT SUM(DoanhThuSanPham) FROM tblDoanhThu");
            mskTheoNgay.Enabled = false;
            grbKhoang.Enabled = false;
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongTien.Text);
            txtTongTien.Enabled = false;
        }
        private void Load_DataGridView()
        {
            dgvBaoCaoDoanhThu.Columns[0].HeaderText = "Ngày bán";
            dgvBaoCaoDoanhThu.Columns[1].HeaderText = "Tên sản phẩm";
            dgvBaoCaoDoanhThu.Columns[2].HeaderText = "Số lượng bán";
            dgvBaoCaoDoanhThu.Columns[3].HeaderText = "Đơn giá bán";
            dgvBaoCaoDoanhThu.Columns[4].HeaderText = "Doanh thu";
            dgvBaoCaoDoanhThu.AllowUserToAddRows = false;
            dgvBaoCaoDoanhThu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Reset()
        {
            mskTheoNgay.Text = "";
            cboTenSP.Text = "";
            txtTongTien.Text = "";
            txtSoLuong.Text = "0";
            txtGiaBan.Text = "0";
            mskTheoNgay.Text = "  /  /";
            mskTheoKhoang1.Text = "  /  /";
            mskTheoKhoang2.Text = "  /  /";
            txtSoLuong.Enabled = false;
            txtGiaBan.Enabled = false;
            txtDoanhThu.Text = "0";
            txtDoanhThu.Enabled = false;
        }

        private void dgvBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            string ma;

            if (tblDT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ma = dgvBaoCaoDoanhThu.CurrentRow.Cells["TenSP"].Value.ToString();
            cboTenSP.Text = Functions.GetFieldValues("SELECT TenSP FROM tblSanPham WHERE TenSP = N'" + ma + "'");
            txtSoLuong.Text = dgvBaoCaoDoanhThu.CurrentRow.Cells["SoLuongBan"].Value.ToString();
            txtGiaBan.Text = dgvBaoCaoDoanhThu.CurrentRow.Cells["GiaSanPham"].Value.ToString();
            mskTheoNgay.Text = dgvBaoCaoDoanhThu.CurrentRow.Cells["NgayBan"].Value.ToString();
            txtDoanhThu.Text = dgvBaoCaoDoanhThu.CurrentRow.Cells["DoanhThuSanPham"].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboTenSP.SelectedValue == null && txtGiaBan.Text == "" && mskTheoNgay.Text == "  /  /" && txtDoanhThu.Text == null && mskTheoKhoang1.Text == "  /  /" && mskTheoKhoang2.Text == "  /  /")
            {
                MessageBox.Show("Hãy nhập ít nhất 1 dữ liệu để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((mskTheoKhoang1.Text != "  /  /" && mskTheoKhoang2.Text == "  /  /") || (mskTheoKhoang1.Text == "  /  /" && mskTheoKhoang2.Text != "  /  /"))
            {
                MessageBox.Show("Bạn phải nhập đủ cả ngày bắt đầu và ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "SELECT * FROM tblDoanhThu where 1=1";
            if (cboTenSP.SelectedValue != null)
            {
                sql += " AND TenSP = N'" + cboTenSP.Text + "'";
            }

            if (txtGiaBan.Text != "")
            {
                sql += " AND GiaSanPham = " + txtGiaBan.Text;
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
                sql += " and CONVERT(date, NgayBan) = '" + Functions.ConvertDateTime(mskTheoNgay.Text) + "'";
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
                sql += " AND (CONVERT(date, NgayBan) BETWEEN '" + Functions.ConvertDateTime(mskTheoKhoang1.Text) + "' AND '" + Functions.ConvertDateTime(mskTheoKhoang2.Text) + "'";
            }
            if (txtDoanhThu.Text != "")
            {
                sql += " and DoanhThuSanPham >= " + txtDoanhThu.Text;
            }

            tblDT = Class.Functions.GetDataToTable(sql);
            if (tblDT.Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn bán nào thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reset();
                dgvBaoCaoDoanhThu.DataSource = tblDT;
                Load_DataGridView();
            }
            else
            {
                MessageBox.Show("Có " + tblDT.Rows.Count + " hóa đơn bán thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvBaoCaoDoanhThu.DataSource = tblDT;
                Load_DataGridView();
                txtTongTien.Text = Functions.GetFieldValues("SELECT SUM(DoanhThuSanPham) FROM  tblDoanhThu WHERE " + sql.Substring(sql.IndexOf("where") + 5));
                lblBangChu.Text = "Bằng chữ:    " + Functions.ChuyenSoSangChu(txtTongTien.Text);
            }
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            Reset();
            dgvBaoCaoDoanhThu.DataSource = null;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblDoanhThu";
            tblDT = Class.Functions.GetDataToTable(sql);
            dgvBaoCaoDoanhThu.DataSource = tblDT;
            Load_DataGridView();
            Functions.FillCombo("SELECT TenSP FROM tblSanPham", cboTenSP, "TenSP", "TenSP");
            cboTenSP.SelectedIndex = -1;
            txtGiaBan.Text = "";
            mskTheoNgay.Text = "";
            txtSoLuong.Text = "";
            txtDoanhThu.Text = "";
            txtTongTien.Text = Functions.GetFieldValues("SELECT SUM(DoanhThuSanPham) FROM tblDoanhThu");
            rdTheoKhoang.Checked = false;
            rdTheoNgay.Checked = false;
            mskTheoNgay.Enabled = false;
            grbKhoang.Enabled = false;
            mskTheoKhoang1.Text = "";
            mskTheoKhoang2.Text = "";
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongTien.Text);
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;

            int hang = 0, cot = 0;

            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];

            exRange.Range["C10: D10:E10"].Font.Size = 14;
            exRange.Range["C10: D10:E10"].Font.Name = "Times new roman";
            exRange.Range["C10: D10:E10"].Font.Bold = true;
            exRange.Range["C10:D10:E10"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C10:D10:E10"].MergeCells = true;
            exRange.Range["C10: D10:E10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C10: D10:E10"].Value = "Báo cáo doanh thu ";

            int rowCount = tblDT.Rows.Count;
            int colCount = tblDT.Columns.Count;

            // Phạm vi bắt đầu từ ô A1 và kết thúc ở ô cuối cùng chứa dữ liệu
            COMExcel.Range dataRange = exSheet.Range[exSheet.Cells[12, 1], exSheet.Cells[rowCount + 12, colCount + 1]];

            // Thiết lập viền cho phạm vi dữ liệu
            dataRange.Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;

            exRange.Range["H12:H12"].Value = "Tổng tiền:";

            exRange.Range["I12:I12"].Value = txtTongTien.Text;

            exRange.Range["A12:F12"].Font.Bold = true;
            exRange.Range["A12:F12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].Value = "Ngày bán";
            exRange.Range["B12:B12"].ColumnWidth = 9.7;
            exRange.Range["C12:C12"].Value = "Tên sản phẩm";
            exRange.Range["C12:C12"].ColumnWidth = 25;
            exRange.Range["D12:D12"].Value = "Số lượng bán";
            exRange.Range["D12:D12"].ColumnWidth = 15;
            exRange.Range["E12:E12"].Value = "Giá bán sản phẩm";
            exRange.Range["E12:E12"].ColumnWidth = 15;
            exRange.Range["F12:F12"].Value = "Doanh thu sản phẩm ";
            exRange.Range["F12:F12"].ColumnWidth = 20;

            for (hang = 0; hang < tblDT.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 13] = hang + 1;
                for (cot = 0; cot < tblDT.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 13] = tblDT.Rows[hang][cot].ToString();
                }
            }
            exApp.Visible = true;
        }

        private void rdTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTheoNgay.Checked == true)
                mskTheoNgay.Enabled = true;
            else
            {
                mskTheoNgay.Enabled = false;
                mskTheoNgay.Text = "";
            }
        }

        private void rdTheoKhoang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTheoKhoang.Checked == true)
                grbKhoang.Enabled = true;
            else
            {
                grbKhoang.Enabled = false;
                mskTheoKhoang1.Text = "";
                mskTheoKhoang2.Text = "";
            }
        }

        private void txtSoLuong_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtGiaBan_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtDoanhThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        
    }
}
