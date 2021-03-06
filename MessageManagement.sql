USE [master]
GO

CREATE DATABASE [MessageManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MessageManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MessageManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MessageManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MessageManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MessageManagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MessageManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MessageManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MessageManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MessageManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MessageManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MessageManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [MessageManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MessageManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MessageManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MessageManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MessageManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MessageManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MessageManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MessageManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MessageManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MessageManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MessageManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MessageManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MessageManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MessageManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MessageManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MessageManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MessageManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MessageManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [MessageManagement] SET  MULTI_USER 
GO
ALTER DATABASE [MessageManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MessageManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MessageManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MessageManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MessageManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MessageManagement', N'ON'
GO
ALTER DATABASE [MessageManagement] SET QUERY_STORE = OFF
GO
USE [MessageManagement]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MessageManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019/9/9 14:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataBase]    Script Date: 2019/9/9 14:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataBase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SdataBaseName] [nvarchar](200) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime] NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataTable]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdataBaseId] [int] NOT NULL,
	[StableName] [nvarchar](50) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime] NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime] NULL,
 CONSTRAINT [PK_DataTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataType]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime2](7) NULL,
	[StypeName] [nvarchar](max) NULL,
 CONSTRAINT [PK_DataType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldRelation]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldRelation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime2](7) NULL,
	[IprimarykeyId] [int] NOT NULL,
	[IforeignkeyId] [int] NOT NULL,
 CONSTRAINT [PK_FieldRelation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IparentId] [int] NOT NULL,
	[Sname] [nvarchar](128) NOT NULL,
	[SiconUrl] [nvarchar](128) NULL,
	[SlinkUrl] [nvarchar](128) NULL,
	[Isort] [int] NOT NULL,
	[Bdisplay] [bit] NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime] NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuAction]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime2](7) NULL,
	[ImenuId] [int] NOT NULL,
	[IactionId] [int] NOT NULL,
	[BisValid] [bit] NULL,
	[Sexplain] [nvarchar](100) NULL,
 CONSTRAINT [PK_MenuAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IroleId] [int] NOT NULL,
	[ImenuId] [int] NOT NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime] NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime] NULL,
	[Sremarks] [nvarchar](200) NULL,
 CONSTRAINT [PK_RoleMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SroleName] [nvarchar](50) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemAction]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime2](7) NULL,
	[SactionName] [nvarchar](200) NULL,
	[IcontrollerId] [int] NOT NULL,
	[SresultType] [nvarchar](max) NULL,
	[Bvalid] [bit] NOT NULL,
 CONSTRAINT [PK_SystemAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemController]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemController](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime2](7) NULL,
	[ScontrollerName] [nvarchar](100) NULL,
 CONSTRAINT [PK_SystemController] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFiled]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFiled](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime2](7) NULL,
	[SfiledName] [nvarchar](max) NULL,
	[IdataTableId] [int] NOT NULL,
	[IdataTypeId] [int] NOT NULL,
	[BisEmpty] [bit] NOT NULL,
	[ImaxLength] [int] NOT NULL,
	[Sexplain] [nvarchar](max) NULL,
 CONSTRAINT [PK_TableFiled] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UploadFileInfo]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadFileInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Uid] [uniqueidentifier] NOT NULL,
	[SoriginalFileName] [nvarchar](100) NOT NULL,
	[SfileName] [nvarchar](100) NOT NULL,
	[SfileType] [nvarchar](30) NOT NULL,
	[SfilePath] [nvarchar](500) NOT NULL,
	[SrelativePath] [nvarchar](500) NOT NULL,
	[Isize] [int] NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NULL,
	[TmodifyTime] [datetime2](7) NULL,
 CONSTRAINT [PK_UploadFileInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SloginName] [nvarchar](30) NOT NULL,
	[SloginPwd] [nvarchar](100) NOT NULL,
	[SuserName] [nvarchar](20) NOT NULL,
	[SuserPhone] [nvarchar](50) NOT NULL,
	[SuserEmail] [nvarchar](50) NOT NULL,
	[BisLock] [bit] NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime] NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime] NULL,
	[SloginLastIp] [nvarchar](64) NULL,
	[TloginLastTime] [datetime2](7) NULL,
	[IfileInfoId] [int] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2019/9/9 14:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IuserId] [int] NOT NULL,
	[IroleId] [int] NOT NULL,
	[Sremarks] [nvarchar](200) NULL,
	[Screater] [nvarchar](50) NOT NULL,
	[TcreateTime] [datetime2](7) NULL,
	[Smodifier] [nvarchar](50) NOT NULL,
	[TmodifyTime] [datetime2](7) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DataBase] ON 

