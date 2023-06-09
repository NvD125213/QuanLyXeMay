
create database [QuanLyXeMay]
go

USE [QuanLyXeMay]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DoanhThuTheoThang]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_DoanhThuTheoThang] (@thang int, @nam int)
RETURNS @DoanhThu TABLE (
    Ngay DATE,
    DoanhThu FLOAT
)
AS
BEGIN
    DECLARE @StartDate DATE
    DECLARE @EndDate DATE
    SET @StartDate = CAST(CAST(@nam AS VARCHAR) + '-' + CAST(@thang AS VARCHAR) + '-01' AS DATE)
    SET @EndDate = DATEADD(DAY, -1, DATEADD(MONTH, 1, @StartDate))
    
    INSERT INTO @DoanhThu (Ngay, DoanhThu)
    SELECT CONVERT(DATE, NgayBan) AS Ngay, SUM(TongTien) AS DoanhThu
    FROM tblHoaDon
    WHERE NgayBan BETWEEN @StartDate AND @EndDate
    GROUP BY CONVERT(DATE, NgayBan)
    
    RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[thongKeNhapThang]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[thongKeNhapThang] (@thang int, @nam int)
RETURNS @DoanhThu TABLE (
    Ngay DATE,
    DoanhThu FLOAT
)
AS
BEGIN
    DECLARE @StartDate DATE
    DECLARE @EndDate DATE
    SET @StartDate = CAST(CAST(@nam AS VARCHAR) + '-' + CAST(@thang AS VARCHAR) + '-01' AS DATE)
    SET @EndDate = DATEADD(DAY, -1, DATEADD(MONTH, 1, @StartDate))
    
    INSERT INTO @DoanhThu (Ngay, DoanhThu)
    SELECT CONVERT(DATE, NgayNhap) AS Ngay, SUM(TongTien) AS DoanhThu
    FROM HoaDonNhap
    WHERE NgayNhap BETWEEN @StartDate AND @EndDate
    GROUP BY CONVERT(DATE, NgayNhap)
    
    RETURN
END
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[MaHoaDonNhap] [int] NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[MaNguoiNv] [int] NOT NULL,
	[MaNhaCC] [int] NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK__HoaDonNh__448838B57DB9F53D] PRIMARY KEY CLUSTERED 
(
	[MaHoaDonNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeNhapTheoThang]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeNhapTheoThang](@NamBaoCao INT)
RETURNS TABLE
AS
RETURN
    SELECT MONTH(NgayNhap) AS Thang, SUM(TongTien) AS TongTienNhap
    FROM HoaDonNhap
    WHERE YEAR(NgayNhap) = @NamBaoCao
    GROUP BY MONTH(NgayNhap)
