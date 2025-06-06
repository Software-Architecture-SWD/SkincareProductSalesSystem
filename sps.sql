USE [master]
GO
/****** Object:  Database [sps13686_SPSS]    Script Date: 3/29/2025 4:58:39 PM ******/
CREATE DATABASE [sps13686_SPSS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sps13686_SPSS', FILENAME = N'C:\Program Files (x86)\Plesk\Databases\MSSQL\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\sps13686_SPSS.mdf' , SIZE = 73728KB , MAXSIZE = 1048576KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sps13686_SPSS_log', FILENAME = N'C:\Program Files (x86)\Plesk\Databases\MSSQL\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\sps13686_SPSS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [sps13686_SPSS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sps13686_SPSS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sps13686_SPSS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET ARITHABORT OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [sps13686_SPSS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sps13686_SPSS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sps13686_SPSS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [sps13686_SPSS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sps13686_SPSS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sps13686_SPSS] SET  MULTI_USER 
GO
ALTER DATABASE [sps13686_SPSS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sps13686_SPSS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sps13686_SPSS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sps13686_SPSS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sps13686_SPSS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sps13686_SPSS] SET QUERY_STORE = OFF
GO
USE [sps13686_SPSS]
GO
/****** Object:  User [sps13686_swd392]    Script Date: 3/29/2025 4:58:39 PM ******/
CREATE USER [sps13686_swd392] FOR LOGIN [sps13686_swd392] WITH DEFAULT_SCHEMA=[sps13686_swd392]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [sps13686_swd392]
GO
ALTER ROLE [db_datareader] ADD MEMBER [sps13686_swd392]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [sps13686_swd392]
GO
/****** Object:  Schema [sps13686_swd392]    Script Date: 3/29/2025 4:58:39 PM ******/
CREATE SCHEMA [sps13686_swd392]
GO
/****** Object:  Table [sps13686_swd392].[__EFMigrationsHistory]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Addresses]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [nvarchar](155) NOT NULL,
	[AddressLine2] [nvarchar](155) NULL,
	[CityId] [int] NOT NULL,
	[AddressTypeId] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AddressTypes]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AddressTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](25) NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_AddressTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AnswerDetails]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AnswerDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnswerSheetId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL,
 CONSTRAINT [PK_AnswerDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Answers]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerText] [nvarchar](155) NOT NULL,
	[Point] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AnswerSheets]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AnswerSheets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[TotalPoint] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_AnswerSheets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AspNetRoleClaims]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AspNetRoles]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AspNetUserClaims]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AspNetUserLogins]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AspNetUserRoles]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AspNetUsers]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime2](7) NULL,
	[isDelete] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[AspNetUserTokens]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[BlogCategories]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[BlogCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlogType] [nvarchar](max) NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_BlogCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[BlogContents]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[BlogContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Content] [nvarchar](600) NOT NULL,
	[Img] [nvarchar](max) NOT NULL,
	[BlogId] [int] NOT NULL,
 CONSTRAINT [PK_BlogContents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Blogs]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[BlogCategoryId] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Status] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[BookingInfos]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[BookingInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [nvarchar](450) NOT NULL,
	[ExpertId] [nvarchar](450) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
	[Start_time] [datetime2](7) NOT NULL,
	[End_time] [datetime2](7) NOT NULL,
	[Special_requests] [nvarchar](500) NULL,
	[Status] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_BookingInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Brands]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Capicities]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Capicities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Size] [int] NOT NULL,
	[Unit] [nvarchar](max) NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Capicities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[CartItems]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[CartItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Carts]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[ItemsCount] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Categories]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Cities]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Conversations]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Conversations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId1] [nvarchar](450) NOT NULL,
	[UserId2] [nvarchar](450) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Conversations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Feedbacks]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Feedbacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[Comment] [nvarchar](250) NOT NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Feedbacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Messages]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [nvarchar](450) NOT NULL,
	[ConversationId] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[MessageStatuses]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[MessageStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[IsRead] [bit] NOT NULL,
	[ReadAt] [datetime2](7) NULL,
 CONSTRAINT [PK_MessageStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[OrderItems]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Orders]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PromotionId] [int] NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[Status] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[ItemsCount] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[PaymentDate] [datetime2](7) NULL,
	[CompletedDate] [datetime2](7) NULL,
	[CanceledDate] [datetime2](7) NULL,
	[OriginalTotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Payments]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[PaymentStatus] [int] NOT NULL,
	[TransactionId] [nvarchar](max) NULL,
	[PaymentDate] [datetime2](7) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[ProductCapicities]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[ProductCapicities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CapicityId] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
 CONSTRAINT [PK_ProductCapicities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Products]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PromotionId] [int] NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Ingredients] [nvarchar](max) NULL,
	[UsageInstructions] [nvarchar](max) NULL,
	[Benefits] [nvarchar](max) NULL,
	[isDelete] [bit] NOT NULL,
	[OriginalPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[ProductSkinTypes]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[ProductSkinTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[SkinTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ProductSkinTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Promotions]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Promotions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DiscountValue] [decimal](18, 2) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[UsageLimit] [int] NULL,
	[Status] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Question]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionDESC] [nvarchar](155) NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Results]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Results](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinPoint] [int] NOT NULL,
	[MaxPoint] [int] NOT NULL,
	[SkinTypeId] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[Routines]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[Routines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Duration] [int] NOT NULL,
	[Frequency] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
	[SkinTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Routines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[RoutinesProductLists]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[RoutinesProductLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoutinesId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_RoutinesProductLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[SkinTypes]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[SkinTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_SkinTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sps13686_swd392].[UserAddresses]    Script Date: 3/29/2025 4:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sps13686_swd392].[UserAddresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_UserAddresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250317143207_addIntitial', N'9.0.1')
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250317143244_addTrigger', N'9.0.1')
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250318011840_addTrigger2', N'9.0.1')
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250318140733_UpdateConversation', N'9.0.1')
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250318161605_AdjustOrderAndProductPrice', N'9.0.1')
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250319013257_AddTriggers', N'9.0.1')
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250319071949_UpdateAuth', N'9.0.1')
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250320142339_UpdateBlogStructure', N'9.0.1')
INSERT [sps13686_swd392].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250325112206_UpdateMaxLengh', N'9.0.1')
GO
SET IDENTITY_INSERT [sps13686_swd392].[Addresses] ON 

INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (11, N'123 Trần Hưng Đạo', N'Tầng 1', 64, 1, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (12, N'45 Lý Thường Kiệt', N'Tòa nhà B', 65, 1, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (13, N'789 Lê Lợi', NULL, 66, 2, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (14, N'10 Nguyễn Huệ', N'Lầu 2', 67, 1, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (15, N'56 Hai Bà Trưng', NULL, 68, 3, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (16, N'88 Pasteur', N'Căn hộ A12', 69, 1, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (17, N'23 Phạm Ngũ Lão', NULL, 70, 2, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (18, N'15 Nguyễn Thị Minh Khai', N'Khu B', 71, 1, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (19, N'202 Trường Chinh', NULL, 72, 3, 0)
INSERT [sps13686_swd392].[Addresses] ([Id], [AddressLine1], [AddressLine2], [CityId], [AddressTypeId], [isDelete]) VALUES (20, N'89 Nguyễn Văn Cừ', N'Block C', 73, 1, 0)
SET IDENTITY_INSERT [sps13686_swd392].[Addresses] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[AddressTypes] ON 

INSERT [sps13686_swd392].[AddressTypes] ([Id], [TypeName], [isDelete]) VALUES (1, N'Home', 0)
INSERT [sps13686_swd392].[AddressTypes] ([Id], [TypeName], [isDelete]) VALUES (2, N'Office', 0)
INSERT [sps13686_swd392].[AddressTypes] ([Id], [TypeName], [isDelete]) VALUES (3, N'Work', 0)
INSERT [sps13686_swd392].[AddressTypes] ([Id], [TypeName], [isDelete]) VALUES (4, N'Primary', 0)
INSERT [sps13686_swd392].[AddressTypes] ([Id], [TypeName], [isDelete]) VALUES (5, N'Secondary', 0)
INSERT [sps13686_swd392].[AddressTypes] ([Id], [TypeName], [isDelete]) VALUES (6, N'Store', 0)
SET IDENTITY_INSERT [sps13686_swd392].[AddressTypes] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[AnswerDetails] ON 

INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (2, 1, 1)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (3, 1, 6)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (4, 1, 11)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (5, 1, 13)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (6, 1, 18)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (7, 1, 22)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (8, 1, 25)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (9, 1, 29)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (10, 1, 33)
INSERT [sps13686_swd392].[AnswerDetails] ([Id], [AnswerSheetId], [AnswerId]) VALUES (11, 1, 38)
SET IDENTITY_INSERT [sps13686_swd392].[AnswerDetails] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Answers] ON 

INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (1, 2, N'a) Tight, rough', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (2, 2, N'b) Soft, comfortable', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (3, 2, N'c) Oily all over', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (4, 2, N'd) Oily in T-zone, dry on cheeks', 1, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (5, 3, N'a) Shiny all over', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (6, 3, N'b) Shiny only in T-zone', 1, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (7, 3, N'c) Dry, slightly flaky', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (8, 3, N'd) Smooth, no shine', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (9, 4, N'a) Large and noticeable, especially on nose/cheeks', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (10, 4, N'b) Large only in T-zone', 1, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (11, 4, N'c) Small, barely visible', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (12, 4, N'd) Dry, almost invisible pores', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (13, 5, N'a) Frequently, in multiple areas', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (14, 5, N'b) Occasionally in T-zone', 1, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (15, 5, N'c) Rarely', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (16, 5, N'd) No acne but dry/flaky skin', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (17, 6, N'a) Redness, itching, irritation', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (18, 6, N'b) Slight stinging', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (19, 6, N'c) No reaction', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (20, 6, N'd) Feels tighter/drier', 1, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (21, 7, N'a) Still dry', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (22, 7, N'b) Soft and balanced', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (23, 7, N'c) Greasy', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (24, 7, N'd) Oily in T-zone', 1, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (25, 8, N'a) Get oily all over', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (26, 8, N'b) Get oily in T-zone', 1, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (27, 8, N'c) Feel drier', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (28, 8, N'd) Stay normal', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (29, 9, N'a) Often', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (30, 9, N'b) Sometimes', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (31, 9, N'c) Rarely', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (32, 10, N'a) Looks shiny', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (33, 10, N'b) Feels tight/dry', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (34, 10, N'c) Feels soft', 0, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (35, 10, N'd) Gets oily in T-zone', 1, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (36, 11, N'a) Frequently', 3, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (37, 11, N'b) Only after cleansing', 2, 0)
INSERT [sps13686_swd392].[Answers] ([Id], [QuestionId], [AnswerText], [Point], [isDelete]) VALUES (38, 11, N'c) Rarely', 0, 0)
SET IDENTITY_INSERT [sps13686_swd392].[Answers] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[AnswerSheets] ON 

INSERT [sps13686_swd392].[AnswerSheets] ([Id], [UserId], [CreatedAt], [TotalPoint], [isDelete]) VALUES (1, N'1b1ccb14-84d0-4a5e-9f1a-5a4b24e883bf', CAST(N'2025-03-26T03:51:53.9853391' AS DateTime2), 16, 0)
INSERT [sps13686_swd392].[AnswerSheets] ([Id], [UserId], [CreatedAt], [TotalPoint], [isDelete]) VALUES (2, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', CAST(N'2025-03-26T05:33:38.9312843' AS DateTime2), 0, 0)
INSERT [sps13686_swd392].[AnswerSheets] ([Id], [UserId], [CreatedAt], [TotalPoint], [isDelete]) VALUES (3, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', CAST(N'2025-03-26T06:08:05.7066396' AS DateTime2), 0, 0)
SET IDENTITY_INSERT [sps13686_swd392].[AnswerSheets] OFF
GO
INSERT [sps13686_swd392].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'31d641a3-e83f-4c09-8ee6-90f025ff892c', N'Admin', N'ADMIN', NULL)
INSERT [sps13686_swd392].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5eef4cec-7084-44b1-88d3-a99402627e50', N'Customer', N'CUSTOMER', NULL)
INSERT [sps13686_swd392].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd90c1272-5df4-45e1-83de-672033dbf072', N'Staff', N'STAFF', NULL)
INSERT [sps13686_swd392].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f622b980-25d2-4669-9e8e-6ec769f3fe7d', N'Expert', N'EXPERT', NULL)
GO
INSERT [sps13686_swd392].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6c8ef9c4-b875-4ccd-8607-e3f4437c7656', N'31d641a3-e83f-4c09-8ee6-90f025ff892c')
INSERT [sps13686_swd392].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5c6f8fef-3b81-4a3e-82b4-e4a75b66c7ec', N'5eef4cec-7084-44b1-88d3-a99402627e50')
INSERT [sps13686_swd392].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'71246fdb-655a-42bf-b027-178548435a63', N'5eef4cec-7084-44b1-88d3-a99402627e50')
INSERT [sps13686_swd392].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd43b2388-1e79-480e-82b4-93bd3e006582', N'5eef4cec-7084-44b1-88d3-a99402627e50')
INSERT [sps13686_swd392].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d560642-564f-4459-b7a5-a35f9a15a16c', N'f622b980-25d2-4669-9e8e-6ec769f3fe7d')
INSERT [sps13686_swd392].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6f77da32-68ac-4bda-a030-88b298a3873c', N'f622b980-25d2-4669-9e8e-6ec769f3fe7d')
GO
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'1b1ccb14-84d0-4a5e-9f1a-5a4b24e883bf', N'3VgnI72MS8RqGdh7ZfrQwQX6kTizqKi1J/q2hNXCq/I=', CAST(N'2025-03-24T15:00:56.2664433' AS DateTime2), 0, N'dr4ce', N'DR4CE', N'tienmanhfake@gmail.com', N'TIENMANHFAKE@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEDR5J3bQqbM5vlW4TxHGYJnm/YvAQP1mM1TF7DveMeUE6HE8VNRjEmsNpwc95Jd6UQ==', N'FO5INMLR2ANHVEDEU6LYN34JQ76P47AY', N'db0cc159-5b06-41f4-9667-a625af37bdd2', NULL, 0, 0, NULL, 1, 0, N'')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'2d560642-564f-4459-b7a5-a35f9a15a16c', N'JIiDahMQiDhUMAv5MH1ufsOFR3qOBbmWIIoK/CFkVcA=', CAST(N'2025-04-02T03:29:14.7132811' AS DateTime2), 0, N'expert2', N'EXPERT2', N'braykul2605@gmail.com', N'BRAYKUL2605@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEPbXNe3iclR67TLymUA0S2EalalwnRysGw5RPzlOPG13aUvjZhwFj7lfljB1wyVp0A==', N'24EPQAW5JWAVO4D4A4Q76MRJZ5QPWQ4P', N'4a2e8f3a-7610-429c-883f-51dfe0c0a85e', NULL, 0, 0, NULL, 1, 0, N'')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'35c60c9a-c4d5-417b-8115-c0b14c60ea41', N'uj0Qm2mxsHdAQeMMNI8z6xzRyv/PjnA6cFdT7Upzjl0=', CAST(N'2025-04-02T06:29:54.0767397' AS DateTime2), 0, N'manh123', N'MANH123', N'ethan.tmanhnguyen@gmail.com', N'ETHAN.TMANHNGUYEN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEOLbF8331ZXC/HRH1X6frYGRSArz/yQR8phL3+/3bHxC/IUTMlGR4f82zdyl+eJ5bQ==', N'HLMFB6L276WACWSKUWWBTFIXQDPZ5Q4D', N'4f0317fe-9bf7-49d5-aee9-48bdca972a54', N'0829388495', 0, 0, NULL, 1, 0, N'Pham Thanh')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'5c6f8fef-3b81-4a3e-82b4-e4a75b66c7ec', N'xOz2LR0ftd37SUwGDoCRcfnb2o/bN5C3mgvTilGqiwk=', CAST(N'2025-04-02T03:23:20.9450554' AS DateTime2), 0, N'customer2', N'CUSTOMER2', N'nha.nduongjaki@gmail.com', N'NHA.NDUONGJAKI@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEOioenv8WgJdBFECJg1gc5Lk9CKLjEy75efCDijXO8Js8qYEtPy/FKlP9td1NFDO8Q==', N'2IEOWHLT7F6JHHRI5LE6QMCOQVIJV26N', N'e3aed1f0-feb6-4c9b-ab48-6936d4a7ec00', NULL, 0, 0, NULL, 1, 0, N'')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'6c8ef9c4-b875-4ccd-8607-e3f4437c7656', N'yxolGJS8Hnu7Ke6QngCuKnSVs+ZvruFgV0xtEM6LQn8=', CAST(N'2025-04-02T03:32:26.0909217' AS DateTime2), 0, N'NhanDuong', N'NHANDUONG', N'simplttl123@gmail.com', N'SIMPLTTL123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEGGKLteX3HG8/8dw25g/tZogTZQ/74wZhhh9wDvORpSWL1W8QJhl2A7OGqhj6fX24A==', N'H7IM77G2MXPCIK25LJKVC4E4CJJQ5UOG', N'b5e8974c-afa1-4c41-9889-9ac96fa7f065', N'0837321111', 0, 0, NULL, 1, 0, N'Duong Minh Nhan')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'6f77da32-68ac-4bda-a030-88b298a3873c', N'sirrJPAGyjw2P6v2unnI73vgI3bwdju/efb+sfsgiKw=', CAST(N'2025-03-25T12:11:33.5761993' AS DateTime2), 0, N'expert', N'EXPERT', N'expert@gmail.com', N'EXPERT@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEHj3IRVJ0zQU8qmF3NdA627TCOoGfEf7MmTciHs5ODyhfUqyzULmEAZgzUifh4Nr8Q==', N'5CJ5NR6U6QXQ4K5ZNF7HURCOBLO7FZME', N'b4cd4cd5-083f-4519-bfb0-65d49993b24b', NULL, 0, 0, NULL, 1, 0, N'')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'71246fdb-655a-42bf-b027-178548435a63', N'd1JZa/W1OZKoMsQYoxkj63WvbDi7pwKVfWMNnydqWcQ=', CAST(N'2025-04-02T03:17:01.4842729' AS DateTime2), 0, N'customer1', N'CUSTOMER1', N'nh.anduongjaki@gmail.com', N'NH.ANDUONGJAKI@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEMVFX8tAle4WWFMIc5S5JmgaJbCWh7DZcOEAhaF0s7DO2kQK5Sc0hIIH6CgCuO7wrQ==', N'2XKKA5ZMXPMFE36U6L5PG7PCCJSFHOU6', N'38773a02-7861-4131-980a-16858e3b423a', NULL, 0, 0, NULL, 1, 0, N'')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'7e6de0be-845d-425a-9031-ecf21cfd51ea', N'3Jzj2AfWT5cF93r5O9qhAu4Dy+6HYA1bjZOB70n/ixU=', CAST(N'2025-04-02T06:19:20.7778244' AS DateTime2), 0, N'thanh', N'THANH', N'thanhpcse161286@fpt.edu.vn', N'THANHPCSE161286@FPT.EDU.VN', 1, N'AQAAAAIAAYagAAAAEHhCSQPqd/tkKfuuxZ5so64LogfyRgdtQFi2FZY3/6K/rUu2T8ho7brl+ayhbdTETg==', N'R74U3P3MLUCF3F4GJFENVSZYVZO3NWIL', N'28d5e8c3-dae2-430c-9c88-e9b7e6c1c4d5', N'123123123', 0, 0, NULL, 1, 0, N'Pham Thanh')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'b2b0fa85-dc5a-4aaf-9216-d84c6c13b5c2', N'yNkWQDh4BXbRGBb/UTsZonczvhT4bTLM1m0s6NV8+PA=', CAST(N'2025-03-25T06:11:42.8640703' AS DateTime2), 0, N'customer', N'CUSTOMER', N'quangminhptnk.26052004@gmail.com', N'QUANGMINHPTNK.26052004@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEJU8F/91n2nSAndvysd4LDZyyUrILtL2+S5NnXCBwjOK14X2aQKhXki0YRxScwc2EQ==', N'ITPBYIICYO4FMIZVPGIMDJCUQ6F4O3UL', N'e6c3777c-81a3-4564-b649-951cbadb8f79', NULL, 0, 0, NULL, 1, 0, N'')
INSERT [sps13686_swd392].[AspNetUsers] ([Id], [RefreshToken], [RefreshTokenExpiryTime], [isDelete], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName]) VALUES (N'd43b2388-1e79-480e-82b4-93bd3e006582', N'ArRcr4/GzSqYdXZz3p0evH+TEsxRJqYMHCdRQVcSaIw=', CAST(N'2025-03-27T04:28:38.2092631' AS DateTime2), 0, N'customer3', N'CUSTOMER3', N'nhan.duongjaki@gmail.com', N'NHAN.DUONGJAKI@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEA0qG/gsvTbJQJCLKX8TBJBXNxiTWGYhXTon9BiVHRIN6J5w6hanLxc++ara90Omew==', N'4FEOPLGN6XUW2D2XSMXCQ2GTYVGS54YT', N'a3d6fdd9-f56b-4b77-86db-b5e47f93b6ae', N'0837321111', 0, 0, NULL, 1, 0, N'Duong Minh Nhan')
GO
SET IDENTITY_INSERT [sps13686_swd392].[BlogCategories] ON 

INSERT [sps13686_swd392].[BlogCategories] ([Id], [BlogType], [isDelete]) VALUES (1, N'Blogs', 0)
INSERT [sps13686_swd392].[BlogCategories] ([Id], [BlogType], [isDelete]) VALUES (2, N'Events', 0)
SET IDENTITY_INSERT [sps13686_swd392].[BlogCategories] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[BlogContents] ON 

INSERT [sps13686_swd392].[BlogContents] ([Id], [Title], [Content], [Img], [BlogId]) VALUES (1, N'Introduction to Hooks dasdas', N'React Hooks were introduced in React 16.8 to allow functional components to manage state and lifecycle methods without needing class components. Before hooks, developers relied on class components for features like state management and side effects using lifecycle methods such as componentDidMount', N'https://picsum.photos/400/200?random=1', 1)
INSERT [sps13686_swd392].[BlogContents] ([Id], [Title], [Content], [Img], [BlogId]) VALUES (2, N'Commonly Used Hooks', N'React provides a set of built-in hooks, each serving a specific purpose. The useState hook allows you to manage local state within a function component. The useEffect hook enables side effects such as data fetching, subscriptions, and manually changing the DOM in a declarative manner. ', N'https://picsum.photos/400/200?random=2', 1)
SET IDENTITY_INSERT [sps13686_swd392].[BlogContents] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Blogs] ON 

INSERT [sps13686_swd392].[Blogs] ([Id], [UserId], [BlogCategoryId], [Title], [Status], [isDelete]) VALUES (1, N'1b1ccb14-84d0-4a5e-9f1a-5a4b24e883bf', 1, N'Understanding React Hooks asdasd as dasd ad  dasdasdsa', 1, 0)
SET IDENTITY_INSERT [sps13686_swd392].[Blogs] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[BookingInfos] ON 

INSERT [sps13686_swd392].[BookingInfos] ([Id], [CustomerId], [ExpertId], [CreateDate], [BookingDate], [Start_time], [End_time], [Special_requests], [Status], [isDelete]) VALUES (4, N'5c6f8fef-3b81-4a3e-82b4-e4a75b66c7ec', N'2d560642-564f-4459-b7a5-a35f9a15a16c', CAST(N'2025-03-29T09:00:00.0000000' AS DateTime2), CAST(N'2025-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-04-01T09:00:00.0000000' AS DateTime2), CAST(N'2025-04-01T10:00:00.0000000' AS DateTime2), N'Tư vấn sức khỏe', 1, 0)
SET IDENTITY_INSERT [sps13686_swd392].[BookingInfos] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Brands] ON 

INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (43, N'CeraVe', N'Developed with dermatologists, CeraVe offers skincare products containing essential ceramides to help restore the skin''s protective barrier.', N'USA', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (44, N'Bioderma', N'French skincare brand known for its dermatological products, especially the Sensibio H2O micellar water.', N'France', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (45, N'La Roche-Posay', N'Renowned for its gentle skincare products suitable for sensitive skin, often recommended by dermatologists.', N'France', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (46, N'Cocoon', N'Vietnamese vegan cosmetics brand utilizing natural ingredients in its skincare products.', N'Vietnam', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (47, N'Vichy', N'French brand offering skincare products enriched with Vichy volcanic water, targeting various skin concerns.', N'France', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (48, N'Garnier', N'Provides a wide range of skincare and haircare products, focusing on natural ingredients.', N'France', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (49, N'Obagi', N'Medical-grade skincare brand offering products designed to address various skin concerns.', N'USA', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (50, N'SVR', N'French dermo-cosmetic brand known for its high-tolerance skincare products suitable for sensitive skin.', N'France', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (51, N'Paula''s Choice', N'Skincare brand emphasizing science-backed products free from fragrances and dyes.', N'USA', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (52, N'Neutrogena', N'Offers dermatologist-recommended skincare and haircare products, including cleansers and moisturizers.', N'USA', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (53, N'Beplain', N'Korean skincare brand focusing on gentle, plant-based ingredients suitable for sensitive skin.', N'South Korea', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (54, N'L''Oreal', N'Global beauty brand offering a vast range of skincare, haircare, and makeup products.', N'France', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (55, N'Naruko', N'Taiwanese skincare brand utilizing natural ingredients, known for its night gelly masks.', N'Taiwan', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (56, N'Eucerin', N'German dermo-cosmetic brand offering medical skincare products for various skin concerns.', N'Germany', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (57, N'Simple', N'UK-based brand known for its gentle, no-frills skincare products suitable for sensitive skin.', N'United Kingdom', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (58, N'Caryophy', N'Korean brand specializing in skincare products targeting acne-prone skin.', N'South Korea', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (59, N'TIA''M', N'Korean skincare brand offering products focusing on brightening and skin rejuvenation.', N'South Korea', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (60, N'oh!oh!', N'Skincare brand known for its innovative and playful products.', N'South Korea', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (61, N'I''m from', N'Korean brand highlighting natural ingredients sourced directly from specific regions.', N'South Korea', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (62, N'So''Natural', N'Korean skincare brand focusing on natural ingredients and minimalistic formulations.', N'South Korea', 0)
INSERT [sps13686_swd392].[Brands] ([Id], [BrandName], [Description], [Country], [isDelete]) VALUES (63, N'JMsolution', N'Korean brand renowned for its sheet masks and skincare products.', N'South Korea', 0)
SET IDENTITY_INSERT [sps13686_swd392].[Brands] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Capicities] ON 

INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (1, 30, N'ml', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (2, 50, N'ml', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (3, 100, N'ml', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (4, 150, N'ml', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (5, 200, N'ml', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (6, 250, N'ml', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (7, 500, N'ml', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (8, 30, N'g', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (9, 50, N'g', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (10, 100, N'g', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (11, 150, N'g', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (12, 200, N'g', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (13, 250, N'g', 0)
INSERT [sps13686_swd392].[Capicities] ([Id], [Size], [Unit], [isDelete]) VALUES (14, 500, N'g', 0)
SET IDENTITY_INSERT [sps13686_swd392].[Capicities] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[CartItems] ON 

INSERT [sps13686_swd392].[CartItems] ([Id], [CartId], [ProductId], [Quantity], [TotalPrice]) VALUES (43, 4, 59, 2, CAST(998000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[CartItems] ([Id], [CartId], [ProductId], [Quantity], [TotalPrice]) VALUES (44, 7, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [sps13686_swd392].[CartItems] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Carts] ON 

INSERT [sps13686_swd392].[Carts] ([Id], [UserId], [TotalAmount], [ItemsCount]) VALUES (4, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', CAST(998000.00 AS Decimal(18, 2)), 1)
INSERT [sps13686_swd392].[Carts] ([Id], [UserId], [TotalAmount], [ItemsCount]) VALUES (7, N'35c60c9a-c4d5-417b-8115-c0b14c60ea41', CAST(325000.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [sps13686_swd392].[Carts] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Categories] ON 

INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (19, N'Makeup Remover', N'Removes makeup and impurities from the skin', 0)
INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (20, N'Facial Cleanser', N'Cleanses the face from dirt and excess oil', 0)
INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (21, N'Facial Exfoliator', N'Removes dead skin cells to renew skin surface', 0)
INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (22, N'Toner', N'Balances the skin’s pH and preps for skincare', 0)
INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (23, N'Serum', N'Concentrated treatment for specific skin concerns', 0)
INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (24, N'Acne Treatment Support', N'Helps to reduce acne and breakouts', 0)
INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (25, N'Facial Mist', N'Provides instant hydration and refreshes skin', 0)
INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (26, N'Lotion', N'Lightweight moisturizer for hydration', 0)
INSERT [sps13686_swd392].[Categories] ([Id], [CategoryName], [Description], [isDelete]) VALUES (27, N'Cream', N'Thicker moisturizer for deep nourishment', 0)
SET IDENTITY_INSERT [sps13686_swd392].[Categories] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Cities] ON 

INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (64, N'Ha Noi', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (65, N'Ho Chi Minh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (66, N'Hai Phong', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (67, N'Da Nang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (68, N'Can Tho', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (69, N'An Giang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (70, N'Ba Ria - Vung Tau', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (71, N'Bac Giang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (72, N'Bac Kan', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (73, N'Bac Lieu', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (74, N'Bac Ninh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (75, N'Ben Tre', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (76, N'Binh Dinh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (77, N'Binh Duong', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (78, N'Binh Phuoc', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (79, N'Binh Thuan', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (80, N'Ca Mau', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (81, N'Cao Bang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (82, N'Dak Lak', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (83, N'Dak Nong', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (84, N'Dien Bien', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (85, N'Dong Nai', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (86, N'Dong Thap', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (87, N'Gia Lai', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (88, N'Ha Giang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (89, N'Ha Nam', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (90, N'Ha Tinh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (91, N'Hai Duong', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (92, N'Hau Giang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (93, N'Hoa Binh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (94, N'Hung Yen', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (95, N'Khanh Hoa', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (96, N'Kien Giang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (97, N'Kon Tum', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (98, N'Lai Chau', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (99, N'Lam Dong', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (100, N'Lang Son', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (101, N'Lao Cai', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (102, N'Long An', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (103, N'Nam Dinh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (104, N'Nghe An', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (105, N'Ninh Binh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (106, N'Ninh Thuan', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (107, N'Phu Tho', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (108, N'Phu Yen', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (109, N'Quang Binh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (110, N'Quang Nam', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (111, N'Quang Ngai', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (112, N'Quang Ninh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (113, N'Quang Tri', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (114, N'Soc Trang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (115, N'Son La', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (116, N'Tay Ninh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (117, N'Thai Binh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (118, N'Thai Nguyen', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (119, N'Thanh Hoa', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (120, N'Thua Thien Hue', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (121, N'Tien Giang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (122, N'Tra Vinh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (123, N'Tuyen Quang', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (124, N'Vinh Long', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (125, N'Vinh Phuc', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (126, N'Yen Bai', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (127, N'TP. Hồ Chí Minh', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (128, N'Hà Nội', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (129, N'Đà Nẵng', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (130, N'Hải Phòng', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (131, N'Cần Thơ', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (132, N'Bình Dương', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (133, N'Biên Hòa', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (134, N'Vũng Tàu', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (135, N'Buôn Ma Thuột', 0)
INSERT [sps13686_swd392].[Cities] ([Id], [Name], [isDelete]) VALUES (136, N'Nha Trang', 0)
SET IDENTITY_INSERT [sps13686_swd392].[Cities] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Conversations] ON 

INSERT [sps13686_swd392].[Conversations] ([Id], [UserId1], [UserId2], [CreatedAt]) VALUES (3, N'b2b0fa85-dc5a-4aaf-9216-d84c6c13b5c2', N'6f77da32-68ac-4bda-a030-88b298a3873c', CAST(N'2025-03-18T14:12:05.0177133' AS DateTime2))
INSERT [sps13686_swd392].[Conversations] ([Id], [UserId1], [UserId2], [CreatedAt]) VALUES (4, N'71246fdb-655a-42bf-b027-178548435a63', N'2d560642-564f-4459-b7a5-a35f9a15a16c', CAST(N'2025-03-19T06:59:22.7730909' AS DateTime2))
INSERT [sps13686_swd392].[Conversations] ([Id], [UserId1], [UserId2], [CreatedAt]) VALUES (5, N'5c6f8fef-3b81-4a3e-82b4-e4a75b66c7ec', NULL, CAST(N'2025-03-19T06:59:41.1540733' AS DateTime2))
INSERT [sps13686_swd392].[Conversations] ([Id], [UserId1], [UserId2], [CreatedAt]) VALUES (6, N'd43b2388-1e79-480e-82b4-93bd3e006582', N'2d560642-564f-4459-b7a5-a35f9a15a16c', CAST(N'2025-03-19T07:28:34.6413827' AS DateTime2))
SET IDENTITY_INSERT [sps13686_swd392].[Conversations] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Feedbacks] ON 

INSERT [sps13686_swd392].[Feedbacks] ([Id], [UserId], [ProductId], [Rating], [Comment], [Created_at], [isDelete]) VALUES (4, N'71246fdb-655a-42bf-b027-178548435a63', 59, 5, N'Sản phẩm trị mụn cực kỳ hiệu quả.', CAST(N'2025-03-29T14:05:22.5700000' AS DateTime2), 0)
INSERT [sps13686_swd392].[Feedbacks] ([Id], [UserId], [ProductId], [Rating], [Comment], [Created_at], [isDelete]) VALUES (5, N'd43b2388-1e79-480e-82b4-93bd3e006582', 60, 4, N'Tẩy tế bào chết nhẹ nhàng và dễ chịu.', CAST(N'2025-03-29T14:05:22.5700000' AS DateTime2), 0)
SET IDENTITY_INSERT [sps13686_swd392].[Feedbacks] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Messages] ON 

INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (1, N'b2b0fa85-dc5a-4aaf-9216-d84c6c13b5c2', 3, N'Xin chao chuyen gia', 0, CAST(N'2025-03-18T14:12:05.5065412' AS DateTime2))
INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (2, N'b2b0fa85-dc5a-4aaf-9216-d84c6c13b5c2', 3, N'xin chao chuyen gia', 0, CAST(N'2025-03-18T14:12:15.2586917' AS DateTime2))
INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (3, N'b2b0fa85-dc5a-4aaf-9216-d84c6c13b5c2', 3, N'chuyen gia oi mat em nhu nay thi phai phai lam sao', 0, CAST(N'2025-03-18T14:17:34.3656832' AS DateTime2))
INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (4, N'6f77da32-68ac-4bda-a030-88b298a3873c', 3, N'mat the nay la binh thuong ma em ?', 0, CAST(N'2025-03-18T14:18:07.6778299' AS DateTime2))
INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (5, N'71246fdb-655a-42bf-b027-178548435a63', 4, N'toi muon gap Minh Curus', 0, CAST(N'2025-03-19T06:59:23.0536337' AS DateTime2))
INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (6, N'5c6f8fef-3b81-4a3e-82b4-e4a75b66c7ec', 5, N'toi muon gap Minh Curus', 0, CAST(N'2025-03-19T06:59:41.2865220' AS DateTime2))
INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (7, N'2d560642-564f-4459-b7a5-a35f9a15a16c', 4, N'Sao vay ban, ban muon tu van chuyen gi ?', 0, CAST(N'2025-03-19T07:03:39.2366691' AS DateTime2))
INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (8, N'd43b2388-1e79-480e-82b4-93bd3e006582', 6, N'chuyen gia oi Minh Curus ngu qua', 0, CAST(N'2025-03-19T07:28:34.9065852' AS DateTime2))
INSERT [sps13686_swd392].[Messages] ([Id], [SenderId], [ConversationId], [Content], [IsDeleted], [CreatedAt]) VALUES (9, N'd43b2388-1e79-480e-82b4-93bd3e006582', 6, N'chuyen gia nhu hh', 0, CAST(N'2025-03-20T04:35:11.1646790' AS DateTime2))
SET IDENTITY_INSERT [sps13686_swd392].[Messages] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[MessageStatuses] ON 

INSERT [sps13686_swd392].[MessageStatuses] ([Id], [MessageId], [UserId], [IsRead], [ReadAt]) VALUES (2, 1, N'b2b0fa85-dc5a-4aaf-9216-d84c6c13b5c2', 1, CAST(N'2025-03-29T14:08:35.8766667' AS DateTime2))
INSERT [sps13686_swd392].[MessageStatuses] ([Id], [MessageId], [UserId], [IsRead], [ReadAt]) VALUES (3, 2, N'b2b0fa85-dc5a-4aaf-9216-d84c6c13b5c2', 1, CAST(N'2025-03-29T14:08:35.8766667' AS DateTime2))
INSERT [sps13686_swd392].[MessageStatuses] ([Id], [MessageId], [UserId], [IsRead], [ReadAt]) VALUES (4, 6, N'5c6f8fef-3b81-4a3e-82b4-e4a75b66c7ec', 1, CAST(N'2025-03-29T14:08:35.8766667' AS DateTime2))
SET IDENTITY_INSERT [sps13686_swd392].[MessageStatuses] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[OrderItems] ON 

INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (1, 1, 59, 13, CAST(6487000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (2, 1, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (3, 2, 59, 10, CAST(4990000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (4, 2, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (5, 3, 61, 1, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (6, 4, 60, 5, CAST(1625000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (7, 4, 61, 1, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (8, 5, 61, 5, CAST(1810000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (9, 5, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (10, 6, 61, 1, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (11, 7, 62, 2, CAST(1498000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (12, 8, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (13, 8, 61, 1, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (14, 9, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (15, 9, 61, 1, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (16, 10, 60, 3, CAST(975000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (17, 11, 61, 2, CAST(724000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (18, 12, 60, 2, CAST(650000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (19, 13, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (20, 14, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (21, 15, 61, 1, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (22, 16, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (23, 17, 64, 1, CAST(225000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (24, 18, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (25, 19, 61, 1, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (26, 19, 59, 5, CAST(2495000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (27, 20, 60, 8, CAST(2600000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (28, 21, 59, 1, CAST(499000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (29, 21, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (30, 22, 61, 2, CAST(724000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (31, 23, 60, 2, CAST(650000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (32, 23, 61, 1, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (33, 24, 59, 1, CAST(499000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (34, 24, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (35, 25, 59, 3, CAST(1497000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [TotalPrice]) VALUES (36, 25, 60, 1, CAST(325000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [sps13686_swd392].[OrderItems] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Orders] ON 

INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (1, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 4, 0, CAST(6812000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T02:54:48.0657783' AS DateTime2), NULL, NULL, NULL, CAST(6812000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (2, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 4, 0, CAST(5315000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T03:05:30.4490890' AS DateTime2), NULL, NULL, NULL, CAST(5315000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (3, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 4, 0, CAST(362000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T03:11:39.9072350' AS DateTime2), NULL, NULL, NULL, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (4, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(1987000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T03:30:59.9012737' AS DateTime2), NULL, NULL, NULL, CAST(1987000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (5, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 4, 0, CAST(2135000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T03:33:25.4157742' AS DateTime2), NULL, NULL, NULL, CAST(2135000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (6, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 4, 0, CAST(362000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T03:42:43.0240489' AS DateTime2), NULL, NULL, NULL, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (7, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(1498000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T03:53:18.4387997' AS DateTime2), NULL, NULL, NULL, CAST(1498000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (8, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(687000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T03:57:16.8104412' AS DateTime2), NULL, NULL, NULL, CAST(687000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (9, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(687000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T05:04:17.6788052' AS DateTime2), NULL, NULL, NULL, CAST(687000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (10, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(975000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:07:26.0905921' AS DateTime2), NULL, NULL, NULL, CAST(975000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (11, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(724000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:09:09.6970214' AS DateTime2), NULL, NULL, NULL, CAST(724000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (12, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(650000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:10:52.8365819' AS DateTime2), NULL, NULL, NULL, CAST(650000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (13, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(325000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:12:23.5303066' AS DateTime2), NULL, NULL, NULL, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (14, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(325000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:16:38.3760221' AS DateTime2), NULL, NULL, NULL, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (15, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(362000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:38:14.8870464' AS DateTime2), NULL, NULL, NULL, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (16, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(325000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:42:09.7042227' AS DateTime2), NULL, NULL, NULL, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (17, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 4, 0, CAST(225000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:46:23.6074186' AS DateTime2), NULL, NULL, NULL, CAST(225000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (18, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(325000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:50:32.5423842' AS DateTime2), NULL, NULL, NULL, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (19, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(2857000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T05:52:04.1137145' AS DateTime2), NULL, NULL, NULL, CAST(2857000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (20, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(2600000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T05:57:07.7942224' AS DateTime2), NULL, NULL, NULL, CAST(2600000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (21, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(824000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T06:15:23.7756614' AS DateTime2), NULL, NULL, NULL, CAST(824000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (22, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(724000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-26T06:16:47.8315094' AS DateTime2), NULL, NULL, NULL, CAST(724000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (23, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(1012000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T06:19:29.9336440' AS DateTime2), NULL, NULL, NULL, CAST(1012000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (24, NULL, N'7e6de0be-845d-425a-9031-ecf21cfd51ea', 1, 0, CAST(824000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T06:21:24.0586163' AS DateTime2), NULL, NULL, NULL, CAST(824000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Orders] ([Id], [PromotionId], [UserId], [Status], [isDelete], [TotalAmount], [ItemsCount], [CreatedAt], [PaymentDate], [CompletedDate], [CanceledDate], [OriginalTotalAmount]) VALUES (25, NULL, N'35c60c9a-c4d5-417b-8115-c0b14c60ea41', 1, 0, CAST(1822000.00 AS Decimal(18, 2)), 2, CAST(N'2025-03-26T06:35:24.2691974' AS DateTime2), NULL, NULL, NULL, CAST(1822000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [sps13686_swd392].[Orders] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Payments] ON 

INSERT [sps13686_swd392].[Payments] ([Id], [OrderId], [PaymentStatus], [TransactionId], [PaymentDate], [CreatedAt]) VALUES (14, 17, 1, N'14869815', CAST(N'2025-03-26T12:57:31.0000000' AS DateTime2), CAST(N'2025-03-26T05:57:37.3626161' AS DateTime2))
INSERT [sps13686_swd392].[Payments] ([Id], [OrderId], [PaymentStatus], [TransactionId], [PaymentDate], [CreatedAt]) VALUES (16, 6, 1, N'14869845', CAST(N'2025-03-26T13:12:09.0000000' AS DateTime2), CAST(N'2025-03-26T06:12:28.1167158' AS DateTime2))
SET IDENTITY_INSERT [sps13686_swd392].[Payments] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[ProductCapicities] ON 

INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (1, 65, 3, 50)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (2, 65, 6, 80)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (3, 68, 3, 60)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (4, 68, 6, 55)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (5, 77, 8, 70)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (6, 77, 10, 50)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (7, 93, 3, 60)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (8, 93, 6, 50)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (9, 59, 1, 20)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (10, 59, 2, 25)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (11, 62, 1, 30)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (12, 62, 2, 40)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (13, 72, 1, 15)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (14, 72, 2, 30)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (15, 79, 1, 25)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (16, 79, 2, 40)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (17, 63, 2, 35)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (18, 63, 4, 45)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (19, 69, 2, 50)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (20, 69, 4, 55)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (21, 71, 2, 40)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (22, 71, 4, 35)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (23, 80, 9, 60)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (24, 80, 11, 50)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (25, 61, 3, 50)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (26, 61, 6, 45)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (27, 70, 3, 45)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (28, 70, 6, 45)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (29, 76, 3, 60)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (30, 76, 6, 40)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (31, 91, 3, 40)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (32, 91, 6, 35)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (33, 60, 9, 60)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (34, 60, 10, 50)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (35, 66, 1, 30)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (36, 66, 2, 35)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (37, 78, 5, 50)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (38, 87, 1, 40)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (39, 90, 10, 30)
INSERT [sps13686_swd392].[ProductCapicities] ([Id], [ProductId], [CapicityId], [StockQuantity]) VALUES (40, 92, 9, 50)
SET IDENTITY_INSERT [sps13686_swd392].[ProductCapicities] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Products] ON 

INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (59, 45, 24, NULL, N'La Roche-Posay Effaclar Duo+', CAST(499000.00 AS Decimal(18, 2)), 33, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/bt_new_74d58e49a2414c6d9add6858b892c109_1024x1024.webp', N'Niacinamide, LHA', N'Apply to affected areas morning and evening.', N'Targets acne, reduces blemishes', 0, CAST(499000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (60, 46, 21, NULL, N'Cocoon Rice Bran Exfoliator', CAST(325000.00 AS Decimal(18, 2)), 94, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/exfoliator_combo_2d33cf9f-3afc-4968-8362-975ecb8cd28a.webp', N'Rice Bran, Aloe Vera', N'Use 2-3 times weekly on damp skin.', N'Gentle exfoliation, brightens complexion', 0, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (61, 46, 26, NULL, N'Cocoon Green Tea Lotion', CAST(362000.00 AS Decimal(18, 2)), 90, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/Artboard_21_9d91f1cce4.jpg', N'Green Tea Extract, Centella Asiatica', N'Apply to face after toner.', N'Lightweight hydration, antioxidant protection', 0, CAST(362000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (62, 47, 23, NULL, N'Vichy Mineral 89 Serum', CAST(749000.00 AS Decimal(18, 2)), 68, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/1_8a8a33ddad6d44d7abc053736faebfa0_1024x1024.webp', N'Hyaluronic Acid, Volcanic Water', N'Apply daily before moisturizer.', N'Boosts hydration, strengthens skin barrier', 0, CAST(749000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (63, 47, 27, NULL, N'Vichy Aqualia Thermal Cream', CAST(637000.00 AS Decimal(18, 2)), 80, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/vichy_aqualia_thermal_cream-light_50ml_a83095848a4a4a979356d61b98948cec_1024x1024.webp', N'Thermal Water, Glycerin', N'Apply morning and evening.', N'Rich hydration for dry skin', 0, CAST(637000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (64, 48, 19, NULL, N'Garnier Micellar Cleansing Water', CAST(225000.00 AS Decimal(18, 2)), 150, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/Nuoc-tay-trang-Garnier-cho-da-dau-Garnier-Micellar-Cleansing-Water-For-Oily-Acne-Prone-Skin-125ml-1.jpg', N'Hexylene Glycol, Glycerin', N'Use on cotton pad to remove makeup.', N'All-in-1 cleanser, no rinsing needed', 0, CAST(225000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (65, 48, 20, NULL, N'Garnier SkinActive Cleanser', CAST(200000.00 AS Decimal(18, 2)), 130, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/garnier-skin-active-hyaluronic-aloe-soothing-cream-cleanser-250ml-40509615046894.webp', N'Salicylic Acid, Zinc', N'Massage onto wet skin, then rinse.', N'Purifies pores, removes excess oil', 0, CAST(200000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (66, 51, 21, NULL, N'Paula''s Choice 2% BHA Liquid Exfoliant', CAST(800000.00 AS Decimal(18, 2)), 65, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/2010-award-winners-2021.jpg', N'Salicylic Acid, Green Tea', N'Apply with cotton pad after cleansing.', N'Unclogs pores, smooths texture', 0, CAST(800000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (67, 51, 23, NULL, N'Paula''s Choice Niacinamide Booster', CAST(1100000.00 AS Decimal(18, 2)), 55, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/663_3ef32cc488764d98bb34efd268c1d155_master.webp', N'10% Niacinamide, Vitamin C', N'Mix with serum or moisturizer.', N'Brightens skin, reduces redness', 0, CAST(1100000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (68, 52, 20, NULL, N'Neutrogena Hydro Boost Cleanser', CAST(250000.00 AS Decimal(18, 2)), 115, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/gel-rua-mat-neutrogena-hydro-boo-3.jpg', N'Hyaluronic Acid, Glycerin', N'Use morning and evening.', N'Hydrating gel cleanser', 0, CAST(250000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (69, 52, 26, NULL, N'Neutrogena Hydro Boost Water Gel', CAST(499000.00 AS Decimal(18, 2)), 105, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/dd_gel_b2879746c8d84a22856364fe9f6cbf1a_1024x1024_d012fe69b2ef4492b80518b6023b210f_1024x1024.webp', N'Hyaluronic Acid, Olive Extract', N'Apply to damp skin after cleansing.', N'Oil-free hydration', 0, CAST(499000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (70, 54, 22, NULL, N'L''Oreal Paris Hydra Fresh Toner', CAST(325000.00 AS Decimal(18, 2)), 90, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/0f49863ac2950ac3b2c4565bf2bbcf26.jpg', N'Aloe Vera, Glycerin', N'Apply with cotton pad after cleansing.', N'Alcohol-free, hydrating toner', 0, CAST(325000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (71, 54, 27, NULL, N'L''Oreal Paris Revitalift Cream', CAST(575000.00 AS Decimal(18, 2)), 75, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/bt_8f10c91a10b24f83be8d5b78104133e6_1024x1024.webp', N'Pro-Retinol, Vitamin C', N'Apply morning and evening.', N'Anti-aging, firms skin', 0, CAST(575000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (72, 49, 23, NULL, N'Obagi Vitamin C Serum', CAST(2500000.00 AS Decimal(18, 2)), 45, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/Huyet-thanh-tri-nam-–-duong-sang-da-Obagi-Vitamin-C-10-Serum-4-5.jpg', N'L-ascorbic Acid, Ferulic Acid', N'Apply in the morning before sunscreen.', N'Brightening, collagen production', 0, CAST(2500000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (73, 49, 21, NULL, N'Obagi Professional-C Microdermabrasion', CAST(1800000.00 AS Decimal(18, 2)), 30, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/obagi-medical-professional-c-microdermabrasion-polish-mask-3__1__9104be6d85a34ec89bec95637f61f89c.webp', N'Vitamin C, Aluminum Oxide', N'Use once weekly for 3-5 minutes.', N'Physical exfoliation, brightening', 0, CAST(1800000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (74, 50, 24, NULL, N'SVR Sebiaclear Active Cream', CAST(450000.00 AS Decimal(18, 2)), 85, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/20190108_y01RPUvu1wBTTUxJgPM7BTGu.jpg', N'Niacinamide, Zinc PCA', N'Apply morning and evening on problem areas.', N'Acne treatment, sebum regulation', 0, CAST(450000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (75, 50, 27, NULL, N'SVR Topialyse Baume', CAST(550000.00 AS Decimal(18, 2)), 75, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/SVR-TOPIALYSE-Baume-Lavant-2.jpg', N'Shea Butter, Squalane', N'Apply to dry areas as needed.', N'Intense repair for very dry skin', 0, CAST(550000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (76, 53, 22, NULL, N'Beplain Chamomile Toner', CAST(350000.00 AS Decimal(18, 2)), 100, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/vn-11134207-7r98o-lrducqczm0t5d7.jpg', N'Chamomile Extract, Panthenol', N'Apply with cotton pad after cleansing.', N'Soothing, pH balancing', 0, CAST(350000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (77, 53, 20, NULL, N'Beplain Greenful Cleansing Foam', CAST(280000.00 AS Decimal(18, 2)), 120, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/da140fa4592515e8bad0a6db2dd9fd19.jpg', N'Green Tea, Willow Bark Extract', N'Use morning and evening.', N'Gentle cleansing, antioxidant', 0, CAST(280000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (78, 55, 25, NULL, N'Naruko Tea Tree Night Gelly', CAST(400000.00 AS Decimal(18, 2)), 90, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/2bd436ca6ea2bc81e065ba4c337842f3.jpg', N'Tea Tree Oil, Niacinamide', N'Apply as last step at night.', N'Oil control, acne prevention', 0, CAST(400000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (79, 55, 23, NULL, N'Naruko Magnolia Brightening Serum', CAST(650000.00 AS Decimal(18, 2)), 65, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/MagnoliaSerum.webp', N'Magnolia Extract, Tranexamic Acid', N'Apply before moisturizer.', N'Brightening, dark spot correction', 0, CAST(650000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (80, 56, 27, NULL, N'Eucerin UreaRepair Cream', CAST(500000.00 AS Decimal(18, 2)), 110, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/6bbf0097-66f5-41ed-a784-f12679779cc5_Eucerin UreaRepair Cream.jpg', N'5% Urea, Ceramides', N'Apply to dry areas 1-2 times daily.', N'Intense hydration, skin barrier repair', 0, CAST(500000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (81, 56, 19, NULL, N'Eucerin Dermatoclean Cleansing Oil', CAST(380000.00 AS Decimal(18, 2)), 95, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/3080a63b-44bd-41e3-bd00-2cf7cc2ba7b7_Eucerin Dermatoclean Cleansing Oil.webp', N'Macadamia Oil, Vitamin E', N'Massage on dry skin, then rinse.', N'Gentle makeup removal', 0, CAST(380000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (82, 57, 20, NULL, N'Simple Water Boost Micellar Wash', CAST(150000.00 AS Decimal(18, 2)), 150, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/606d5d46-b993-4a63-9243-d189b9b0928a_Simple Water Boost Micellar Wash.webp', N'Vitamin B3, Pentavitin', N'Use morning and evening.', N'Hydrating, no harsh ingredients', 0, CAST(150000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (83, 57, 22, NULL, N'Simple Soothing Toner', CAST(180000.00 AS Decimal(18, 2)), 130, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/dc3782df-ec3e-4c95-8106-94bca3cf0fe6_Simple Soothing Toner.jpg', N'Chamomile, Allantoin', N'Apply after cleansing.', N'Alcohol-free, calming', 0, CAST(180000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (84, 58, 21, NULL, N'Caryophy Gentle Peeling Gel', CAST(220000.00 AS Decimal(18, 2)), 80, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/44aa2c16-b812-4167-b35a-3ea2a9465a20_Caryophy Gentle Peeling Gel.webp', N'Willow Bark, Papaya Extract', N'Use 1-2 times weekly.', N'Enzyme exfoliation, brightening', 0, CAST(220000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (85, 58, 26, NULL, N'Caryophy Cica Calming Lotion', CAST(300000.00 AS Decimal(18, 2)), 90, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/bd20d6ea-65b6-4575-8b03-ebb44c184d1e_Caryophy Cica Calming Lotion.jpg', N'Centella Asiatica, Madecassoside', N'Apply after serum.', N'Soothing, redness reduction', 0, CAST(300000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (86, 59, 23, NULL, N'TIA''M Vita B3 Source', CAST(420000.00 AS Decimal(18, 2)), 70, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/a233a291-b233-452e-b742-47f6ef3f6dfb_TIA''M Vita B3 Source.jpg', N'10% Niacinamide, Zinc', N'Apply before moisturizer.', N'Oil control, pore refining', 0, CAST(420000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (87, 59, 24, NULL, N'TIA''M A.C. Fighting Serum', CAST(380000.00 AS Decimal(18, 2)), 85, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/47c931af-1745-41b0-96d4-64ef23b03f70_TIA''M A.C. Fighting Serum.jpg', N'Tea Tree Oil, Salicylic Acid', N'Apply to acne-prone areas.', N'Acne treatment, inflammation reduction', 0, CAST(380000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (88, 60, 25, NULL, N'ohIoh! Green Tea Mist', CAST(250000.00 AS Decimal(18, 2)), 100, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/befe5348-272b-45b5-89c1-db7a55ee5d99_ohIoh! Green Tea Mist.jpg', N'Green Tea Extract, Hyaluronic Acid', N'Use throughout the day.', N'Refreshing, antioxidant', 0, CAST(250000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (89, 60, 19, NULL, N'ohIoh! Makeup Cleansing Water', CAST(200000.00 AS Decimal(18, 2)), 120, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/9e0aa258-7700-4a50-b736-a066fb9a7810_ohIoh! Makeup Cleansing Water.jpg', N'Rose Water, Vitamin E', N'Use with cotton pad.', N'Gentle makeup removal', 0, CAST(200000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (90, 61, 21, NULL, N'I''m from Rice Scrub Mask', CAST(550000.00 AS Decimal(18, 2)), 60, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/e8bfde3d-e679-4871-af3b-77e23dde78d4_71Hh6Cr3aUL.jpg', N'Rice Bran, Walnut Shell Powder', N'Use 1-2 times weekly.', N'Physical exfoliation, brightening', 0, CAST(550000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (91, 61, 22, NULL, N'I''m from Mugwort Toner', CAST(600000.00 AS Decimal(18, 2)), 75, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/dd38b201-2a06-4e47-a093-631b3c2007f4_anh-02_dd96181d64de4418b8f929082f94ef78.webp', N'Mugwort Extract, Artemisia', N'Apply after cleansing.', N'Calming, redness reduction', 0, CAST(600000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (92, 62, 27, NULL, N'So''Natural Cica Cream', CAST(350000.00 AS Decimal(18, 2)), 95, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/6d20304e-8a4a-4f4d-8f9d-2c010ec438da_sonatural-tinh-chat-red-peel-white-11ml-2-1723457940194.webp', N'Centella Asiatica, Shea Butter', N'Apply morning and evening.', N'Repairing, soothing', 0, CAST(350000.00 AS Decimal(18, 2)))
INSERT [sps13686_swd392].[Products] ([Id], [BrandId], [CategoryId], [PromotionId], [ProductName], [Price], [StockQuantity], [ImageUrl], [Ingredients], [UsageInstructions], [Benefits], [isDelete], [OriginalPrice]) VALUES (93, 62, 20, NULL, N'So''Natural Amino Acid Cleanser', CAST(280000.00 AS Decimal(18, 2)), 110, N'https://storage.googleapis.com/spss-e4dcd.firebasestorage.app/images/f82a5648-04f0-47f6-94cc-920683527dca_vn-11134207-7ras8-m2qiqpk8fldy87.webp', N'Amino Acids, Coconut Derivatives', N'Use morning and evening.', N'Gentle cleansing, pH balanced', 0, CAST(280000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [sps13686_swd392].[Products] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[ProductSkinTypes] ON 

INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (1, 59, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (2, 59, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (3, 60, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (4, 60, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (5, 61, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (6, 61, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (7, 62, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (8, 62, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (9, 63, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (10, 63, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (11, 64, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (12, 64, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (13, 65, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (14, 65, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (15, 66, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (16, 66, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (17, 67, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (18, 67, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (19, 68, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (20, 68, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (21, 69, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (22, 69, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (23, 70, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (24, 70, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (25, 71, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (26, 71, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (27, 72, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (28, 72, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (29, 73, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (30, 73, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (31, 74, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (32, 74, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (33, 75, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (34, 75, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (35, 76, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (36, 76, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (37, 77, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (38, 77, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (39, 78, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (40, 78, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (41, 79, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (42, 79, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (43, 80, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (44, 80, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (45, 81, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (46, 81, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (47, 82, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (48, 82, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (49, 83, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (50, 83, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (51, 84, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (52, 84, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (53, 85, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (54, 85, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (55, 86, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (56, 86, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (57, 87, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (58, 87, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (59, 88, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (60, 88, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (61, 89, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (62, 89, 2)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (63, 90, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (64, 90, 3)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (65, 91, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (66, 91, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (67, 92, 4)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (68, 92, 5)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (69, 93, 1)
INSERT [sps13686_swd392].[ProductSkinTypes] ([Id], [ProductId], [SkinTypeId]) VALUES (70, 93, 5)
SET IDENTITY_INSERT [sps13686_swd392].[ProductSkinTypes] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Promotions] ON 

INSERT [sps13686_swd392].[Promotions] ([Id], [Code], [Name], [DiscountValue], [StartDate], [EndDate], [UsageLimit], [Status], [CreatedAt], [isDelete]) VALUES (7, N'BF2025', N'Black Friday Sale', CAST(20.00 AS Decimal(18, 2)), CAST(N'2025-11-25T00:00:00.0000000' AS DateTime2), CAST(N'2025-11-30T00:00:00.0000000' AS DateTime2), 1000, 1, CAST(N'2025-03-18T01:31:33.0366667' AS DateTime2), 0)
INSERT [sps13686_swd392].[Promotions] ([Id], [Code], [Name], [DiscountValue], [StartDate], [EndDate], [UsageLimit], [Status], [CreatedAt], [isDelete]) VALUES (8, N'WELCOME10', N'New User Discount', CAST(10.00 AS Decimal(18, 2)), CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-12-31T00:00:00.0000000' AS DateTime2), NULL, 1, CAST(N'2025-03-18T01:31:33.0366667' AS DateTime2), 0)
INSERT [sps13686_swd392].[Promotions] ([Id], [Code], [Name], [DiscountValue], [StartDate], [EndDate], [UsageLimit], [Status], [CreatedAt], [isDelete]) VALUES (9, N'SUMMER25', N'Summer Sale', CAST(25.00 AS Decimal(18, 2)), CAST(N'2025-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-06-15T00:00:00.0000000' AS DateTime2), 500, 1, CAST(N'2025-03-18T01:31:33.0366667' AS DateTime2), 0)
INSERT [sps13686_swd392].[Promotions] ([Id], [Code], [Name], [DiscountValue], [StartDate], [EndDate], [UsageLimit], [Status], [CreatedAt], [isDelete]) VALUES (10, N'HOLIDAY50', N'Holiday Special', CAST(50.00 AS Decimal(18, 2)), CAST(N'2025-12-20T00:00:00.0000000' AS DateTime2), CAST(N'2025-12-31T00:00:00.0000000' AS DateTime2), 300, 1, CAST(N'2025-03-18T01:31:33.0366667' AS DateTime2), 0)
INSERT [sps13686_swd392].[Promotions] ([Id], [Code], [Name], [DiscountValue], [StartDate], [EndDate], [UsageLimit], [Status], [CreatedAt], [isDelete]) VALUES (11, N'FLASH15', N'Flash Sale', CAST(15.00 AS Decimal(18, 2)), CAST(N'2025-03-10T00:00:00.0000000' AS DateTime2), CAST(N'2025-03-12T00:00:00.0000000' AS DateTime2), 200, 1, CAST(N'2025-03-18T01:31:33.0366667' AS DateTime2), 0)
SET IDENTITY_INSERT [sps13686_swd392].[Promotions] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Question] ON 

INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (2, N'Question 1: After cleansing, how does your skin feel after 30 minutes?', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (3, N'Question 2: How does your skin look midday?', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (4, N'Question 3: How visible are your pores?', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (5, N'Question 4: How often do you break out?', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (6, N'Question 5: How does your skin react to new products?', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (7, N'Question 6: After applying moisturizer, how does your skin feel?', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (8, N'Question 7: In humid weather, your skin tends to:', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (9, N'Question 8: Does your skin easily get red or irritated?', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (10, N'Question 9: In the evening, your skin usually:', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (11, N'Question 10: How often does your skin flake?', 0)
INSERT [sps13686_swd392].[Question] ([Id], [QuestionDESC], [isDelete]) VALUES (12, N'Moa', 0)
SET IDENTITY_INSERT [sps13686_swd392].[Question] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Results] ON 

INSERT [sps13686_swd392].[Results] ([Id], [MinPoint], [MaxPoint], [SkinTypeId], [isDelete]) VALUES (1, 0, 10, 1, 0)
INSERT [sps13686_swd392].[Results] ([Id], [MinPoint], [MaxPoint], [SkinTypeId], [isDelete]) VALUES (2, 11, 15, 2, 0)
INSERT [sps13686_swd392].[Results] ([Id], [MinPoint], [MaxPoint], [SkinTypeId], [isDelete]) VALUES (3, 16, 20, 3, 0)
INSERT [sps13686_swd392].[Results] ([Id], [MinPoint], [MaxPoint], [SkinTypeId], [isDelete]) VALUES (4, 21, 25, 4, 0)
INSERT [sps13686_swd392].[Results] ([Id], [MinPoint], [MaxPoint], [SkinTypeId], [isDelete]) VALUES (5, 26, 30, 5, 0)
SET IDENTITY_INSERT [sps13686_swd392].[Results] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[Routines] ON 

INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (2, N'Daily Care for Normal Skin', N'Morning and evening routine to maintain healthy normal skin', CAST(1250000.00 AS Decimal(18, 2)), 30, 2, 0, 1)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (3, N'Weekly Maintenance for Normal Skin', N'Weekly treatments to enhance normal skin radiance', CAST(850000.00 AS Decimal(18, 2)), 7, 1, 0, 1)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (4, N'Balance Routine for Combination Skin', N'Controls oil in T-zone while hydrating dry areas', CAST(1350000.00 AS Decimal(18, 2)), 30, 2, 0, 2)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (5, N'Combination Skin Rescue', N'Special treatment for seasonal changes affecting combination skin', CAST(950000.00 AS Decimal(18, 2)), 14, 1, 0, 2)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (6, N'Oil Control Daily Routine', N'Regulates sebum production and minimizes pores', CAST(1400000.00 AS Decimal(18, 2)), 30, 2, 0, 3)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (7, N'Acne Treatment Routine', N'Targets breakouts and prevents new acne formation', CAST(1550000.00 AS Decimal(18, 2)), 30, 1, 0, 3)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (8, N'Intensive Hydration Routine', N'Deep moisture replenishment for very dry skin', CAST(1450000.00 AS Decimal(18, 2)), 30, 2, 0, 4)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (9, N'Dry Skin Repair Night Routine', N'Overnight treatment to repair moisture barrier', CAST(1100000.00 AS Decimal(18, 2)), 30, 3, 0, 4)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (10, N'Gentle Care for Sensitive Skin', N'Soothing products to calm irritation and redness', CAST(1300000.00 AS Decimal(18, 2)), 30, 1, 0, 5)
INSERT [sps13686_swd392].[Routines] ([Id], [Name], [Description], [Price], [Duration], [Frequency], [isDelete], [SkinTypeId]) VALUES (11, N'Sensitive Skin Recovery', N'Treatment for compromised sensitive skin', CAST(1050000.00 AS Decimal(18, 2)), 14, 2, 0, 5)
SET IDENTITY_INSERT [sps13686_swd392].[Routines] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[RoutinesProductLists] ON 

INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (2, 2, 59)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (3, 2, 61)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (4, 2, 69)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (5, 3, 60)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (6, 3, 72)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (7, 4, 65)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (8, 4, 70)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (9, 4, 71)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (10, 5, 66)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (11, 5, 79)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (12, 6, 68)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (13, 6, 66)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (14, 6, 69)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (15, 7, 87)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (16, 7, 78)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (17, 8, 81)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (18, 8, 62)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (19, 8, 80)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (20, 9, 63)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (21, 9, 75)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (22, 10, 77)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (23, 10, 76)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (24, 10, 92)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (25, 11, 85)
INSERT [sps13686_swd392].[RoutinesProductLists] ([Id], [RoutinesId], [ProductId]) VALUES (26, 11, 67)
SET IDENTITY_INSERT [sps13686_swd392].[RoutinesProductLists] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[SkinTypes] ON 

INSERT [sps13686_swd392].[SkinTypes] ([Id], [Name], [Description], [isDelete]) VALUES (1, N'Normal Skin', N'Balanced, few imperfections, small pores.', 0)
INSERT [sps13686_swd392].[SkinTypes] ([Id], [Name], [Description], [isDelete]) VALUES (2, N'Combination Skin', N'Oily T-zone, dry/normal cheeks.', 0)
INSERT [sps13686_swd392].[SkinTypes] ([Id], [Name], [Description], [isDelete]) VALUES (3, N'Oily Skin', N'Shiny all over, enlarged pores, prone to acne.', 0)
INSERT [sps13686_swd392].[SkinTypes] ([Id], [Name], [Description], [isDelete]) VALUES (4, N'Dry Skin', N'Tight, flaky, dehydrated, tiny pores.', 0)
INSERT [sps13686_swd392].[SkinTypes] ([Id], [Name], [Description], [isDelete]) VALUES (5, N'Sensitive Skin', N'Prone to redness, irritation, and reactions to products.', 0)
SET IDENTITY_INSERT [sps13686_swd392].[SkinTypes] OFF
GO
SET IDENTITY_INSERT [sps13686_swd392].[UserAddresses] ON 

INSERT [sps13686_swd392].[UserAddresses] ([Id], [UserId], [AddressId]) VALUES (2, N'71246fdb-655a-42bf-b027-178548435a63', 11)
INSERT [sps13686_swd392].[UserAddresses] ([Id], [UserId], [AddressId]) VALUES (3, N'b2b0fa85-dc5a-4aaf-9216-d84c6c13b5c2', 12)
INSERT [sps13686_swd392].[UserAddresses] ([Id], [UserId], [AddressId]) VALUES (4, N'd43b2388-1e79-480e-82b4-93bd3e006582', 13)
INSERT [sps13686_swd392].[UserAddresses] ([Id], [UserId], [AddressId]) VALUES (5, N'5c6f8fef-3b81-4a3e-82b4-e4a75b66c7ec', 14)
SET IDENTITY_INSERT [sps13686_swd392].[UserAddresses] OFF
GO
/****** Object:  Index [IX_Addresses_AddressTypeId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Addresses_AddressTypeId] ON [sps13686_swd392].[Addresses]
(
	[AddressTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Addresses_CityId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Addresses_CityId] ON [sps13686_swd392].[Addresses]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnswerDetails_AnswerId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AnswerDetails_AnswerId] ON [sps13686_swd392].[AnswerDetails]
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnswerDetails_AnswerSheetId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AnswerDetails_AnswerSheetId] ON [sps13686_swd392].[AnswerDetails]
(
	[AnswerSheetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Answers_QuestionId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Answers_QuestionId] ON [sps13686_swd392].[Answers]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AnswerSheets_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AnswerSheets_UserId] ON [sps13686_swd392].[AnswerSheets]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [sps13686_swd392].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [sps13686_swd392].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [sps13686_swd392].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [sps13686_swd392].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [sps13686_swd392].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [sps13686_swd392].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [sps13686_swd392].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogContents_BlogId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_BlogContents_BlogId] ON [sps13686_swd392].[BlogContents]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Blogs_BlogCategoryId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Blogs_BlogCategoryId] ON [sps13686_swd392].[Blogs]
(
	[BlogCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Blogs_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Blogs_UserId] ON [sps13686_swd392].[Blogs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_BookingInfos_CustomerId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookingInfos_CustomerId] ON [sps13686_swd392].[BookingInfos]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_BookingInfos_ExpertId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookingInfos_ExpertId] ON [sps13686_swd392].[BookingInfos]
(
	[ExpertId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartItems_CartId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartItems_CartId] ON [sps13686_swd392].[CartItems]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartItems_ProductId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartItems_ProductId] ON [sps13686_swd392].[CartItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Carts_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Carts_UserId] ON [sps13686_swd392].[Carts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Conversations_UserId1]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Conversations_UserId1] ON [sps13686_swd392].[Conversations]
(
	[UserId1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Conversations_UserId2]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Conversations_UserId2] ON [sps13686_swd392].[Conversations]
(
	[UserId2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Feedbacks_ProductId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Feedbacks_ProductId] ON [sps13686_swd392].[Feedbacks]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Feedbacks_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Feedbacks_UserId] ON [sps13686_swd392].[Feedbacks]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Messages_ConversationId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Messages_ConversationId] ON [sps13686_swd392].[Messages]
(
	[ConversationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Messages_SenderId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Messages_SenderId] ON [sps13686_swd392].[Messages]
(
	[SenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MessageStatuses_MessageId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_MessageStatuses_MessageId] ON [sps13686_swd392].[MessageStatuses]
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MessageStatuses_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_MessageStatuses_UserId] ON [sps13686_swd392].[MessageStatuses]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [sps13686_swd392].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_ProductId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_ProductId] ON [sps13686_swd392].[OrderItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_PromotionId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_PromotionId] ON [sps13686_swd392].[Orders]
(
	[PromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [sps13686_swd392].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_OrderId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Payments_OrderId] ON [sps13686_swd392].[Payments]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCapicities_CapicityId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductCapicities_CapicityId] ON [sps13686_swd392].[ProductCapicities]
(
	[CapicityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCapicities_ProductId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductCapicities_ProductId] ON [sps13686_swd392].[ProductCapicities]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_BrandId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_BrandId] ON [sps13686_swd392].[Products]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [sps13686_swd392].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_PromotionId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_PromotionId] ON [sps13686_swd392].[Products]
(
	[PromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSkinTypes_ProductId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSkinTypes_ProductId] ON [sps13686_swd392].[ProductSkinTypes]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSkinTypes_SkinTypeId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSkinTypes_SkinTypeId] ON [sps13686_swd392].[ProductSkinTypes]
(
	[SkinTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Promotions_Code]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Promotions_Code] ON [sps13686_swd392].[Promotions]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Results_SkinTypeId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Results_SkinTypeId] ON [sps13686_swd392].[Results]
(
	[SkinTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Routines_SkinTypeId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Routines_SkinTypeId] ON [sps13686_swd392].[Routines]
(
	[SkinTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoutinesProductLists_ProductId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoutinesProductLists_ProductId] ON [sps13686_swd392].[RoutinesProductLists]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoutinesProductLists_RoutinesId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoutinesProductLists_RoutinesId] ON [sps13686_swd392].[RoutinesProductLists]
(
	[RoutinesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserAddresses_AddressId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserAddresses_AddressId] ON [sps13686_swd392].[UserAddresses]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserAddresses_UserId]    Script Date: 3/29/2025 4:58:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserAddresses_UserId] ON [sps13686_swd392].[UserAddresses]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [sps13686_swd392].[AspNetUsers] ADD  DEFAULT (N'') FOR [FullName]
GO
ALTER TABLE [sps13686_swd392].[Orders] ADD  DEFAULT ((0.0)) FOR [OriginalTotalAmount]
GO
ALTER TABLE [sps13686_swd392].[Products] ADD  DEFAULT ((0.0)) FOR [OriginalPrice]
GO
ALTER TABLE [sps13686_swd392].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_AddressTypes_AddressTypeId] FOREIGN KEY([AddressTypeId])
REFERENCES [sps13686_swd392].[AddressTypes] ([Id])
GO
ALTER TABLE [sps13686_swd392].[Addresses] CHECK CONSTRAINT [FK_Addresses_AddressTypes_AddressTypeId]
GO
ALTER TABLE [sps13686_swd392].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [sps13686_swd392].[Cities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Addresses] CHECK CONSTRAINT [FK_Addresses_Cities_CityId]
GO
ALTER TABLE [sps13686_swd392].[AnswerDetails]  WITH CHECK ADD  CONSTRAINT [FK_AnswerDetails_Answers_AnswerId] FOREIGN KEY([AnswerId])
REFERENCES [sps13686_swd392].[Answers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AnswerDetails] CHECK CONSTRAINT [FK_AnswerDetails_Answers_AnswerId]
GO
ALTER TABLE [sps13686_swd392].[AnswerDetails]  WITH CHECK ADD  CONSTRAINT [FK_AnswerDetails_AnswerSheets_AnswerSheetId] FOREIGN KEY([AnswerSheetId])
REFERENCES [sps13686_swd392].[AnswerSheets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AnswerDetails] CHECK CONSTRAINT [FK_AnswerDetails_AnswerSheets_AnswerSheetId]
GO
ALTER TABLE [sps13686_swd392].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Question_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [sps13686_swd392].[Question] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Answers] CHECK CONSTRAINT [FK_Answers_Question_QuestionId]
GO
ALTER TABLE [sps13686_swd392].[AnswerSheets]  WITH CHECK ADD  CONSTRAINT [FK_AnswerSheets_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AnswerSheets] CHECK CONSTRAINT [FK_AnswerSheets_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [sps13686_swd392].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [sps13686_swd392].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [sps13686_swd392].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [sps13686_swd392].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[BlogContents]  WITH CHECK ADD  CONSTRAINT [FK_BlogContents_Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [sps13686_swd392].[Blogs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[BlogContents] CHECK CONSTRAINT [FK_BlogContents_Blogs_BlogId]
GO
ALTER TABLE [sps13686_swd392].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Blogs] CHECK CONSTRAINT [FK_Blogs_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_BlogCategories_BlogCategoryId] FOREIGN KEY([BlogCategoryId])
REFERENCES [sps13686_swd392].[BlogCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Blogs] CHECK CONSTRAINT [FK_Blogs_BlogCategories_BlogCategoryId]
GO
ALTER TABLE [sps13686_swd392].[BookingInfos]  WITH CHECK ADD  CONSTRAINT [FK_BookingInfos_AspNetUsers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
GO
ALTER TABLE [sps13686_swd392].[BookingInfos] CHECK CONSTRAINT [FK_BookingInfos_AspNetUsers_CustomerId]
GO
ALTER TABLE [sps13686_swd392].[BookingInfos]  WITH CHECK ADD  CONSTRAINT [FK_BookingInfos_AspNetUsers_ExpertId] FOREIGN KEY([ExpertId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
GO
ALTER TABLE [sps13686_swd392].[BookingInfos] CHECK CONSTRAINT [FK_BookingInfos_AspNetUsers_ExpertId]
GO
ALTER TABLE [sps13686_swd392].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Carts_CartId] FOREIGN KEY([CartId])
REFERENCES [sps13686_swd392].[Carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[CartItems] CHECK CONSTRAINT [FK_CartItems_Carts_CartId]
GO
ALTER TABLE [sps13686_swd392].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [sps13686_swd392].[Products] ([Id])
GO
ALTER TABLE [sps13686_swd392].[CartItems] CHECK CONSTRAINT [FK_CartItems_Products_ProductId]
GO
ALTER TABLE [sps13686_swd392].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Carts] CHECK CONSTRAINT [FK_Carts_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[Conversations]  WITH CHECK ADD  CONSTRAINT [FK_Conversations_AspNetUsers_UserId1] FOREIGN KEY([UserId1])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
GO
ALTER TABLE [sps13686_swd392].[Conversations] CHECK CONSTRAINT [FK_Conversations_AspNetUsers_UserId1]
GO
ALTER TABLE [sps13686_swd392].[Conversations]  WITH CHECK ADD  CONSTRAINT [FK_Conversations_AspNetUsers_UserId2] FOREIGN KEY([UserId2])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
GO
ALTER TABLE [sps13686_swd392].[Conversations] CHECK CONSTRAINT [FK_Conversations_AspNetUsers_UserId2]
GO
ALTER TABLE [sps13686_swd392].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_Feedbacks_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Feedbacks] CHECK CONSTRAINT [FK_Feedbacks_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_Feedbacks_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [sps13686_swd392].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Feedbacks] CHECK CONSTRAINT [FK_Feedbacks_Products_ProductId]
GO
ALTER TABLE [sps13686_swd392].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_AspNetUsers_SenderId] FOREIGN KEY([SenderId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
GO
ALTER TABLE [sps13686_swd392].[Messages] CHECK CONSTRAINT [FK_Messages_AspNetUsers_SenderId]
GO
ALTER TABLE [sps13686_swd392].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Conversations_ConversationId] FOREIGN KEY([ConversationId])
REFERENCES [sps13686_swd392].[Conversations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Messages] CHECK CONSTRAINT [FK_Messages_Conversations_ConversationId]
GO
ALTER TABLE [sps13686_swd392].[MessageStatuses]  WITH CHECK ADD  CONSTRAINT [FK_MessageStatuses_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[MessageStatuses] CHECK CONSTRAINT [FK_MessageStatuses_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[MessageStatuses]  WITH CHECK ADD  CONSTRAINT [FK_MessageStatuses_Messages_MessageId] FOREIGN KEY([MessageId])
REFERENCES [sps13686_swd392].[Messages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[MessageStatuses] CHECK CONSTRAINT [FK_MessageStatuses_Messages_MessageId]
GO
ALTER TABLE [sps13686_swd392].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [sps13686_swd392].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
ALTER TABLE [sps13686_swd392].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [sps13686_swd392].[Products] ([Id])
GO
ALTER TABLE [sps13686_swd392].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Products_ProductId]
GO
ALTER TABLE [sps13686_swd392].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_UserId]
GO
ALTER TABLE [sps13686_swd392].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Promotions_PromotionId] FOREIGN KEY([PromotionId])
REFERENCES [sps13686_swd392].[Promotions] ([Id])
GO
ALTER TABLE [sps13686_swd392].[Orders] CHECK CONSTRAINT [FK_Orders_Promotions_PromotionId]
GO
ALTER TABLE [sps13686_swd392].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [sps13686_swd392].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Payments] CHECK CONSTRAINT [FK_Payments_Orders_OrderId]
GO
ALTER TABLE [sps13686_swd392].[ProductCapicities]  WITH CHECK ADD  CONSTRAINT [FK_ProductCapicities_Capicities_CapicityId] FOREIGN KEY([CapicityId])
REFERENCES [sps13686_swd392].[Capicities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[ProductCapicities] CHECK CONSTRAINT [FK_ProductCapicities_Capicities_CapicityId]
GO
ALTER TABLE [sps13686_swd392].[ProductCapicities]  WITH CHECK ADD  CONSTRAINT [FK_ProductCapicities_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [sps13686_swd392].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[ProductCapicities] CHECK CONSTRAINT [FK_ProductCapicities_Products_ProductId]
GO
ALTER TABLE [sps13686_swd392].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [sps13686_swd392].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
ALTER TABLE [sps13686_swd392].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [sps13686_swd392].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [sps13686_swd392].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Promotions_PromotionId] FOREIGN KEY([PromotionId])
REFERENCES [sps13686_swd392].[Promotions] ([Id])
GO
ALTER TABLE [sps13686_swd392].[Products] CHECK CONSTRAINT [FK_Products_Promotions_PromotionId]
GO
ALTER TABLE [sps13686_swd392].[ProductSkinTypes]  WITH CHECK ADD  CONSTRAINT [FK_ProductSkinTypes_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [sps13686_swd392].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[ProductSkinTypes] CHECK CONSTRAINT [FK_ProductSkinTypes_Products_ProductId]
GO
ALTER TABLE [sps13686_swd392].[ProductSkinTypes]  WITH CHECK ADD  CONSTRAINT [FK_ProductSkinTypes_SkinTypes_SkinTypeId] FOREIGN KEY([SkinTypeId])
REFERENCES [sps13686_swd392].[SkinTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[ProductSkinTypes] CHECK CONSTRAINT [FK_ProductSkinTypes_SkinTypes_SkinTypeId]
GO
ALTER TABLE [sps13686_swd392].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_SkinTypes_SkinTypeId] FOREIGN KEY([SkinTypeId])
REFERENCES [sps13686_swd392].[SkinTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Results] CHECK CONSTRAINT [FK_Results_SkinTypes_SkinTypeId]
GO
ALTER TABLE [sps13686_swd392].[Routines]  WITH CHECK ADD  CONSTRAINT [FK_Routines_SkinTypes_SkinTypeId] FOREIGN KEY([SkinTypeId])
REFERENCES [sps13686_swd392].[SkinTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[Routines] CHECK CONSTRAINT [FK_Routines_SkinTypes_SkinTypeId]
GO
ALTER TABLE [sps13686_swd392].[RoutinesProductLists]  WITH CHECK ADD  CONSTRAINT [FK_RoutinesProductLists_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [sps13686_swd392].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[RoutinesProductLists] CHECK CONSTRAINT [FK_RoutinesProductLists_Products_ProductId]
GO
ALTER TABLE [sps13686_swd392].[RoutinesProductLists]  WITH CHECK ADD  CONSTRAINT [FK_RoutinesProductLists_Routines_RoutinesId] FOREIGN KEY([RoutinesId])
REFERENCES [sps13686_swd392].[Routines] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[RoutinesProductLists] CHECK CONSTRAINT [FK_RoutinesProductLists_Routines_RoutinesId]
GO
ALTER TABLE [sps13686_swd392].[UserAddresses]  WITH CHECK ADD  CONSTRAINT [FK_UserAddresses_Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [sps13686_swd392].[Addresses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[UserAddresses] CHECK CONSTRAINT [FK_UserAddresses_Addresses_AddressId]
GO
ALTER TABLE [sps13686_swd392].[UserAddresses]  WITH CHECK ADD  CONSTRAINT [FK_UserAddresses_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [sps13686_swd392].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [sps13686_swd392].[UserAddresses] CHECK CONSTRAINT [FK_UserAddresses_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [sps13686_SPSS] SET  READ_WRITE 
GO
