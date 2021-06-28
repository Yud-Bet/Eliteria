USE [master]
GO
/****** Object:  Database [ELITERIA]    Script Date: 6/28/2021 10:42:42 PM ******/
CREATE DATABASE [ELITERIA]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'ELITERIA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ELITERIA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'ELITERIA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ELITERIA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ELITERIA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ELITERIA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ELITERIA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ELITERIA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ELITERIA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ELITERIA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ELITERIA] SET ARITHABORT OFF 
GO
ALTER DATABASE [ELITERIA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ELITERIA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ELITERIA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ELITERIA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ELITERIA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ELITERIA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ELITERIA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ELITERIA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ELITERIA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ELITERIA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ELITERIA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ELITERIA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ELITERIA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ELITERIA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ELITERIA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ELITERIA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ELITERIA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ELITERIA] SET RECOVERY FULL 
GO
ALTER DATABASE [ELITERIA] SET  MULTI_USER 
GO
ALTER DATABASE [ELITERIA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ELITERIA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ELITERIA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ELITERIA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ELITERIA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ELITERIA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ELITERIA', N'ON'
GO
ALTER DATABASE [ELITERIA] SET QUERY_STORE = OFF
GO
USE [ELITERIA]
GO
/****** Object:  Table [dbo].[BAOCAODSHD]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAOCAODSHD](
	[MaBCDSHD] [int] IDENTITY(1000,1) NOT NULL,
	[Ngay] [date] NULL,
	[MaLoaiSTK] [int] NULL,
	[TongThu] [money] NULL,
	[TongChi] [money] NULL,
	[ChenhLech] [money] NULL,
 CONSTRAINT [PK_BAOCAODSHD] PRIMARY KEY CLUSTERED 
(
	[MaBCDSHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BAOCAOMODONGSO]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAOCAOMODONGSO](
	[MaBCMODONGSO] [int] IDENTITY(1000,1) NOT NULL,
	[Ngay] [date] NULL,
	[MaLoaiSTK] [int] NOT NULL,
	[SoSoMo] [int] NULL,
	[SoSoDong] [int] NULL,
	[ChenhLech] [int] NULL,
 CONSTRAINT [PK_BAOCAOMODONGSO] PRIMARY KEY CLUSTERED 
(
	[MaBCMODONGSO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](50) NULL,
 CONSTRAINT [PK_CHUCVU] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[CCCD/CMND] [varchar](50) NOT NULL,
	[DienThoai] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIGIAODICH]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIGIAODICH](
	[MaLoaiGD] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiGD] [nvarchar](50) NULL,
 CONSTRAINT [PK_LAOIGIAODICH] PRIMARY KEY CLUSTERED 
(
	[MaLoaiGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISOTIETKIEM]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISOTIETKIEM](
	[MaLoaiSTK] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSTK] [nvarchar](50) NOT NULL,
	[KyHan] [int] NOT NULL,
	[LaiSuat] [real] NULL,
	[NgayApDung] [date] NULL,
	[SoNgayToiThieuDuocRutTien] [int] NOT NULL,
	[QDSoTienDuocRut] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LOAISOTIETKIEM] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[MaCV] [int] NOT NULL,
	[Pass] [varchar](50) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[CCCD/CMND] [varchar](50) NOT NULL,
	[DienThoai] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUGIAODICH]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUGIAODICH](
	[MaPhieuGD] [int] IDENTITY(1000,1) NOT NULL,
	[MaLoaiGD] [int] NOT NULL,
	[MaSTK] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayLapPhieu] [smalldatetime] NULL,
	[SoTien] [money] NOT NULL,
 CONSTRAINT [PK_PHIEUGIAODICH] PRIMARY KEY CLUSTERED 
(
	[MaPhieuGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOTIETKIEM]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOTIETKIEM](
	[MaSTK] [int] IDENTITY(1000,1) NOT NULL,
	[MaKH] [int] NOT NULL,
	[MaLoaiSTK] [int] NOT NULL,
	[NgayMoSo] [date] NULL,
	[TongSoTienDaGui] [money] NULL,
	[TongSoTienDaRut] [money] NULL,
	[TienLaiPhatSinh] [money] NULL,
	[SoDu] [money] NULL,
	[NgayDaoHanKeTiep] [date] NULL,
	[LaiSuatApDung] [real] NULL,
	[TrangThai] [bit] NULL,
	[NgayDongSo] [date] NULL,
	[NgayDaoHanTruoc] [date] NULL,
 CONSTRAINT [PK_SOTIETKIEM] PRIMARY KEY CLUSTERED 
(
	[MaSTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 6/28/2021 10:42:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[SoTienGuiBDToiThieu] [money] NULL,
	[SoTienGuiThemToiThieu] [money] NULL,
	[ChucNangDongMoSo] [bit] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CHUCVU] ON 
GO
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (1, N'Quản lý')
GO
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (2, N'Nhân viên')
GO
SET IDENTITY_INSERT [dbo].[CHUCVU] OFF
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [CCCD/CMND], [DienThoai], [Email], [DiaChi], [GioiTinh], [NgaySinh], [TrangThai]) VALUES (1, N'Hồ Minh Quân', N'19521313', N'0123123456', N'quanhominh@gmail.com', N'Kom Tum', 1, CAST(N'2001-04-30' AS Date), 1)
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [CCCD/CMND], [DienThoai], [Email], [DiaChi], [GioiTinh], [NgaySinh], [TrangThai]) VALUES (2, N'Lê Thanh Dàn', N'19521311', N'0366588558', N'danlethanh@gmail.com', N'Quảng Trị', 1, CAST(N'2001-03-27' AS Date), 1)
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [CCCD/CMND], [DienThoai], [Email], [DiaChi], [GioiTinh], [NgaySinh], [TrangThai]) VALUES (3, N'Lê Trung Hiếu', N'19521499', N'123123', N'hieuletrung@gmail.com', N'Huế', 1, CAST(N'2001-04-01' AS Date), 1)
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [CCCD/CMND], [DienThoai], [Email], [DiaChi], [GioiTinh], [NgaySinh], [TrangThai]) VALUES (4, N'Hoàng Anh', N'1952xxxx', N'1212', N'abc', N'TP.HCM', 1, CAST(N'2001-09-01' AS Date), 1)
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [CCCD/CMND], [DienThoai], [Email], [DiaChi], [GioiTinh], [NgaySinh], [TrangThai]) VALUES (5, N'Nguyễn Văn Huấn', N'1952xxxx', N'1212121212', N'huan@gmai.com', N'Nghệ An', 1, CAST(N'2001-05-01' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[LOAIGIAODICH] ON 
GO
INSERT [dbo].[LOAIGIAODICH] ([MaLoaiGD], [TenLoaiGD]) VALUES (1, N'Gửi tiền')
GO
INSERT [dbo].[LOAIGIAODICH] ([MaLoaiGD], [TenLoaiGD]) VALUES (2, N'Rút tiền')
GO
SET IDENTITY_INSERT [dbo].[LOAIGIAODICH] OFF
GO
SET IDENTITY_INSERT [dbo].[LOAISOTIETKIEM] ON 
GO
INSERT [dbo].[LOAISOTIETKIEM] ([MaLoaiSTK], [TenLoaiSTK], [KyHan], [LaiSuat], [NgayApDung], [SoNgayToiThieuDuocRutTien], [QDSoTienDuocRut]) VALUES (1, N'Không kỳ hạn', 1, 0.15, CAST(N'2021-06-14' AS Date), 15, N'<=')
GO
INSERT [dbo].[LOAISOTIETKIEM] ([MaLoaiSTK], [TenLoaiSTK], [KyHan], [LaiSuat], [NgayApDung], [SoNgayToiThieuDuocRutTien], [QDSoTienDuocRut]) VALUES (2, N'3 tháng', 3, 0.5, CAST(N'2021-06-14' AS Date), 90, N'=')
GO
INSERT [dbo].[LOAISOTIETKIEM] ([MaLoaiSTK], [TenLoaiSTK], [KyHan], [LaiSuat], [NgayApDung], [SoNgayToiThieuDuocRutTien], [QDSoTienDuocRut]) VALUES (3, N'6 tháng', 6, 0.55, CAST(N'2021-06-14' AS Date), 180, N'=')
GO
SET IDENTITY_INSERT [dbo].[LOAISOTIETKIEM] OFF
GO
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [MaCV], [Pass], [TenNV], [CCCD/CMND], [DienThoai], [Email], [DiaChi], [GioiTinh], [NgaySinh], [TrangThai]) VALUES (1, 1, N'1', N'Lê Trung Hiếu', N'19521499', N'0123321123', N'1', N'Thừa Thiên Huế', 1, CAST(N'2001-04-01' AS Date), 1)
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [MaCV], [Pass], [TenNV], [CCCD/CMND], [DienThoai], [Email], [DiaChi], [GioiTinh], [NgaySinh], [TrangThai]) VALUES (2, 1, N'2', N'Nguyễn Văn Huấn', N'19521556', N'0987890009', N'huannguyenvan@gmail.com', N'Nghệ An', 1, CAST(N'2001-05-01' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
GO
SET IDENTITY_INSERT [dbo].[SOTIETKIEM] ON 
GO
INSERT [dbo].[SOTIETKIEM] ([MaSTK], [MaKH], [MaLoaiSTK], [NgayMoSo], [TongSoTienDaGui], [TongSoTienDaRut], [TienLaiPhatSinh], [SoDu], [NgayDaoHanKeTiep], [LaiSuatApDung], [TrangThai], [NgayDongSo], [NgayDaoHanTruoc]) VALUES (1000, 1, 1, CAST(N'2021-06-28' AS Date), 1001000000.0000, 0.0000, 0.0000, 1001000000.0000, CAST(N'2021-07-28' AS Date), 0.15, 1, NULL, CAST(N'2021-06-28' AS Date))
GO
INSERT [dbo].[SOTIETKIEM] ([MaSTK], [MaKH], [MaLoaiSTK], [NgayMoSo], [TongSoTienDaGui], [TongSoTienDaRut], [TienLaiPhatSinh], [SoDu], [NgayDaoHanKeTiep], [LaiSuatApDung], [TrangThai], [NgayDongSo], [NgayDaoHanTruoc]) VALUES (1001, 2, 2, CAST(N'2021-06-28' AS Date), 1002000000.0000, 0.0000, 0.0000, 1002000000.0000, CAST(N'2021-09-28' AS Date), 0.5, 1, NULL, CAST(N'2021-06-28' AS Date))
GO
INSERT [dbo].[SOTIETKIEM] ([MaSTK], [MaKH], [MaLoaiSTK], [NgayMoSo], [TongSoTienDaGui], [TongSoTienDaRut], [TienLaiPhatSinh], [SoDu], [NgayDaoHanKeTiep], [LaiSuatApDung], [TrangThai], [NgayDongSo], [NgayDaoHanTruoc]) VALUES (1002, 3, 3, CAST(N'2021-06-28' AS Date), 1100000000.0000, 0.0000, 0.0000, 1100000000.0000, CAST(N'2021-12-28' AS Date), 0.55, 1, NULL, CAST(N'2021-06-28' AS Date))
GO
INSERT [dbo].[SOTIETKIEM] ([MaSTK], [MaKH], [MaLoaiSTK], [NgayMoSo], [TongSoTienDaGui], [TongSoTienDaRut], [TienLaiPhatSinh], [SoDu], [NgayDaoHanKeTiep], [LaiSuatApDung], [TrangThai], [NgayDongSo], [NgayDaoHanTruoc]) VALUES (1003, 4, 1, CAST(N'2021-06-28' AS Date), 1000000000.0000, 0.0000, 0.0000, 1000000000.0000, CAST(N'2021-07-28' AS Date), 0.15, 1, NULL, CAST(N'2021-06-28' AS Date))
GO
INSERT [dbo].[SOTIETKIEM] ([MaSTK], [MaKH], [MaLoaiSTK], [NgayMoSo], [TongSoTienDaGui], [TongSoTienDaRut], [TienLaiPhatSinh], [SoDu], [NgayDaoHanKeTiep], [LaiSuatApDung], [TrangThai], [NgayDongSo], [NgayDaoHanTruoc]) VALUES (1004, 4, 2, CAST(N'2021-06-28' AS Date), 1010000000.0000, 0.0000, 0.0000, 1010000000.0000, CAST(N'2021-09-28' AS Date), 0.5, 1, NULL, CAST(N'2021-06-28' AS Date))
GO
INSERT [dbo].[SOTIETKIEM] ([MaSTK], [MaKH], [MaLoaiSTK], [NgayMoSo], [TongSoTienDaGui], [TongSoTienDaRut], [TienLaiPhatSinh], [SoDu], [NgayDaoHanKeTiep], [LaiSuatApDung], [TrangThai], [NgayDongSo], [NgayDaoHanTruoc]) VALUES (1005, 1, 2, CAST(N'2021-06-28' AS Date), 1000000000.0000, 0.0000, 0.0000, 1000000000.0000, CAST(N'2021-09-28' AS Date), 0.5, 1, NULL, CAST(N'2021-06-28' AS Date))
GO
INSERT [dbo].[SOTIETKIEM] ([MaSTK], [MaKH], [MaLoaiSTK], [NgayMoSo], [TongSoTienDaGui], [TongSoTienDaRut], [TienLaiPhatSinh], [SoDu], [NgayDaoHanKeTiep], [LaiSuatApDung], [TrangThai], [NgayDongSo], [NgayDaoHanTruoc]) VALUES (1006, 2, 2, CAST(N'2021-06-28' AS Date), 1000100000.0000, 0.0000, 0.0000, 1000100000.0000, CAST(N'2021-09-28' AS Date), 0.5, 1, NULL, CAST(N'2021-06-28' AS Date))
GO
SET IDENTITY_INSERT [dbo].[SOTIETKIEM] OFF
GO
SET IDENTITY_INSERT [dbo].[PHIEUGIAODICH] ON 
GO
INSERT [dbo].[PHIEUGIAODICH] ([MaPhieuGD], [MaLoaiGD], [MaSTK], [MaNV], [NgayLapPhieu], [SoTien]) VALUES (1000, 1, 1000, 1, CAST(N'2021-06-28T22:07:00' AS SmallDateTime), 1000000.0000)
GO
INSERT [dbo].[PHIEUGIAODICH] ([MaPhieuGD], [MaLoaiGD], [MaSTK], [MaNV], [NgayLapPhieu], [SoTien]) VALUES (1001, 1, 1001, 1, CAST(N'2021-06-28T22:07:00' AS SmallDateTime), 1000000.0000)
GO
INSERT [dbo].[PHIEUGIAODICH] ([MaPhieuGD], [MaLoaiGD], [MaSTK], [MaNV], [NgayLapPhieu], [SoTien]) VALUES (1002, 1, 1002, 1, CAST(N'2021-06-28T22:07:00' AS SmallDateTime), 100000000.0000)
GO
INSERT [dbo].[PHIEUGIAODICH] ([MaPhieuGD], [MaLoaiGD], [MaSTK], [MaNV], [NgayLapPhieu], [SoTien]) VALUES (1003, 1, 1004, 1, CAST(N'2021-06-28T22:07:00' AS SmallDateTime), 10000000.0000)
GO
INSERT [dbo].[PHIEUGIAODICH] ([MaPhieuGD], [MaLoaiGD], [MaSTK], [MaNV], [NgayLapPhieu], [SoTien]) VALUES (1004, 1, 1006, 1, CAST(N'2021-06-28T22:07:00' AS SmallDateTime), 100000.0000)
GO
INSERT [dbo].[PHIEUGIAODICH] ([MaPhieuGD], [MaLoaiGD], [MaSTK], [MaNV], [NgayLapPhieu], [SoTien]) VALUES (1005, 1, 1001, 1, CAST(N'2021-06-28T22:37:00' AS SmallDateTime), 1000000.0000)
GO
SET IDENTITY_INSERT [dbo].[PHIEUGIAODICH] OFF
GO
SET IDENTITY_INSERT [dbo].[BAOCAODSHD] ON 
GO
INSERT [dbo].[BAOCAODSHD] ([MaBCDSHD], [Ngay], [MaLoaiSTK], [TongThu], [TongChi], [ChenhLech]) VALUES (1000, CAST(N'2021-06-28' AS Date), 1, 2001000000.0000, 0.0000, 2001000000.0000)
GO
INSERT [dbo].[BAOCAODSHD] ([MaBCDSHD], [Ngay], [MaLoaiSTK], [TongThu], [TongChi], [ChenhLech]) VALUES (1001, CAST(N'2021-06-28' AS Date), 2, 4012100000.0000, 0.0000, 4012100000.0000)
GO
INSERT [dbo].[BAOCAODSHD] ([MaBCDSHD], [Ngay], [MaLoaiSTK], [TongThu], [TongChi], [ChenhLech]) VALUES (1002, CAST(N'2021-06-28' AS Date), 3, 1100000000.0000, 0.0000, 1100000000.0000)
GO
SET IDENTITY_INSERT [dbo].[BAOCAODSHD] OFF
GO
SET IDENTITY_INSERT [dbo].[BAOCAOMODONGSO] ON 
GO
INSERT [dbo].[BAOCAOMODONGSO] ([MaBCMODONGSO], [Ngay], [MaLoaiSTK], [SoSoMo], [SoSoDong], [ChenhLech]) VALUES (1000, CAST(N'2021-06-28' AS Date), 1, 2, 0, 2)
GO
INSERT [dbo].[BAOCAOMODONGSO] ([MaBCMODONGSO], [Ngay], [MaLoaiSTK], [SoSoMo], [SoSoDong], [ChenhLech]) VALUES (1001, CAST(N'2021-06-28' AS Date), 2, 4, 0, 4)
GO
INSERT [dbo].[BAOCAOMODONGSO] ([MaBCMODONGSO], [Ngay], [MaLoaiSTK], [SoSoMo], [SoSoDong], [ChenhLech]) VALUES (1002, CAST(N'2021-06-28' AS Date), 3, 1, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[BAOCAOMODONGSO] OFF
GO

INSERT [dbo].[THAMSO] ([SoTienGuiBDToiThieu], [SoTienGuiThemToiThieu], [ChucNangDongMoSo]) VALUES (1000000.0000, 100000.0000, 1)
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT ((1)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[LOAISOTIETKIEM] ADD  DEFAULT (getdate()) FOR [NgayApDung]
GO
ALTER TABLE [dbo].[NHANVIEN] ADD  DEFAULT ((1)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[NHANVIEN] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PHIEUGIAODICH] ADD  DEFAULT (getdate()) FOR [NgayLapPhieu]
GO
ALTER TABLE [dbo].[SOTIETKIEM] ADD  DEFAULT (getdate()) FOR [NgayMoSo]
GO
ALTER TABLE [dbo].[SOTIETKIEM] ADD  DEFAULT ((0)) FOR [TongSoTienDaGui]
GO
ALTER TABLE [dbo].[SOTIETKIEM] ADD  DEFAULT ((0)) FOR [TongSoTienDaRut]
GO
ALTER TABLE [dbo].[SOTIETKIEM] ADD  DEFAULT ((0)) FOR [TienLaiPhatSinh]
GO
ALTER TABLE [dbo].[SOTIETKIEM] ADD  DEFAULT ((0)) FOR [SoDu]
GO
ALTER TABLE [dbo].[SOTIETKIEM] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[BAOCAODSHD]  WITH CHECK ADD  CONSTRAINT [FK_BAOCAODSHD_LOAISOTIETKIEM] FOREIGN KEY([MaLoaiSTK])
REFERENCES [dbo].[LOAISOTIETKIEM] ([MaLoaiSTK])
GO
ALTER TABLE [dbo].[BAOCAODSHD] CHECK CONSTRAINT [FK_BAOCAODSHD_LOAISOTIETKIEM]
GO
ALTER TABLE [dbo].[BAOCAOMODONGSO]  WITH CHECK ADD  CONSTRAINT [FK_BAOCAOMODONGSO_LOAISOTIETKIEM] FOREIGN KEY([MaLoaiSTK])
REFERENCES [dbo].[LOAISOTIETKIEM] ([MaLoaiSTK])
GO
ALTER TABLE [dbo].[BAOCAOMODONGSO] CHECK CONSTRAINT [FK_BAOCAOMODONGSO_LOAISOTIETKIEM]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_CHUCVU] FOREIGN KEY([MaCV])
REFERENCES [dbo].[CHUCVU] ([MaCV])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_CHUCVU]
GO
ALTER TABLE [dbo].[PHIEUGIAODICH]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUGIAODICH_LOAIGIAODICH] FOREIGN KEY([MaLoaiGD])
REFERENCES [dbo].[LOAIGIAODICH] ([MaLoaiGD])
GO
ALTER TABLE [dbo].[PHIEUGIAODICH] CHECK CONSTRAINT [FK_PHIEUGIAODICH_LOAIGIAODICH]
GO
ALTER TABLE [dbo].[PHIEUGIAODICH]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUGIAODICH_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUGIAODICH] CHECK CONSTRAINT [FK_PHIEUGIAODICH_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUGIAODICH]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUGIAODICH_SOTIETKIEM] FOREIGN KEY([MaSTK])
REFERENCES [dbo].[SOTIETKIEM] ([MaSTK])
GO
ALTER TABLE [dbo].[PHIEUGIAODICH] CHECK CONSTRAINT [FK_PHIEUGIAODICH_SOTIETKIEM]
GO
ALTER TABLE [dbo].[SOTIETKIEM]  WITH CHECK ADD  CONSTRAINT [FK_SOTIETKIEM_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[SOTIETKIEM] CHECK CONSTRAINT [FK_SOTIETKIEM_KHACHHANG]
GO
ALTER TABLE [dbo].[SOTIETKIEM]  WITH CHECK ADD  CONSTRAINT [FK_SOTIETKIEM_LOAISOTIETKIEM] FOREIGN KEY([MaLoaiSTK])
REFERENCES [dbo].[LOAISOTIETKIEM] ([MaLoaiSTK])
GO
ALTER TABLE [dbo].[SOTIETKIEM] CHECK CONSTRAINT [FK_SOTIETKIEM_LOAISOTIETKIEM]
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_AddNewSavingType]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Eliteria_AddNewSavingType]
(
	@Name nvarchar(50),
	@Period int,
	@InterestRate real,
	@EffectiveDate date,
	@MinNumOfDateToWithdraw int,
	@WithdrawalRule varchar(50)
)
as
begin
	if (select count(*)
		from LOAISOTIETKIEM L
		where @Period = l.KyHan
		and @InterestRate = l.LaiSuat
		and @MinNumOfDateToWithdraw = l.SoNgayToiThieuDuocRutTien
		and @WithdrawalRule = l.QDSoTienDuocRut) = 0 
	begin
		insert into LOAISOTIETKIEM 
		(TenLoaiSTK, KyHan,LaiSuat,NgayApDung,SoNgayToiThieuDuocRutTien,QDSoTienDuocRut)
		values (@Name,@Period,@InterestRate,@EffectiveDate,@MinNumOfDateToWithdraw,@WithdrawalRule)
	end 
end
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_AddNewStaff]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_AddNewStaff] @Position int, @Name nvarchar(50), @IdentificationNumber varchar(50), @Gender bit, @Birthday date, @PhoneNumber varchar(50), @Address nvarchar(200), @Password varchar(50), @Email varchar(50)
AS
BEGIN
	insert into NHANVIEN(MaCV, TenNV, [CCCD/CMND], GioiTinh, NgaySinh, DienThoai, DiaChi, Pass, Email)
	values (@Position , @Name , @IdentificationNumber , @Gender , @Birthday , @PhoneNumber , @Address , @Password , @Email)
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_AutomaticCalculateInterest]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Eliteria_AutomaticCalculateInterest] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	update SOTIETKIEM
	set TienLaiPhatSinh = TienLaiPhatSinh + (SoDu * LaiSuatApDung / 365) * DATEDIFF(day, NgayDaoHanTruoc, GETDATE()),
		NgayDaoHanTruoc = NgayDaoHanKeTiep,
		NgayDaoHanKeTiep = DATEADD(	MONTH,
						(select top 1 KyHan from LOAISOTIETKIEM
							where LOAISOTIETKIEM.MaLoaiSTK = SOTIETKIEM.MaLoaiSTK), NgayDaoHanKeTiep)

	where NgayDaoHanKeTiep = (select convert(date,(select GETDATE())))
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_CalculatePreMaturityInterest]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Eliteria_CalculatePreMaturityInterest]
	-- Add the parameters for the stored procedure here
	@MaSTK int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here

	declare @laiSuat real
	set @laiSuat = (select LaiSuat from LOAISOTIETKIEM where MaLoaiSTK = 1)
	
	update SOTIETKIEM
	set LaiSuatApDung = @laiSuat,
		TienLaiPhatSinh = TienLaiPhatSinh + (SoDu * @laiSuat / 365) * DATEDIFF(day, NgayDaoHanTruoc, GETDATE()),
		NgayDaoHanTruoc = GETDATE(),
		NgayDaoHanKeTiep = DATEADD(	MONTH,
						(select top 1 KyHan from LOAISOTIETKIEM
							where LOAISOTIETKIEM.MaLoaiSTK = SOTIETKIEM.MaLoaiSTK), GETDATE())
	where MaSTK = @MaSTK
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_ControlCloseSaving]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Eliteria_ControlCloseSaving] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT off;
	declare @iMaLoaiSTK int

    -- Insert statements for procedure here
	if ((select ChucNangDongMoSo from THAMSO) = 1)
		begin
			update SOTIETKIEM
			set TrangThai = 0, NgayDongSo = GETDATE(), @iMaLoaiSTK = SOTIETKIEM.MaLoaiSTK
			where SoDu = 0 and TrangThai = 1

			if (@iMaLoaiSTK is not null)
				begin
					if (0 = (select COUNT(*) from BAOCAOMODONGSO
							where	Ngay = Convert(date, GETDATE()) and
									MaLoaiSTK = @iMaLoaiSTK))
						begin
							insert into BAOCAOMODONGSO (Ngay,MaLoaiSTK, SoSoMo, SoSoDong, ChenhLech) values (GETDATE(), @iMaLoaiSTK ,0,1,-1)
						end
					else --if ((select top 1 NgayMoSo from inserted) = (select top 1 NgayMoSo from deleted))
						begin
							update BAOCAOMODONGSO
							set SoSoDong = SoSoDong + 1
							where	Ngay = Convert(date, GETDATE()) and
									MaLoaiSTK = @iMaLoaiSTK
						end
				end
		end
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_CreateNewAccountForNewCustomer]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_CreateNewAccountForNewCustomer] @tenkh nvarchar(50),@cmnd varchar(50),@diachi nvarchar(200),
				@dienthoai varchar(50),@email varchar(50),@gioitinh bit,@ngaysinh date,
				@loaitk nvarchar(50),@ngaymoso date,@tongtiendagui money
				
AS
BEGIN
DECLARE @makh int,@maltk int
INSERT INTO KHACHHANG(TenKH,[CCCD/CMND],DienThoai,DiaChi,Email,GioiTinh,NgaySinh,TrangThai)
VALUES(@tenkh,@cmnd,@dienthoai,@diachi,@email,@gioitinh,@ngaysinh,1)
SET @makh = (SELECT MAKH FROM KHACHHANG WHERE [CCCD/CMND]=@cmnd)
SET @maltk = (SELECT MaLoaiSTK FROM LOAISOTIETKIEM WHERE TenLoaiSTK = @loaitk)
INSERT INTO SOTIETKIEM(MaKH,MaLoaiSTK,NgayMoSo,TongSoTienDaGui,TrangThai)
VALUES(@makh,@maltk,@ngaymoso,@tongtiendagui,1)
END	
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_CreateNewAccountForOldUser]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_CreateNewAccountForOldUser] @cmnd varchar(50), @loaitk nvarchar(50),@ngaymoso date,@tiengui money
AS
BEGIN
DECLARE @makh INT ,@maltk int
SET @makh = (SELECT TOP 1 MaKH  FROM KHACHHANG WHERE [CCCD/CMND] =@cmnd)
Set @maltk = (SELECT TOP 1 MaLoaiSTK FROM LOAISOTIETKIEM WHERE TenLoaiSTK = @loaitk)
INSERT INTO SOTIETKIEM(MaKH,MaLoaiSTK,NgayMoSo,TongSoTienDaGui,TrangThai)
VALUES(@makh,@maltk,@ngaymoso,@tiengui,1)
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_EditOtherParameters]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Eliteria_EditOtherParameters]
(
	@MinDepositAmount money,
	@MinInitialDeposit money
)
as
begin
	update THAMSO
	set SoTienGuiBDToiThieu=@MinInitialDeposit,SoTienGuiThemToiThieu=@MinDepositAmount
end
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_EditSavingType]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Eliteria_EditSavingType]
(
	@ID int,
	@Period int,
	@NewInterestRate real,
	@NewMinNumOfDateToWithdraw int,
	@WithdrawalRule varchar(50)
)
as
begin
	if (select count(*)
		from LOAISOTIETKIEM L
		where @Period = l.KyHan
		and @NewInterestRate = l.LaiSuat
		and @NewMinNumOfDateToWithdraw = l.SoNgayToiThieuDuocRutTien
		and @WithdrawalRule = l.QDSoTienDuocRut) = 0 
	begin
		update LOAISOTIETKIEM 
		set LaiSuat=@NewInterestRate, SoNgayToiThieuDuocRutTien=@NewMinNumOfDateToWithdraw
		where MaLoaiSTK=@ID
	end 
end
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_GetAllCustomer]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_GetAllCustomer]

AS
BEGIN
	SELECT * FROM KHACHHANG
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_GetAllParameters]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_GetAllParameters]

AS
BEGIN
	SELECT * FROM KHACHHANG
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_GetAllSaving]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Eliteria_GetAllSaving]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select MaSTK, TenKH, SoDu , NgayDaoHanKeTiep, QDSoTienDuocRut, NgayDaoHanTruoc, NgayMoSo, SOTIETKIEM.MaLoaiSTK, SoNgayToiThieuDuocRutTien, TienLaiPhatSinh
	from SOTIETKIEM, KHACHHANG, LOAISOTIETKIEM
	where SOTIETKIEM.MaKH = KHACHHANG.MaKH and SOTIETKIEM.MaLoaiSTK = LOAISOTIETKIEM.MaLoaiSTK and SOTIETKIEM.TrangThai = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_GetCustomerIf]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Eliteria_GetCustomerIf]
	@MaKH int
AS
BEGIN
	SELECT * 
	FROM KHACHHANG
	where MaKH= @MaKH
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_GetSavingAccounts]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[Eliteria_GetSavingAccounts]
AS
BEGIN
	SELECT
		KH.TenKH,SK.MaSTK,KH.[CCCD/CMND],SK.SoDu,LTK.TenLoaiSTK,SK.NgayMoSo,KH.DiaChi,KH.Email,KH.DienThoai,KH.GioiTinh,KH.NgaySinh	
	FROM
		SOTIETKIEM SK,KHACHHANG KH, LOAISOTIETKIEM LTK
	WHERE
		SK.MaKH = KH.MaKH AND LTK.MaLoaiSTK =SK.MaLoaiSTK AND SK.TrangThai = 1
	
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_GetSavingIf]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_GetSavingIf]
	@MaSTK INT
AS
BEGIN
	SELECT * FROM SOTIETKIEM
	WHERE MaSTK = @MaSTK
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_InsertNewTransaction]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Eliteria_InsertNewTransaction]
	-- Add the parameters for the stored procedure here
	@MaLoaiGD int,
	@MaSTK int,
	@MaNV int,
	@Ngay	datetime,
	@SoTien money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	insert into PHIEUGIAODICH (MaLoaiGD,MaSTK,MaNV,NgayLapPhieu,SoTien) values (@MaLoaiGD,@MaSTK,@MaNV, @Ngay, @SoTien)

END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_LastTransactionID]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_LastTransactionID]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select top 1 MaPhieuGD from PHIEUGIAODICH
	order by MaPhieuGD desc 
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_LoadAllStaffs]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_LoadAllStaffs]
AS
BEGIN
	select TenNV, MaCV, [CCCD/CMND], GioiTinh, NgaySinh, DienThoai, DiaChi, Email
	from NHANVIEN
	where TrangThai = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_LoadMonthlyData]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_LoadMonthlyData]
AS
BEGIN
	select TenLoaiSTK, Ngay, SoSoMo, SoSoDong, ChenhLech
	from BAOCAOMODONGSO, LOAISOTIETKIEM
	where BAOCAOMODONGSO.MaLoaiSTK = LOAISOTIETKIEM.MaLoaiSTK
	order by Ngay asc
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_LoadOtherParameters]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Eliteria_LoadOtherParameters]
as
begin
	select *
	from THAMSO
end
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_LoadRevenueData]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_LoadRevenueData]
AS
BEGIN
	select Ngay, TenLoaiSTK, TongThu, TongChi, ChenhLech
	from BAOCAODSHD, LOAISOTIETKIEM
	where BAOCAODSHD.MaLoaiSTK = LOAISOTIETKIEM.MaLoaiSTK
	order by Ngay asc
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_LoadSavingsType]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_LoadSavingsType]
AS
BEGIN
	select TenLoaiSTK
	from LOAISOTIETKIEM
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_LoadSavingType]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Eliteria_LoadSavingType]
as
begin
	select * 
	from LOAISOTIETKIEM
end
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_Login]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_Login]
(
	@username AS VARCHAR,
	@password AS VARCHAR
)
AS
BEGIN
		SELECT *
		FROM NHANVIEN N
		WHERE N.Email=@username AND N.Pass=@password;
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_ModifyStaffInfo]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_ModifyStaffInfo] @StaffId int, @Position int, @Name nvarchar(50), @PhoneNumber varchar(50), @Email varchar(50), @Address nvarchar(200)
AS
BEGIN
	update NHANVIEN
	set MaCV = @Position, TenNV = @Name, DienThoai = @PhoneNumber, Email = @Email, DiaChi  = @Address
	where MaNV = @StaffId
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_SearchSaving]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliteria_SearchSaving]
AS
BEGIN
	select MaSTK, TenKH, SoDu
	from SOTIETKIEM, KHACHHANG
	where SOTIETKIEM.MaKH = KHACHHANG.MaKH
END
GO
/****** Object:  StoredProcedure [dbo].[Eliteria_WithdrawInterest]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Eliteria_WithdrawInterest]
	-- Add the parameters for the stored procedure here
	@MaSTK int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	update SOTIETKIEM 
	set --TongSoTienDaRut = TongSoTienDaRut + TienLaiPhatSinh,
		TienLaiPhatSinh = 0
	where MaSTK = @MaSTK
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetSavingAccounts]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSavingAccounts]
AS
BEGIN
	SELECT
		KH.TenKH,SK.MaSTK,KH.[CCCD/CMND],SK.SoDu,LTK.TenLoaiSTK,SK.NgayMoSo,KH.DiaChi	
	FROM
		SOTIETKIEM SK,KHACHHANG KH, LOAISOTIETKIEM LTK
	WHERE
		SK.MaKH = KH.MaKH AND LTK.MaLoaiSTK =SK.MaLoaiSTK
	
END


--EXEC GetSavingAccounts
GO
/****** Object:  Trigger [dbo].[TG_BAOCAODSHD]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TG_BAOCAODSHD]
on [dbo].[BAOCAODSHD]
after update
as
begin
	update BAOCAODSHD
	set ChenhLech = TongThu - TongChi
	where MaBCDSHD = (select top 1 MaBCDSHD from inserted)
end
GO
ALTER TABLE [dbo].[BAOCAODSHD] ENABLE TRIGGER [TG_BAOCAODSHD]
GO
/****** Object:  Trigger [dbo].[TG_BAOCAOMODONGSO_UPDATE]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[TG_BAOCAOMODONGSO_UPDATE]
on [dbo].[BAOCAOMODONGSO]
after update, insert
as
begin
	update BAOCAOMODONGSO
	set ChenhLech = SoSoMo - SoSoDong
	where MaBCMODONGSO in (select MaBCMODONGSO from inserted)
end
GO
ALTER TABLE [dbo].[BAOCAOMODONGSO] ENABLE TRIGGER [TG_BAOCAOMODONGSO_UPDATE]
GO
/****** Object:  Trigger [dbo].[TG_PHIEUGIAODICH_INSERT]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[TG_PHIEUGIAODICH_INSERT]
on [dbo].[PHIEUGIAODICH]
after insert
as
begin
	declare @iMaLoaiGD int,
			@iNgay date,
			@iMaSTK int,
			@iSoTien money,
			@iMaLoaiSTK int

	set @iMaLoaiGD = (select distinct top 1 MaLoaiGD from inserted)
	set @iNgay = (select distinct top 1 NgayLapPhieu from inserted)
	set @iMaSTK = (select top 1 MaSTK from inserted)
	set @iSoTien = (select top 1 SoTien from inserted)
	set @iMaLoaiSTK = (select MaLoaiSTK from SOTIETKIEM	where MaSTK = @iMaSTK)
	--update SOTIETKIEM
	if (@iMaLoaiGD = 1)
		begin
			update SOTIETKIEM 
			set TongSoTienDaGui = TongSoTienDaGui + @iSoTien
			where MaSTK = @iMaSTK
		end
	else if (@iMaLoaiGD = 2)
		begin
			update SOTIETKIEM 
			set TongSoTienDaRut = TongSoTienDaRut + @iSoTien
			where MaSTK = @iMaSTK
		end

	--update BAOCAODSHD
	if (0 = (select COUNT(*) from BAOCAODSHD
			where Ngay = @iNgay and MaLoaiSTK = @iMaLoaiSTK))
		begin
			if (@iMaLoaiGD = 1 or @iMaLoaiGD = 2)
				insert into BAOCAODSHD (Ngay,MaLoaiSTK,TongThu,TongChi,ChenhLech) values (@iNgay, @iMaLoaiSTK, (2 - @iMaLoaiGD) * @iSoTien, (@iMaLoaiGD - 1) * @iSoTien, @iSoTien)
		end
	else
		begin
			update BAOCAODSHD
			set TongThu = TongThu + (2 - @iMaLoaiGD) * @iSoTien,
				TongChi = TongChi + (@iMaLoaiGD - 1) * @iSoTien
			where Ngay = @iNgay and MaLoaiSTK = @iMaLoaiSTK
		end
end


GO
ALTER TABLE [dbo].[PHIEUGIAODICH] ENABLE TRIGGER [TG_PHIEUGIAODICH_INSERT]
GO
/****** Object:  Trigger [dbo].[TG_SOTIETKIEM_INSERT]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[TG_SOTIETKIEM_INSERT]
on [dbo].[SOTIETKIEM]
after INsert
as
begin
	update SOTIETKIEM
	set LaiSuatApDung = (select LaiSuat from LOAISOTIETKIEM 
							where LOAISOTIETKIEM.MaLoaiSTK = (select MaLoaiSTK from inserted)),
		NgayDaoHanTruoc = NgayMoSo,
		NgayDaoHanKeTiep = DATEADD(	MONTH,
									(select KyHan from LOAISOTIETKIEM
										where MaLoaiSTK = (select MaLoaiSTK from inserted)),
									(select NgayMoSo from inserted))
	where MaSTK = (select MaSTK from inserted)

	declare @iNgay date,
			@iMaLoaiSTK int,
			@SoTienGuiBD money

	set @iNgay = (select top 1 NgayMoSo from inserted)
	set @iMaLoaiSTK = (select top 1 MaLoaiSTK from inserted)
	set @SoTienGuiBD = (select top 1 TongSoTienDaGui from inserted)

	if (0 = (select COUNT(*) from BAOCAOMODONGSO
			where	Ngay = @iNgay and
					MaLoaiSTK = @iMaLoaiSTK))
		begin
			insert into BAOCAOMODONGSO (Ngay,MaLoaiSTK, SoSoMo, SoSoDong, ChenhLech) values (@iNgay, @iMaLoaiSTK ,1,0,1)
		end
	else --if ((select top 1 NgayMoSo from inserted) = (select top 1 NgayMoSo from deleted))
		begin
			update BAOCAOMODONGSO
			set SoSoMo = SoSoMo + 1
			where	Ngay = @iNgay and
					MaLoaiSTK = @iMaLoaiSTK
		end

	if (0 = (select COUNT(*) from BAOCAODSHD
			where	Ngay = @iNgay and
					MaLoaiSTK = @iMaLoaiSTK))
		begin
			insert into BAOCAODSHD(Ngay,MaLoaiSTK, TongThu, TongChi, ChenhLech) values (@iNgay, @iMaLoaiSTK ,@SoTienGuiBD,0,@SoTienGuiBD)
		end
	else --if ((select top 1 NgayMoSo from inserted) = (select top 1 NgayMoSo from deleted))
		begin
			update BAOCAODSHD
			set TongThu = TongThu + @SoTienGuiBD
			where	Ngay = @iNgay and
					MaLoaiSTK = @iMaLoaiSTK
		end



end
GO
ALTER TABLE [dbo].[SOTIETKIEM] ENABLE TRIGGER [TG_SOTIETKIEM_INSERT]
GO
/****** Object:  Trigger [dbo].[TG_SOTIETKIEM_UPDATE]    Script Date: 6/28/2021 10:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[TG_SOTIETKIEM_UPDATE]
on [dbo].[SOTIETKIEM]
after update
as
begin

	declare @iNgay date,
			@iMaLoaiSTK int

	set @iNgay = (select top 1 NgayMoSo from inserted)
	set @iMaLoaiSTK = (select top 1 MaLoaiSTK from inserted)

	update SOTIETKIEM
	set SoDu = TongSoTienDaGui - TongSoTienDaRut + TienLaiPhatSinh
		--NgayDaoHanKeTiep = DATEADD(	MONTH,
		--						(select top 1 KyHan from LOAISOTIETKIEM
		--							where MaLoaiSTK = (select top 1 MaLoaiSTK from inserted)),
		--						(select top 1 NgayDaoHanTruoc from inserted))
	where MaSTK in (select MaSTK from inserted)



	--if (((select top 1 TrangThai from inserted) = 0 and (select top 1 TrangThai from deleted) = 1))
	--	begin
	--		update BAOCAOMODONGSO
	--		set SoSoDong = SoSoDong + 1
	--		where	Ngay = GETDATE() and
	--				MaLoaiSTK = @iMaLoaiSTK
	--	end

end
GO
ALTER TABLE [dbo].[SOTIETKIEM] ENABLE TRIGGER [TG_SOTIETKIEM_UPDATE]
GO
USE [master]
GO
ALTER DATABASE [ELITERIA] SET  READ_WRITE 
GO
