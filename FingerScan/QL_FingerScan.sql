USE [master]
GO
/****** Object:  Database [QL_FingerScan] ******/
CREATE DATABASE [QL_FingerScan]
 CONTAINMENT = NONE

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_FingerScan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_FingerScan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_FingerScan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_FingerScan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_FingerScan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_FingerScan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_FingerScan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_FingerScan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_FingerScan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_FingerScan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_FingerScan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_FingerScan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_FingerScan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_FingerScan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_FingerScan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_FingerScan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_FingerScan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_FingerScan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_FingerScan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_FingerScan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_FingerScan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_FingerScan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_FingerScan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_FingerScan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_FingerScan] SET  MULTI_USER 
GO
ALTER DATABASE [QL_FingerScan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_FingerScan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_FingerScan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_FingerScan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QL_FingerScan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QL_FingerScan] SET QUERY_STORE = ON
GO
ALTER DATABASE [QL_FingerScan] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO
USE [QL_FingerScan]
GO
/****** Object:  Table [dbo].[tblVanTay] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVanTay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](255) NULL,
	[NamSinh] [nvarchar](4) NULL,
	[ChucVu] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](12) NULL,
	[Email] [nvarchar](255) NULL,
	[HinhAnh_DaiDien] [image] NULL,
	[HinhAnh_VanTay] [image] NULL,
	[HinhAnh_VanTay_TenFile] [nvarchar](255) NULL,
 CONSTRAINT [PK_tblVanTay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_User] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Delete_User]
(
	@Original_ID int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [tblVanTay] WHERE (([ID] = @Original_ID))
GO
/****** Object:  StoredProcedure [dbo].[SP_Get_UserData_By_Id] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Get_UserData_By_Id]
	@ID int
AS
	SET NOCOUNT ON;
SELECT tblVanTay.*
FROM     tblVanTay
WHERE tblVanTay.ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAll_UserData] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAll_UserData]
AS
	SET NOCOUNT ON;
SELECT tblVanTay.*
FROM     tblVanTay
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_NewUser] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insert_NewUser]
(
	@HoTen nvarchar(255),
	@NamSinh nvarchar(4),
	@ChucVu nvarchar(255),
	@SoDienThoai nvarchar(12),
	@Email nvarchar(255),
	@HinhAnh_DaiDien image,
	@HinhAnh_VanTay image,
	@HinhAnh_VanTay_TenFile nvarchar(255)
)
AS
INSERT INTO [tblVanTay] ([HoTen], [NamSinh], [ChucVu], [SoDienThoai], [Email], [HinhAnh_DaiDien], [HinhAnh_VanTay], [HinhAnh_VanTay_TenFile]) 
VALUES (@HoTen, @NamSinh, @ChucVu, @SoDienThoai, @Email, @HinhAnh_DaiDien, @HinhAnh_VanTay, @HinhAnh_VanTay_TenFile);
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_User] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_User]
(
	@HoTen nvarchar(255),
	@NamSinh nvarchar(4),
	@ChucVu nvarchar(255),
	@SoDienThoai nvarchar(12),
	@Email nvarchar(255),
	@HinhAnh_DaiDien image,
	@HinhAnh_VanTay image,
	@Original_ID int,
	@ID int
)
AS
	SET NOCOUNT OFF;
UPDATE [tblVanTay] SET [HoTen] = @HoTen, [NamSinh] = @NamSinh, [ChucVu] = @ChucVu, [SoDienThoai] = @SoDienThoai, [Email] = @Email, [HinhAnh_DaiDien] = @HinhAnh_DaiDien, [HinhAnh_VanTay] = @HinhAnh_VanTay WHERE (([ID] = @Original_ID));
	
SELECT ID, HoTen, NamSinh, ChucVu, SoDienThoai, Email, HinhAnh_DaiDien, HinhAnh_VanTay FROM tblVanTay WHERE (ID = @ID)
GO
USE [master]
GO
ALTER DATABASE [QL_FingerScan] SET  READ_WRITE 
GO