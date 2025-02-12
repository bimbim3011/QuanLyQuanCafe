USE [master]
GO
/****** Object:  Database [QuanLyQuanCafe]    Script Date: 27/05/2024 9:05:44 PM ******/
CREATE DATABASE [QuanLyQuanCafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyQuanCafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.HATRONGCUONG\MSSQL\DATA\QuanLyQuanCafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyQuanCafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.HATRONGCUONG\MSSQL\DATA\QuanLyQuanCafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuanLyQuanCafe] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyQuanCafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyQuanCafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyQuanCafe', N'ON'
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuanLyQuanCafe]
GO
/****** Object:  Table [dbo].[tblChiTietHDB]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHDB](
	[MaHDB] [nvarchar](50) NOT NULL,
	[MaSP] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[KhuyenMai] [float] NOT NULL,
 CONSTRAINT [PK_tblChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblChiTietHDN]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHDN](
	[MaHDN] [nvarchar](50) NOT NULL,
	[MaSP] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[ChietKhau] [float] NOT NULL,
 CONSTRAINT [PK_tblChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCongDung]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCongDung](
	[MaCongDung] [nvarchar](10) NOT NULL,
	[TenCongDung] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblCongDung] PRIMARY KEY CLUSTERED 
(
	[MaCongDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHoaDonBan]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoaDonBan](
	[MaHDB] [nvarchar](50) NOT NULL,
	[NgayBan] [datetime] NOT NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[MaKH] [nvarchar](10) NOT NULL,
	[TongTien] [float] NOT NULL,
 CONSTRAINT [PK_tblHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHoaDonNhap]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoaDonNhap](
	[MaHDN] [nvarchar](50) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[MaNCC] [nvarchar](10) NOT NULL,
	[TongTien] [float] NOT NULL,
 CONSTRAINT [PK_tblHoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhachHang](
	[MaKH] [nvarchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[SDT] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLoai]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLoai](
	[MaLoai] [nvarchar](10) NOT NULL,
	[TenLoai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblLoai] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNhaCungCap]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhaCungCap](
	[MaNCC] [nvarchar](10) NOT NULL,
	[TenNCC] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[SDT] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblNhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[MaNV] [nvarchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[MaQue] [nvarchar](10) NOT NULL,
	[SDT] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQue]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQue](
	[MaQue] [nvarchar](10) NOT NULL,
	[TenQue] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblQue] PRIMARY KEY CLUSTERED 
(
	[MaQue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSanPham]    Script Date: 27/05/2024 9:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSanPham](
	[MaSP] [nvarchar](10) NOT NULL,
	[TenSP] [nvarchar](50) NOT NULL,
	[MaLoai] [nvarchar](10) NOT NULL,
	[GiaNhap] [float] NOT NULL,
	[GiaBan] [float] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[MaCongDung] [nvarchar](10) NOT NULL,
	[HinhAnh] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblSanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaSP], [SoLuong], [ThanhTien], [KhuyenMai]) VALUES (N'HDB25052024225601', N'SP01', 2, 20, 0)
GO
INSERT [dbo].[tblCongDung] ([MaCongDung], [TenCongDung]) VALUES (N'CD01', N'Công dụng 01')
INSERT [dbo].[tblCongDung] ([MaCongDung], [TenCongDung]) VALUES (N'CD02', N'Công dụng 01')
GO
INSERT [dbo].[tblHoaDonBan] ([MaHDB], [NgayBan], [MaNV], [MaKH], [TongTien]) VALUES (N'HDB25052024225601', CAST(N'2024-05-25T00:00:00.000' AS DateTime), N'NV01', N'KH01', 20)
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH01', N'Khách hàng 01', N'Hà Nội', N'0984930224')
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH02', N'Khách Hàng 02', N'Vĩnh Phúc', N'0984930225')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L01', N'Loai 01')
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L02', N'Loai 02')
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L03', N'Loai 03')
GO
INSERT [dbo].[tblNhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'CT01', N'Công ty 01', N'Ha Noi', N'0984930226')
INSERT [dbo].[tblNhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'CT02', N'Công ty 02', N'Vinh Phuc', N'0984930227')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV01', N'Nhân viên 01', N'Hà Nội', N'Nữ', CAST(N'2003-12-20' AS Date), N'05', N'0984930223')
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV02', N'Nhân viên 02', N'Vĩnh Phúc', N'Nam', CAST(N'2003-12-25' AS Date), N'06', N'0984930222')
GO
INSERT [dbo].[tblQue] ([MaQue], [TenQue]) VALUES (N'01', N'An Giang')
INSERT [dbo].[tblQue] ([MaQue], [TenQue]) VALUES (N'02', N'Bà Rịa-Vũng Tàu')
INSERT [dbo].[tblQue] ([MaQue], [TenQue]) VALUES (N'03', N'Bạc Liêu')
INSERT [dbo].[tblQue] ([MaQue], [TenQue]) VALUES (N'04', N'Bắc Giang')
INSERT [dbo].[tblQue] ([MaQue], [TenQue]) VALUES (N'05', N'Hà Nội')
INSERT [dbo].[tblQue] ([MaQue], [TenQue]) VALUES (N'06', N'Vĩnh Phúc')
INSERT [dbo].[tblQue] ([MaQue], [TenQue]) VALUES (N'07', N'Bắc Ninh')
INSERT [dbo].[tblQue] ([MaQue], [TenQue]) VALUES (N'08', N'Đà Nẵng')
GO
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [MaLoai], [GiaNhap], [GiaBan], [SoLuong], [MaCongDung], [HinhAnh]) VALUES (N'SP01', N'Sản phẩm 01', N'L01', 7, 10, 3, N'CD01', N'Hình ảnh 01')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [MaLoai], [GiaNhap], [GiaBan], [SoLuong], [MaCongDung], [HinhAnh]) VALUES (N'SP02', N'Sản phẩm 02', N'L01', 6, 15, 7, N'CD01', N'Hình ảnh 02')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [MaLoai], [GiaNhap], [GiaBan], [SoLuong], [MaCongDung], [HinhAnh]) VALUES (N'SP03', N'Sản phẩm 03', N'L02', 8, 20, 8, N'CD02', N'Hình ảnh 03')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [MaLoai], [GiaNhap], [GiaBan], [SoLuong], [MaCongDung], [HinhAnh]) VALUES (N'SP04', N'Sản phẩm 04', N'L02', 5, 12, 7, N'CD02', N'Hình ảnh 04')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [MaLoai], [GiaNhap], [GiaBan], [SoLuong], [MaCongDung], [HinhAnh]) VALUES (N'SP05', N'Sản phẩm 05', N'L03', 5, 14, 10, N'CD01', N'Hình ảnh 05')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [MaLoai], [GiaNhap], [GiaBan], [SoLuong], [MaCongDung], [HinhAnh]) VALUES (N'SP06', N'Sản phẩm 06', N'L03', 7, 15, 15, N'CD02', N'Hình ảnh 06')
GO
ALTER TABLE [dbo].[tblChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDB_tblHoaDonBan] FOREIGN KEY([MaHDB])
REFERENCES [dbo].[tblHoaDonBan] ([MaHDB])
GO
ALTER TABLE [dbo].[tblChiTietHDB] CHECK CONSTRAINT [FK_tblChiTietHDB_tblHoaDonBan]
GO
ALTER TABLE [dbo].[tblChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDB_tblSanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[tblSanPham] ([MaSP])
GO
ALTER TABLE [dbo].[tblChiTietHDB] CHECK CONSTRAINT [FK_tblChiTietHDB_tblSanPham]
GO
ALTER TABLE [dbo].[tblChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDN_tblHoaDonNhap] FOREIGN KEY([MaHDN])
REFERENCES [dbo].[tblHoaDonNhap] ([MaHDN])
GO
ALTER TABLE [dbo].[tblChiTietHDN] CHECK CONSTRAINT [FK_tblChiTietHDN_tblHoaDonNhap]
GO
ALTER TABLE [dbo].[tblChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDN_tblSanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[tblSanPham] ([MaSP])
GO
ALTER TABLE [dbo].[tblChiTietHDN] CHECK CONSTRAINT [FK_tblChiTietHDN_tblSanPham]
GO
ALTER TABLE [dbo].[tblHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonBan_tblKhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tblKhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[tblHoaDonBan] CHECK CONSTRAINT [FK_tblHoaDonBan_tblKhachHang]
GO
ALTER TABLE [dbo].[tblHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonBan_tblNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tblHoaDonBan] CHECK CONSTRAINT [FK_tblHoaDonBan_tblNhanVien]
GO
ALTER TABLE [dbo].[tblHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonNhap_tblNhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[tblNhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[tblHoaDonNhap] CHECK CONSTRAINT [FK_tblHoaDonNhap_tblNhaCungCap]
GO
ALTER TABLE [dbo].[tblHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonNhap_tblNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tblHoaDonNhap] CHECK CONSTRAINT [FK_tblHoaDonNhap_tblNhanVien]
GO
ALTER TABLE [dbo].[tblNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_tblNhanVien_tblQue] FOREIGN KEY([MaQue])
REFERENCES [dbo].[tblQue] ([MaQue])
GO
ALTER TABLE [dbo].[tblNhanVien] CHECK CONSTRAINT [FK_tblNhanVien_tblQue]
GO
ALTER TABLE [dbo].[tblSanPham]  WITH CHECK ADD  CONSTRAINT [FK_tblSanPham_tblCongDung] FOREIGN KEY([MaCongDung])
REFERENCES [dbo].[tblCongDung] ([MaCongDung])
GO
ALTER TABLE [dbo].[tblSanPham] CHECK CONSTRAINT [FK_tblSanPham_tblCongDung]
GO
ALTER TABLE [dbo].[tblSanPham]  WITH CHECK ADD  CONSTRAINT [FK_tblSanPham_tblLoai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[tblLoai] ([MaLoai])
GO
ALTER TABLE [dbo].[tblSanPham] CHECK CONSTRAINT [FK_tblSanPham_tblLoai]
GO
USE [master]
GO
ALTER DATABASE [QuanLyQuanCafe] SET  READ_WRITE 
GO
