namespace QuanLyQuanCafe.Forms
{
    partial class frmBaoCaoDoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grbKhoang = new System.Windows.Forms.GroupBox();
            this.mskTheoKhoang2 = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mskTheoKhoang1 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mskTheoNgay = new System.Windows.Forms.MaskedTextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.cboTenSP = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.rdTheoKhoang = new System.Windows.Forms.RadioButton();
            this.rdTheoNgay = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvBaoCaoDoanhThu = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.lblBangChu = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grbKhoang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(521, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO DOANH THU";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.txtDoanhThu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.grbKhoang);
            this.groupBox1.Controls.Add(this.mskTheoNgay);
            this.groupBox1.Controls.Add(this.txtGiaBan);
            this.groupBox1.Controls.Add(this.cboTenSP);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.rdTheoKhoang);
            this.groupBox1.Controls.Add(this.rdTheoNgay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(91, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1334, 202);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(1237, 175);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(97, 27);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(916, 143);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(215, 22);
            this.txtDoanhThu.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(804, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Doanh thu:";
            // 
            // grbKhoang
            // 
            this.grbKhoang.Controls.Add(this.mskTheoKhoang2);
            this.grbKhoang.Controls.Add(this.label6);
            this.grbKhoang.Controls.Add(this.mskTheoKhoang1);
            this.grbKhoang.Controls.Add(this.label5);
            this.grbKhoang.Location = new System.Drawing.Point(916, 74);
            this.grbKhoang.Name = "grbKhoang";
            this.grbKhoang.Size = new System.Drawing.Size(372, 38);
            this.grbKhoang.TabIndex = 7;
            this.grbKhoang.TabStop = false;
            // 
            // mskTheoKhoang2
            // 
            this.mskTheoKhoang2.Location = new System.Drawing.Point(226, 11);
            this.mskTheoKhoang2.Mask = "00/00/0000";
            this.mskTheoKhoang2.Name = "mskTheoKhoang2";
            this.mskTheoKhoang2.Size = new System.Drawing.Size(130, 22);
            this.mskTheoKhoang2.TabIndex = 10;
            this.mskTheoKhoang2.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Đến";
            // 
            // mskTheoKhoang1
            // 
            this.mskTheoKhoang1.Location = new System.Drawing.Point(35, 11);
            this.mskTheoKhoang1.Mask = "00/00/0000";
            this.mskTheoKhoang1.Name = "mskTheoKhoang1";
            this.mskTheoKhoang1.Size = new System.Drawing.Size(130, 22);
            this.mskTheoKhoang1.TabIndex = 8;
            this.mskTheoKhoang1.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Từ";
            // 
            // mskTheoNgay
            // 
            this.mskTheoNgay.Location = new System.Drawing.Point(916, 30);
            this.mskTheoNgay.Mask = "00/00/0000";
            this.mskTheoNgay.Name = "mskTheoNgay";
            this.mskTheoNgay.Size = new System.Drawing.Size(130, 22);
            this.mskTheoNgay.TabIndex = 6;
            this.mskTheoNgay.ValidatingType = typeof(System.DateTime);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(160, 140);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(215, 22);
            this.txtGiaBan.TabIndex = 5;
            // 
            // cboTenSP
            // 
            this.cboTenSP.FormattingEnabled = true;
            this.cboTenSP.Location = new System.Drawing.Point(160, 28);
            this.cboTenSP.Name = "cboTenSP";
            this.cboTenSP.Size = new System.Drawing.Size(215, 24);
            this.cboTenSP.TabIndex = 2;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(160, 88);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(215, 22);
            this.txtSoLuong.TabIndex = 3;
            // 
            // rdTheoKhoang
            // 
            this.rdTheoKhoang.AutoSize = true;
            this.rdTheoKhoang.Location = new System.Drawing.Point(771, 92);
            this.rdTheoKhoang.Name = "rdTheoKhoang";
            this.rdTheoKhoang.Size = new System.Drawing.Size(111, 20);
            this.rdTheoKhoang.TabIndex = 4;
            this.rdTheoKhoang.TabStop = true;
            this.rdTheoKhoang.Text = "Theo khoảng:";
            this.rdTheoKhoang.UseVisualStyleBackColor = true;
            // 
            // rdTheoNgay
            // 
            this.rdTheoNgay.AutoSize = true;
            this.rdTheoNgay.Location = new System.Drawing.Point(771, 34);
            this.rdTheoNgay.Name = "rdTheoNgay";
            this.rdTheoNgay.Size = new System.Drawing.Size(96, 20);
            this.rdTheoNgay.TabIndex = 3;
            this.rdTheoNgay.TabStop = true;
            this.rdTheoNgay.Text = "Theo ngày:";
            this.rdTheoNgay.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giá bán:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số lượng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // dgvBaoCaoDoanhThu
            // 
            this.dgvBaoCaoDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoDoanhThu.Location = new System.Drawing.Point(251, 283);
            this.dgvBaoCaoDoanhThu.Name = "dgvBaoCaoDoanhThu";
            this.dgvBaoCaoDoanhThu.RowHeadersWidth = 51;
            this.dgvBaoCaoDoanhThu.RowTemplate.Height = 24;
            this.dgvBaoCaoDoanhThu.Size = new System.Drawing.Size(971, 149);
            this.dgvBaoCaoDoanhThu.TabIndex = 2;
            this.dgvBaoCaoDoanhThu.Click += new System.EventHandler(this.dgvBaoCaoDoanhThu_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 448);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(320, 442);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(146, 22);
            this.txtTongTien.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(248, 485);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Bằng chữ:";
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Location = new System.Drawing.Point(1125, 464);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(97, 27);
            this.btnInBaoCao.TabIndex = 10;
            this.btnInBaoCao.Text = "In báo cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnHienThi
            // 
            this.btnHienThi.Location = new System.Drawing.Point(1007, 464);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(97, 27);
            this.btnHienThi.TabIndex = 12;
            this.btnHienThi.Text = "Hiển thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            // 
            // lblBangChu
            // 
            this.lblBangChu.AutoSize = true;
            this.lblBangChu.Location = new System.Drawing.Point(320, 485);
            this.lblBangChu.Name = "lblBangChu";
            this.lblBangChu.Size = new System.Drawing.Size(0, 16);
            this.lblBangChu.TabIndex = 13;
            // 
            // frmBaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1516, 550);
            this.Controls.Add(this.lblBangChu);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.btnInBaoCao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvBaoCaoDoanhThu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCaoDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Doanh Thu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbKhoang.ResumeLayout(false);
            this.grbKhoang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdTheoKhoang;
        private System.Windows.Forms.RadioButton rdTheoNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grbKhoang;
        private System.Windows.Forms.MaskedTextBox mskTheoKhoang2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mskTheoKhoang1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mskTheoNgay;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.ComboBox cboTenSP;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.DataGridView dgvBaoCaoDoanhThu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Label lblBangChu;
    }
}