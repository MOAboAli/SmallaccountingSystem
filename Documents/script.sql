USE [master]
GO
/****** Object:  Database [CMS]    Script Date: 07/12/2017 10:49:40 ص ******/
CREATE DATABASE [CMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CMS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CMS_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [CMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CMS] SET RECOVERY FULL 
GO
ALTER DATABASE [CMS] SET  MULTI_USER 
GO
ALTER DATABASE [CMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CMS', N'ON'
GO
USE [CMS]
GO
/****** Object:  User [prince]    Script Date: 07/12/2017 10:49:40 ص ******/
CREATE USER [prince] FOR LOGIN [prince] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [bibo]    Script Date: 07/12/2017 10:49:40 ص ******/
CREATE USER [bibo] FOR LOGIN [bibo] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[Bank_Id] [int] NOT NULL,
	[BankName_ID] [int] NOT NULL,
	[Collecting_Id] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[PersonInCharge] [nvarchar](150) NOT NULL,
	[Operation_Type] [tinyint] NOT NULL,
	[Bank_Notes] [nvarchar](max) NULL,
	[RecTime] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[Expenses_Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bank_Name]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank_Name](
	[BankName_Id] [int] NOT NULL,
	[Bank_Name] [nvarchar](150) NOT NULL,
	[DateOfOpen] [datetime] NOT NULL,
	[AccountNo] [int] NOT NULL,
	[Loation] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](30) NOT NULL,
	[PersonInCharge] [nvarchar](50) NOT NULL,
	[Phone_PersonInCharge] [nvarchar](50) NOT NULL,
	[Bank_Name_Notes] [nvarchar](max) NULL,
	[RecTime] [datetime] NOT NULL,
	[UserId] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cash]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cash](
	[Cash_Id] [int] NOT NULL,
	[Collecting_Id] [int] NOT NULL,
	[Cash_Amount] [float] NOT NULL,
	[Cash_Date] [datetime] NOT NULL,
	[PersonInCharge] [nvarchar](150) NOT NULL,
	[Operation_Type] [tinyint] NOT NULL,
	[Cash_Notes] [nvarchar](max) NULL,
	[Cash_RecTime] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[Expenses_Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cash_Type]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cash_Type](
	[Cash_Type_Id] [int] NOT NULL,
	[Cash_Type_Name] [nvarchar](150) NOT NULL,
	[UserId] [int] NOT NULL,
	[Cash_Type_Rectime] [datetime] NOT NULL,
	[Cash_Type_Notes] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cheque]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cheque](
	[Cheque_Id] [int] NOT NULL,
	[Cheque_No] [int] NOT NULL,
	[Cheque_Date] [datetime] NOT NULL,
	[PersonInCharge] [nvarchar](150) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecTime] [datetime] NOT NULL,
	[Done] [tinyint] NOT NULL,
	[Cheque_Bank_Name] [nvarchar](150) NOT NULL,
	[Cheque_Notes] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Collecting]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collecting](
	[Collecting_Id] [int] NOT NULL,
	[Collecting_Name] [nvarchar](350) NOT NULL,
	[Collecting_No] [int] NOT NULL,
	[Collecting_Date] [datetime] NOT NULL,
	[Invoice_Id] [int] NOT NULL,
	[Collecting_Amount] [float] NOT NULL,
	[Collecting_WhatsLeft] [float] NOT NULL,
	[Collecting_Rectime] [datetime] NOT NULL,
	[Collecting_Note] [nvarchar](max) NULL,
	[Cheque_Id] [int] NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[User_Id] [int] NOT NULL,
	[Log_Date] [datetime] NOT NULL,
	[Operation_Type_Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Contact_Id] [int] NOT NULL,
	[Contact_Name] [nvarchar](150) NOT NULL,
	[Contact_Mobile] [nvarchar](20) NOT NULL,
	[Contact_Location] [nvarchar](250) NOT NULL,
	[Contact_Phone] [nvarchar](50) NOT NULL,
	[Contact_Website] [nvarchar](500) NULL,
	[Contact_Note] [nvarchar](max) NULL,
	[Client_Type] [int] NOT NULL,
	[Contact_Rectime] [datetime] NOT NULL,
	[Contact_ManinCharge] [nvarchar](50) NULL,
	[Contact_Mobile_ManinChaarge] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contat_T]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contat_T](
	[Contat_T_Id] [int] NOT NULL,
	[Contat_T_Name] [nvarchar](250) NOT NULL,
	[Contat_T_RecTime] [datetime] NOT NULL,
	[Contat_T_Note] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DiscountInvoice]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountInvoice](
	[DiscountInvoice_Id] [int] NOT NULL,
	[Invoice_Id] [int] NOT NULL,
	[DiscountInvoice_Percentage] [float] NOT NULL,
	[DiscountInvoice_Amount] [float] NOT NULL,
	[DiscountInvoice_Date] [datetime] NOT NULL,
	[DiscountInvoice_Notes] [nvarchar](max) NOT NULL,
	[DiscountInvoice_RecTime] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
	[IsFromCollecting] [tinyint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[Expenses_Id] [int] NOT NULL,
	[Expenses_Type_Id] [int] NOT NULL,
	[Expenses_No] [int] NOT NULL,
	[Expenses_Date] [datetime] NOT NULL,
	[Expenses_Cost] [float] NOT NULL,
	[Expenses_Quantity] [float] NOT NULL,
	[Expenses_Total] [float] NOT NULL,
	[Expenses_From] [datetime] NOT NULL,
	[Expenses_PersonInCharge] [nvarchar](150) NOT NULL,
	[UserId] [int] NOT NULL,
	[Expenses_Rectime] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expenses_Type]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses_Type](
	[Expenses_Type_Id] [int] NOT NULL,
	[Expenses_Type_Name] [nvarchar](150) NOT NULL,
	[UserId] [int] NOT NULL,
	[Expenses_Type_Rectime] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Invoice_Id] [int] NOT NULL,
	[Invoice_No] [int] NOT NULL,
	[Invoice_Date] [datetime] NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[Invoice_Type_Id] [int] NOT NULL,
	[Invoice_Rectime] [datetime] NOT NULL,
	[Invoice_Note] [nvarchar](max) NULL,
	[Invoice_TotalCost] [float] NOT NULL,
	[Invoice_IsDone] [tinyint] NOT NULL,
	[Invoice_Price] [float] NOT NULL,
	[Invoice_AfterDiscountprice] [float] NOT NULL,
	[Invoice_AfterDiscountprice_ATax] [float] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice_Details]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Details](
	[Invoice_Details_Id] [int] NOT NULL,
	[Invoice_Id] [int] NOT NULL,
	[Item_ID] [int] NOT NULL,
	[Unit_Cost] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total_Cost] [float] NOT NULL,
	[Total_Price] [float] NOT NULL,
	[After_Disount_Price] [float] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice_Serial_Collect]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Serial_Collect](
	[Invoice_Serial_Collect_Id] [int] NOT NULL,
	[Invoice_Serial_Collect_Collecting] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice_T]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_T](
	[Invoice_T_Id] [int] NOT NULL,
	[Invoice_T_Name] [nvarchar](250) NOT NULL,
	[Invoice_T_Rectime] [datetime] NOT NULL,
	[Invoice_T_Note] [nvarchar](max) NULL,
	[Invoice_T_PayOrGain] [tinyint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceTax]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceTax](
	[InvoiceTax_Id] [int] NOT NULL,
	[InvoiceTax_Percentage] [float] NOT NULL,
	[InvoiceTax_Amount] [float] NOT NULL,
	[Invoice_ID] [int] NOT NULL,
	[Tax_Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[InvoiceTax_RecTime] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item_Type]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item_Type](
	[Item_Type] [int] NOT NULL,
	[Item_Type_Name] [nvarchar](150) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecTime] [datetime] NOT NULL,
	[Item_Type_Notes] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Items_Id] [int] NOT NULL,
	[Items_Name] [nvarchar](150) NOT NULL,
	[Items_Notes] [nvarchar](max) NULL,
	[Items_Price] [float] NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[Type_Id] [int] NOT NULL,
	[User_Id] [int] NOT NULL,
	[RecTime] [datetime] NOT NULL,
	[HasStock] [int] NOT NULL,
	[AverageCost] [float] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Stock_ID] [int] NOT NULL,
	[Stock_Quantity] [int] NOT NULL,
	[LastModifyDate] [datetime] NOT NULL,
	[Last_UserId] [int] NOT NULL,
	[Item_Id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tax]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax](
	[Tax_Id] [int] NOT NULL,
	[Tax_Name] [nvarchar](150) NOT NULL,
	[Tax_Percentage] [float] NOT NULL,
	[IsDisable] [tinyint] NOT NULL,
	[UserId] [int] NOT NULL,
	[Tax_RecTime] [datetime] NOT NULL,
	[Tax_Notes] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Total_Transation]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Total_Transation](
	[Total_Transation_Id] [int] NOT NULL,
	[Total_Transation_Month] [int] NOT NULL,
	[Total_Transation_Year] [int] NOT NULL,
	[TotalInvoiceGain] [float] NOT NULL,
	[TotalInvoicePay] [float] NOT NULL,
	[TotalCollectingPay] [float] NOT NULL,
	[TotalCollectingGain] [float] NOT NULL,
	[TotalExpenses] [float] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transaction_Details]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction_Details](
	[Transaction_Details_Id] [int] NOT NULL,
	[Transaction_Details_Name] [nvarchar](250) NOT NULL,
	[Transaction_Type_Id] [int] NOT NULL,
	[Transaction_Details_Date] [datetime] NOT NULL,
	[Transaction_Details_Cost] [float] NOT NULL,
	[Transaction_Details_Price] [float] NOT NULL,
	[Original_ID] [int] NOT NULL,
	[Transaction_Details_Profit] [float] NOT NULL,
	[Transaction_Details_Notes] [nvarchar](max) NOT NULL,
	[Transaction_Details_UserId] [int] NOT NULL,
	[Transaction_Details_Rectime] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transaction_Type]    Script Date: 07/12/2017 10:49:41 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction_Type](
	[Transaction_Type_Id] [int] NOT NULL,
	[Transaction_Type_Name] [nvarchar](150) NOT NULL,
	[Transaction_Type_UserId] [int] NOT NULL,
	[Transaction_Type_RecTime] [datetime] NOT NULL,
	[Transaction_Type_Notes] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [CMS] SET  READ_WRITE 
GO
