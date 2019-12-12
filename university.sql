USE [master]
GO
/****** Object:  Database [universityDB]    Script Date: 12-Dec-19 10:28:52 AM ******/
CREATE DATABASE [universityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'universityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\universityDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'universityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\universityDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [universityDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [universityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [universityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [universityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [universityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [universityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [universityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [universityDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [universityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [universityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [universityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [universityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [universityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [universityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [universityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [universityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [universityDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [universityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [universityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [universityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [universityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [universityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [universityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [universityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [universityDB] SET RECOVERY FULL 
GO
ALTER DATABASE [universityDB] SET  MULTI_USER 
GO
ALTER DATABASE [universityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [universityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [universityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [universityDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [universityDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'universityDB', N'ON'
GO
ALTER DATABASE [universityDB] SET QUERY_STORE = OFF
GO
USE [universityDB]
GO
/****** Object:  Table [dbo].[AssaignClassRoom]    Script Date: 12-Dec-19 10:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssaignClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomNo] [varchar](50) NULL,
	[Day] [varchar](50) NULL,
	[FromTime] [datetime] NULL,
	[ToTIme] [datetime] NULL,
	[CourseName] [varchar](50) NULL,
	[CourseCode] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssaignCourse]    Script Date: 12-Dec-19 10:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssaignCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[Status] [int] NULL,
	[TeacherId] [int] NULL,
	[RemainingCredit] [decimal](18, 1) NULL,
	[TeacherName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnrollCourse]    Script Date: 12-Dec-19 10:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentRegistrationNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[CourseId] [int] NULL,
	[Date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 12-Dec-19 10:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentRegistrationNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[CourseId] [int] NULL,
	[Grade] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblCourse]    Script Date: 12-Dec-19 10:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Credit] [decimal](18, 1) NULL,
	[Description] [varchar](50) NULL,
	[DepartmentId] [varchar](50) NULL,
	[Semester] [varchar](50) NULL,
	[TeacherName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblDepartment]    Script Date: 12-Dec-19 10:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblStudent]    Script Date: 12-Dec-19 10:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblStudent](
	[RegistrationId] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[contractNo] [int] NULL,
	[Date] [date] NULL,
	[Address] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[DepartmentName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTeacher]    Script Date: 12-Dec-19 10:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[ContractNo] [int] NULL,
	[Designation] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[CreditTobeTaken] [decimal](18, 1) NULL,
	[RemainingCredit] [decimal](18, 1) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [universityDB] SET  READ_WRITE 
GO
