using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.Class;
using System.Globalization;
using System.Security.Cryptography;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmBaoCaoHDN : Form
    {
        public frmBaoCaoHDN()
        {
            InitializeComponent();
        }

        private void frmBaoCaoHDN_Load(object sender, EventArgs e)
        {
            ResetValues();
            dataGridViewHoadon.DataSource = null;
            dataGridViewSanpham.DataSource = null;
            Functions.FillCombo("select MaNCC, TenNCC from tblNhaCungCap", comboMaNCC, "MaNCC", "TenNCC");
            comboMaNCC.SelectedIndex = -1;
            Functions.FillCombo("select MaNV, TenNV from tblNhanVien", comboMaNV, "MaNV", "TenNV");
            comboMaNV.SelectedIndex = -1;
            Functions.FillCombo("select MaSP, TenSP from tblSanPham", comboMaSP, "MaSP", "TenSP");
            comboMaSP.SelectedIndex = -1;
            Functions.FillCombo("select MaHDN from tblChiTietHDN", comboMaHD, "MaHDN", "MaHDN");
            comboMaHD.SelectedIndex = -1;
        }

        private void ResetValues()
        {
            comboMaHD.Text = "";
            comboMaSP.Text = "";
            comboMaNCC.Text = "";
            comboMaNV.Text = "";
            textDongianhap.Text = "";
            maskNgay.Text = "  /  /";
            maskedNgaybd.Text = "  /  /";
            maskedNgaykt.Text = "  /  /";
        }

        DataTable tblDSHD;
        DataTable tblSP;

        private void Load_DataGridViewHDN()
        {
            dataGridViewHoadon.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewHoadon.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewHoadon.Columns[2].HeaderText = "Mã sản phẩm";
            dataGridViewHoadon.Columns[3].HeaderText = "Số lượng";
            dataGridViewHoadon.Columns[4].HeaderText = "Đơn giá nhập";
            dataGridViewHoadon.Columns[5].HeaderText = "Chiết khấu";
            dataGridViewHoadon.Columns[6].HeaderText = "Thành tiền";
            dataGridViewHoadon.Columns[7].HeaderText = "Ngày nhập";
            dataGridViewHoadon.Columns[8].HeaderText = "Tên nhà cung cấp";
            dataGridViewHoadon.Columns[9].HeaderText = "Tên nhân viên";

            dataGridViewHoadon.Columns[0].Width = 100;
            dataGridViewHoadon.Columns[1].Width = 150;
            dataGridViewHoadon.Columns[2].Width = 100;
            dataGridViewHoadon.Columns[3].Width = 100;
            dataGridViewHoadon.Columns[4].Width = 100;
            dataGridViewHoadon.Columns[5].Width = 100;
            dataGridViewHoadon.Columns[6].Width = 100;
            dataGridViewHoadon.Columns[7].Width = 100;
            dataGridViewHoadon.Columns[8].Width = 150;
            dataGridViewHoadon.Columns[9].Width = 150;

            dataGridViewHoadon.AllowUserToAddRows = false;
            dataGridViewHoadon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Load_DataGridViewSanpham()
        {
            dataGridViewSanpham.Columns[0].HeaderText = "Tên sản phẩm";
            dataGridViewSanpham.Columns[1].HeaderText = "Số lượng";

            dataGridViewSanpham.Columns[0].Width = 150;
            dataGridViewSanpham.Columns[1].Width = 120;

            dataGridViewSanpham.AllowUserToAddRows = false;
            dataGridViewSanpham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void buttonTimkiem_Click(object sender, EventArgs e)
        {
            string sql;

            if (comboMaHD.SelectedValue == null && comboMaSP.SelectedValue == null && maskNgay.Text == "  /  /" && comboMaNCC.SelectedValue == null && comboMaNV.SelectedValue == null && maskedNgaybd.Text == "  /  /" && maskedNgaykt.Text == "  /  /" && textDongianhap.Text == "")
            {
                MessageBox.Show("Hãy nhập ít nhất 1 dữ liệu để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "SELECT a.MaHDN, c.TenSP, c.MaSP, b.SoLuong, b.DonGia, b.ChietKhau, b.ThanhTien, a.NgayNhap, d.TenNCC, e.TenNV " +
                  "FROM tblHoaDonNhap AS a " +
                  "JOIN tblChiTietHDN AS b ON a.MaHDN = b.MaHDN " +
                  "JOIN tblSanPham AS c ON b.MaSP = c.MaSP " +
                  "JOIN tblNhaCungCap AS d ON a.MaNCC = d.MaNCC " +
                  "JOIN tblNhanVien AS e ON a.MaNV = e.MaNV " +
                  "WHERE 1=1";
            if (comboMaHD.SelectedValue != null)
            {
                sql = sql + " AND a.MaHDN LIKE N'%" + comboMaHD.Text + "%' ";
            }
            if (comboMaSP.SelectedValue != null)
            {
                sql = sql + " AND c.TenSP LIKE N'%" + comboMaSP.Text + "%'";
            }
            if (maskNgay.Text != "  /  /")
            {
                if (!Functions.IsDate(maskNgay.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskNgay.Focus();
                    maskNgay.Text = "";
                    return;
                }
                sql = sql + " AND a.NgayNhap ='" + Functions.ConvertDateTime(maskNgay.Text) + "'";
            }
            if (maskedNgaybd.Text != "  /  /")
            {
                if (maskedNgaybd.Text == "  /  /")
                {
                    MessageBox.Show("Hãy nhập ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedNgaybd.Focus();
                    return;
                }
            }
            if (maskedNgaykt.Text != "  /  /")
            {
                if (maskedNgaykt.Text == "  /  /")
                {
                    MessageBox.Show("Hãy nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedNgaykt.Focus();
                    return;
                }
            }
            if (maskedNgaybd.Text != "  /  /" && maskedNgaybd.Text != "  /  /")
            {
                if (!Functions.IsDate(maskedNgaykt.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedNgaykt.Focus();
                    maskedNgaykt.Text = "";
                    return;
                }
                if (!Functions.IsDate(maskedNgaybd.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedNgaybd.Focus();
                    maskedNgaybd.Text = "";
                    return;
                }
                if (DateTime.ParseExact(maskedNgaybd.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(maskedNgaykt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedNgaybd.Text = "";
                    maskedNgaykt.Text = "";
                    return;
                }
                sql = sql + " AND (a.NgayNhap BETWEEN '" + Functions.ConvertDateTime(maskedNgaybd.Text) + "' AND '" + Functions.ConvertDateTime(maskedNgaykt.Text) + "')";
            }
            if (comboMaNCC.SelectedValue != null)
            {
                sql = sql + " AND d.TenNCC LIKE N'%" + comboMaNCC.Text + "%'";
            }
            if (comboMaNV.SelectedValue != null)
            {
                sql = sql + " AND e.TenNV LIKE N'%" + comboMaNV.Text + "%'";
            }
            if (textDongianhap.Text != "")
                sql = sql + " AND b.DonGia LIKE N'%" + textDongianhap.Text + "%'";
            tblDSHD = Class.Functions.GetDataToTable(sql);
            if (tblDSHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn bán nào thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblDSHD.Rows.Count + " hóa đơn bán thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridViewHoadon.DataSource = tblDSHD;
            Load_DataGridViewHDN();
            //sql1 = "SELECT * FROM tblSanPham";

            tblSP = new DataTable();
            tblSP.Columns.Add("TenSP");
            tblSP.Columns.Add("TongSoLuong");

            var query = from row in tblDSHD.AsEnumerable()
                        group row by row.Field<string>("TenSP") into g
                        select new
                        {
                            TenSP = g.Key,
                            TongSoLuong = g.Sum(r => r.Field<int>("SoLuong"))
                        };

            foreach (var item in query)
            {
                DataRow newRow = tblSP.NewRow();
                newRow["TenSP"] = item.TenSP;
                newRow["TongSoLuong"] = item.TongSoLuong;
                tblSP.Rows.Add(newRow);
            }
            dataGridViewSanpham.DataSource = tblSP;
            Load_DataGridViewSanpham();
        }

        private void buttonInBC_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;

            int hang = 0, cot = 0;

            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];

            exRange.Range["A2:P2"].Font.Size = 28;
            exRange.Range["A2:P2"].Font.Name = "Times new roman";
            exRange.Range["A2:P2"].Font.Bold = true;
            exRange.Range["A2:P2"].Font.ColorIndex = 3;
            exRange.Range["A2:P2"].MergeCells = true;
            exRange.Range["A2:P2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:P2"].Value = "Danh sách Nhập hàng ";

            exRange.Range["A4:K4"].Font.Bold = true;
            exRange.Range["A4:K4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B4:C4,I4:K4"].ColumnWidth = 18;
            exRange.Range["D4:H4"].ColumnWidth = 12;
            exRange.Range["A4:A4"].Value = "STT";
            exRange.Range["B4:B4"].Value = "Mã hoá đơn";
            exRange.Range["C4:C4"].Value = "Tên sản phẩm";
            exRange.Range["D4:D4"].Value = "Mã sản phẩm";
            exRange.Range["E4:E4"].Value = "Số lượng nhập";
            exRange.Range["F4:F4"].Value = "Đơn giá nhập";
            exRange.Range["G4:G4"].Value = "Chiết khấu";
            exRange.Range["H4:H4"].Value = "Thành tiền";
            exRange.Range["I4:I4"].Value = "Ngày nhập";
            exRange.Range["J4:J4"].Value = "Tên nhà cung cấp";
            exRange.Range["K4:K4"].Value = "Tên nhân viên nhập";
            for (int row = 0; row < tblDSHD.Rows.Count; row++)
            {
                exSheet.Cells[1][row + 5] = row + 1;
                for (int col = 0; col < tblDSHD.Columns.Count; col++)
                {
                    if (tblDSHD.Columns[col].ColumnName == "ngaynhap")
                    {

                        DateTime ngayNhap = Convert.ToDateTime(tblDSHD.Rows[row]["ngaynhap"]);
                        exSheet.Cells[col + 2][row + 5] = ngayNhap.ToShortDateString();
                    }
                    else
                    {

                        exSheet.Cells[col + 2][row + 5] = tblDSHD.Rows[row][col].ToString();
                    }
                }
            }

            for (hang = 0; hang < tblDSHD.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 5] = hang + 1;
                for (cot = 0; cot < tblDSHD.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 5] = tblDSHD.Rows[hang][cot].ToString();
                }
            }

            exRange.Range["O4:P4"].Font.Bold = true;
            exRange.Range["O4:P4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["O4:P4"].ColumnWidth = 15;
            exRange.Range["O4:O4"].Value = "Tên sản phẩm";
            exRange.Range["P4:P4"].Value = "Số lượng nhập";
            for (hang = 0; hang < tblSP.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 5] = hang + 1;
                for (cot = 0; cot < tblSP.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 15][hang + 5] = tblSP.Rows[hang][cot].ToString();
                }
            }

            exApp.Visible = true;
        }
    }
}