INSERT [dbo].[DataBase] ([Id], [SdataBaseName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (2, N'MessageManagement', NULL, N'admin', CAST(N'2019-08-29T15:23:01.927' AS DateTime), N'admin', CAST(N'2019-08-29T15:23:01.927' AS DateTime))
SET IDENTITY_INSERT [dbo].[DataBase] OFF
SET IDENTITY_INSERT [dbo].[DataTable] ON 

INSERT [dbo].[DataTable] ([Id], [IdataBaseId], [StableName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (8, 2, N'MenuAction', NULL, N'admin', CAST(N'2019-09-04T14:28:23.213' AS DateTime), N'admin', CAST(N'2019-09-04T14:28:23.213' AS DateTime))
SET IDENTITY_INSERT [dbo].[DataTable] OFF
SET IDENTITY_INSERT [dbo].[DataType] ON 

INSERT [dbo].[DataType] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [StypeName]) VALUES (1, NULL, N'admin', CAST(N'2019-08-30T12:42:53.2235932' AS DateTime2), N'admin', CAST(N'2019-08-30T12:42:53.2237132' AS DateTime2), N'bool')
INSERT [dbo].[DataType] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [StypeName]) VALUES (2, NULL, N'admin', CAST(N'2019-08-30T12:44:07.5743141' AS DateTime2), N'admin', CAST(N'2019-08-30T12:44:07.5743215' AS DateTime2), N'int')
INSERT [dbo].[DataType] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [StypeName]) VALUES (3, NULL, N'admin', CAST(N'2019-08-30T12:44:25.0058251' AS DateTime2), N'admin', CAST(N'2019-08-30T12:44:25.0058313' AS DateTime2), N'float')
INSERT [dbo].[DataType] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [StypeName]) VALUES (4, NULL, N'admin', CAST(N'2019-08-30T12:44:39.1851906' AS DateTime2), N'admin', CAST(N'2019-08-30T12:44:39.1851962' AS DateTime2), N'long')
INSERT [dbo].[DataType] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [StypeName]) VALUES (5, NULL, N'admin', CAST(N'2019-08-30T12:45:30.2253523' AS DateTime2), N'admin', CAST(N'2019-08-30T12:45:30.2253578' AS DateTime2), N'string')
INSERT [dbo].[DataType] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [StypeName]) VALUES (6, NULL, N'admin', CAST(N'2019-08-30T12:45:46.7087701' AS DateTime2), N'admin', CAST(N'2019-08-30T12:45:46.7087770' AS DateTime2), N'DateTime')
INSERT [dbo].[DataType] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [StypeName]) VALUES (7, NULL, N'admin', CAST(N'2019-08-30T12:45:57.4077856' AS DateTime2), N'admin', CAST(N'2019-08-30T12:45:57.4077918' AS DateTime2), N'Guid')
SET IDENTITY_INSERT [dbo].[DataType] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (2, -1, N'系统管理', N'&#xe620;', NULL, 9000, 0, NULL, N'admin', CAST(N'2019-07-22T00:00:00.000' AS DateTime), N'admin', CAST(N'2019-07-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (3, 2, N'用户管理', N'&#xe612;', N'/Admin/UserInfo/Index?iPageId=3', 100, 0, NULL, N'admin', CAST(N'2019-07-22T00:00:00.000' AS DateTime), N'admin', CAST(N'2019-08-13T10:31:38.263' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (14, 2, N'菜单管理', N'', N'/Admin/Menu/Index?iPageId=14', 200, 0, NULL, N'admin', CAST(N'2019-08-07T00:00:00.000' AS DateTime), N'admin', CAST(N'2019-09-06T10:56:45.540' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (8, 2, N'角色管理', N'', N'/Admin/Roles/Index?iPageId=8', 300, 0, NULL, N'admin', CAST(N'2019-07-22T00:00:00.000' AS DateTime), N'admin', CAST(N'2019-09-06T10:59:24.883' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (9, 2, N'测试', N'icon-vip', N'/Admin/Test/index?iPageId=9', 1000, 0, NULL, N'admin', CAST(N'2019-07-02T00:00:00.000' AS DateTime), N'admin', CAST(N'2019-08-28T16:41:31.573' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (11, -1, N'测试菜单', N'layui-icon-app', N'2', 13000, 0, NULL, N'admin', CAST(N'2019-08-06T11:23:26.107' AS DateTime), N'admin', CAST(N'2019-08-14T13:31:43.017' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (15, 11, N'测试2', N'icon-vip', N'/Admin/Test/index?iPageId=15', 400, 0, NULL, N'admin', CAST(N'2019-08-07T10:57:39.843' AS DateTime), N'admin', CAST(N'2019-08-13T10:39:32.350' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (21, 11, N'测试1', N'icon-vip', N'/Admin/Test/index?iPageId=21', 700, 0, NULL, N'admin', CAST(N'2019-08-09T10:48:22.070' AS DateTime), N'admin', CAST(N'2019-08-13T10:30:58.017' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (22, 11, N'测试3', N'icon-vip', N'/Admin/Test/index?iPageId=22', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:00.080' AS DateTime), N'admin', CAST(N'2019-08-13T10:30:43.720' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (23, 11, N'测试4', N'icon-vip', N'/Admin/Test/index?iPageId=23', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:06.357' AS DateTime), N'admin', CAST(N'2019-08-13T10:30:31.587' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (19, 11, N'测试6', N'icon-vip', N'/Admin/Test/index?iPageId=6', 600, 0, N'', N'admin', CAST(N'2019-08-07T10:58:56.700' AS DateTime), N'admin', CAST(N'2019-08-29T10:23:24.723' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (20, 11, N'测试7', N'icon-vip', N'/Admin/Test/index?iPageId=20', 500, 0, NULL, N'admin', CAST(N'2019-08-07T10:59:06.647' AS DateTime), N'admin', CAST(N'2019-08-13T10:46:48.610' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (24, 11, N'测试5', N'icon-vip', N'/Admin/Test/index?iPageId=24', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:12.190' AS DateTime), N'admin', CAST(N'2019-08-13T10:30:21.837' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (25, 11, N'测试8', N'icon-vip', N'/Admin/Test/index?iPageId=25', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:31.003' AS DateTime), N'admin', CAST(N'2019-08-13T10:30:13.290' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (26, 11, N'测试9', N'icon-vip', N'/Admin/Test/index?iPageId=26', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:36.333' AS DateTime), N'admin', CAST(N'2019-08-13T10:30:04.027' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (27, 11, N'测试10', N'icon-vip', N'/Admin/Test/index?iPageId=27', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:41.663' AS DateTime), N'admin', CAST(N'2019-08-13T10:29:52.173' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (28, 11, N'测试11', N'icon-vip', N'/Admin/Test/index?iPageId=28', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:47.723' AS DateTime), N'admin', CAST(N'2019-08-13T10:29:42.343' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (29, 11, N'测试12', N'icon-vip', N'/Admin/Test/index?iPageId=29', 200, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:53.823' AS DateTime), N'admin', CAST(N'2019-08-13T10:43:50.127' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (30, 11, N'测试13', N'icon-vip', N'/Admin/Test/index?iPageId=30', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:54:58.553' AS DateTime), N'admin', CAST(N'2019-08-13T10:29:13.370' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (31, 11, N'测试14', N'icon-vip', N'/Admin/Test/index?iPageId=31', 600, 0, NULL, N'admin', CAST(N'2019-08-09T10:55:03.583' AS DateTime), N'admin', CAST(N'2019-08-13T10:29:03.257' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (33, 2, N'控制器管理', N'', N'/Admin/SystemController/Index?iPageId=33', 400, 0, NULL, N'admin', CAST(N'2019-08-27T15:18:32.003' AS DateTime), N'admin', CAST(N'2019-09-06T11:01:23.097' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (34, 2, N'Action管理', N'&#xe643;', N'/Admin/SystemAction/Index?iPageId=34', 500, 0, NULL, N'admin', CAST(N'2019-08-28T14:02:03.480' AS DateTime), N'admin', CAST(N'2019-08-28T14:04:52.347' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (35, 2, N'数据库管理', N'', N'/Admin/DataBase/Index?iPageId=35', 550, 0, NULL, N'admin', CAST(N'2019-08-29T14:46:11.087' AS DateTime), N'admin', CAST(N'2019-09-06T11:04:09.843' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (36, 2, N'数据表管理', N'', N'/Admin/DataTable/Index?iPageId=36', 560, 0, NULL, N'admin', CAST(N'2019-08-29T15:25:31.660' AS DateTime), N'admin', CAST(N'2019-08-29T15:25:31.760' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (37, 2, N'数据列管理', N'', N'/Admin/TableFiled/Index?iPageId=37', 570, 0, NULL, N'admin', CAST(N'2019-08-30T10:32:16.773' AS DateTime), N'admin', CAST(N'2019-09-06T11:04:33.317' AS DateTime))
INSERT [dbo].[Menu] ([Id], [IparentId], [Sname], [SiconUrl], [SlinkUrl], [Isort], [Bdisplay], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (38, 2, N'菜单权限', N'', N'/Admin/MenuAction/Index?iPageId=38', 210, 0, NULL, N'admin', CAST(N'2019-08-30T12:38:16.880' AS DateTime), N'admin', CAST(N'2019-09-05T09:40:53.190' AS DateTime))
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MenuAction] ON 

INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (3, N'Test', N'admin', CAST(N'2019-09-04T17:19:00.0000000' AS DateTime2), N'admin', CAST(N'2019-09-04T17:19:00.0000000' AS DateTime2), 8, 1320, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (4, N'Test', N'admin', CAST(N'2019-09-04T17:19:00.0000000' AS DateTime2), N'admin', CAST(N'2019-09-04T17:19:00.0000000' AS DateTime2), 38, 1395, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (6, NULL, N'admin', CAST(N'2019-09-06T11:28:46.7638918' AS DateTime2), N'admin', CAST(N'2019-09-06T15:24:52.3062111' AS DateTime2), 38, 1397, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (7, NULL, N'admin', CAST(N'2019-09-06T12:31:48.0667087' AS DateTime2), N'admin', CAST(N'2019-09-06T15:59:49.8398602' AS DateTime2), 38, 1399, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (8, NULL, N'admin', CAST(N'2019-09-06T14:34:33.4087884' AS DateTime2), N'admin', CAST(N'2019-09-06T14:39:11.4276395' AS DateTime2), 38, 1306, 0, N'编辑区菜单权限弹出层')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (9, NULL, N'admin', CAST(N'2019-09-06T14:35:57.8774334' AS DateTime2), N'admin', CAST(N'2019-09-06T14:35:57.8774384' AS DateTime2), 38, 1328, 0, N'编辑区Action弹出层')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (10, NULL, N'admin', CAST(N'2019-09-06T14:51:59.1177487' AS DateTime2), N'admin', CAST(N'2019-09-06T15:31:31.7915105' AS DateTime2), 14, 1306, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (11, NULL, N'admin', CAST(N'2019-09-06T16:51:16.2070289' AS DateTime2), N'admin', CAST(N'2019-09-06T16:51:16.2072260' AS DateTime2), 3, 1341, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (12, NULL, N'admin', CAST(N'2019-09-06T16:53:41.0495821' AS DateTime2), N'admin', CAST(N'2019-09-06T16:53:41.0495875' AS DateTime2), 3, 1342, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (13, NULL, N'admin', CAST(N'2019-09-06T16:54:06.2722119' AS DateTime2), N'admin', CAST(N'2019-09-06T16:54:27.8653454' AS DateTime2), 3, 1346, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (14, NULL, N'admin', CAST(N'2019-09-06T16:56:44.1999452' AS DateTime2), N'admin', CAST(N'2019-09-06T16:59:19.2310259' AS DateTime2), 3, 1323, 0, N'编辑区数据')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (15, NULL, N'admin', CAST(N'2019-09-06T16:59:10.9163081' AS DateTime2), N'admin', CAST(N'2019-09-06T16:59:10.9163180' AS DateTime2), 3, 1351, 0, N'编辑区数据')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (16, NULL, N'admin', CAST(N'2019-09-06T17:01:29.5408600' AS DateTime2), N'admin', CAST(N'2019-09-06T17:01:29.5408689' AS DateTime2), 14, 1308, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (17, NULL, N'admin', CAST(N'2019-09-06T17:12:10.9228746' AS DateTime2), N'admin', CAST(N'2019-09-06T17:12:10.9231379' AS DateTime2), 33, 1422, 0, N'反射控制器Action')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (18, NULL, N'admin', CAST(N'2019-09-06T17:21:21.7998548' AS DateTime2), N'admin', CAST(N'2019-09-06T17:21:21.8000663' AS DateTime2), 33, 1434, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (19, NULL, N'admin', CAST(N'2019-09-06T17:22:11.7947938' AS DateTime2), N'admin', CAST(N'2019-09-06T17:22:11.7947996' AS DateTime2), 33, 1436, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (20, NULL, N'admin', CAST(N'2019-09-06T17:22:49.0239680' AS DateTime2), N'admin', CAST(N'2019-09-06T17:22:49.0239759' AS DateTime2), 33, 1438, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (21, NULL, N'admin', CAST(N'2019-09-06T17:26:15.1354008' AS DateTime2), N'admin', CAST(N'2019-09-06T17:26:15.1354058' AS DateTime2), 14, 1443, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (22, NULL, N'admin', CAST(N'2019-09-06T17:27:32.4454212' AS DateTime2), N'admin', CAST(N'2019-09-06T17:27:32.4454295' AS DateTime2), 14, 1315, 0, N'编辑区数据')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (23, NULL, N'admin', CAST(N'2019-09-06T17:28:23.8672628' AS DateTime2), N'admin', CAST(N'2019-09-06T17:28:23.8672679' AS DateTime2), 14, 1323, 0, N'编辑区数据')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (24, NULL, N'admin', CAST(N'2019-09-06T17:34:17.2936790' AS DateTime2), N'admin', CAST(N'2019-09-06T17:34:17.2939143' AS DateTime2), 14, 1311, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (25, N'Test', N'admin', CAST(N'2019-09-06T17:37:06.3848435' AS DateTime2), N'admin', CAST(N'2019-09-06T17:37:06.3848496' AS DateTime2), 8, 1322, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (26, N'Test', N'admin', CAST(N'2019-09-06T17:37:42.1647310' AS DateTime2), N'admin', CAST(N'2019-09-06T17:37:42.1647356' AS DateTime2), 8, 1325, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (27, N'Test', N'admin', CAST(N'2019-09-06T17:39:10.9586760' AS DateTime2), N'admin', CAST(N'2019-09-06T17:39:10.9586822' AS DateTime2), 8, 1352, 0, N'编辑区数据')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (28, NULL, N'admin', CAST(N'2019-09-06T17:39:44.6910797' AS DateTime2), N'admin', CAST(N'2019-09-06T17:39:44.6910887' AS DateTime2), 8, 1316, 0, N'编辑区数据')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (29, NULL, N'admin', CAST(N'2019-09-06T17:40:19.8852608' AS DateTime2), N'admin', CAST(N'2019-09-06T17:40:19.8852701' AS DateTime2), 8, 1347, 0, N'编辑区数据')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (30, NULL, N'admin', CAST(N'2019-09-06T17:40:38.1044818' AS DateTime2), N'admin', CAST(N'2019-09-06T17:40:38.1044870' AS DateTime2), 8, 1310, 0, N'编辑区数据')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (31, NULL, N'admin', CAST(N'2019-09-06T17:42:51.3493245' AS DateTime2), N'admin', CAST(N'2019-09-06T17:42:51.3493336' AS DateTime2), 34, 1328, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (32, NULL, N'admin', CAST(N'2019-09-06T17:43:17.9513246' AS DateTime2), N'admin', CAST(N'2019-09-06T17:43:17.9513373' AS DateTime2), 34, 1330, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (33, NULL, N'admin', CAST(N'2019-09-06T17:43:37.0969543' AS DateTime2), N'admin', CAST(N'2019-09-06T17:43:37.0969592' AS DateTime2), 34, 1331, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (34, NULL, N'admin', CAST(N'2019-09-06T17:44:53.8275319' AS DateTime2), N'admin', CAST(N'2019-09-06T17:44:53.8275370' AS DateTime2), 35, 1364, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (35, NULL, N'admin', CAST(N'2019-09-06T17:45:12.8078719' AS DateTime2), N'admin', CAST(N'2019-09-06T17:45:12.8078765' AS DateTime2), 35, 1363, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (36, NULL, N'admin', CAST(N'2019-09-06T17:45:34.0663608' AS DateTime2), N'admin', CAST(N'2019-09-06T17:45:34.0663687' AS DateTime2), 35, 1360, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (37, NULL, N'admin', CAST(N'2019-09-06T17:46:25.5570316' AS DateTime2), N'admin', CAST(N'2019-09-06T17:46:25.5570375' AS DateTime2), 36, 1371, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (40, NULL, N'admin', CAST(N'2019-09-06T17:52:20.7267902' AS DateTime2), N'admin', CAST(N'2019-09-06T17:52:20.7267958' AS DateTime2), 36, 1369, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (41, NULL, N'admin', CAST(N'2019-09-06T17:53:01.6560125' AS DateTime2), N'admin', CAST(N'2019-09-06T17:53:01.6560171' AS DateTime2), 36, 1372, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (42, NULL, N'admin', CAST(N'2019-09-06T17:54:12.4018216' AS DateTime2), N'admin', CAST(N'2019-09-06T17:54:12.4018272' AS DateTime2), 37, 1409, 0, N'查询')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (43, NULL, N'admin', CAST(N'2019-09-06T17:54:46.4902434' AS DateTime2), N'admin', CAST(N'2019-09-06T17:54:46.4902490' AS DateTime2), 37, 1412, 0, N'编辑')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (44, NULL, N'admin', CAST(N'2019-09-06T17:55:08.6372373' AS DateTime2), N'admin', CAST(N'2019-09-06T17:55:08.6372428' AS DateTime2), 37, 1413, 0, N'删除')
INSERT [dbo].[MenuAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ImenuId], [IactionId], [BisValid], [Sexplain]) VALUES (45, NULL, N'admin', CAST(N'2019-09-09T10:39:28.9540683' AS DateTime2), N'admin', CAST(N'2019-09-09T10:39:28.9543152' AS DateTime2), 36, 1414, 0, N'外链')
SET IDENTITY_INSERT [dbo].[MenuAction] OFF
SET IDENTITY_INSERT [dbo].[RoleMenu] ON 

INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (1, 1, 2, N'1', CAST(N'2019-07-19T00:00:00.000' AS DateTime), N'1', CAST(N'2019-07-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (4, 1, 8, N'1', CAST(N'2019-07-19T00:00:00.000' AS DateTime), N'1', CAST(N'2019-07-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (5, 1, 9, N'1', CAST(N'2019-07-02T00:00:00.000' AS DateTime), N'1', CAST(N'2019-07-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (8, 2, 2, N'1', CAST(N'2019-07-25T00:00:00.000' AS DateTime), N'1', CAST(N'2019-07-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (12, 3, 11, N'admin', CAST(N'2019-08-06T12:43:12.643' AS DateTime), N'admin', CAST(N'2019-08-06T12:43:12.643' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (14, 1, 11, N'admin', CAST(N'2019-08-06T13:34:46.903' AS DateTime), N'admin', CAST(N'2019-08-06T13:34:46.903' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (19, 2, 8, N'admin', CAST(N'2019-08-06T16:27:37.687' AS DateTime), N'admin', CAST(N'2019-08-06T16:27:37.687' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (20, 2, 9, N'admin', CAST(N'2019-08-06T16:27:37.833' AS DateTime), N'admin', CAST(N'2019-08-06T16:27:37.833' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (22, 2, 11, N'admin', CAST(N'2019-08-06T16:32:43.293' AS DateTime), N'admin', CAST(N'2019-08-06T16:32:43.293' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (23, 2, 14, N'admin', CAST(N'2019-08-07T09:50:51.843' AS DateTime), N'admin', CAST(N'2019-08-07T09:50:51.843' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (24, 2, 15, N'admin', CAST(N'2019-08-07T10:57:39.903' AS DateTime), N'admin', CAST(N'2019-08-07T10:57:39.903' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (32, 2, 20, N'admin', CAST(N'2019-08-07T10:59:06.667' AS DateTime), N'admin', CAST(N'2019-08-07T10:59:06.667' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (35, 2, 24, N'admin', CAST(N'2019-08-09T10:55:28.790' AS DateTime), N'admin', CAST(N'2019-08-09T10:55:28.790' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (36, 2, 23, N'admin', CAST(N'2019-08-09T10:55:49.253' AS DateTime), N'admin', CAST(N'2019-08-09T10:55:49.253' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (37, 2, 22, N'admin', CAST(N'2019-08-09T10:56:09.180' AS DateTime), N'admin', CAST(N'2019-08-09T10:56:09.180' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (38, 2, 21, N'admin', CAST(N'2019-08-09T10:56:12.257' AS DateTime), N'admin', CAST(N'2019-08-09T10:56:12.257' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (39, 2, 19, N'admin', CAST(N'2019-08-09T10:56:14.327' AS DateTime), N'admin', CAST(N'2019-08-09T10:56:14.327' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (41, 1, 31, N'admin', CAST(N'2019-08-09T10:56:57.337' AS DateTime), N'admin', CAST(N'2019-08-09T10:56:57.337' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (42, 1, 30, N'admin', CAST(N'2019-08-09T10:56:57.597' AS DateTime), N'admin', CAST(N'2019-08-09T10:56:57.597' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (43, 1, 3, N'admin', CAST(N'2019-08-14T13:25:02.333' AS DateTime), N'admin', CAST(N'2019-08-14T13:25:02.333' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (44, 1, 14, N'admin', CAST(N'2019-08-14T13:25:02.893' AS DateTime), N'admin', CAST(N'2019-08-14T13:25:02.893' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (46, 1, 19, N'admin', CAST(N'2019-08-16T16:45:30.477' AS DateTime), N'admin', CAST(N'2019-08-16T16:45:30.477' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (48, 16, 8, N'admin', CAST(N'2019-08-16T17:09:35.740' AS DateTime), N'admin', CAST(N'2019-08-16T17:09:35.740' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (49, 16, 2, N'admin', CAST(N'2019-08-19T15:58:00.000' AS DateTime), N'admin', CAST(N'2019-08-19T15:58:00.000' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (52, 1, 27, N'admin', CAST(N'2019-08-27T14:32:41.253' AS DateTime), N'admin', CAST(N'2019-08-27T14:32:41.253' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (53, 1, 26, N'admin', CAST(N'2019-08-27T14:41:05.223' AS DateTime), N'admin', CAST(N'2019-08-27T14:41:05.223' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (54, 1, 33, N'admin', CAST(N'2019-08-27T15:18:32.653' AS DateTime), N'admin', CAST(N'2019-08-27T15:18:32.653' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (55, 1, 34, N'admin', CAST(N'2019-08-28T14:02:03.973' AS DateTime), N'admin', CAST(N'2019-08-28T14:02:03.973' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (56, 1, 35, N'admin', CAST(N'2019-08-29T14:46:11.760' AS DateTime), N'admin', CAST(N'2019-08-29T14:46:11.760' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (57, 1, 36, N'admin', CAST(N'2019-08-29T15:25:32.070' AS DateTime), N'admin', CAST(N'2019-08-29T15:25:32.070' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (58, 1, 37, N'admin', CAST(N'2019-08-30T10:32:17.280' AS DateTime), N'admin', CAST(N'2019-08-30T10:32:17.280' AS DateTime), NULL)
INSERT [dbo].[RoleMenu] ([Id], [IroleId], [ImenuId], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [Sremarks]) VALUES (59, 1, 38, N'admin', CAST(N'2019-08-30T12:38:17.353' AS DateTime), N'admin', CAST(N'2019-08-30T12:38:17.353' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[RoleMenu] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (1, N'开发人员', N'开发者', N'admin', CAST(N'2019-07-22T00:00:00.0000000' AS DateTime2), N'admin', CAST(N'2019-08-27T14:41:04.7826778' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (2, N'系统管理员', N'最高权限', N'admin', CAST(N'2019-07-22T00:00:00.0000000' AS DateTime2), N'admin', CAST(N'2019-08-13T14:39:53.4070589' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (3, N'来宾', N'', N'admin', CAST(N'2019-07-26T00:00:00.0000000' AS DateTime2), N'admin', CAST(N'2019-07-26T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (7, N'Test', NULL, N'admin', CAST(N'2019-08-07T11:00:29.5194480' AS DateTime2), N'admin', CAST(N'2019-08-07T11:00:29.5195508' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (8, N'Test2', NULL, N'admin', CAST(N'2019-08-07T11:00:34.9351420' AS DateTime2), N'admin', CAST(N'2019-08-07T11:00:34.9351537' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (9, N'Test3', NULL, N'admin', CAST(N'2019-08-07T11:00:40.2524120' AS DateTime2), N'admin', CAST(N'2019-08-07T11:00:40.2524334' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (10, N'Test4', NULL, N'admin', CAST(N'2019-08-07T11:00:45.1857873' AS DateTime2), N'admin', CAST(N'2019-08-07T11:00:45.1858131' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (11, N'Test5', NULL, N'admin', CAST(N'2019-08-07T11:00:50.7347744' AS DateTime2), N'admin', CAST(N'2019-08-07T11:00:50.7347957' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (12, N'Test6', NULL, N'admin', CAST(N'2019-08-07T11:00:58.0329488' AS DateTime2), N'admin', CAST(N'2019-08-07T11:00:58.0329654' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (13, N'Test7', NULL, N'admin', CAST(N'2019-08-07T11:03:46.5472728' AS DateTime2), N'admin', CAST(N'2019-08-07T11:03:46.5472893' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (14, N'Test8', NULL, N'admin', CAST(N'2019-08-07T11:04:00.1066659' AS DateTime2), N'admin', CAST(N'2019-08-07T11:04:00.1066979' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (15, N'Test9', NULL, N'admin', CAST(N'2019-08-07T11:04:05.6530667' AS DateTime2), N'admin', CAST(N'2019-08-07T11:04:05.6530899' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (16, N'Test10', NULL, N'admin', CAST(N'2019-08-07T11:04:10.4835634' AS DateTime2), N'admin', CAST(N'2019-08-16T17:09:35.4806716' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [SroleName], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (18, N'前台', NULL, N'admin', CAST(N'2019-08-13T09:56:17.0164212' AS DateTime2), N'admin', CAST(N'2019-08-13T09:56:17.0166704' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[SystemAction] ON 

INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1297, NULL, N'admin', CAST(N'2019-08-28T16:42:02.7884113' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:02.7884178' AS DateTime2), N'Index', 58, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1298, NULL, N'admin', CAST(N'2019-08-28T16:42:02.9531435' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:02.9531486' AS DateTime2), N'SignInAsync', 58, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1299, NULL, N'admin', CAST(N'2019-08-28T16:42:03.0866090' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:03.0866145' AS DateTime2), N'GetCaptchaImage', 58, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1300, NULL, N'admin', CAST(N'2019-08-28T16:42:03.2251348' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:03.2251410' AS DateTime2), N'SignOutAsync', 58, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1301, NULL, N'admin', CAST(N'2019-08-28T16:42:03.5835657' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:03.5835706' AS DateTime2), N'IndexAsync', 59, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1302, NULL, N'admin', CAST(N'2019-08-28T16:42:03.7172706' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:03.7172757' AS DateTime2), N'GetMenuAsync', 59, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1303, NULL, N'admin', CAST(N'2019-08-28T16:42:03.8606832' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:03.8606901' AS DateTime2), N'GetUserTreeMenuAsync', 59, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1304, NULL, N'admin', CAST(N'2019-08-28T16:42:03.9980640' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:03.9980706' AS DateTime2), N'Main', 59, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1305, NULL, N'admin', CAST(N'2019-08-28T16:42:04.1343747' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:04.1343808' AS DateTime2), N'Error', 59, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1306, NULL, N'admin', CAST(N'2019-08-28T16:42:04.4504878' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:04.4504961' AS DateTime2), N'LoadData', 60, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1307, NULL, N'admin', CAST(N'2019-08-28T16:42:04.5850873' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:04.5850965' AS DateTime2), N'Index', 60, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1309, NULL, N'admin', CAST(N'2019-08-28T16:42:04.8933030' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:04.8933081' AS DateTime2), N'ChangeMenuState', 60, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1310, NULL, N'admin', CAST(N'2019-08-28T16:42:05.0248221' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:05.0248269' AS DateTime2), N'GetMenuListAsync', 60, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1311, NULL, N'admin', CAST(N'2019-08-28T16:42:05.1557385' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:05.1557437' AS DateTime2), N'DeleteRange', 60, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1312, NULL, N'admin', CAST(N'2019-08-28T16:42:05.2942682' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:05.2942733' AS DateTime2), N'GetJsonValue', 60, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1313, NULL, N'admin', CAST(N'2019-08-28T16:42:05.4677345' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:05.4677390' AS DateTime2), N'Edit', 60, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1314, NULL, N'admin', CAST(N'2019-08-28T16:42:05.7411509' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:05.7411561' AS DateTime2), N'LoadData', 61, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1315, NULL, N'admin', CAST(N'2019-08-28T16:42:05.8723909' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:05.8723968' AS DateTime2), N'GetMenuRoleAsync', 61, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1316, NULL, N'admin', CAST(N'2019-08-28T16:42:05.9977603' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:05.9977655' AS DateTime2), N'GetRoleMenuAsync', 61, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1317, NULL, N'admin', CAST(N'2019-08-28T16:42:06.1325235' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:06.1325290' AS DateTime2), N'GetJsonValue', 61, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1318, NULL, N'admin', CAST(N'2019-08-28T16:42:06.2582514' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:06.2582566' AS DateTime2), N'List', 61, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1319, NULL, N'admin', CAST(N'2019-08-28T16:42:06.3835729' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:06.3835776' AS DateTime2), N'Edit', 61, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1320, NULL, N'admin', CAST(N'2019-08-28T16:42:06.6725251' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:06.6725299' AS DateTime2), N'LoadData', 62, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1321, NULL, N'admin', CAST(N'2019-08-28T16:42:06.8041810' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:06.8041859' AS DateTime2), N'Index', 62, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1322, NULL, N'admin', CAST(N'2019-08-28T16:42:06.9627597' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:06.9627645' AS DateTime2), N'AddOrModify', 62, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1323, NULL, N'admin', CAST(N'2019-08-28T16:42:07.1199614' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:07.1199667' AS DateTime2), N'GetRoleList', 62, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1324, NULL, N'admin', CAST(N'2019-08-28T16:42:07.2376524' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:07.2376575' AS DateTime2), N'AddOrModifyAsync', 62, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1325, NULL, N'admin', CAST(N'2019-08-28T16:42:07.3622840' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:07.3622895' AS DateTime2), N'DeleteRange', 62, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1326, NULL, N'admin', CAST(N'2019-08-28T16:42:07.4909275' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:07.4909324' AS DateTime2), N'GetJsonValue', 62, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1327, NULL, N'admin', CAST(N'2019-08-28T16:42:07.6582253' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:07.6582300' AS DateTime2), N'Edit', 62, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1328, NULL, N'admin', CAST(N'2019-08-28T16:42:07.9297084' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:07.9297141' AS DateTime2), N'LoadData', 63, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1329, NULL, N'admin', CAST(N'2019-08-28T16:42:08.0567744' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:08.0567791' AS DateTime2), N'Index', 63, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1330, NULL, N'admin', CAST(N'2019-08-28T16:42:08.1762238' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:08.1762286' AS DateTime2), N'AddOrModifyAsync', 63, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1331, NULL, N'admin', CAST(N'2019-08-28T16:42:08.3279613' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:08.3279661' AS DateTime2), N'DeleteRange', 63, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1332, NULL, N'admin', CAST(N'2019-08-28T16:42:08.4643614' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:08.4643662' AS DateTime2), N'GetJsonValue', 63, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1333, NULL, N'admin', CAST(N'2019-08-28T16:42:08.5814150' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:08.5814211' AS DateTime2), N'List', 63, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1334, NULL, N'admin', CAST(N'2019-08-28T16:42:08.7051892' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:08.7051942' AS DateTime2), N'Edit', 63, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1336, NULL, N'admin', CAST(N'2019-08-28T16:42:09.4672271' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:09.4672321' AS DateTime2), N'UploadImageAsync', 64, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1337, NULL, N'admin', CAST(N'2019-08-28T16:42:09.5935981' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:09.5936037' AS DateTime2), N'GetJsonValue', 64, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1338, NULL, N'admin', CAST(N'2019-08-28T16:42:09.7132274' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:09.7132324' AS DateTime2), N'List', 64, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1339, NULL, N'admin', CAST(N'2019-08-28T16:42:09.8431771' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:09.8431820' AS DateTime2), N'Edit', 64, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1340, NULL, N'admin', CAST(N'2019-08-28T16:42:10.1256268' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:10.1256319' AS DateTime2), N'Index', 65, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1341, NULL, N'admin', CAST(N'2019-08-28T16:42:10.2492274' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:10.2492321' AS DateTime2), N'LoadData', 65, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1342, NULL, N'admin', CAST(N'2019-08-28T16:42:10.3738609' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:10.3738661' AS DateTime2), N'AddOrModify', 65, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1343, NULL, N'admin', CAST(N'2019-08-28T16:42:10.4947022' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:10.4947071' AS DateTime2), N'AddOrModifyAsync', 65, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1344, NULL, N'admin', CAST(N'2019-08-28T16:42:10.6206975' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:10.6207024' AS DateTime2), N'ChangeUserLockStates', 65, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1345, NULL, N'admin', CAST(N'2019-08-28T16:42:10.7380037' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:10.7380085' AS DateTime2), N'PersonalInfo', 65, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1346, NULL, N'admin', CAST(N'2019-08-28T16:42:10.8931993' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:10.8932041' AS DateTime2), N'DeleteRange', 65, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1347, NULL, N'admin', CAST(N'2019-08-28T16:42:11.0201278' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:11.0201467' AS DateTime2), N'GetUserListAsync', 65, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1348, NULL, N'admin', CAST(N'2019-08-28T16:42:11.1370230' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:11.1370286' AS DateTime2), N'GetJsonValue', 65, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1349, NULL, N'admin', CAST(N'2019-08-28T16:42:11.3036747' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:11.3036802' AS DateTime2), N'Edit', 65, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1350, NULL, N'admin', CAST(N'2019-08-28T16:42:11.5901481' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:11.5901535' AS DateTime2), N'LoadData', 66, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1351, NULL, N'admin', CAST(N'2019-08-28T16:42:11.7167620' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:11.7167671' AS DateTime2), N'GetUserRoleIdList', 66, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1352, NULL, N'admin', CAST(N'2019-08-28T16:42:11.8412381' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:11.8412432' AS DateTime2), N'GetRoleUserIdListAsync', 66, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1353, NULL, N'admin', CAST(N'2019-08-28T16:42:11.9747979' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:11.9748098' AS DateTime2), N'GetJsonValue', 66, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1354, NULL, N'admin', CAST(N'2019-08-28T16:42:12.1537607' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:12.1537659' AS DateTime2), N'Edit', 66, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1355, NULL, N'admin', CAST(N'2019-08-28T16:44:38.5397868' AS DateTime2), N'admin', CAST(N'2019-08-28T16:44:38.5399428' AS DateTime2), N'Index', 61, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1356, NULL, N'admin', CAST(N'2019-08-28T16:44:39.3622464' AS DateTime2), N'admin', CAST(N'2019-08-28T16:44:39.3622508' AS DateTime2), N'AddOrModifyAsync', 61, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1357, NULL, N'admin', CAST(N'2019-08-28T16:44:55.2149573' AS DateTime2), N'admin', CAST(N'2019-08-28T16:44:55.2149621' AS DateTime2), N'ChangeMenuState', 61, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1358, NULL, N'admin', CAST(N'2019-08-28T16:44:55.3635068' AS DateTime2), N'admin', CAST(N'2019-08-28T16:44:55.3635117' AS DateTime2), N'GetMenuListAsync', 61, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1359, NULL, N'admin', CAST(N'2019-08-28T16:44:55.5190500' AS DateTime2), N'admin', CAST(N'2019-08-28T16:44:55.5190548' AS DateTime2), N'DeleteRange', 61, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1360, NULL, N'admin', CAST(N'2019-09-05T09:54:34.3163599' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:34.3163756' AS DateTime2), N'LoadData', 67, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1361, NULL, N'admin', CAST(N'2019-09-05T09:54:34.4939260' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:34.4939309' AS DateTime2), N'Index', 67, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1362, NULL, N'admin', CAST(N'2019-09-05T09:54:34.6481502' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:34.6481547' AS DateTime2), N'AddOrModify', 67, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1363, NULL, N'admin', CAST(N'2019-09-05T09:54:34.8165253' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:34.8165314' AS DateTime2), N'AddOrModifyAsync', 67, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1364, NULL, N'admin', CAST(N'2019-09-05T09:54:34.9843756' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:34.9843800' AS DateTime2), N'DeleteRange', 67, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1365, NULL, N'admin', CAST(N'2019-09-05T09:54:35.2168487' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:35.2168529' AS DateTime2), N'GetJsonValue', 67, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1366, NULL, N'admin', CAST(N'2019-09-05T09:54:35.3813887' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:35.3813954' AS DateTime2), N'List', 67, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1367, NULL, N'admin', CAST(N'2019-09-05T09:54:35.5497842' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:35.5497889' AS DateTime2), N'Edit', 67, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1368, NULL, N'admin', CAST(N'2019-09-05T09:54:35.7307905' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:35.7307963' AS DateTime2), N'Empty', 67, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1369, NULL, N'admin', CAST(N'2019-09-05T09:54:36.0955907' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:36.0955984' AS DateTime2), N'LoadData', 68, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1370, NULL, N'admin', CAST(N'2019-09-05T09:54:36.2475113' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:36.2475181' AS DateTime2), N'IndexAsync', 68, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1371, NULL, N'admin', CAST(N'2019-09-05T09:54:36.3875125' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:36.3875169' AS DateTime2), N'AddOrModifyAsync', 68, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1372, NULL, N'admin', CAST(N'2019-09-05T09:54:36.5733148' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:36.5733192' AS DateTime2), N'DeleteRange', 68, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1373, NULL, N'admin', CAST(N'2019-09-05T09:54:36.7266319' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:36.7266371' AS DateTime2), N'GetJsonValue', 68, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1374, NULL, N'admin', CAST(N'2019-09-05T09:54:36.8785112' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:36.8785174' AS DateTime2), N'List', 68, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1375, NULL, N'admin', CAST(N'2019-09-05T09:54:37.0286567' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:37.0286613' AS DateTime2), N'Edit', 68, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1376, NULL, N'admin', CAST(N'2019-09-05T09:54:37.1742222' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:37.1742281' AS DateTime2), N'Empty', 68, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1377, NULL, N'admin', CAST(N'2019-09-05T09:54:37.5194743' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:37.5194815' AS DateTime2), N'LoadData', 69, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1378, NULL, N'admin', CAST(N'2019-09-05T09:54:37.6755296' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:37.6755343' AS DateTime2), N'Index', 69, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1379, NULL, N'admin', CAST(N'2019-09-05T09:54:37.8104775' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:37.8104823' AS DateTime2), N'AddOrModify', 69, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1380, NULL, N'admin', CAST(N'2019-09-05T09:54:37.9459110' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:37.9459156' AS DateTime2), N'AddOrModifyAsync', 69, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1381, NULL, N'admin', CAST(N'2019-09-05T09:54:38.1237389' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:38.1237434' AS DateTime2), N'DeleteRange', 69, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1382, NULL, N'admin', CAST(N'2019-09-05T09:54:38.2595677' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:38.2595720' AS DateTime2), N'GetJsonValue', 69, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1383, NULL, N'admin', CAST(N'2019-09-05T09:54:38.3974380' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:38.3974424' AS DateTime2), N'List', 69, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1384, NULL, N'admin', CAST(N'2019-09-05T09:54:38.5388397' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:38.5388437' AS DateTime2), N'Edit', 69, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1385, NULL, N'admin', CAST(N'2019-09-05T09:54:38.6756748' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:38.6756800' AS DateTime2), N'Empty', 69, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1386, NULL, N'admin', CAST(N'2019-09-05T09:54:38.9943775' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:38.9943816' AS DateTime2), N'LoadData', 70, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1387, NULL, N'admin', CAST(N'2019-09-05T09:54:39.1271929' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:39.1271994' AS DateTime2), N'Index', 70, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1388, NULL, N'admin', CAST(N'2019-09-05T09:54:39.2531400' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:39.2531454' AS DateTime2), N'AddOrModify', 70, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1389, NULL, N'admin', CAST(N'2019-09-05T09:54:39.3855094' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:39.3855142' AS DateTime2), N'AddOrModifyAsync', 70, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1390, NULL, N'admin', CAST(N'2019-09-05T09:54:39.5145380' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:39.5145422' AS DateTime2), N'DeleteRange', 70, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1391, NULL, N'admin', CAST(N'2019-09-05T09:54:39.6560330' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:39.6560377' AS DateTime2), N'GetJsonValue', 70, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1392, NULL, N'admin', CAST(N'2019-09-05T09:54:39.7880350' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:39.7880397' AS DateTime2), N'List', 70, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1393, NULL, N'admin', CAST(N'2019-09-05T09:54:39.9189368' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:39.9189410' AS DateTime2), N'Edit', 70, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1394, NULL, N'admin', CAST(N'2019-09-05T09:54:40.0716959' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:40.0717001' AS DateTime2), N'Empty', 70, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1395, NULL, N'admin', CAST(N'2019-09-05T09:54:40.6969298' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:40.6969339' AS DateTime2), N'LoadData', 71, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1396, NULL, N'admin', CAST(N'2019-09-05T09:54:40.8646972' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:40.8647027' AS DateTime2), N'Index', 71, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1397, NULL, N'admin', CAST(N'2019-09-05T09:54:41.1716224' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:41.1716281' AS DateTime2), N'AddOrModify', 71, N'IActionResult', 0)
GO
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1398, NULL, N'admin', CAST(N'2019-09-05T09:54:41.3079972' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:41.3080017' AS DateTime2), N'AddOrModifyAsync', 71, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1399, NULL, N'admin', CAST(N'2019-09-05T09:54:41.4519476' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:41.4519518' AS DateTime2), N'DeleteRange', 71, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1400, NULL, N'admin', CAST(N'2019-09-05T09:54:41.5849797' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:41.5849838' AS DateTime2), N'GetJsonValue', 71, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1401, NULL, N'admin', CAST(N'2019-09-05T09:54:41.7437802' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:41.7437864' AS DateTime2), N'List', 71, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1402, NULL, N'admin', CAST(N'2019-09-05T09:54:41.8892690' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:41.8892736' AS DateTime2), N'Edit', 71, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1403, NULL, N'admin', CAST(N'2019-09-05T09:54:42.0121868' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:42.0121919' AS DateTime2), N'Empty', 71, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1404, NULL, N'admin', CAST(N'2019-09-05T09:54:42.3751057' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:42.3751114' AS DateTime2), N'ChangeMenuState', 71, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1405, NULL, N'admin', CAST(N'2019-09-05T09:54:42.5095819' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:42.5095863' AS DateTime2), N'GetMenuListAsync', 71, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1406, NULL, N'admin', CAST(N'2019-09-05T09:54:43.1350876' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:43.1350919' AS DateTime2), N'Empty', 61, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1407, NULL, N'admin', CAST(N'2019-09-05T09:54:43.7380383' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:43.7380428' AS DateTime2), N'Empty', 62, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1408, NULL, N'admin', CAST(N'2019-09-05T09:54:44.3272526' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:44.3272581' AS DateTime2), N'Empty', 63, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1409, NULL, N'admin', CAST(N'2019-09-05T09:54:45.1616323' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:45.1616365' AS DateTime2), N'LoadData', 72, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1410, NULL, N'admin', CAST(N'2019-09-05T09:54:45.3002025' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:45.3002074' AS DateTime2), N'Index', 72, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1411, NULL, N'admin', CAST(N'2019-09-05T09:54:45.4465894' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:45.4465939' AS DateTime2), N'AddOrModify', 72, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1412, NULL, N'admin', CAST(N'2019-09-05T09:54:45.5636209' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:45.5636251' AS DateTime2), N'AddOrModifyAsync', 72, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1413, NULL, N'admin', CAST(N'2019-09-05T09:54:45.6865691' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:45.6865737' AS DateTime2), N'DeleteRange', 72, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1414, NULL, N'admin', CAST(N'2019-09-05T09:54:45.8046836' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:45.8046884' AS DateTime2), N'TableInfo', 72, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1415, NULL, N'admin', CAST(N'2019-09-05T09:54:45.9314796' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:45.9314838' AS DateTime2), N'GetJsonValue', 72, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1416, NULL, N'admin', CAST(N'2019-09-05T09:54:46.0541418' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:46.0541460' AS DateTime2), N'List', 72, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1417, NULL, N'admin', CAST(N'2019-09-05T09:54:46.1815082' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:46.1815126' AS DateTime2), N'Edit', 72, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1418, NULL, N'admin', CAST(N'2019-09-05T09:54:46.3036409' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:46.3036454' AS DateTime2), N'Empty', 72, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1419, NULL, N'admin', CAST(N'2019-09-05T09:54:46.6595862' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:46.6595906' AS DateTime2), N'Empty', 64, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1420, NULL, N'admin', CAST(N'2019-09-05T09:54:47.4061054' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:47.4061105' AS DateTime2), N'Empty', 65, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1421, NULL, N'admin', CAST(N'2019-09-05T09:54:47.8776469' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:47.8776519' AS DateTime2), N'Empty', 66, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1422, NULL, N'admin', CAST(N'2019-09-06T00:00:00.0000000' AS DateTime2), N'admin', CAST(N'2019-09-06T00:00:00.0000000' AS DateTime2), N'ReflectionController', 74, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1423, NULL, N'admin', CAST(N'2019-09-06T17:15:49.3267009' AS DateTime2), N'admin', CAST(N'2019-09-06T17:15:49.3267214' AS DateTime2), N'Empty', 60, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1434, NULL, N'admin', CAST(N'2019-09-06T17:20:45.3399144' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:45.3400627' AS DateTime2), N'LoadData', 74, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1435, NULL, N'admin', CAST(N'2019-09-06T17:20:45.7044868' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:45.7044913' AS DateTime2), N'Index', 74, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1436, NULL, N'admin', CAST(N'2019-09-06T17:20:45.8549108' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:45.8549165' AS DateTime2), N'AddOrModify', 74, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1437, NULL, N'admin', CAST(N'2019-09-06T17:20:45.9905804' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:45.9905860' AS DateTime2), N'AddOrModifyAsync', 74, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1438, NULL, N'admin', CAST(N'2019-09-06T17:20:46.2083833' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:46.2083898' AS DateTime2), N'DeleteRange', 74, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1439, NULL, N'admin', CAST(N'2019-09-06T17:20:46.3492132' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:46.3492438' AS DateTime2), N'GetJsonValue', 74, N'String', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1440, NULL, N'admin', CAST(N'2019-09-06T17:20:46.4941171' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:46.4941234' AS DateTime2), N'List', 74, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1441, NULL, N'admin', CAST(N'2019-09-06T17:20:46.6313561' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:46.6313624' AS DateTime2), N'Edit', 74, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1442, NULL, N'admin', CAST(N'2019-09-06T17:20:46.7769384' AS DateTime2), N'admin', CAST(N'2019-09-06T17:20:46.7769443' AS DateTime2), N'Empty', 74, N'IActionResult', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1443, NULL, N'admin', CAST(N'2019-09-06T17:25:54.2825562' AS DateTime2), N'admin', CAST(N'2019-09-06T17:25:54.2825658' AS DateTime2), N'AddOrModify', 60, N'Task`1', 0)
INSERT [dbo].[SystemAction] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SactionName], [IcontrollerId], [SresultType], [Bvalid]) VALUES (1444, NULL, N'admin', CAST(N'2019-09-06T17:25:54.4216343' AS DateTime2), N'admin', CAST(N'2019-09-06T17:25:54.4216536' AS DateTime2), N'AddOrModifyAsync', 60, N'Task`1', 0)
SET IDENTITY_INSERT [dbo].[SystemAction] OFF
SET IDENTITY_INSERT [dbo].[SystemController] ON 

INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (58, NULL, N'admin', CAST(N'2019-08-28T16:42:02.4839014' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:02.4839119' AS DateTime2), N'Account')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (59, NULL, N'admin', CAST(N'2019-08-28T16:42:03.4392248' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:03.4392326' AS DateTime2), N'Home')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (60, NULL, N'admin', CAST(N'2019-08-28T16:42:04.3007227' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:04.3007290' AS DateTime2), N'Menu')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (61, NULL, N'admin', CAST(N'2019-08-28T16:42:05.6087862' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:05.6087911' AS DateTime2), N'RoleMenu')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (62, NULL, N'admin', CAST(N'2019-08-28T16:42:06.5422416' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:06.5422464' AS DateTime2), N'Roles')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (63, NULL, N'admin', CAST(N'2019-08-28T16:42:07.7919835' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:07.7919897' AS DateTime2), N'SystemAction')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (64, NULL, N'admin', CAST(N'2019-08-28T16:42:09.3372515' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:09.3372567' AS DateTime2), N'UploadFileInfo')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (65, NULL, N'admin', CAST(N'2019-08-28T16:42:09.9952802' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:09.9952857' AS DateTime2), N'UserInfo')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (66, NULL, N'admin', CAST(N'2019-08-28T16:42:11.4523708' AS DateTime2), N'admin', CAST(N'2019-08-28T16:42:11.4523755' AS DateTime2), N'UserRole')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (67, NULL, N'admin', CAST(N'2019-09-05T09:54:33.8457799' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:33.8460686' AS DateTime2), N'DataBase')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (68, NULL, N'admin', CAST(N'2019-09-05T09:54:35.9235811' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:35.9235864' AS DateTime2), N'DataTable')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (69, NULL, N'admin', CAST(N'2019-09-05T09:54:37.3562329' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:37.3562375' AS DateTime2), N'DataType')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (70, NULL, N'admin', CAST(N'2019-09-05T09:54:38.8424103' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:38.8424146' AS DateTime2), N'FieldRelation')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (71, NULL, N'admin', CAST(N'2019-09-05T09:54:40.5510933' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:40.5510978' AS DateTime2), N'MenuAction')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (72, NULL, N'admin', CAST(N'2019-09-05T09:54:45.0314636' AS DateTime2), N'admin', CAST(N'2019-09-05T09:54:45.0314681' AS DateTime2), N'TableFiled')
INSERT [dbo].[SystemController] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [ScontrollerName]) VALUES (74, NULL, N'admin', CAST(N'2019-09-06T00:00:00.0000000' AS DateTime2), N'admin', CAST(N'2019-09-06T00:00:00.0000000' AS DateTime2), N'SystemController')
SET IDENTITY_INSERT [dbo].[SystemController] OFF
SET IDENTITY_INSERT [dbo].[TableFiled] ON 

INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (23, NULL, N'admin', CAST(N'2019-09-04T14:28:29.1877000' AS DateTime2), N'admin', CAST(N'2019-09-04T14:28:29.1879446' AS DateTime2), N'Id', 8, 2, 0, 0, N'主键ID')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (24, NULL, N'admin', CAST(N'2019-09-04T14:28:29.3449999' AS DateTime2), N'admin', CAST(N'2019-09-04T14:28:29.3450051' AS DateTime2), N'Sremarks', 8, 5, 1, 200, N'备注')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (25, NULL, N'admin', CAST(N'2019-09-04T14:28:29.5205688' AS DateTime2), N'admin', CAST(N'2019-09-04T14:28:29.5205735' AS DateTime2), N'Screater', 8, 5, 0, 50, N'创建人')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (26, NULL, N'admin', CAST(N'2019-09-04T14:28:29.6165296' AS DateTime2), N'admin', CAST(N'2019-09-04T14:28:29.6165389' AS DateTime2), N'TcreateTime', 8, 6, 1, 0, N'创建时间')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (27, NULL, N'admin', CAST(N'2019-09-04T14:28:29.7100206' AS DateTime2), N'admin', CAST(N'2019-09-04T14:28:29.7100315' AS DateTime2), N'Smodifier', 8, 5, 0, 50, N'修改人')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (28, NULL, N'admin', CAST(N'2019-09-04T14:28:29.7993512' AS DateTime2), N'admin', CAST(N'2019-09-04T14:28:29.7993562' AS DateTime2), N'TmodifyTime', 8, 6, 1, 0, N'修改时间')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (29, NULL, N'admin', CAST(N'2019-09-04T14:42:20.6748181' AS DateTime2), N'admin', CAST(N'2019-09-04T14:42:20.6748352' AS DateTime2), N'ImenuId', 8, 2, 0, 0, N'菜单ID')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (30, NULL, N'admin', CAST(N'2019-09-04T14:43:29.7819678' AS DateTime2), N'admin', CAST(N'2019-09-04T14:43:29.7819727' AS DateTime2), N'IactionId', 8, 2, 0, 0, N'Action方法Id')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (31, NULL, N'admin', CAST(N'2019-09-04T15:05:51.5514579' AS DateTime2), N'admin', CAST(N'2019-09-04T15:05:51.5514662' AS DateTime2), N'Sexplain', 8, 5, 1, 100, N'说明')
INSERT [dbo].[TableFiled] ([Id], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SfiledName], [IdataTableId], [IdataTypeId], [BisEmpty], [ImaxLength], [Sexplain]) VALUES (32, NULL, N'admin', CAST(N'2019-09-04T16:12:14.8778488' AS DateTime2), N'admin', CAST(N'2019-09-06T12:12:32.9080017' AS DateTime2), N'BisValid', 8, 1, 0, 0, N'是否有效')
SET IDENTITY_INSERT [dbo].[TableFiled] OFF
SET IDENTITY_INSERT [dbo].[UploadFileInfo] ON 

INSERT [dbo].[UploadFileInfo] ([Id], [Uid], [SoriginalFileName], [SfileName], [SfileType], [SfilePath], [SrelativePath], [Isize], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (29, N'35fdb4ea-5c45-4565-a994-0ff3b0b8558c', N'DefaultUserHeadImage.jpg', N'ab2334cf4d254770901eca1c960fc292.jpg', N'.jpg', N'E:\works_lq\DotnetCoreTest\MessageManagement\Message.UI\wwwroot\uploads\20190731\ab2334cf4d254770901eca1c960fc292.jpg', N'/uploads/20190731/ab2334cf4d254770901eca1c960fc292.jpg', 14647, NULL, N'admin', CAST(N'2019-07-31T10:26:32.0032382' AS DateTime2), N'admin', CAST(N'2019-07-31T10:26:32.0034879' AS DateTime2))
INSERT [dbo].[UploadFileInfo] ([Id], [Uid], [SoriginalFileName], [SfileName], [SfileType], [SfilePath], [SrelativePath], [Isize], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (30, N'61be6cb9-26ea-4ce1-beb8-20e8cb2e313f', N'DefaultUserHeadImage.jpg', N'cf927527bebf448098a5d0430ea70c23.jpg', N'.jpg', N'E:\works_lq\DotnetCoreTest\MessageManagement\Message.UI\wwwroot\uploads\20190731\cf927527bebf448098a5d0430ea70c23.jpg', N'/uploads/20190731/cf927527bebf448098a5d0430ea70c23.jpg', 14647, NULL, N'admin', CAST(N'2019-07-31T10:53:56.2527851' AS DateTime2), N'admin', CAST(N'2019-07-31T10:53:56.2529955' AS DateTime2))
INSERT [dbo].[UploadFileInfo] ([Id], [Uid], [SoriginalFileName], [SfileName], [SfileType], [SfilePath], [SrelativePath], [Isize], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (31, N'77eb459f-fa5e-42e5-9c09-99858b4b332a', N'login_tx.jpg', N'f9b4817a0b98407c8e4dcf8f221f0478.jpg', N'.jpg', N'E:\works_lq\DotnetCoreTest\MessageManagement\Message.UI\wwwroot\uploads\20190731\f9b4817a0b98407c8e4dcf8f221f0478.jpg', N'/uploads/20190731/f9b4817a0b98407c8e4dcf8f221f0478.jpg', 12072, NULL, N'admin', CAST(N'2019-07-31T10:54:19.4427116' AS DateTime2), N'admin', CAST(N'2019-07-31T10:54:19.4427215' AS DateTime2))
INSERT [dbo].[UploadFileInfo] ([Id], [Uid], [SoriginalFileName], [SfileName], [SfileType], [SfilePath], [SrelativePath], [Isize], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (32, N'bc3333e3-220f-4124-b1f5-7783aea76709', N'login_tx.jpg', N'b8dd49cfa9db4b41a24b9cfccc0d4870.jpg', N'.jpg', N'E:\works_lq\DotnetCoreTest\MessageManagement\MessageManagement\Message.UI\wwwroot\uploads\20190828\b8dd49cfa9db4b41a24b9cfccc0d4870.jpg', N'/uploads/20190828/b8dd49cfa9db4b41a24b9cfccc0d4870.jpg', 12072, NULL, N'admin', CAST(N'2019-08-28T10:15:13.6685405' AS DateTime2), N'admin', CAST(N'2019-08-28T10:15:13.6688729' AS DateTime2))
INSERT [dbo].[UploadFileInfo] ([Id], [Uid], [SoriginalFileName], [SfileName], [SfileType], [SfilePath], [SrelativePath], [Isize], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (33, N'572d22e5-6f9f-43ba-901a-a2f6f97411bc', N'150102198105062046_1.jpeg', N'cc412d3a730b491e837861b38e73fc93.jpeg', N'.jpeg', N'E:\works_lq\DotnetCoreTest\MessageManagement\MessageManagement\Message.UI\wwwroot\uploads\20190909\cc412d3a730b491e837861b38e73fc93.jpeg', N'/uploads/20190909/cc412d3a730b491e837861b38e73fc93.jpeg', 46541, NULL, N'admin', CAST(N'2019-09-09T10:54:23.5317334' AS DateTime2), N'admin', CAST(N'2019-09-09T10:54:23.5319069' AS DateTime2))
SET IDENTITY_INSERT [dbo].[UploadFileInfo] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (4, N'admin', N'F7-6C-E2-45-0B-A8-59-8C-E9-C2-8D-C8-78-29-91-70', N'Admin', N'12345678912', N'123@qq.com', 0, NULL, N'admin', CAST(N'2019-07-19T17:39:14.110' AS DateTime), N'admin', CAST(N'2019-09-09T13:56:46.107' AS DateTime), N'::1', CAST(N'2019-09-09T13:56:45.9704542' AS DateTime2), 31)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (5, N'admin123', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'Admin123', N'12312312312', N'admin@qq.com', 0, NULL, N'admin', CAST(N'2019-07-26T10:08:00.933' AS DateTime), N'admin', CAST(N'2019-08-06T12:47:05.950' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (7, N'test2', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'test2', N'12312312312', N'admin@qq.com', 0, NULL, N'admin', CAST(N'2019-07-31T16:31:23.980' AS DateTime), N'admin', CAST(N'2019-08-06T13:39:32.913' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (10, N'test3', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'test3', N'12312312312', N'admin@qq.com', 0, NULL, N'admin', CAST(N'2019-08-07T10:25:04.287' AS DateTime), N'admin', CAST(N'2019-08-07T10:25:04.287' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (11, N'test4', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'test4', N'12312312312', N'admin@qq.com', 0, NULL, N'admin', CAST(N'2019-08-07T10:27:38.290' AS DateTime), N'admin', CAST(N'2019-08-07T10:27:38.290' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (12, N'test5', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'test5', N'12312312312', N'admin@qq.com', 0, NULL, N'admin', CAST(N'2019-08-07T10:28:05.573' AS DateTime), N'admin', CAST(N'2019-08-07T10:28:05.573' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (13, N'test6', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'test6', N'12312312312', N'admin@qq.com', 0, NULL, N'admin', CAST(N'2019-08-07T10:29:43.623' AS DateTime), N'admin', CAST(N'2019-08-07T10:29:43.623' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (14, N'test7', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'test7', N'12312312312', N'admin@qq.com', 0, NULL, N'admin', CAST(N'2019-08-07T10:30:01.820' AS DateTime), N'admin', CAST(N'2019-08-07T10:30:01.820' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (15, N'test8', N'888888', N'test8', N'12312312312', N'admin@qq.com', 0, NULL, N'admin', CAST(N'2019-08-07T10:33:31.530' AS DateTime), N'admin', CAST(N'2019-08-07T10:33:49.480' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (16, N'admintest', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'123123', N'12312312312', N'123123123@qq.com', 0, NULL, N'admin', CAST(N'2019-08-19T16:08:34.123' AS DateTime), N'admintest', CAST(N'2019-08-19T16:09:08.950' AS DateTime), N'::1', CAST(N'2019-08-19T16:09:08.8892348' AS DateTime2), 0)
INSERT [dbo].[UserInfo] ([Id], [SloginName], [SloginPwd], [SuserName], [SuserPhone], [SuserEmail], [BisLock], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime], [SloginLastIp], [TloginLastTime], [IfileInfoId]) VALUES (17, N'admin111114', N'D6-C3-2F-77-A8-E2-BC-BE-6C-DA-92-14-7D-CB-49-B5', N'Admin', N'12312312313', N'123@qq.com', 0, NULL, N'admin', CAST(N'2019-08-28T10:36:43.610' AS DateTime), N'admin', CAST(N'2019-08-28T13:10:32.637' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [IuserId], [IroleId], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (5, 5, 4, NULL, N'admin', CAST(N'2019-07-26T10:08:01.3480389' AS DateTime2), N'admin', CAST(N'2019-07-26T10:08:01.3482368' AS DateTime2))
INSERT [dbo].[UserRole] ([Id], [IuserId], [IroleId], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (9, 7, 6, NULL, N'admin', CAST(N'2019-08-06T16:05:38.1595299' AS DateTime2), N'admin', CAST(N'2019-08-06T16:05:38.1597743' AS DateTime2))
INSERT [dbo].[UserRole] ([Id], [IuserId], [IroleId], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (10, 5, 6, NULL, N'admin', CAST(N'2019-08-06T16:05:40.1600395' AS DateTime2), N'admin', CAST(N'2019-08-06T16:05:40.1600504' AS DateTime2))
INSERT [dbo].[UserRole] ([Id], [IuserId], [IroleId], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (14, 15, 3, NULL, N'admin', CAST(N'2019-08-07T10:34:10.5830503' AS DateTime2), N'admin', CAST(N'2019-08-07T10:34:10.5830599' AS DateTime2))
INSERT [dbo].[UserRole] ([Id], [IuserId], [IroleId], [Sremarks], [Screater], [TcreateTime], [Smodifier], [TmodifyTime]) VALUES (20, 4, 1, NULL, N'admin', CAST(N'2019-08-19T15:59:44.2616465' AS DateTime2), N'admin', CAST(N'2019-08-19T15:59:44.2618580' AS DateTime2))
SET IDENTITY_INSERT [dbo].[UserRole] OFF
/****** Object:  Index [IX_DataTable_IdataBaseId]    Script Date: 2019/9/9 14:01:05 ******/
CREATE NONCLUSTERED INDEX [IX_DataTable_IdataBaseId] ON [dbo].[DataTable]
(
	[IdataBaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FieldRelation_IforeignkeyId_IprimarykeyId]    Script Date: 2019/9/9 14:01:05 ******/
CREATE NONCLUSTERED INDEX [IX_FieldRelation_IforeignkeyId_IprimarykeyId] ON [dbo].[FieldRelation]
(
	[IforeignkeyId] ASC,
	[IprimarykeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_MENU]    Script Date: 2019/9/9 14:01:05 ******/
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [PK_MENU] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuAction_ImenuId_IactionId]    Script Date: 2019/9/9 14:01:05 ******/
CREATE NONCLUSTERED INDEX [IX_MenuAction_ImenuId_IactionId] ON [dbo].[MenuAction]
(
	[ImenuId] ASC,
	[IactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleMenu_IroleId_ImenuId]    Script Date: 2019/9/9 14:01:05 ******/
CREATE NONCLUSTERED INDEX [IX_RoleMenu_IroleId_ImenuId] ON [dbo].[RoleMenu]
(
	[IroleId] ASC,
	[ImenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SystemAction_IcontrollerId]    Script Date: 2019/9/9 14:01:05 ******/
CREATE NONCLUSTERED INDEX [IX_SystemAction_IcontrollerId] ON [dbo].[SystemAction]
(
	[IcontrollerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TableFiled_IdataTableId_IdataTypeId]    Script Date: 2019/9/9 14:01:05 ******/
CREATE NONCLUSTERED INDEX [IX_TableFiled_IdataTableId_IdataTypeId] ON [dbo].[TableFiled]
(
	[IdataTableId] ASC,
	[IdataTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UploadFileInfo_Uid]    Script Date: 2019/9/9 14:01:05 ******/
CREATE NONCLUSTERED INDEX [IX_UploadFileInfo_Uid] ON [dbo].[UploadFileInfo]
(
	[Uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRole_IroleId_IuserId]    Script Date: 2019/9/9 14:01:05 ******/
CREATE NONCLUSTERED INDEX [IX_UserRole_IroleId_IuserId] ON [dbo].[UserRole]
(
	[IroleId] ASC,
	[IuserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DataBase] ADD  DEFAULT (getdate()) FOR [TcreateTime]
GO
ALTER TABLE [dbo].[DataTable] ADD  CONSTRAINT [DF_DataTables_TcreateTime]  DEFAULT (getdate()) FOR [TcreateTime]
GO
ALTER TABLE [dbo].[Menu] ADD  DEFAULT (getdate()) FOR [TcreateTime]
GO
ALTER TABLE [dbo].[RoleMenu] ADD  DEFAULT (getdate()) FOR [TcreateTime]
GO
ALTER TABLE [dbo].[SystemAction] ADD  DEFAULT ((0)) FOR [Bvalid]
GO
ALTER TABLE [dbo].[TableFiled] ADD  DEFAULT ((0)) FOR [BisEmpty]
GO
ALTER TABLE [dbo].[TableFiled] ADD  DEFAULT ((0)) FOR [ImaxLength]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF__UserInfo__Tcreat__5BE2A6F2]  DEFAULT (getdate()) FOR [TcreateTime]
GO
ALTER TABLE [dbo].[UserInfo] ADD  DEFAULT ((0)) FOR [IfileInfoId]
GO
USE [master]
GO
ALTER DATABASE [MessageManagement] SET  READ_WRITE 
GO
