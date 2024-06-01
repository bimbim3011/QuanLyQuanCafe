using QuanLyQuanCafe.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmHoaDonNhap : Form
    {
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            buttonThemHD.Enabled = true;
            buttonLuu.Enabled = false;
            buttonHuyHD.Enabled = false;
            buttonInHD.Enabled = false;
            textMaHDN.ReadOnly = true;
            textTenNV.ReadOnly = true;
            textTenNCC.ReadOnly = true;
            textDiachi.ReadOnly = true;
            textDienthoai.ReadOnly = true;
            textTenhang.ReadOnly = true;
            textThanhtien.ReadOnly = true;
            textTongtien.ReadOnly = true;
            textChietkhau.Text = "0";
            textTongtien.Text = "0";
            Functions.FillCombo("select MaNCC, TenNCC from tblNhaCungCap", comboMaNCC, "MaNCC", "MaNCC");
            comboMaNCC.SelectedIndex = -1;
            Functions.FillCombo("select MaNV, TenNV from tblNhanVien", comboMaNV, "MaNV", "MaNV");
            comboMaNV.SelectedIndex = -1;
            Functions.FillCombo("select MaSP, TenSP from tblSanPham", comboMahang, "MaSP", "MaSP");
            comboMahang.SelectedIndex = -1;
            Functions.FillCombo("select MaHDN from tblHoaDonNhap", comboMaHDN, "MaHDN", "MaHDN");
            comboMaHDN.SelectedIndex = -1;
            if (textMaHDN.Text != "")
            {
                Load_ThongtinHD();
                buttonHuyHD.Enabled = true;
                buttonInHD.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }

        DataTable tblHDN;

        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "select a.MaSP, b.TenSP, a.SoLuong, a.DonGia, a.ChietKhau, a.ThanhTien " +
                "from tblChiTietHDN as a, tblSanPham as b " +
                "where a.MaHDN = N'" + textMaHDN.Text + "' and a.MaSP = b.MaSP";
            tblHDN = Functions.GetDataToTable(sql);
            dataGridViewHDN.DataSource = tblHDN;
            dataGridViewHDN.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewHDN.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewHDN.Columns[2].HeaderText = "Số lượng";
            dataGridViewHDN.Columns[3].HeaderText = "Đơn giá nhập";
            dataGridViewHDN.Columns[4].HeaderText = "Chiết khấu %";
            dataGridViewHDN.Columns[5].HeaderText = "Thành tiền";
            dataGridViewHDN.Columns[0].Width = 80;
            dataGridViewHDN.Columns[1].Width = 100;
            dataGridViewHDN.Columns[2].Width = 80;
            dataGridViewHDN.Columns[3].Width = 90;
            dataGridViewHDN.Columns[4].Width = 90;
            dataGridViewHDN.Columns[5].Width = 90;
            dataGridViewHDN.AllowUserToAddRows = false;
            dataGridViewHDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "select NgayNhap from tblHoaDonNhap where MaHDN = N'" + textMaHDN.Text + "'";
            textNgaynhap.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "select MaNV from tblHoaDonNhap where MaHDN = N'" + textMaHDN.Text + "'";
            comboMaNV.Text = Functions.GetFieldValues(str);
            str = "select MaNCC from tblHoaDonNhap where MaHDN = N'" + textMaHDN.Text + "'";
            comboMaNCC.Text = Functions.GetFieldValues(str);
            str = "select TongTien from tblHoaDonNhap where MaHDN = N'" + textMaHDN.Text + "'";
            textTongtien.Text = Functions.GetFieldValues(str);
            labelBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(textTongtien.Text);
        }

        private void buttonThemHD_Click(object sender, EventArgs e)
        {
            buttonHuyHD.Enabled = false;
            buttonLuu.Enabled = true;
            buttonInHD.Enabled = false;
            buttonThemHD.Enabled = false;
            ResetValues();
            textMaHDN.Text = Functions.CreateKey("HDN");
            Load_DataGridViewChitiet();
        }

        private void ResetValues()
        {
            textMaHDN.Text = "";
            textNgaynhap.Text = DateTime.Now.ToShortDateString();
            comboMaNV.Text = "";
            comboMaNCC.Text = "";
            textTongtien.Text = "0";
            labelBangchu.Text = "Bằng chữ: ";
            comboMahang.Text = "";
            textSoluong.Text = "";
            textDongianhap.Text = "";
            textChietkhau.Text = "0";
            textThanhtien.Text = "0";
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, slcon, tong, tongmoi, dongianhap, dongiaban;
            sql = "select MaHDN from tblHoaDonNhap where MaHDN = N'" + textMaHDN.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                if (textNgaynhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textNgaynhap.Focus();
                    return;
                }
                if (comboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaNV.Focus();
                    return;
                }
                if (comboMaNCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaNCC.Focus();
                    return;
                }
                sql = "insert into tblHoaDonNhap(MaHDN, NgayNhap, MaNV, MaNCC, TongTien) values(N'" + textMaHDN.Text.Trim() + "', '" + Functions.ConvertDateTime(textNgaynhap.Text.Trim()) + "',N'" + comboMaNV.SelectedValue + "',N'" + comboMaNCC.SelectedValue + "'," + textTongtien.Text + ")";
                Functions.RunSQL(sql);
            }

            if (comboMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMahang.Focus();
                return;
            }
            if ((textSoluong.Text.Trim().Length == 0) || (textSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSoluong.Text = "";
                textSoluong.Focus();
                return;
            }
            if (textDongianhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDongianhap.Focus();
                return;
            }
            if (textChietkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chiết khấu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textChietkhau.Focus();
                return;
            }
            sql = "select MaSP from tblChiTietHDN where MaSP = N'" + comboMahang.SelectedValue + "' and MaHDN = N'" + textMaHDN.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                comboMahang.Focus();
                return;
            }

            sql = "insert into tblChiTietHDN(MaHDN, MaSP, SoLuong, DonGia, Chietkhau, ThanhTien) values(N'" + textMaHDN.Text.Trim() + "', N'" + comboMahang.SelectedValue + "'," + textSoluong.Text + "'," + textDongianhap.Text + "," + textChietkhau.Text + "," + textThanhtien.Text + ")";
            Functions.RunSQL(sql);
            Load_DataGridViewChitiet();

            sl = Convert.ToInt32(Functions.GetFieldValues("select SoLuong from tblSanPham where MaSP = N'" + comboMahang.SelectedValue + "'"));
            slcon = sl + Convert.ToInt32(textSoluong.Text);
            sql = "update tblSanPham set SoLuong =" + slcon + " where MaSP = N'" + comboMahang.SelectedValue + "'";
            Functions.RunSQL(sql);

            dongianhap = Convert.ToDouble(textDongianhap.Text);
            dongiaban = dongianhap * 1.10;
            sql = "update tblSanPham set GiaNhap = " + dongianhap + ", GiaBan = " + dongiaban + " where MaSP = N'" + comboMahang.SelectedValue + "'";
            Functions.RunSQL(sql);

            tong = Convert.ToDouble(Functions.GetFieldValues("select TongTien from tblHoaDonNhap where MaHDN = N'" + textMaHDN.Text + "'"));
            tongmoi = tong + Convert.ToDouble(textThanhtien.Text);
            sql = "update tblHoaDonNhap set TongTien =" + tongmoi + " where MaHDN = N'" + textMaHDN.Text + "'";
            Functions.RunSQL(sql);

            textTongtien.Text = tongmoi.ToString();
            labelBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(tongmoi.ToString());
            ResetValuesHang();
            buttonHuyHD.Enabled = true;
            buttonThemHD.Enabled = true;
            buttonInHD.Enabled = true;
        }

        private void ResetValuesHang()
        {
            comboMahang.Text = "";
            textSoluong.Text = "";
            textDongianhap.Text = "";
            textChietkhau.Text = "0";
            textThanhtien.Text = "0";
        }

        private void dataGridViewHDN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double thanhtien;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                mahang = dataGridViewHDN.CurrentRow.Cells["MaSP"].Value.ToString();
                DelHang(textMaHDN.Text, mahang);
                thanhtien = Convert.ToDouble(dataGridViewHDN.CurrentRow.Cells["ThanhTien"].Value.ToString());
                DelUpdateTongtien(textMaHDN.Text, thanhtien);
                Load_DataGridViewChitiet();
            }
        }

        private void DelHang(string MaHDN, string MaSP)
        {
            Double s, sl, slcon;
            string sql;
            sql = "select SoLuong from tblChiTietHDN where MaHDN = N'" + MaHDN + "' and MaSP = N'" + MaSP + "'";
            s = Convert.ToInt32(Functions.GetFieldValues(sql));
            sql = "delete tblChiTietHDN where MaHDN = N'" + MaHDN + "' and MaSP = N'" + MaSP + "'";
            Functions.RunSQL_Del(sql);
            sql = "select SoLuong from tblSanPham where MaSP = N'" + MaSP + "'";
            sl = Convert.ToInt32(Functions.GetFieldValues(sql));
            slcon = sl - s;
            sql = "update tblSanPham set SoLuong =" + slcon + " where MaSP = N'" + MaSP + "'";
            Functions.RunSQL(sql);
        }

        private void DelUpdateTongtien(string MaHDN, double ThanhTien)
        {
            Double tong, tongmoi;
            string sql;
            sql = "select TongTien from tblHoaDonNhap where MaHDN = N'" + MaHDN + "'";
            tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            tongmoi = tong - ThanhTien;
            sql = "update tblHoaDonNhap set TongTien =" + tongmoi + " where MaHDN = N'" + MaHDN + "'";
            Functions.RunSQL(sql);
            textTongtien.Text = tongmoi.ToString();
            labelBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(tongmoi.ToString());
        }

        private void buttonHuyHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] MaSP = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "select MaSP from tblChiTietHDN where MaHDN = N'" + textMaHDN.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaSP[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                for (i = 0; i <= n - 1; i++)
                    DelHang(textMaHDN.Text, MaSP[i]);
                sql = "delete tblHoaDonNhap where MaHDN = N'" + textMaHDN.Text + "'";
                Functions.RunSQL_Del(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                buttonHuyHD.Enabled = false;
                buttonInHD.Enabled = false;
            }
        }

        private void comboMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaNV.Text == "")
                textTenNV.Text = "";
            str = "select TenNV from tblNhanVien where MaNV = N'" + comboMaNV.SelectedValue + "'";
            textTenNV.Text = Functions.GetFieldValues(str);
        }

        private void comboMaNCC_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaNCC.Text == "")
            {
                textTenNCC.Text = "";
                textDiachi.Text = "";
                textDienthoai.Text = "";
            }
            str = "select TenNCC from tblNhaCungCap where MaNCC = N'" + comboMaNCC.SelectedValue + "'";
            textTenNCC.Text = Functions.GetFieldValues(str);
            str = "select DiaChi from tblNhaCungCap where MaNCC = N'" + comboMaNCC.SelectedValue + "'";
            textDiachi.Text = Functions.GetFieldValues(str);
            str = "select SDT from tblNhaCungCap where MaNCC = N'" + comboMaNCC.SelectedValue + "'";
            textDienthoai.Text = Functions.GetFieldValues(str);
        }

        private void comboMahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMahang.Text == "")
            {
                textTenhang.Text = "";
            }
            str = "select TenSP from tblSanPham where MaSP =N'" + comboMahang.SelectedValue + "'";
            textTenhang.Text = Functions.GetFieldValues(str);
        }

        private void textSoluong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dgn, ck;
            if (textSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSoluong.Text);
            if (textChietkhau.Text == "")
                ck = 0;
            else
                ck = Convert.ToDouble(textChietkhau.Text);
            if (textDongianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(textDongianhap.Text);
            tt = sl * dgn - sl * dgn * ck / 100;
            textThanhtien.Text = tt.ToString();
        }

        private void textChietkhau_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dgn, ck;
            if (textSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSoluong.Text);
            if (textChietkhau.Text == "")
                ck = 0;
            else
                ck = Convert.ToDouble(textChietkhau.Text);
            if (textDongianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(textDongianhap.Text);
            tt = sl * dgn - sl * dgn * ck / 100;
            textThanhtien.Text = tt.ToString();
        }

        private void textDongianhap_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dgn, ck;
            if (textSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSoluong.Text);
            if (textChietkhau.Text == "")
                ck = 0;
            else
                ck = Convert.ToDouble(textChietkhau.Text);
            if (textDongianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(textDongianhap.Text);
            tt = sl * dgn - sl * dgn * ck / 100;
            textThanhtien.Text = tt.ToString();
        }

        private void buttonInHD_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHDN, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Quán Cafe";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Ba Đình - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (09)84930223";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";

            sql = "select a.MaHDN, a.NgayNhap, a.TongTien, b.TenNCC, b.DiaChi, b.SDT, c.TenNV " +
                "from tblHoaDonNhap as a, tblNhaCungCap as b, tblNhanVien as c " +
                "where a.MaHDN = N'" + textMaHDN.Text + "' and a.MaNCC = b.MaNCC and a.MaNV = c.MaNV";
            tblThongtinHDN = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn nhập:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHDN.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHDN.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHDN.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHDN.Rows[0][5].ToString();

            sql = "select b.TenSP, a.SoLuong, a.DonGia, a.ChietKhau, a.ThanhTien " +
                  "from tblChiTietHDN as a , tblSanPham as b " +
                  "where a.MaHDN = N'" + textMaHDN.Text + "' and a.MaSP = b.MaSP";
            tblThongtinHang = Functions.GetDataToTable(sql);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá nhập";
            exRange.Range["E11:E11"].Value = "Chiết khấu";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHDN.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHDN.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHDN.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHDN.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void buttonTimkiem_Click(object sender, EventArgs e)
        {
            if (comboMaHDN.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaHDN.Focus();
                return;
            }
            textMaHDN.Text = comboMaHDN.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            buttonHuyHD.Enabled = true;
            buttonLuu.Enabled = true;
            buttonInHD.Enabled = true;
            comboMaHDN.SelectedIndex = -1;
        }

        private void textSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textChietkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textDongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void comboMaHDN_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("select MaHDN from tblHoaDonNhap", comboMaHDN, "MaHDN", "MaHDN");
            comboMaHDN.SelectedIndex = -1;
        }

        private void frmHoaDonNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void buttonBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            buttonThemHD.Enabled = true;
            buttonHuyHD.Enabled = false;
            buttonBoqua.Enabled = false;
            textMaHDN.Enabled = true;
            textNgaynhap.Text = "";
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}