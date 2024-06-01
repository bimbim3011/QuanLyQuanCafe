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
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            buttonThemHD.Enabled = true;
            buttonLuu.Enabled = false;
            buttonHuyHD.Enabled = false;
            buttonInHD.Enabled = false;
            textMaHD.ReadOnly = true;
            textTenNV.ReadOnly = true;
            textTenKH.ReadOnly = true;
            textDiachi.ReadOnly = true;
            textDienthoai.ReadOnly = true;
            textTenhang.ReadOnly = true;
            textDongia.ReadOnly = true;
            textThanhtien.ReadOnly = true;
            textTongtien.ReadOnly = true;
            textGiamgia.Text = "0";
            textTongtien.Text = "0";
            Functions.FillCombo("select MaKH, TenKH from tblKhachHang", comboMaKH, "MaKH", "MaKH");
            comboMaKH.SelectedIndex = -1;
            Functions.FillCombo("select MaNV, TenNV from tblNhanVien", comboMaNV, "MaNV", "MaNV");
            comboMaNV.SelectedIndex = -1;
            Functions.FillCombo("select MaSP, TenSP from tblSanPham", comboMahang, "MaSP", "MaSP");
            comboMahang.SelectedIndex = -1;
            Functions.FillCombo("select MaHDB from tblHoaDonBan", comboMaHDB, "MaHDB", "MaHDB");
            comboMaHDB.SelectedIndex = -1;
            if (textMaHD.Text != "")
            {
                Load_ThongtinHD();
                buttonHuyHD.Enabled = true;
                buttonInHD.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }

        DataTable tblHDB;

        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "select a.MaSP, b.TenSP, a.SoLuong, b.GiaBan, a.KhuyenMai, a.ThanhTien " +
                "from tblChiTietHDB as a, tblSanPham as b " +
                "where a.MaHDB = N'" + textMaHD.Text + "' and a.MaSP=b.MaSP";
            tblHDB = Functions.GetDataToTable(sql);
            dataGridViewHDB.DataSource = tblHDB;
            dataGridViewHDB.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewHDB.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewHDB.Columns[2].HeaderText = "Số lượng";
            dataGridViewHDB.Columns[3].HeaderText = "Đơn giá";
            dataGridViewHDB.Columns[4].HeaderText = "Giảm giá %";
            dataGridViewHDB.Columns[5].HeaderText = "Thành tiền";
            dataGridViewHDB.Columns[0].Width = 80;
            dataGridViewHDB.Columns[1].Width = 100;
            dataGridViewHDB.Columns[2].Width = 80;
            dataGridViewHDB.Columns[3].Width = 90;
            dataGridViewHDB.Columns[4].Width = 90;
            dataGridViewHDB.Columns[5].Width = 90;
            dataGridViewHDB.AllowUserToAddRows = false;
            dataGridViewHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "select NgayBan from tblHoaDonBan where MaHDB = N'" + textMaHD.Text + "'";
            textNgayban.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));

            str = "select MaNV from tblHoaDonBan where MaHDB = N'" + textMaHD.Text + "'";
            comboMaNV.Text = Functions.GetFieldValues(str);

            str = "select MaKH from tblHoaDonBan where MaHDB = N'" + textMaHD.Text + "'";
            comboMaKH.Text = Functions.GetFieldValues(str);

            str = "select TongTien from tblHoaDonBan where MaHDB = N'" + textMaHD.Text + "'";
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
            textMaHD.Text = Functions.CreateKey("HDB");
            Load_DataGridViewChitiet();
        }

        private void ResetValues()
        {
            textMaHD.Text = "";
            textNgayban.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            comboMaNV.Text = "";
            textTenNV.Text = "";
            comboMaKH.Text = "";
            textTenKH.Text = "";
            textDiachi.Text = "";
            textDienthoai.Text = "";
            textTongtien.Text = "0";
            labelBangchu.Text = "Bằng chữ: ";
            comboMahang.Text = "";
            textSoluong.Text = "";
            textGiamgia.Text = "0";
            textThanhtien.Text = "0";
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, slcon, tong, tongmoi;
            sql = "select MaHDB from tblHoaDonBan where MaHDB=N'" + textMaHD.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (textNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textNgayban.Focus();
                    return;
                }
                if (comboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaNV.Focus();
                    return;
                }
                if (comboMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaKH.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng tblhdban    
                sql = "insert into tblHoaDonBan(MaHDB, NgayBan, MaNV, MaKH, TongTien) values(N'" + textMaHD.Text.Trim() + "', '" + DateTime.ParseExact(textNgayban.Text.Trim(), "dd/MM/yyyy HH:mm:ss", null).ToString("yyyy-MM-dd HH:mm:ss") + "',N'" + comboMaNV.SelectedValue + "',N'" + comboMaKH.SelectedValue + "'," + textTongtien.Text + ")";
                Functions.RunSQL(sql);
            }

            // Lưu thông tin của các mặt hàng
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
            if (textGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textGiamgia.Focus();
                return;
            }
            sql = "select MaSP from tblChiTietHDB where MaSP=N'" + comboMahang.SelectedValue + "' and MaHDB = N'" + textMaHD.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                comboMahang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToInt32(Functions.GetFieldValues("select SoLuong from tblSanPham where MaSP = N'" + comboMahang.SelectedValue + "'"));
            if (Convert.ToInt32(textSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textSoluong.Text = "";
                textSoluong.Focus();
                return;
            }
            sql = "insert into tblChiTietHDB(MaHDB,MaSP,SoLuong,KhuyenMai,ThanhTien) values(N'" + textMaHD.Text.Trim() + "', N'" + comboMahang.SelectedValue + "'," + textSoluong.Text + "," + textGiamgia.Text + "," + textThanhtien.Text + ")";
            Functions.RunSQL(sql);
            Load_DataGridViewChitiet();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            slcon = sl - Convert.ToInt32(textSoluong.Text);
            sql = "update tblSanPham set SoLuong =" + slcon + " where MaSP= N'" + comboMahang.SelectedValue + "'";
            Functions.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("select TongTien from tblHoaDonBan where MaHDB = N'" + textMaHD.Text + "'"));
            tongmoi = tong + Convert.ToDouble(textThanhtien.Text);
            sql = "update tblHoaDonBan set TongTien =" + tongmoi + " where MaHDB = N'" + textMaHD.Text + "'";
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
            textTenhang.Text = "";
            textSoluong.Text = "";
            textDongia.Text = "";
            textGiamgia.Text = "0";
            textThanhtien.Text = "0";
        }

        private void dataGridViewHDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double thanhtien;
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = dataGridViewHDB.CurrentRow.Cells["MaSP"].Value.ToString();
                DelHang(textMaHD.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                thanhtien = Convert.ToDouble(dataGridViewHDB.CurrentRow.Cells["ThanhTien"].Value.ToString());
                DelUpdateTongtien(textMaHD.Text, thanhtien);
                Load_DataGridViewChitiet();
            }
        }

        private void DelHang(string MaHD, string MaSP)
        {
            Double s, sl, slcon;
            string sql;
            sql = "select SoLuong from tblChiTietHDB where MaHDB = N'" + MaHD + "' and MaSP = N'" + MaSP + "'";
            s = Convert.ToInt32(Functions.GetFieldValues(sql));
            sql = "delete tblChiTietHDB where MaHDB=N'" + MaHD + "' and MaSP = N'" + MaSP + "'";
            Functions.RunSQL_Del(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "select SoLuong from tblSanPham where MaSP = N'" + MaSP + "'";
            sl = Convert.ToInt32(Functions.GetFieldValues(sql));
            slcon = sl + s;
            sql = "update tblSanPham set SoLuong =" + slcon + " where MaSP= N'" + MaSP + "'";
            Functions.RunSQL(sql);
        }

        private void DelUpdateTongtien(string MaHD, double ThanhTien)
        {
            Double tong, tongmoi;
            string sql;
            sql = "select TongTien from tblHoaDonBan where MaHDB = N'" + MaHD + "'";
            tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            tongmoi = tong - ThanhTien;
            sql = "update tblHoaDonBan set TongTien =" + tongmoi + " where MaHDB = N'" + MaHD + "'";
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
                sql = "select MaSP from tblChiTietHDB where MaHDB = N'" + textMaHD.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaSP[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(textMaHD.Text, MaSP[i]);
                //Xóa hóa đơn
                sql = "delete tblHoaDonBan where MaHDB=N'" + textMaHD.Text + "'";
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
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "select TenNV from tblNhanVien where MaNV =N'" + comboMaNV.SelectedValue + "'";
            textTenNV.Text = Functions.GetFieldValues(str);
        }

        private void comboMaKH_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaKH.Text == "")
            {
                textTenKH.Text = "";
                textDiachi.Text = "";
                textDienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "select TenKH from tblKhachHang where MaKH = N'" + comboMaKH.SelectedValue + "'";
            textTenKH.Text = Functions.GetFieldValues(str);
            str = "select DiaChi from tblKhachHang where MaKH = N'" + comboMaKH.SelectedValue + "'";
            textDiachi.Text = Functions.GetFieldValues(str);
            str = "select SDT from tblKhachHang where MaKH= N'" + comboMaKH.SelectedValue + "'";
            textDienthoai.Text = Functions.GetFieldValues(str);
        }

        private void comboMahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMahang.Text == "")
            {
                textTenhang.Text = "";
                textDongia.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "select TenSP from tblSanPham where MaSP =N'" + comboMahang.SelectedValue + "'";
            textTenhang.Text = Functions.GetFieldValues(str);
            str = "select GiaBan from tblSanPham where MaSP =N'" + comboMahang.SelectedValue + "'";
            textDongia.Text = Functions.GetFieldValues(str);
        }

        private void textSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (textSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSoluong.Text);
            if (textGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(textGiamgia.Text);
            if (textDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textDongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            textThanhtien.Text = tt.ToString();
        }

        private void textGiamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (textSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSoluong.Text);
            if (textGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(textGiamgia.Text);
            if (textDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textDongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            textThanhtien.Text = tt.ToString();
        }

        private void buttonInHD_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
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
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "select a.MaHDB, a.NgayBan, a.TongTien, b.TenKH, b.DiaChi, b.SDT, c.TenNV " +
                "from tblHoaDonBan as a, tblKhachHang as b, tblNhanVien as c " +
                "where a.MaHDB = N'" + textMaHD.Text + "' and a.MaKH = b.MaKH and a.MaNV = c.MaNV";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "select b.TenSP, a.SoLuong, b.GiaBan, a.KhuyenMai, a.ThanhTien " +
                  "from tblChiTietHDB as a , tblSanPham as b " +
                  "where a.MaHDB = N'" + textMaHD.Text + "' and a.MaSP = b.MaSP";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;
        }

        private void buttonTimkiem_Click(object sender, EventArgs e)
        {
            if (comboMaHDB.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaHDB.Focus();
                return;
            }
            textMaHD.Text = comboMaHDB.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            buttonHuyHD.Enabled = true;
            buttonLuu.Enabled = true;
            buttonInHD.Enabled = true;
            comboMaHDB.SelectedIndex = -1;
        }

        private void textSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void comboMaHDB_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("select MaHDB from tblHoaDonBan", comboMaHDB, "MaHDB", "MaHDB");
            comboMaHDB.SelectedIndex = -1;
        }

        private void frmHoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}