GO
/****** Object:  Table [dbo].[ChiTietHoaDonNhap]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonNhap](
	[MaHoaDonNhap] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
 CONSTRAINT [pk_ChiTietHoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[MaHoaDonNhap] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[id] [int] NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[diaChi] [nvarchar](50) NOT NULL,
	[soDienThoai] [char](10) NOT NULL,
	[email] [char](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiNv]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiNv](
	[id] [int] NOT NULL,
	[tenNguoi] [nvarchar](50) NOT NULL,
	[gioiTinh] [nvarchar](5) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[QueQuan] [nvarchar](50) NOT NULL,
	[soDienThoai] [char](9) NOT NULL,
	[LuongCoBan] [int] NOT NULL,
	[Email] [char](50) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassWordd] [nvarchar](50) NOT NULL,
	[Typee] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCC]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCC](
	[id] [int] NOT NULL,
	[tenNhaCC] [nvarchar](50) NULL,
	[sdtNhaCC] [char](12) NULL,
	[emailNhaCC] [char](100) NULL,
 CONSTRAINT [PK_NhaCC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblChiTietHoaDon]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHoaDon](
	[MaHD] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Gia] [int] NOT NULL,
	[vat] [int] NOT NULL,
	[chietKhau] [int] NULL,
 CONSTRAINT [pk_tblChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHoaDon]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoaDon](
	[id] [int] NOT NULL,
	[NgayBan] [datetime] NOT NULL,
	[Manv] [int] NOT NULL,
	[MaKh] [int] NOT NULL,
	[TongTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[xe]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[xe](
	[id] [int] NOT NULL,
	[tenXE] [nvarchar](50) NOT NULL,
	[hangXE] [nvarchar](50) NOT NULL,
	[dungTich] [nvarchar](50) NOT NULL,
	[loaiXe] [nchar](50) NOT NULL,
	[namSx] [char](4) NOT NULL,
	[Color] [nvarchar](20) NOT NULL,
	[GiaBan] [int] NULL,
	[anh] [nvarchar](max) NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [fk_HoaDonNhap] FOREIGN KEY([MaHoaDonNhap])
REFERENCES [dbo].[HoaDonNhap] ([MaHoaDonNhap])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] CHECK CONSTRAINT [fk_HoaDonNhap]
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [fk_SanPham_HDN] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[xe] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] CHECK CONSTRAINT [fk_SanPham_HDN]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK__HoaDonNha__MaNgu__47DBAE45] FOREIGN KEY([MaNguoiNv])
REFERENCES [dbo].[NguoiNv] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK__HoaDonNha__MaNgu__47DBAE45]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhaCC] FOREIGN KEY([MaNhaCC])
REFERENCES [dbo].[NhaCC] ([id])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhaCC]
GO
ALTER TABLE [dbo].[tblChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[tblHoaDon] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[xe] ([id])
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemChiTietHoaDon7]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemChiTietHoaDon7] 
 @MaHoaDon int , @MaSanPham int , @SoLuong int
 AS
BEGIN
 SET NOCOUNT ON;

	 DECLARE  @TienMoi int   ;
	 select @TienMoi = GiaBan *@SoLuong from dbo.xe WHERE id = @MaSanPham

 IF EXISTS (SELECT 1 FROM tblChiTietHoaDon WHERE MaHD = @MaHoaDon AND MaSP = @MaSanPham)
    BEGIN


	UPDATE tblChiTietHoaDon set SoLuong = SoLuong + @SoLuong ,Gia=Gia+@TienMoi  WHERE MaHD = @MaHoaDon

	UPDATE xe set SoLuong = SoLuong - @SoLuong WHERE id = @MaSanPham

	UPDATE dbo.tblHoaDon set TongTien= TongTien+@TienMoi   WHERE id = @MaHoaDon

       
    END
    ELSE
    BEGIN

	insert into tblChiTietHoaDon(MaHD,MaSP,SoLuong,Gia,vat) values(@MaHoaDon,@MaSanPham,@SoLuong , @TienMoi,0)
	UPDATE xe set SoLuong = SoLuong - @SoLuong WHERE id = @MaSanPham
	UPDATE dbo.tblHoaDon set TongTien= TongTien+@TienMoi   WHERE id = @MaHoaDon
     
    END

 END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThongKeDoanhThu]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThongKeDoanhThu] 
    @NgayBatDau datetime, 
    @NgayKetThuc datetime
AS
BEGIN
    -- Kiểm tra ngày bắt đầu và ngày kết thúc có cách nhau quá 30 ngày không
    IF DATEDIFF(day, @NgayBatDau, @NgayKetThuc) > 30
    BEGIN
        RAISERROR('Khoảng thời gian tìm kiếm quá lớn, không hỗ trợ thống kê.', 16, 1)
        RETURN
    END
    
    -- Kiểm tra ngày bắt đầu và ngày kết thúc có cùng năm không
    IF YEAR(@NgayBatDau) <> YEAR(@NgayKetThuc)
    BEGIN
        RAISERROR('Khoảng thời gian tìm kiếm phải trong cùng một năm.', 16, 1)
        RETURN
    END
    
    -- Tạo bảng tạm để lưu trữ doanh thu của mỗi ngày
    DECLARE @BangTam TABLE (
        Ngay date,
        DoanhThu int
    )
    
    -- Tính toán doanh thu của mỗi ngày trong khoảng thời gian tìm kiếm
    DECLARE @NgayTrongKhoang datetime = @NgayBatDau
    
    WHILE @NgayTrongKhoang <= @NgayKetThuc
    BEGIN
        DECLARE @DoanhThu int
        
        SELECT @DoanhThu = SUM(Gia * SoLuong)
        FROM tblChiTietHoaDon ctdh
        JOIN tblHoaDon dh ON dh.id = ctdh.MaHD
        WHERE dh.NgayBan = @NgayTrongKhoang
        
        INSERT INTO @BangTam (Ngay, DoanhThu) VALUES (@NgayTrongKhoang, ISNULL(@DoanhThu, 0))
        
        SET @NgayTrongKhoang = DATEADD(day, 1, @NgayTrongKhoang)
    END
    
    -- Nếu khoảng thời gian tìm kiếm nhỏ hơn hoặc bằng 7 ngày, trả về doanh thu của từng ngày
    IF DATEDIFF(day, @NgayBatDau, @NgayKetThuc) <= 7
    BEGIN
        SELECT * FROM @BangTam
    END
    -- Nếu khoảng thời gian tìm kiếm từ 8 đến 30 ngày, trả về doanh thu của từng ngày theo tháng
    -- Nếu khoảng thời gian tìm kiếm từ 8 đến 30 ngày, trả về doanh thu của từng ngày theo tháng
    IF DATEDIFF(day, @NgayBatDau, @NgayKetThuc) <= 30
    BEGIN
        -- Tạo bảng tạm để lưu trữ tổng doanh thu của từng tháng
        DECLARE @BangTam2 TABLE (
            Thang varchar(7),
            DoanhThu int
        )
        
        -- Tính toán tổng doanh thu của từng tháng trong khoảng thời gian tìm kiếm
        DECLARE @ThangTrongKhoang varchar(7) = CONVERT(varchar(7), @NgayBatDau, 126)
        DECLARE @TongDoanhThu int = 0
        
        WHILE @ThangTrongKhoang <= CONVERT(varchar(7), @NgayKetThuc, 126)
        BEGIN
            SELECT @TongDoanhThu = SUM(DoanhThu)
            FROM @BangTam
            WHERE CONVERT(varchar(7), Ngay, 126) = @ThangTrongKhoang
            
            INSERT INTO @BangTam2 (Thang, DoanhThu) VALUES (@ThangTrongKhoang, @TongDoanhThu)
            
            SET @ThangTrongKhoang = CONVERT(varchar(7), DATEADD(month, 1, CONVERT(datetime, @ThangTrongKhoang + '-01', 126)), 126)
        END
        
        SELECT * FROM @BangTam2
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThongKeDoanhThuTheoThang]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThongKeDoanhThuTheoThang] 
    @Nam INT
AS
BEGIN
    SELECT 
        MONTH(NgayBan) AS Thang, 
        SUM(TongTien) AS DoanhThu
    FROM 
        tblHoaDon
    WHERE 
        YEAR(NgayBan) = @Nam
    GROUP BY 
        MONTH(NgayBan)
    ORDER BY 
        MONTH(NgayBan)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaChiTietHoaDon]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_xoaChiTietHoaDon]
    @MaHoaDon INT,
    @MaSanPham INT
as
BEGIN
	SET NOCOUNT ON;
    DECLARE @SoLuong INT ,@GiaSanPham INT

	-- Thêm dữ liệu vào bảng tblChiTietHoaDon
		select @SoLuong=SoLuong ,@GiaSanPham=Gia FROM tblChiTietHoaDon WHERE MaHD = @MaHoaDon AND MaSP = @MaSanPham
    
		-- Cập nhật số lượng trong bảng xe
		UPDATE xe SET SoLuong = SoLuong + @SoLuong WHERE id = @MaSanPham
    
		-- Cập nhật tổng tiền trong bảng tblHoaDon
		UPDATE tblHoaDon SET TongTien = TongTien -@GiaSanPham WHERE id = @MaHoaDon
		
END
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaChiTietHoaDon1]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_xoaChiTietHoaDon1]
    @MaHoaDon INT,
    @MaSanPham INT
as
BEGIN
	SET NOCOUNT ON;
    DECLARE @SoLuong INT ,@GiaSanPham INT

	-- Thêm dữ liệu vào bảng tblChiTietHoaDon
		select @SoLuong=SoLuong ,@GiaSanPham=Gia FROM tblChiTietHoaDon WHERE MaHD = @MaHoaDon AND MaSP = @MaSanPham
    
		-- Cập nhật số lượng trong bảng xe
		UPDATE xe SET SoLuong = SoLuong + @SoLuong WHERE id = @MaSanPham
    
		-- Cập nhật tổng tiền trong bảng tblHoaDon
		UPDATE tblHoaDon SET TongTien = TongTien -@GiaSanPham WHERE id = @MaHoaDon
		DELETE FROM tblChiTietHoaDon WHERE MaHD = @MaHoaDon AND MaSP = @MaSanPham
		
END
GO
/****** Object:  StoredProcedure [dbo].[ThemHoaDonNhap3]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ThemHoaDonNhap3]
    @MaHoaDon INT,
    @MaSanPham INT,
    @SoLuong INT,
    @GiaSanPham FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SoLuongCu INT, @TongTienCu FLOAT, @TongTienMoi FLOAT;
	

    IF EXISTS (
        SELECT 1 FROM ChiTietHoaDonNhap WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham
    )
    BEGIN
        SELECT @SoLuongCu = SoLuong, @TongTienCu = SoLuong * DonGia
        FROM ChiTietHoaDonNhap
        WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham;

        UPDATE xe SET SoLuong = SoLuong + @SoLuong 
        WHERE id = @MaSanPham;

        SELECT @TongTienMoi = @SoLuong * @GiaSanPham;

        UPDATE ChiTietHoaDonNhap SET SoLuong = @SoLuong, DonGia = @GiaSanPham
        WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham;

        UPDATE HoaDonNhap SET TongTien = TongTien - @TongTienCu + @TongTienMoi
        WHERE MaHoaDonNhap = @MaHoaDon;
    END
    ELSE
    BEGIN
        INSERT INTO ChiTietHoaDonNhap (MaHoaDonNhap, MaSanPham, SoLuong, DonGia)
        VALUES (@MaHoaDon, @MaSanPham, @SoLuong, @GiaSanPham);

        UPDATE xe SET SoLuong = SoLuong + @SoLuong
        WHERE id = @MaSanPham;

        SELECT @TongTienMoi = @SoLuong * @GiaSanPham;

        UPDATE HoaDonNhap SET TongTien = TongTien + @TongTienMoi
        WHERE MaHoaDonNhap = @MaHoaDon;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[ThemHoaDonNhap4]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- nhập hóa đơn nhâpj
CREATE PROCEDURE [dbo].[ThemHoaDonNhap4]
    @MaHoaDon INT,
    @MaSanPham INT,
    @SoLuong INT,
    @GiaSanPham FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SoLuongCu INT, @TongTienCu FLOAT, @TongTienMoi FLOAT;
	select @SoLuongCu 

    IF EXISTS (
        SELECT 1 FROM ChiTietHoaDonNhap WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham
    )
    BEGIN
        SELECT @SoLuongCu = SoLuong, @TongTienCu = SoLuong * DonGia
        FROM ChiTietHoaDonNhap
        WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham;

        UPDATE xe SET SoLuong = SoLuong + @SoLuong - @SoLuongCu
        WHERE id = @MaSanPham;

        SELECT @TongTienMoi = @SoLuong * @GiaSanPham;

        UPDATE ChiTietHoaDonNhap SET SoLuong = @SoLuong, DonGia = @GiaSanPham
        WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham;

        UPDATE HoaDonNhap SET TongTien = TongTien - @TongTienCu + @TongTienMoi
        WHERE MaHoaDonNhap = @MaHoaDon;
    END
    ELSE
    BEGIN
        INSERT INTO ChiTietHoaDonNhap (MaHoaDonNhap, MaSanPham, SoLuong, DonGia)
        VALUES (@MaHoaDon, @MaSanPham, @SoLuong, @GiaSanPham);

        UPDATE xe SET SoLuong = SoLuong + @SoLuong
        WHERE id = @MaSanPham;

        SELECT @TongTienMoi = @SoLuong * @GiaSanPham;

        UPDATE HoaDonNhap SET TongTien = TongTien + @TongTienMoi
        WHERE MaHoaDonNhap = @MaHoaDon;
    END
END

select MaHoaDonNhap ,
    MaSanPham ,
    SoLuong ,DonGia from dbo.ChiTietHoaDonNhap 
GO
/****** Object:  StoredProcedure [dbo].[USP_DangNhap]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_DangNhap]
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM NguoiNv WHERE UserName = @userName AND PassWordd = @passWord
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login]
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM NguoiNv WHERE UserName = @userName AND PassWordd = @passWord
END
GO
/****** Object:  StoredProcedure [dbo].[XoaChiTietHoaDonNhap]    Script Date: 31/05/2023 2:08:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[XoaChiTietHoaDonNhap]
(
    @MaHoaDon INT,
    @MaSanPham INT
)
AS
BEGIN
    -- Tìm số lượng sản phẩm trong chi tiết hóa đơn nhập cần xóa
    DECLARE @SoLuong INT
    SELECT @SoLuong = SoLuong
    FROM ChiTietHoaDonNhap
    WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham
    
    -- Cập nhật lại số lượng sản phẩm trong bảng xe
    UPDATE xe
    SET SoLuong = SoLuong - @SoLuong
    WHERE id = @MaSanPham
    
    -- Tìm giá sản phẩm trong chi tiết hóa đơn nhập cần xóa
    DECLARE @GiaSanPham FLOAT
    SELECT @GiaSanPham = DonGia
    FROM ChiTietHoaDonNhap
    WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham
    
    -- Cập nhật lại tổng tiền của hóa đơn nhập
    UPDATE HoaDonNhap
    SET TongTien = TongTien - @SoLuong * @GiaSanPham
    WHERE MaHoaDonNhap = @MaHoaDon
    
    -- Xóa chi tiết hóa đơn nhập
    DELETE FROM ChiTietHoaDonNhap
    WHERE MaHoaDonNhap = @MaHoaDon AND MaSanPham = @MaSanPham
END

GO

insert into NguoiNv(id,tenNguoi,gioiTinh,NgaySinh,QueQuan,soDienThoai,LuongCoBan,Email,UserName,PassWordd,Typee) values('admin','admin','0','2002-10-10','admin',0,'admin','admin','admin',0)
go
USE [QuanLyXeMay]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DoanhThuTheoThang]    Script Date: 31/05/2023 4:16:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  FUNCTION [dbo].[thongke] (@StartDate date, @EndDate date)
RETURNS @DoanhThu TABLE (
    Ngay DATE,
    DoanhThu FLOAT
)
AS
BEGIN
    
    
    INSERT INTO @DoanhThu (Ngay, DoanhThu)
    SELECT CONVERT(DATE, NgayBan) AS Ngay, SUM(TongTien) AS DoanhThu
    FROM tblHoaDon
    WHERE NgayBan BETWEEN @StartDate AND @EndDate
    GROUP BY CONVERT(DATE, NgayBan)
    
    RETURN
END
go

