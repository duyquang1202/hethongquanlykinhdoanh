USE [QLCongTacVien]
GO
/****** Object:  Table [dbo].[tblAccount]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccount](
	[MaAccount] [bigint] NOT NULL,
	[TenAccount] [nvarchar](100) NULL,
	[LoaiAccount] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[AccountManager] [bigint] NULL,
	[NgayTao] [datetime] NULL,
	[NgayUpdate] [datetime] NULL,
	[UserTao] [nvarchar](50) NULL,
	[UserUpdate] [nvarchar](50) NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_tblAccount] PRIMARY KEY CLUSTERED 
(
	[MaAccount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (1, N'Admin Manager', N'AD', N'admin', 1, CAST(0x0000A2E0011826C0 AS DateTime), CAST(0x0000A2E0011826C0 AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403071517369255, N'test account', N'QL', N'sdg', 1, CAST(0x0000A2E700FC07D6 AS DateTime), CAST(0x0000A2E70119F206 AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403090204497648, N'test12', N'QL', NULL, 1, CAST(0x0000A2E900224912 AS DateTime), CAST(0x0000A2E900273443 AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403092231113319, N'kgh', N'KD', N'sdsd', 201403090204497648, CAST(0x0000A2E901731D78 AS DateTime), CAST(0x0000A2EA012787EA AS DateTime), N'abc', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403101756506510, N'fjghjhgj', N'QL', N'khhjk', 201403071517369255, CAST(0x0000A2EA0127C39B AS DateTime), CAST(0x0000A2EA0127C39B AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403101757138503, N'khkhk', N'QL', NULL, 201403071517369255, CAST(0x0000A2EA0127DECB AS DateTime), CAST(0x0000A2EA0127DECB AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403101758412623, N'jkhj', N'QL', NULL, 201403071517369255, CAST(0x0000A2EA0128453B AS DateTime), CAST(0x0000A2EA0128453B AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403101800255353, N'khjhkjk', N'QL', NULL, 201403071517369255, CAST(0x0000A2EA0128BF6D AS DateTime), CAST(0x0000A2EA0128BF6D AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403101801311920, N'hjkjk', N'QL', NULL, 201403071517369255, CAST(0x0000A2EA01290C5E AS DateTime), CAST(0x0000A2EA01290C5E AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblAccount] ([MaAccount], [TenAccount], [LoaiAccount], [GhiChu], [AccountManager], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403101801480270, N'khjkjk', N'QL', N'f', 201403071517369255, CAST(0x0000A2EA01292018 AS DateTime), CAST(0x0000A2EA01292018 AS DateTime), N'admin', N'admin', 1)
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhachHang](
	[MaKhachHang] [bigint] NOT NULL,
	[TenKhachHang] [nvarchar](100) NULL,
	[SoDT] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[GhiChu1] [nvarchar](max) NULL,
	[GhiChu2] [nvarchar](max) NULL,
	[GhiChu3] [nvarchar](max) NULL,
	[GhiChu4] [nvarchar](max) NULL,
	[GiaTri] [float] NULL,
	[TrangThai1] [int] NULL,
	[TrangThai2] [int] NULL,
	[TrangThai3] [int] NULL,
	[TrangThai4] [int] NULL,
	[NgayTao] [datetime] NULL,
	[NgayUpdate] [datetime] NULL,
	[UserTao] [nvarchar](50) NULL,
	[UserUpdate] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNhom]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhom](
	[MaNhom] [bigint] NOT NULL,
	[TenNhom] [nvarchar](100) NULL,
	[MoTaoNhom] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayUpdate] [datetime] NULL,
	[UserTao] [nvarchar](50) NULL,
	[UserUpdate] [nvarchar](50) NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_tblNhom] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLichSu]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLichSu](
	[MaLichSu] [bigint] NOT NULL,
	[NoiDung] [nvarchar](max) NULL,
	[GiaTri] [float] NULL,
	[GhiChu1] [nvarchar](max) NULL,
	[GhiChu2] [nvarchar](max) NULL,
	[GhiChu3] [nvarchar](max) NULL,
	[GhiChu4] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayUpdate] [datetime] NULL,
	[UserTao] [datetime] NULL,
	[UserUpdate] [datetime] NULL,
 CONSTRAINT [PK_tblLichSu] PRIMARY KEY CLUSTERED 
(
	[MaLichSu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPhongBan]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPhongBan](
	[MaPhongBan] [bigint] NOT NULL,
	[TenPhongBan] [nvarchar](100) NULL,
	[MoTaPhongBan] [nvarchar](max) NULL,
	[GhiChuPhongBan] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayUpdate] [datetime] NULL,
	[UserTao] [nvarchar](50) NULL,
	[UserUpdate] [nvarchar](50) NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_tblPhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tblPhongBan] ([MaPhongBan], [TenPhongBan], [MoTaPhongBan], [GhiChuPhongBan], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (1, N'Admin Manager', N'Admin Manager', N'Admin', CAST(0x0000A2E0011826C0 AS DateTime), CAST(0x0000A2E500F74995 AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblPhongBan] ([MaPhongBan], [TenPhongBan], [MoTaPhongBan], [GhiChuPhongBan], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403070946092419, N'a1', N'sdsgsd', N'ds', CAST(0x0000A2E700A0FDF5 AS DateTime), CAST(0x0000A2EA011B4773 AS DateTime), N'admin', N'admin', 1)
/****** Object:  Table [dbo].[tblUser]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[MaUser] [bigint] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[FullName] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[Email] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayUpdate] [datetime] NULL,
	[UserTao] [nvarchar](50) NULL,
	[UserUpdate] [nvarchar](50) NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[MaUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tblUser] ([MaUser], [UserName], [Password], [FullName], [DienThoai], [DiaChi], [Email], [GhiChu], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (1, N'admin', N'123456', N'duy quang', N'0902557167', N'sggds', N'duyquang1202@gmail.com', N'sdgsgd xin chao', CAST(0x0000A2E0011826C0 AS DateTime), CAST(0x0000A2EA0120F9EF AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblUser] ([MaUser], [UserName], [Password], [FullName], [DienThoai], [DiaChi], [Email], [GhiChu], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201403091956427888, N't1', N'123456', N'sdgds', N'sdg', N'sdg', N't1@gmail.com', NULL, CAST(0x0000A2E90148AFE5 AS DateTime), CAST(0x0000A2E90148AFE5 AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblUser] ([MaUser], [UserName], [Password], [FullName], [DienThoai], [DiaChi], [Email], [GhiChu], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201411111857017778, N'duyquang1202', N'123456', N'sdg', N'523523525', N'5235235', N'duyquang11202@gmail.com', NULL, CAST(0x0000A3E001384B65 AS DateTime), CAST(0x0000A3E001384B65 AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[tblUser] ([MaUser], [UserName], [Password], [FullName], [DienThoai], [DiaChi], [Email], [GhiChu], [NgayTao], [NgayUpdate], [UserTao], [UserUpdate], [TrangThai]) VALUES (201411111923462656, N'jkk', N'123456', N'dsggs', N'463463', N'dhdhd', N'ssdd@gmail.com', NULL, CAST(0x0000A3E0013FA3A8 AS DateTime), CAST(0x0000A3E0013FA3A8 AS DateTime), N'admin', N'admin', 1)
/****** Object:  Table [dbo].[tblPhongBan_Account]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPhongBan_Account](
	[MaPhongBan] [bigint] NOT NULL,
	[MaAccount] [bigint] NOT NULL,
 CONSTRAINT [PK_tblPhongBan_Account] PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC,
	[MaAccount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (1, 1)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403071517369255)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403090204497648)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403092231113319)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403101756506510)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403101757138503)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403101758412623)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403101800255353)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403101801311920)
INSERT [dbo].[tblPhongBan_Account] ([MaPhongBan], [MaAccount]) VALUES (201403070946092419, 201403101801480270)
/****** Object:  Table [dbo].[tblNhom_KhachHang]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhom_KhachHang](
	[MaNhom] [bigint] NOT NULL,
	[MaKhachHang] [bigint] NOT NULL,
 CONSTRAINT [PK_tblNhom_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC,
	[MaKhachHang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKhachHang_LichSu]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhachHang_LichSu](
	[MaKhachHang] [bigint] NOT NULL,
	[MaLichSu] [bigint] NOT NULL,
 CONSTRAINT [PK_tblKhachHang_LichSu] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC,
	[MaLichSu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAccount_User]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccount_User](
	[MaAccount] [bigint] NOT NULL,
	[MaUser] [bigint] NOT NULL,
 CONSTRAINT [PK_tblAccount_User] PRIMARY KEY CLUSTERED 
(
	[MaAccount] ASC,
	[MaUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblAccount_User] ([MaAccount], [MaUser]) VALUES (1, 1)
INSERT [dbo].[tblAccount_User] ([MaAccount], [MaUser]) VALUES (1, 201411111923462656)
INSERT [dbo].[tblAccount_User] ([MaAccount], [MaUser]) VALUES (201403071517369255, 201403091956427888)
INSERT [dbo].[tblAccount_User] ([MaAccount], [MaUser]) VALUES (201403092231113319, 201411111857017778)
/****** Object:  Table [dbo].[tblAccount_Nhom]    Script Date: 12/06/2014 14:07:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccount_Nhom](
	[MaAccount] [bigint] NOT NULL,
	[MaNhom] [bigint] NOT NULL,
 CONSTRAINT [PK_tblAccount_Nhom] PRIMARY KEY CLUSTERED 
(
	[MaAccount] ASC,
	[MaNhom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_tblAccount_TrangThai]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblAccount] ADD  CONSTRAINT [DF_tblAccount_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
/****** Object:  Default [DF_tblPhongBan_TrangThai]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblPhongBan] ADD  CONSTRAINT [DF_tblPhongBan_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
/****** Object:  ForeignKey [FK_tblAccount_tblAccount]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_tblAccount] FOREIGN KEY([AccountManager])
REFERENCES [dbo].[tblAccount] ([MaAccount])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK_tblAccount_tblAccount]
GO
/****** Object:  ForeignKey [FK_tblAccount_Nhom_tblAccount]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblAccount_Nhom]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_Nhom_tblAccount] FOREIGN KEY([MaAccount])
REFERENCES [dbo].[tblAccount] ([MaAccount])
GO
ALTER TABLE [dbo].[tblAccount_Nhom] CHECK CONSTRAINT [FK_tblAccount_Nhom_tblAccount]
GO
/****** Object:  ForeignKey [FK_tblAccount_Nhom_tblNhom]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblAccount_Nhom]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_Nhom_tblNhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[tblNhom] ([MaNhom])
GO
ALTER TABLE [dbo].[tblAccount_Nhom] CHECK CONSTRAINT [FK_tblAccount_Nhom_tblNhom]
GO
/****** Object:  ForeignKey [FK_tblAccount_User_tblAccount]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblAccount_User]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_User_tblAccount] FOREIGN KEY([MaAccount])
REFERENCES [dbo].[tblAccount] ([MaAccount])
GO
ALTER TABLE [dbo].[tblAccount_User] CHECK CONSTRAINT [FK_tblAccount_User_tblAccount]
GO
/****** Object:  ForeignKey [FK_tblAccount_User_tblUser]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblAccount_User]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_User_tblUser] FOREIGN KEY([MaUser])
REFERENCES [dbo].[tblUser] ([MaUser])
GO
ALTER TABLE [dbo].[tblAccount_User] CHECK CONSTRAINT [FK_tblAccount_User_tblUser]
GO
/****** Object:  ForeignKey [FK_tblKhachHang_LichSu_tblKhachHang]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblKhachHang_LichSu]  WITH CHECK ADD  CONSTRAINT [FK_tblKhachHang_LichSu_tblKhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[tblKhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[tblKhachHang_LichSu] CHECK CONSTRAINT [FK_tblKhachHang_LichSu_tblKhachHang]
GO
/****** Object:  ForeignKey [FK_tblKhachHang_LichSu_tblLichSu]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblKhachHang_LichSu]  WITH CHECK ADD  CONSTRAINT [FK_tblKhachHang_LichSu_tblLichSu] FOREIGN KEY([MaLichSu])
REFERENCES [dbo].[tblLichSu] ([MaLichSu])
GO
ALTER TABLE [dbo].[tblKhachHang_LichSu] CHECK CONSTRAINT [FK_tblKhachHang_LichSu_tblLichSu]
GO
/****** Object:  ForeignKey [FK_tblNhom_KhachHang_tblKhachHang]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblNhom_KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_tblNhom_KhachHang_tblKhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[tblKhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[tblNhom_KhachHang] CHECK CONSTRAINT [FK_tblNhom_KhachHang_tblKhachHang]
GO
/****** Object:  ForeignKey [FK_tblNhom_KhachHang_tblNhom]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblNhom_KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_tblNhom_KhachHang_tblNhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[tblNhom] ([MaNhom])
GO
ALTER TABLE [dbo].[tblNhom_KhachHang] CHECK CONSTRAINT [FK_tblNhom_KhachHang_tblNhom]
GO
/****** Object:  ForeignKey [FK_tblPhongBan_Account_tblAccount]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblPhongBan_Account]  WITH CHECK ADD  CONSTRAINT [FK_tblPhongBan_Account_tblAccount] FOREIGN KEY([MaAccount])
REFERENCES [dbo].[tblAccount] ([MaAccount])
GO
ALTER TABLE [dbo].[tblPhongBan_Account] CHECK CONSTRAINT [FK_tblPhongBan_Account_tblAccount]
GO
/****** Object:  ForeignKey [FK_tblPhongBan_Account_tblPhongBan]    Script Date: 12/06/2014 14:07:33 ******/
ALTER TABLE [dbo].[tblPhongBan_Account]  WITH CHECK ADD  CONSTRAINT [FK_tblPhongBan_Account_tblPhongBan] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[tblPhongBan] ([MaPhongBan])
GO
ALTER TABLE [dbo].[tblPhongBan_Account] CHECK CONSTRAINT [FK_tblPhongBan_Account_tblPhongBan]
GO
