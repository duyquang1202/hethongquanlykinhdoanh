USE [QLCongTacVien]
GO
/****** Object:  Table [dbo].[tblAccount]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAccount]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblKhachHang]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblNhom]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNhom]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblLichSu]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLichSu]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblPhongBan]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPhongBan]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblPhongBan_Account]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPhongBan_Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblPhongBan_Account](
	[MaPhongBan] [bigint] NOT NULL,
	[MaAccount] [bigint] NOT NULL,
 CONSTRAINT [PK_tblPhongBan_Account] PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC,
	[MaAccount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblNhom_KhachHang]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNhom_KhachHang]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblNhom_KhachHang](
	[MaNhom] [bigint] NOT NULL,
	[MaKhachHang] [bigint] NOT NULL,
 CONSTRAINT [PK_tblNhom_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC,
	[MaKhachHang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblKhachHang_LichSu]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblKhachHang_LichSu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblKhachHang_LichSu](
	[MaKhachHang] [bigint] NOT NULL,
	[MaLichSu] [bigint] NOT NULL,
 CONSTRAINT [PK_tblKhachHang_LichSu] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC,
	[MaLichSu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblAccount_User]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAccount_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblAccount_User](
	[MaAccount] [bigint] NOT NULL,
	[MaUser] [bigint] NOT NULL,
 CONSTRAINT [PK_tblAccount_User] PRIMARY KEY CLUSTERED 
(
	[MaAccount] ASC,
	[MaUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblAccount_Nhom]    Script Date: 12/06/2014 14:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAccount_Nhom]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblAccount_Nhom](
	[MaAccount] [bigint] NOT NULL,
	[MaNhom] [bigint] NOT NULL,
 CONSTRAINT [PK_tblAccount_Nhom] PRIMARY KEY CLUSTERED 
(
	[MaAccount] ASC,
	[MaNhom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Default [DF_tblAccount_TrangThai]    Script Date: 12/06/2014 14:01:38 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tblAccount_TrangThai]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tblAccount_TrangThai]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tblAccount] ADD  CONSTRAINT [DF_tblAccount_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
END


End
GO
/****** Object:  Default [DF_tblPhongBan_TrangThai]    Script Date: 12/06/2014 14:01:38 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tblPhongBan_TrangThai]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblPhongBan]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tblPhongBan_TrangThai]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tblPhongBan] ADD  CONSTRAINT [DF_tblPhongBan_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
END


End
GO
/****** Object:  ForeignKey [FK_tblAccount_tblAccount]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_tblAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount]'))
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_tblAccount] FOREIGN KEY([AccountManager])
REFERENCES [dbo].[tblAccount] ([MaAccount])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_tblAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount]'))
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK_tblAccount_tblAccount]
GO
/****** Object:  ForeignKey [FK_tblAccount_Nhom_tblAccount]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_Nhom_tblAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount_Nhom]'))
ALTER TABLE [dbo].[tblAccount_Nhom]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_Nhom_tblAccount] FOREIGN KEY([MaAccount])
REFERENCES [dbo].[tblAccount] ([MaAccount])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_Nhom_tblAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount_Nhom]'))
ALTER TABLE [dbo].[tblAccount_Nhom] CHECK CONSTRAINT [FK_tblAccount_Nhom_tblAccount]
GO
/****** Object:  ForeignKey [FK_tblAccount_Nhom_tblNhom]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_Nhom_tblNhom]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount_Nhom]'))
ALTER TABLE [dbo].[tblAccount_Nhom]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_Nhom_tblNhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[tblNhom] ([MaNhom])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_Nhom_tblNhom]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount_Nhom]'))
ALTER TABLE [dbo].[tblAccount_Nhom] CHECK CONSTRAINT [FK_tblAccount_Nhom_tblNhom]
GO
/****** Object:  ForeignKey [FK_tblAccount_User_tblAccount]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_User_tblAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount_User]'))
ALTER TABLE [dbo].[tblAccount_User]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_User_tblAccount] FOREIGN KEY([MaAccount])
REFERENCES [dbo].[tblAccount] ([MaAccount])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_User_tblAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount_User]'))
ALTER TABLE [dbo].[tblAccount_User] CHECK CONSTRAINT [FK_tblAccount_User_tblAccount]
GO
/****** Object:  ForeignKey [FK_tblAccount_User_tblUser]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_User_tblUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount_User]'))
ALTER TABLE [dbo].[tblAccount_User]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_User_tblUser] FOREIGN KEY([MaUser])
REFERENCES [dbo].[tblUser] ([MaUser])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblAccount_User_tblUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblAccount_User]'))
ALTER TABLE [dbo].[tblAccount_User] CHECK CONSTRAINT [FK_tblAccount_User_tblUser]
GO
/****** Object:  ForeignKey [FK_tblKhachHang_LichSu_tblKhachHang]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblKhachHang_LichSu_tblKhachHang]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblKhachHang_LichSu]'))
ALTER TABLE [dbo].[tblKhachHang_LichSu]  WITH CHECK ADD  CONSTRAINT [FK_tblKhachHang_LichSu_tblKhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[tblKhachHang] ([MaKhachHang])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblKhachHang_LichSu_tblKhachHang]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblKhachHang_LichSu]'))
ALTER TABLE [dbo].[tblKhachHang_LichSu] CHECK CONSTRAINT [FK_tblKhachHang_LichSu_tblKhachHang]
GO
/****** Object:  ForeignKey [FK_tblKhachHang_LichSu_tblLichSu]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblKhachHang_LichSu_tblLichSu]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblKhachHang_LichSu]'))
ALTER TABLE [dbo].[tblKhachHang_LichSu]  WITH CHECK ADD  CONSTRAINT [FK_tblKhachHang_LichSu_tblLichSu] FOREIGN KEY([MaLichSu])
REFERENCES [dbo].[tblLichSu] ([MaLichSu])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblKhachHang_LichSu_tblLichSu]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblKhachHang_LichSu]'))
ALTER TABLE [dbo].[tblKhachHang_LichSu] CHECK CONSTRAINT [FK_tblKhachHang_LichSu_tblLichSu]
GO
/****** Object:  ForeignKey [FK_tblNhom_KhachHang_tblKhachHang]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblNhom_KhachHang_tblKhachHang]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblNhom_KhachHang]'))
ALTER TABLE [dbo].[tblNhom_KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_tblNhom_KhachHang_tblKhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[tblKhachHang] ([MaKhachHang])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblNhom_KhachHang_tblKhachHang]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblNhom_KhachHang]'))
ALTER TABLE [dbo].[tblNhom_KhachHang] CHECK CONSTRAINT [FK_tblNhom_KhachHang_tblKhachHang]
GO
/****** Object:  ForeignKey [FK_tblNhom_KhachHang_tblNhom]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblNhom_KhachHang_tblNhom]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblNhom_KhachHang]'))
ALTER TABLE [dbo].[tblNhom_KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_tblNhom_KhachHang_tblNhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[tblNhom] ([MaNhom])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblNhom_KhachHang_tblNhom]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblNhom_KhachHang]'))
ALTER TABLE [dbo].[tblNhom_KhachHang] CHECK CONSTRAINT [FK_tblNhom_KhachHang_tblNhom]
GO
/****** Object:  ForeignKey [FK_tblPhongBan_Account_tblAccount]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblPhongBan_Account_tblAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblPhongBan_Account]'))
ALTER TABLE [dbo].[tblPhongBan_Account]  WITH CHECK ADD  CONSTRAINT [FK_tblPhongBan_Account_tblAccount] FOREIGN KEY([MaAccount])
REFERENCES [dbo].[tblAccount] ([MaAccount])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblPhongBan_Account_tblAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblPhongBan_Account]'))
ALTER TABLE [dbo].[tblPhongBan_Account] CHECK CONSTRAINT [FK_tblPhongBan_Account_tblAccount]
GO
/****** Object:  ForeignKey [FK_tblPhongBan_Account_tblPhongBan]    Script Date: 12/06/2014 14:01:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblPhongBan_Account_tblPhongBan]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblPhongBan_Account]'))
ALTER TABLE [dbo].[tblPhongBan_Account]  WITH CHECK ADD  CONSTRAINT [FK_tblPhongBan_Account_tblPhongBan] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[tblPhongBan] ([MaPhongBan])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblPhongBan_Account_tblPhongBan]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblPhongBan_Account]'))
ALTER TABLE [dbo].[tblPhongBan_Account] CHECK CONSTRAINT [FK_tblPhongBan_Account_tblPhongBan]
GO
