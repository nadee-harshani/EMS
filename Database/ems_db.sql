USE [master]
GO
/****** Object:  Database [EMS]    Script Date: 5/4/2024 4:13:05 PM ******/
CREATE DATABASE [EMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [EMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EMS] SET RECOVERY FULL 
GO
ALTER DATABASE [EMS] SET  MULTI_USER 
GO
ALTER DATABASE [EMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EMS', N'ON'
GO
ALTER DATABASE [EMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [EMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EMS]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/4/2024 4:13:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Designation] [nvarchar](250) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[DeletedDateTime] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 5/4/2024 4:13:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday](
	[Name] [nvarchar](250) NOT NULL,
	[HolidayDate] [datetime] NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED 
(
	[HolidayDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [Email], [Designation], [CreatedDateTime], [DeletedDateTime]) VALUES (1, N'Amith Weerasingha', N'amith@abc.com', N'Software Engineer Test', CAST(N'2024-05-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [Designation], [CreatedDateTime], [DeletedDateTime]) VALUES (2, N'Jhone Smith', N'jhone@abc.com', N'Tech Lead', CAST(N'2024-05-02T13:29:58.247' AS DateTime), CAST(N'2024-05-02T13:30:20.487' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Email], [Designation], [CreatedDateTime], [DeletedDateTime]) VALUES (3, N'Amal Madushanka', N'amal@abc.com', N'Manager', CAST(N'2024-05-03T19:50:08.940' AS DateTime), NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [Designation], [CreatedDateTime], [DeletedDateTime]) VALUES (4, N'Hashan Malinda', N'hashan@abc.com', N'CEO', CAST(N'2024-05-03T19:51:36.567' AS DateTime), NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [Designation], [CreatedDateTime], [DeletedDateTime]) VALUES (5, N'Ann Frenando', N'ann@abc.com', N'HR Group Manager', CAST(N'2024-05-03T19:56:34.370' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Tamil Thai Pongal Day', CAST(N'2024-01-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Duruthu Poya Day', CAST(N'2024-01-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Independance Day', CAST(N'2024-02-04T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Navam Poya Day', CAST(N'2024-02-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Madin Poya Day', CAST(N'2024-03-24T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Day Prior to New Year Day', CAST(N'2024-04-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Sinhala and Tamil New Year', CAST(N'2024-04-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Bak Poya Day', CAST(N'2024-04-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'International Workers Day', CAST(N'2024-05-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Wesak Poya Day', CAST(N'2024-05-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Day Following Wesak', CAST(N'2024-05-24T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Poson Poya Day', CAST(N'2024-06-21T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Esala Poya Day', CAST(N'2024-07-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Nikini Poya Day', CAST(N'2024-08-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Milad-Un-Nabi', CAST(N'2024-09-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Binara Poya Day', CAST(N'2024-09-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Vap Poya Day', CAST(N'2024-10-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Ill Poya Day', CAST(N'2024-11-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Unduvap Poya Day', CAST(N'2024-12-14T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Holiday] ([Name], [HolidayDate], [Description]) VALUES (N'Christmas Day', CAST(N'2024-12-25T00:00:00.000' AS DateTime), NULL)
GO
/****** Object:  StoredProcedure [dbo].[HolidayCalenderCalculation]    Script Date: 5/4/2024 4:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nadeesha Kularathna
-- Create date: 2024/05/01
-- Description:	Holiday Calender Calculation
-- =============================================
CREATE PROCEDURE [dbo].[HolidayCalenderCalculation]
	@Year int
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO Holiday ([Name],[HolidayDate],[Description])
	SELECT Holiday, HolidayDate,null
	FROM (
		SELECT 'Tamil Thai Pongal Day' AS Holiday, DATEFROMPARTS(@Year, 1, 15) AS HolidayDate
		UNION ALL
		SELECT 'Duruthu Poya Day' AS Holiday, DATEFROMPARTS(@Year, 1, 25) AS HolidayDate
		UNION ALL
		SELECT 'Independance Day' AS Holiday, DATEFROMPARTS(@Year, 2, 4) AS HolidayDate
		UNION ALL
		SELECT 'Navam Poya Day' AS Holiday, DATEFROMPARTS(@Year, 2, 23) AS HolidayDate
		UNION ALL
		SELECT 'Madin Poya Day' AS Holiday, DATEFROMPARTS(@Year, 3, 24) AS HolidayDate
		UNION ALL
		SELECT 'Day Prior to New Year Day' AS Holiday, DATEFROMPARTS(@Year, 4, 12) AS HolidayDate
		UNION ALL
		SELECT 'Sinhala and Tamil New Year' AS Holiday, DATEFROMPARTS(@Year, 4, 13) AS HolidayDate
		UNION ALL
		SELECT 'Bak Poya Day' AS Holiday, DATEFROMPARTS(@Year, 4, 23) AS HolidayDate
		UNION ALL
		SELECT 'International Workers Day' AS Holiday, DATEFROMPARTS(@Year, 5, 1) AS HolidayDate
		UNION ALL
		SELECT 'Wesak Poya Day' AS Holiday, DATEFROMPARTS(@Year, 5, 23) AS HolidayDate
		UNION ALL
		SELECT 'Day Following Wesak' AS Holiday, DATEFROMPARTS(@Year, 5, 24) AS HolidayDate
		UNION ALL
		SELECT 'Poson Poya Day' AS Holiday, DATEFROMPARTS(@Year, 6, 21) AS HolidayDate
		UNION ALL
		SELECT 'Esala Poya Day' AS Holiday, DATEFROMPARTS(@Year, 7, 20) AS HolidayDate
		UNION ALL
		SELECT 'Nikini Poya Day' AS Holiday, DATEFROMPARTS(@Year, 8, 19) AS HolidayDate
		UNION ALL
		SELECT 'Milad-Un-Nabi' AS Holiday, DATEFROMPARTS(@Year, 9, 16) AS HolidayDate
		UNION ALL
		SELECT 'Binara Poya Day' AS Holiday, DATEFROMPARTS(@Year, 9, 17) AS HolidayDate
		UNION ALL
		SELECT 'Vap Poya Day' AS Holiday, DATEFROMPARTS(@Year, 10, 17) AS HolidayDate
		UNION ALL
		SELECT 'Ill Poya Day' AS Holiday, DATEFROMPARTS(@Year, 11, 15) AS HolidayDate
		UNION ALL
		SELECT 'Unduvap Poya Day' AS Holiday, DATEFROMPARTS(@Year, 12, 14) AS HolidayDate
		UNION ALL
		SELECT 'Christmas Day' AS Holiday, DATEFROMPARTS(@Year, 12, 25) AS HolidayDate
	) AS subquery;
END
GO
USE [master]
GO
ALTER DATABASE [EMS] SET  READ_WRITE 
GO
